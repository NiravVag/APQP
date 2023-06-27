// <copyright file="UserController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.ApiControllers
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Commands.User;
    using MESHWorksAPQP.Management.Interface.Factories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class UserController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public UserController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var command = new GetUserCommand()
            {
                Id = id,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("Search/{companyId:Guid}")]
        public async Task<IActionResult> GetUserList(Guid companyId)
        {
            var command = new GetUsersCommand()
            {
                CompanyId = companyId,
            };

            await this.handler.Execute(command);
            return this.Ok(command.Result);
        }

        /// <summary>
        /// Users the menus.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [Route("menu")]
        [HttpGet]
        [ValidateModel]
        [AllowAnonymous]
        public async Task<IActionResult> UserMenu()
        {
            var command = new GetUserMenuCommand()
            {
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Permissions the specified company identifier.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [Route("permission")]
        [HttpGet]
        [ValidateModel]
        [AllowAnonymous]
        public async Task<IActionResult> Permission()
        {
            var command = new GetPermissionCommand()
            {
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
