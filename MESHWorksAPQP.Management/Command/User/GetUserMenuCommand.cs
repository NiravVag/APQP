// <copyright file="GetUserMenuCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Abstract;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.User;

    /// <summary>
    /// Class GetUserMenuCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Commands.Abstract.BaseCompanyCommand{MESHWorksAPQP.Management.ViewModel.User.MenuVM}" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.IGetCommand{MESHWorksAPQP.Management.ViewModel.User.MenuVM}" />
    public class GetUserMenuCommand : ICommandResult<List<MenuVM>>
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public List<MenuVM> Result { get; set; }
    }
}
