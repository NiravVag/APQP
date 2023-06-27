// <copyright file="RoleController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup.Role
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.Setup.MaterialType;
    using MESHWorksAPQP.Management.Command.Setup.Role;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.Role;
    using MESHWorksAPQP.Shared.Enum;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class The RoleController.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Controllers.Setup.SetupController{MESHWorksAPQP.Management.Command.Setup.Role.SearchRoleCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM, MESHWorksAPQP.Management.ViewModel.Setup.Role.RoleFilterVM, MESHWorksAPQP.Management.Command.Setup.Role.GetRoleCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.Role.SaveRoleCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.Role.DeleteRoleCommand}" />
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : SetupController<SearchRoleCommand, SetupListVM, RoleFilterVM, GetRoleCommand, SetupVM, SaveRoleCommand, SetupVM, DeleteRoleCommand>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public RoleController(IHandlerFactory handler)
            : base(handler)
        {
            this.handler = handler;
        }
    }
}
