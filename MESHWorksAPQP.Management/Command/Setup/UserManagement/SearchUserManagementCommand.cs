// <copyright file="SearchUserManagementCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Setup.UserManagement
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup.UserManagement;

    /// <summary>
    /// class SearchUserManagementCommand
    /// </summary>
    public class SearchUserManagementCommand : Page<UserManagementListVM>, ISearchCommand<UserManagementListVM, UserManagemetFilterVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public UserManagemetFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<UserManagementListVM> Result { get; set; }
    }
}
