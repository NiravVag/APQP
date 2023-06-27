// <copyright file="UserManagementController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup.UserManagement
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.Setup.UserManagement;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.Setup.UserManagement;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class UserManagementController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManagementController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public UserManagementController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// IActionResult.
        /// </returns>
        [HttpGet]
        [Route("{userId:guid}")]
        public virtual async Task<IActionResult> Get(Guid userId)
        {
            var command = new GetUserManagementCommand() { UserId = userId };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Posts the specified company type.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] UserManagementVM model)
        {
            var command = new SaveUserManagementCommand()
            {
                Entity = model,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Put(Guid id, [FromBody] UserManagementVM model)
        {
            var command = new SaveUserManagementCommand()
            {
                Id = id,
                Entity = model,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Searches the specified company identifier.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> Search([FromBody] UserManagemetFilterVM model)
        {
            var command = new SearchUserManagementCommand()
            {
                Filter = model
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
