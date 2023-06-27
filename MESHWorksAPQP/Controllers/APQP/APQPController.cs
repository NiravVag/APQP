// <copyright file="APQPController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.APQP
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;
    using MESHWorksAPQP.Management.ViewModel.Document;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class APQPController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class APQPController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="APQPController"/> class.
        /// </summary>
        /// <param name="manager">The handler.</param>
        private readonly IAPQPManager manager;

        public APQPController(IHandlerFactory handler,
            IAPQPManager manager)
        {
            this.handler = handler;
            this.manager = manager;
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
            var command = new GetAPQPCommand() { Id = id };
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
        public async Task<IActionResult> Post([FromBody] GateDataVM model)
        {
            var command = new SaveAPQPCommand()
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
        public async Task<IActionResult> Put(Guid id, [FromBody] GateDataVM model)
        {
            var command = new SaveAPQPCommand()
            {
                Id = id,
                Entity = model,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Saves the project.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("SaveProject")]
        [ValidateModel]
        public async Task<IActionResult> SaveProject([FromBody] APQPProjectCM model)
        {
            var command = new SaveAPQPProjectCommand()
            {
                Entity = model,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete]
        [Route("DeleteProject/{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var command = new DeleteAPQPProjectCommand()
            {
                Id = id
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="referanceId">The referanceId.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("GetDocumentList/{id:guid}/{referanceId:guid}")]
        [ValidateModel]
        public async Task<List<DocumentAttachmentCM>> GetDocumentList(Guid id, Guid referanceId)
        {
            return await this.manager.GetDocumentData(id, referanceId);
        }

        /// <summary>
        /// GetAPQPDocumentList
        /// </summary>
        /// <param name="id">The Identifier.</param>
        /// <param name="model"> Model </param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("GetAPQPDocumentList/{id}")]
        public async Task<IActionResult> GetAPQPDocument(Guid id, [FromBody] PartDocumentFilterVM model)
        {
            var command = new SearchAPQPDocumentCommand()
            {
                Filter = model,
                Id = id
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
