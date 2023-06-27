// <copyright file="PartRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.Part
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using MESHWorksAPQP.Repository.CustomModel.Part;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.Part;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class PartRepository
    /// </summary>
    public class PartRepository : GenericRepository<Part>, IPartRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public PartRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the part relations.
        /// </summary>
        /// <param name="partId">The part identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>
        /// List of PartRelationsCM.
        /// </returns>
        public async Task<IList<PartRelationsCM>> GetPartRelations(Guid partId, Guid companyId)
        {
            IList<PartRelationsCM> partRelations = null;
            IList<PartRelationsCM> results = null;
            try
            {
                await this.dbContext.LoadStoredProc("[APQP].[GetPartRelations]")
                   .WithSqlParam("PartId", partId)
                   .WithSqlParam("CompanyId", companyId)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       results = handler.ReadToList<PartRelationsCM>();
                       handler.NextResult();
                   });

                if (results != null && results.Any())
                {
                    partRelations = results.Where(x => x.ParentPartId == null)
                        .Select(x => new PartRelationsCM
                        {
                            Id = x.Id,
                            Name = x.Name,
                            ParentPartId = x.ParentPartId,
                            Level = x.Level,
                            Childs = this.GetChildParts(results, x.Id)
                        })
                        .ToList();
                }

                return partRelations;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the part relations.
        /// </summary>
        /// <param name="partId">The part identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>
        /// List of PartRelationsCM.
        /// </returns>
        public async Task<IList<PartRelationsCM>> GetPartRelationsForParent(Guid partId, Guid companyId)
        {
            IList<PartRelationsCM> partRelations = null;
            IList<PartRelationsCM> results = null;
            try
            {
                await this.dbContext.LoadStoredProc("[APQP].[GetPartRelations]")
                   .WithSqlParam("PartId", partId)
                   .WithSqlParam("CompanyId", companyId)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       results = handler.ReadToList<PartRelationsCM>();
                       handler.NextResult();
                   });

                if (results != null && results.Any())
                {
                    partRelations = results.ToList();
                }

                return partRelations;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private IList<PartRelationsCM> GetChildParts(IList<PartRelationsCM> partRelations, Guid parentPartId)
        {
            return partRelations.Where(x => x.ParentPartId == parentPartId)
                .Select(x => new PartRelationsCM
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentPartId = x.ParentPartId,
                    Level = x.Level,
                    Childs = this.GetChildParts(partRelations, x.Id)
                })
                .ToList();
        }

        /// <summary>
        /// Gets the apqp discussions.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="pageNumber">The PageNumber</param>
        /// <param name="pageSize">The PageSize</param>
        /// <param name="sortBy">SortBy</param>
        /// <param name="sortOrder">sort order</param>
        /// <returns>
        /// List of GetPartDocuments.
        /// </returns>
        public async Task<(IList<APQPPartDocumentCM>, int totalRecord)> GetPartDocuments(Guid apqpId, int pageNumber, int pageSize, string sortBy, string sortOrder)
        {
            DbParameter dbTotalRecords = null;
            IList<APQPPartDocumentCM> apqpDocument = null;
            await this.dbContext.LoadStoredProc("[APQP].[GetPartDocuments]")
                   .WithSqlParam("APQPTemplateId", apqpId)
                   .WithSqlParam("PageNumber", pageNumber)
                   .WithSqlParam("PageSize", pageSize)
                   .WithSqlParam("SortBy", sortBy)
                   .WithSqlParam("SortOrder", sortOrder)
                   .WithSqlParam("TotalRecords", (dbParam) =>
                   {
                       dbParam.Direction = System.Data.ParameterDirection.Output;
                       dbParam.DbType = System.Data.DbType.Int32;
                       dbTotalRecords = dbParam;
                   })
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       apqpDocument = handler.ReadToList<APQPPartDocumentCM>();
                       handler.NextResult();
                   });
            return (apqpDocument, (int)dbTotalRecords?.Value);
        }
    }
}
