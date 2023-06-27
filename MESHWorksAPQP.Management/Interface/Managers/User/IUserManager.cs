// <copyright file="IUserManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.User
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.User;
    using MESHWorksAPQP.Management.ViewModel.User;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Interface IUserManager.
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Gets the user menu.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of MenuVM.
        /// </returns>
        Task<List<MenuVM>> GetUserMenu(GetUserMenuCommand command);

        /// <summary>
        /// Gets the user permissions.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of PermissionDetail.
        /// </returns>
        Task<IList<PermissionDetail>> GetUserPermissions(GetPermissionCommand command);

        /// <summary>
        /// Gets the user list.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of users</returns>
        Task<List<UserVM>> GetUserList(GetUsersCommand command);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>User</returns>
        Task<UserVM> GetUser(GetUserCommand command);
    }
}
