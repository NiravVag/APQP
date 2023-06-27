// <copyright file="SetupController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Shared.Enum;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class SetupController.
    /// </summary>
    /// <typeparam name="TSearchCommand">The type of the search command.</typeparam>
    /// <typeparam name="TSearchResult">The type of the search result.</typeparam>
    /// <typeparam name="TFilterVM">The type of the filter vm.</typeparam>
    /// <typeparam name="TGetCommand">The type of the get command.</typeparam>
    /// <typeparam name="TGetResult">The type of the get result.</typeparam>
    /// <typeparam name="TSaveCommand">The type of the save command.</typeparam>
    /// <typeparam name="TSaveResult">The type of the save result.</typeparam>
    /// <typeparam name="TDeleteCommand">The type of the delete command.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SetupController<TSearchCommand, TSearchResult, TFilterVM, TGetCommand, TGetResult, TSaveCommand, TSaveResult, TDeleteCommand>
     : ControllerBase
    where TSearchCommand : ISearchCommand<TSearchResult, TFilterVM>, new()
    where TGetCommand : IGetCommand<TGetResult>, new()
    where TSaveCommand : ISaveCommand<TSaveResult>, new()
    where TSaveResult : ISaveResult
    where TDeleteCommand : IDeleteCommand, new()
    where TFilterVM : IFilterVM
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetupController{TSearchCommand, TSearchResult, TFilterVM, TGetCommand, TGetResult, TSaveCommand, TSaveResult, TDeleteCommand}"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public SetupController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Searches the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// IActionResult.
        /// </returns>
        [HttpPost]
        [Route("Search")]
        //[AuthorizePermission(PermissionCode.Setup, PermissionType.View)]
        public virtual async Task<IActionResult> Search([FromBody] TFilterVM model)
        {
            var command = new TSearchCommand()
            {
                Filter = model,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// IActionResult.
        /// </returns>
        [HttpGet]
        [Route("{id:guid}")]
       // [AuthorizePermission(PermissionCode.Setup, PermissionType.View)]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var command = new TGetCommand() { Id = id };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Posts the specified identifier.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// IActionResult.
        /// </returns>
        [HttpPost]
        [ValidateModel]
        //[AuthorizePermission(PermissionCode.Setup, PermissionType.AddEdit)]
        public virtual async Task<IActionResult> Post([FromBody] TSaveResult model)
        {
            var command = new TSaveCommand()
            {
                Id = null,
            };
            command.Entity = model;

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
        //[AuthorizePermission(PermissionCode.Setup, PermissionType.AddEdit)]
        public virtual async Task<IActionResult> Put(Guid id, [FromBody] TSaveResult model)
        {
            var command = new TSaveCommand()
            {
                Id = id,
            };
            command.Entity = model;

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete]
        [Route("{id:guid}")]
        //[AuthorizePermission(PermissionCode.Setup, PermissionType.Delete)]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            var command = new TDeleteCommand() { Id = id };
            await this.handler.Execute(command);

            return this.Ok();
        }
    }
}
