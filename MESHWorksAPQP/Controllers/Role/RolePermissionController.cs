// <copyright file="RolePermissionController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Role
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Commands.Role.RolePermission;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Repository.CustomModel;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class RolePermissionController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/RolePermission/{roleId:guid}")]
    [Route("api/{companyId:guid}/RolePermission/{roleId:guid}")]
    [Route("api/{companyId:guid}/RolePermission")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolePermissionController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public RolePermissionController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Searches the specified company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("{userId:guid}/Search")]
        public async Task<IActionResult> Search(Guid? companyId, Guid userId, Guid? roleId, [FromBody] FilterVM model)
        {
            var command = new SearchRolePermissionCommand()
            {
                CompanyId = companyId,
                UserId = userId,
                RoleId = roleId,
                Filter = model
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Posts the specified company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateModel]
        [Route("{userId:guid}")]
        public async Task<IActionResult> Post(Guid? companyId, Guid userId, Guid? roleId, [FromBody] List<RolePermissionDetail> model)
        {
            var command = new SaveRolePermissionCommand()
            {
                CompanyId = companyId,
                UserId = userId,
                RoleId = roleId,
                Entity = model
            };

            await this.handler.Execute(command);

            return new OkObjectResult(command.Result);
        }
    }
}
