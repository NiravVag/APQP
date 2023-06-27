// <copyright file="PartController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Part
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Commands.Document;
    using MESHWorksAPQP.Management.Commands.Part;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.Document;
    using MESHWorksAPQP.Management.ViewModel.Part;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class PartController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]

    // [Authorize]
    public class PartController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public PartController(IHandlerFactory handler)
        {
            this.handler = handler;
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
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var command = new GetPartCommand() { Id = id };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Gets the part relation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("Relations/{id:guid}")]
        public virtual async Task<IActionResult> GetPartRelation(Guid id)
        {
            var command = new GetPartRelationCommand() { Id = id };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
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
        public async Task<IActionResult> Search([FromBody] PartFilterVM model)
        {
            var command = new SearchPartCommand()
            {
                Filter = model,
            };

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
        public async Task<IActionResult> Post([FromBody] PartVM model)
        {
            var command = new SavePartCommand()
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
        public async Task<IActionResult> Put(Guid id, [FromBody] PartVM model)
        {
            var command = new SavePartCommand()
            {
                Id = id,
                Entity = model,
            };

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
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePartCommand()
            {
                Id = id,
            };
            await this.handler.Execute(command);

            return this.Ok();
        }

        /// <summary>
        /// Gets the part apqp.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("apqp")]
        public virtual async Task<IActionResult> GetPartAPQP([FromBody] PartFilterVM model)
        {
            var command = new GetPartAPQPCommand()
            {
                Filter = model,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Gets the part relations.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("Relations/{id:guid}/{companyId:guid}")]
        public virtual async Task<IActionResult> GetPartRelations(Guid id, Guid companyId)
        {
            var command = new GetPartRelationsCommand() { Id = id, CompanyId = companyId };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// GetDocumentList
        /// </summary>
        /// <param name="id">The Identifier.</param>
        /// <param name="model">Model </param>
        /// <returns> IActionResult.</returns>
        [HttpPost]
        [Route("GetPartDocumentList/{id}")]
        public async Task<IActionResult> GetPartDocument(Guid id, [FromBody] PartDocumentFilterVM model)
        {
            var command = new SearchPartDocumentCommand()
            {
                Filter = model,
                Id = id
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
