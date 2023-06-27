// <copyright file="PartManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Part
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Commands.Document;
    using MESHWorksAPQP.Management.Commands.Part;
    using MESHWorksAPQP.Management.Interface.Managers.Part;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Part;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using MESHWorksAPQP.Repository.CustomModel.Part;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Part;
    using MESHWorksAPQP.Shared.Interface;
    using APQPTable = MESHWorksAPQP.Model.Models.APQP;

    /// <summary>
    /// Class IPartManager.
    /// </summary>
    public class PartManager : BaseManager<Part, SearchPartCommand, PartListVM, GetPartCommand, PartVM, SavePartCommand, PartVM, PartFilterVM>, IPartManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IPartRepository repository;

        /// <summary>
        /// The part relationrepository
        /// </summary>
        private readonly IGenericRepository<PartRelation> partRelationrepository;

        /// <summary>
        /// The part apqprepository/
        /// </summary>
        private readonly IGenericRepository<APQPTable.APQP> partApqprepository;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="partRelationrepository">The partRelationrepository.</param>
        /// <param name="partApqprepository">The partApqprepository.</param>
        /// <param name="userIdentity">The userIdentity.</param>
        public PartManager(
            IMapper mapper,
            IPartRepository repository,
            IGenericRepository<PartRelation> partRelationrepository,
            IGenericRepository<APQPTable.APQP> partApqprepository,
            IUserIdentity userIdentity)
             : base(mapper, repository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.partRelationrepository = partRelationrepository;
            this.partApqprepository = partApqprepository;
            this.userIdentity = userIdentity;
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>PartVM.</returns>
        public override async Task<PartVM> Save(SavePartCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Entity.CompanyId;

            if (command.Entity != null)
            {
                bool isPartNoValid = await this.ChecksPartNoExists(command.Entity.PartNumber, companyId, command.Entity.Id);
                if (isPartNoValid)
                {
                    Part entity;
                    if (command.Id != null && command.Id.HasValue)
                    {
                        entity = await this.GetEntity(command.Id.Value);

                        if (entity == null || entity.IsDeleted)
                        {
                            throw new ValidationException("Record not found.");
                        }

                        this.mapper.Map(command.Entity, entity);
                        this.repository.Update(entity);
                    }
                    else
                    {
                        entity = this.mapper.Map<Part>(command.Entity);
                        this.repository.Create(entity);
                    }

                    await this.repository.SaveAsync();
                    command.Entity.Id = entity.Id;
                    if (command.Entity.ParentPartId != null)
                    {
                        await this.AddEditPartRelation(entity.Id, command.Entity.ParentPartId);
                    }

                    return command.Entity;
                }
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// PartVM.
        /// </returns>
        public override async Task<PartVM> Get(GetPartCommand command)
        {
            var entity = await this.GetEntity(command.Id);
            if (entity == null || entity.IsDeleted)
            {
                throw new ValidationException("Record not found.");
            }

            PartVM part = this.mapper.Map<PartVM>(entity);

            var parentEntity = this.partRelationrepository.GetAll().Where(x => x.PartId == part.Id && !x.IsDeleted);

            if (parentEntity.Any())
            {
                part.ParentPartId = parentEntity.Select(x => x.ParentPartId).ToList();
            }

            return part;
        }

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of PartListVM.</returns>
        public override async Task<Page<PartListVM>> Search(SearchPartCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Filter.CompanyId;

            try
            {
                var query = this.repository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId);

                if (!string.IsNullOrWhiteSpace(command?.Filter?.SearchText))
                {
                    query = query.Where(x => x.PartNumber.Contains(command.Filter.SearchText));
                }

                var size = query.Count();

                if (command.Filter?.SortingOption != null && !string.IsNullOrWhiteSpace(command.Filter.SortingOption.SortBy) && !string.IsNullOrWhiteSpace(command.Filter.SortingOption.SortOrder))
                {
                    if (command.Filter.SortingOption.SortBy.ToLower() == "CommodityName".ToLower())
                    {
                        command.Filter.SortingOption.SortBy = "Commodity.Name";
                    }
                    else if (command.Filter.SortingOption.SortBy.ToLower() == "ProcessName".ToLower())
                    {
                        command.Filter.SortingOption.SortBy = "Process.Name";
                    }
                    else if (command.Filter.SortingOption.SortBy.ToLower() == "MaterialTypeName".ToLower())
                    {
                        command.Filter.SortingOption.SortBy = "MaterialType.Name";
                    }

                    query = query.OrderBy($"{command.Filter.SortingOption.SortBy} {command.Filter.SortingOption.SortOrder}");
                }

                var limit = command.Filter.PagingOption?.Limit ?? (size == 0 ? 1 : size);
                var skip = (command.Filter.PagingOption?.Offset ?? 0) * limit;
                var parts = query
                   .Skip(skip)
                   .Take(limit)
                   .ProjectTo<PartListVM>(this.mapper.ConfigurationProvider).ToList();

                return new Page<PartListVM>()
                {
                    Items = parts,
                    TotalSize = size,
                };
            }
            catch (Exception ex)
            {
                return new Page<PartListVM>()
                {
                    Items = null,
                    TotalSize = 0,
                };
            }
        }

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// bool.
        /// </returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">Record not found.</exception>
        public async Task<bool> Delete(DeletePartCommand command)
        {

            var entity = await this.GetEntity(command.Id);
            if (entity == null || entity.IsDeleted)
            {
                throw new ValidationException("Record not found.");
            }

            entity.IsDeleted = true;
            await this.repository.SaveAsync();
            await this.DeleteParentRelation(command.Id);
            return true;
        }

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="Id">The Id.</param>
        /// <returns>
        /// bool.
        /// </returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">Record not found.</exception>
        public async Task<bool> DeleteParentRelation(Guid Id)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : Guid.Empty;
            var relationList = this.partRelationrepository.GetAll().Where(x => x.PartId == Id || x.ParentPartId == Id).ToList();
            if (relationList != null)
            {
                foreach (var item in relationList)
                {
                    var partRelationEntity = await this.partRelationrepository.FirstOrDefaultAsync(x => x.Id == item.Id);
                    partRelationEntity.IsDeleted = true;
                    await this.partRelationrepository.SaveAsync();
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the part relation.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of PartRelationListVM
        /// </returns>
        public async Task<List<PartRelationListVM>> GetPartRelation(GetPartRelationCommand command)
        {
            if (command.Id != default(Guid))
            {
                var entity = this.partRelationrepository.GetAll(x => !x.IsDeleted && x.PartId == command.Id);

                return entity.ProjectTo<PartRelationListVM>(this.mapper.ConfigurationProvider).ToList();
            }

            return null;
        }

        /// <summary>
        /// Gets the part apqp.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of part apqp.
        /// </returns>
        public async Task<Page<PartAPQPListVM>> GetPartAPQP(GetPartAPQPCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Filter.CompanyId;

            var query = this.partApqprepository.GetAll(x => !x.IsDeleted && x.PartId == command.Filter.PartId && x.CompanyId == companyId);

            var size = query.Count();

            if (command.Filter?.SortingOption != null && !string.IsNullOrWhiteSpace(command.Filter.SortingOption.SortBy) && !string.IsNullOrWhiteSpace(command.Filter.SortingOption.SortOrder))
            {
                query = query.OrderBy($"{command.Filter.SortingOption.SortBy} {command.Filter.SortingOption.SortOrder}");
            }

            var limit = command.Filter.PagingOption?.Limit ?? (size == 0 ? 1 : size);
            var skip = (command.Filter.PagingOption?.Offset ?? 0) * limit;
            var parts = query
               .Skip(skip)
               .Take(limit)
               .ProjectTo<PartAPQPListVM>(this.mapper.ConfigurationProvider).ToList();

            return new Page<PartAPQPListVM>()
            {
                Items = parts,
                TotalSize = size,
            };
        }

        /// <summary>
        /// Gets the part relations.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of PartRelationsCM.
        /// </returns>
        public async Task<IList<PartRelationsCM>> GetPartRelations(GetPartRelationsCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.CompanyId;

            if (command.Id != Guid.Empty && companyId != Guid.Empty)
            {
                var part = await this.GetEntity(command.Id);

                if (part.CompanyId == companyId)
                {
                    return await this.repository.GetPartRelations(command.Id, companyId);
                }

                throw new ValidationException("Invalid Request.");
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="query">The query.</param>
        /// <returns>
        /// IQueryable Part.
        /// </returns>
        protected override IQueryable<Part> FilterData(SearchPartCommand command, IQueryable<Part> query)
        {
            if (!string.IsNullOrWhiteSpace(command.Filter?.SearchText))
            {
                query = query.Where(x => x.PartNumber.ToString().Contains(command.Filter.SearchText, StringComparison.OrdinalIgnoreCase));
            }

            return query;
        }

        /// <summary>
        /// Adds the edit part relation.
        /// </summary>
        /// <param name="partId">The part identifier.</param>
        /// <param name="partParentIds">The partent part identifier.</param>
        /// <returns>bool.</returns>
        private async Task<bool> AddEditPartRelation(Guid partId, List<Guid> partParentIds)
        {
            if (partId != default(Guid))
            {
                Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : Guid.Empty;
                Dictionary<Guid, bool> parentList = new Dictionary<Guid, bool>();
                if (partParentIds.Count > 0)
                {
                    parentList = await this.CheckParent(partId, companyId, partParentIds);
                }

                var validatePartParentId = parentList.Where(x => x.Value == true).Select(x => x.Key).ToList();
                var invalidPartParentId = parentList.Where(x => x.Value == false).Select(x => x.Key).ToList();

                var dbPartParents = this.partRelationrepository.GetAll(x => !x.IsDeleted && x.PartId == partId).ToList();
                var deletePartParentIds = dbPartParents.Where(x => !validatePartParentId.Contains(x.ParentPartId)).ToList();
                if (deletePartParentIds.Any())
                {
                    deletePartParentIds.ForEach(x => x.IsDeleted = true);
                }

                var dbPartParentIds = dbPartParents.Select(x => x.ParentPartId);
                var newPartParentIds = validatePartParentId.Where(x => !dbPartParentIds.Contains(x));
                if (newPartParentIds.Any())
                {
                    foreach (var parentId in newPartParentIds)
                    {
                        this.partRelationrepository.Create(new PartRelation
                        {
                            PartId = partId,
                            ParentPartId = parentId,
                        });
                    }
                }

                await this.partRelationrepository.SaveAsync();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                if (invalidPartParentId.Count > 0)
                {
                    foreach (var invalidparentid in invalidPartParentId)
                    {
                        var parentName = await this.repository.FirstOrDefaultAsync(x => x.Id == invalidparentid);
                        if (sb.Length == 0)
                        {
                            sb.Append(parentName?.PartNumber);
                        }
                        else
                        {
                            sb.Append("," + parentName?.PartNumber);
                        }
                    }

                    throw new ValidationException(sb + " are invalid parents.");
                }
            }

            return true;
        }

        private async Task<Dictionary<Guid, bool>> CheckParent(Guid partId, Guid companyId, List<Guid> partParentIds)
        {
            Dictionary<Guid, bool> parentList = new Dictionary<Guid, bool>();
            var relationList = await this.repository.GetPartRelationsForParent(partId, companyId);
            var parentPartId = relationList?.FirstOrDefault(x => x.Id == partId)?.ParentPartId;
            if (parentPartId != null)
            {
                await this.CheckParentExist(relationList, parentPartId, parentList, partParentIds);
            }
            else
            {
                var isAddFirstParent = false;
                foreach (var item in partParentIds)
                {
                    var checkChild = relationList?.FirstOrDefault(x => x.Id == item);
                    if (checkChild != null)
                    {
                        parentList.Add(item, false);
                    }
                    else if (!isAddFirstParent)
                    {
                        isAddFirstParent = true;
                        this.partRelationrepository.Create(new PartRelation
                        {
                            PartId = partId,
                            ParentPartId = item
                        });
                        await this.partRelationrepository.SaveAsync();
                        parentList.Add(item, true);
                    }
                    else
                    {
                        var parentPartLevel = relationList?.FirstOrDefault(x => x.Id == parentPartId)?.Level;
                        var addParentData = relationList?.FirstOrDefault(x => x.Id == item);
                        if (addParentData == null)
                        {
                            parentList.Add(item, true);
                        }
                        else
                        {
                            if (addParentData?.Level == parentPartLevel)
                            {
                                parentList.Add(item, true);
                            }
                            else
                            {
                                parentList.Add(item, false);
                            }
                        }
                    }
                }
            }

            return parentList;
        }

        private async Task CheckParentExist(IList<PartRelationsCM> relationList, Guid? parentPartId, Dictionary<Guid, bool> parentList, List<Guid> partParentIds)
        {
            var parentPartLevel = relationList?.FirstOrDefault(x => x.Id == parentPartId)?.Level;
            foreach (var item in partParentIds)
            {
                var addParentData = relationList.Where(x => x.Id == item).ToList();              
                if (addParentData == null)
                {
                    parentList.Add(item, true);
                }
                else
                {
                    bool flag = false;
                    foreach (var nesteditem in addParentData)
                    {
                        if (nesteditem.Level == parentPartLevel)
                        {
                           flag = true;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag == true)
                    {
                        parentList.Add(item, true);
                    }
                    else
                    {
                        parentList.Add(item, false);
                    }
                }
            }
        }

        /// <summary>
        /// Checkses the part exists.
        /// </summary>
        /// <param name="partNo">The part no.</param>
        /// <param name="partId">The part identifier.</param>
        /// <returns>
        /// bool.
        /// </returns>
        /// <exception cref="ValidationException">My parts - Part No {part.PartNo} already exists
        /// or
        /// Invalid Request.</exception>
        private async Task<bool> ChecksPartNoExists(string partNo, Guid companyId, Guid? partId = null)
        {
            var part = await this.repository.FirstOrDefaultAsync(x => x.PartNumber == partNo && !x.IsDeleted && x.CompanyId == companyId);
            if (part == null || (part != null && partId != null && part.Id == partId))
            {
                return true;
            }

            throw new ValidationException($"Part No {part.PartNumber} already exists.");
        }

        /// <summary>
        /// Get part document List.
        /// </summary>
        /// <param name="command">SearchPartDocumentCommand command</param>
        /// <returns>
        /// bool
        /// </returns>
        public async Task<Page<APQPPartDocumentCM>> GetPartDocument(SearchPartDocumentCommand command)
        {

            (var items, int totalRecord) = await this.repository.GetPartDocuments(command.Id, (command.Filter.PagingOption?.Offset ?? 0) + 1, command.Filter.PagingOption?.Limit ?? 1, command.Filter.SortingOption?.SortBy, command.Filter.SortingOption?.SortOrder);

            var data = new Page<APQPPartDocumentCM>()
            {
                Items = items,
                TotalSize = totalRecord,
            };
            return data;
        }
    }
}
