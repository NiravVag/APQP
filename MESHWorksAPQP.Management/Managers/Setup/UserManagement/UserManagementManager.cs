// <copyright file="UserManagementManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Setup.UserManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Command.Setup.UserManagement;
    using MESHWorksAPQP.Management.Commands.User;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.UserManagement;
    using MESHWorksAPQP.Management.Interface.Managers.User;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup.UserManagement;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// class UserManagementManager.
    /// </summary>
    public class UserManagementManager : IUserManagementManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IGenericRepository<UserRole> userRoleRepository;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IGenericRepository<UserDesignations> userDesignationsRepository;

        /// <summary>
        /// The user management repository.
        /// </summary>
        private readonly IUserManagementRepository userManagementRepository;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// The user manager
        /// </summary>
        private readonly IUserManager userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManagementManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="userRoleRepository">The user role repository.</param>
        /// <param name="userDesignationsRepository">The user designation repository.</param>
        /// <param name="userManagementRepository;">The user management repository.</param>
        /// <param name="userIdentity">The user identity.</param>
        /// <param name="userManager">The user manager.</param>
        public UserManagementManager(
            IMapper mapper,
            IGenericRepository<UserRole> userRoleRepository,
            IGenericRepository<UserDesignations> userDesignationsRepository,
            IUserManagementRepository userManagementRepository,
            IUserIdentity userIdentity,
            IUserManager userManager)
        {
            this.mapper = mapper;
            this.userRoleRepository = userRoleRepository;
            this.userDesignationsRepository = userDesignationsRepository;
            this.userManagementRepository = userManagementRepository;
            this.userIdentity = userIdentity;
            this.userManager = userManager;
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>TResult.</returns>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public async Task<UserManagementVM> Get(GetUserManagementCommand command)
        {
            if (command.UserId != Guid.Empty)
            {
                UserManagementVM userManagement = new UserManagementVM()
                {
                    UserId = command.UserId
                };

                var userRole = await this.userRoleRepository.FirstOrDefaultAsync(x => x.UserId == command.UserId && !x.IsDeleted);

                if (userRole != null)
                {
                    userManagement.RoleId = userRole.RoleId;
                    userManagement.UserRole = this.mapper.Map<UserRoleVM>(userRole);
                }

                var userDesignations = this.userDesignationsRepository.GetAll(x => x.UserId == command.UserId && !x.IsDeleted).ToList();

                if (userDesignations != null && userDesignations.Any())
                {
                    userManagement.DesignationIds = userDesignations.Select(x => x.DesignationId).ToList();
                    userManagement.UserDesignations = this.mapper.Map<List<UserDesignationsVM>>(userDesignations);
                }

                return userManagement;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>TSaveResult.</returns>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public async Task<UserManagementVM> Save(SaveUserManagementCommand command)
        {
            if (command.Entity != null && command.Entity.UserId != Guid.Empty)
            {
                command.Entity.CompanyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Entity.CompanyId ?? default(Guid);
                bool isUserRoleValid = await this.ChecksUserRoleExists(command.Entity.UserRole?.Id, command.Entity.UserId);

                if (isUserRoleValid)
                {
                    UserRole userRoleEntity;
                    List<UserDesignations> userDesignationsEntity;

                    // user role
                    if (command.Entity.UserRole != null)
                    {
                        if (command.Entity.UserRole.Id != null && command.Entity.UserRole.Id.HasValue)
                        {
                            userRoleEntity = await this.userRoleRepository.FirstOrDefaultAsync(x => x.UserId == command.Entity.UserId && !x.IsDeleted);

                            if (userRoleEntity == null)
                            {
                                throw new ValidationException("Record not found.");
                            }

                            if (command.Entity.RoleId != null && command.Entity.RoleId != Guid.Empty && command.Entity.UserRole.RoleId != Guid.Empty)
                            {
                                this.mapper.Map(command.Entity.UserRole, userRoleEntity);
                                this.userRoleRepository.Update(userRoleEntity);
                            }
                            else
                            {
                                userRoleEntity.IsDeleted = true;
                            }
                        }
                        else
                        {
                            userRoleEntity = this.mapper.Map<UserRole>(command.Entity.UserRole);
                            this.userRoleRepository.Create(userRoleEntity);
                        }

                        await this.userRoleRepository.SaveAsync();
                        command.Entity.UserRole.Id = userRoleEntity.Id;
                    }

                    // user designations
                    userDesignationsEntity = this.userDesignationsRepository.GetAll(x => x.UserId == command.Entity.UserId && !x.IsDeleted).ToList();

                    if (userDesignationsEntity != null && userDesignationsEntity.Any())
                    {
                        var availableIds = command.Entity.UserDesignations?.Where(x => x.DesignationId != Guid.Empty)?.Select(x => x.Id);
                        userDesignationsEntity.Where(x => !availableIds.Contains(x.DesignationId)).ToList().ForEach(x => x.IsDeleted = true);
                    }

                    if (command.Entity.UserDesignations != null && command.Entity.UserDesignations.Any())
                    {
                        foreach (var item in command.Entity.UserDesignations)
                        {
                            UserDesignations userDesignations = null;

                            if (item.Id != null && item.Id != Guid.Empty)
                            {
                                userDesignations = await this.userDesignationsRepository.FirstOrDefaultAsync(x => x.Id == item.Id && !x.IsDeleted);
                            }

                            if (userDesignations == null)
                            {
                                userDesignations = this.mapper.Map<UserDesignations>(item);
                                userDesignationsEntity.Add(userDesignations);
                                this.userDesignationsRepository.Create(userDesignations);
                            }
                            else
                            {
                                this.mapper.Map(item, userDesignations);
                                userDesignations.IsDeleted = false;
                                this.userDesignationsRepository.Update(userDesignations);
                            }

                            item.Id = userDesignations.Id;
                        }
                    }

                    await this.userDesignationsRepository.SaveAsync();
                }

                return command.Entity;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name = "command" > The command.</param>
        /// <returns>Page of TSearchResult.</returns>
        public async Task<Page<UserManagementListVM>> Search(SearchUserManagementCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Filter.CompanyId ?? default(Guid);

            var (userRoles, designtations) = await this.userManagementRepository.GetAllUserManagement(companyId, command.Filter.SearchText, command.Filter.IsDeleted ?? false, (command.Filter.PagingOption?.Offset ?? 0) + 1, command.Filter.PagingOption?.Limit ?? 1, command.Filter.SortingOption?.SortBy, command.Filter.SortingOption?.SortOrder);

            List<UserDesignationsVM> userDesignations = designtations.AsQueryable().ProjectTo<UserDesignationsVM>(this.mapper.ConfigurationProvider).ToList();

            List<UserManagementListVM> userManagements = new List<UserManagementListVM>();

            var users = await this.userManager.GetUserList(new GetUsersCommand()
            {
                CompanyId = companyId
            });

            foreach (var item in users)
            {
                var userManagement = new UserManagementListVM();
                userManagement.UserId = item.Id.Value;
                userManagement.CompanyId = companyId;
                userManagement.FirstName = item.FirstName;
                userManagement.LastName = item.LastName;
                userManagement.UserName = item.UserName;
                userManagement.RoleId = userRoles.FirstOrDefault(x => x.UserId == item.Id)?.RoleId;
                userManagement.Role = userRoles.FirstOrDefault(x => x.UserId == item.Id)?.Role;
                userManagement.UserDesignations = userDesignations.Where(x => x.UserId == item.Id)?.ToList();
                userManagements.Add(userManagement);
            }

            if (!string.IsNullOrWhiteSpace(command?.Filter?.SearchText))
            {
                userManagements = userManagements.Where(x => x.FirstName.Contains(command.Filter.SearchText) || x.LastName.Contains(command.Filter.SearchText) || x.UserName.Contains(command.Filter.SearchText)).ToList();
            }

            if (command?.Filter?.RoleId != null && command?.Filter?.RoleId != Guid.Empty)
            {
                userManagements = userManagements.Where(x => x.RoleId == command.Filter.RoleId).ToList();
            }

            if (command?.Filter?.designationId != null && command.Filter.designationId.Any())
            {
                userManagements = userManagements.Where(x => x.UserDesignations.Any(y => command.Filter.designationId.Any(z => z == y.DesignationId))).ToList();
            }

            var size = userManagements.Count();
            var limit = command.Filter.PagingOption?.Limit ?? (size == 0 ? 1 : size);
            var skip = (command.Filter.PagingOption?.Offset ?? 0) * limit;
            userManagements = userManagements
               .Skip(skip)
               .Take(limit)
               .ToList();

            return new Page<UserManagementListVM>()
            {
                Items = userManagements,
                TotalSize = size,
            };
        }

        /// <summary>
        /// Checkses the user role exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The bool</returns>
        private async Task<bool> ChecksUserRoleExists(Guid? id, Guid userId)
        {
            var existingUserRole = await this.userRoleRepository.FirstOrDefaultAsync(x => x.UserId == userId && !x.IsDeleted);

            if (existingUserRole == null || (existingUserRole != null && id != null && existingUserRole.Id == id))
            {
                return true;
            }

            throw new ValidationException($"User Management for the user already exists.");
        }
    }
}
