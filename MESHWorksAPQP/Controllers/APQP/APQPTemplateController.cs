// <copyright file="APQPTemplateController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.APQP
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Commands.APQP.APQPTemplate;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.APQP;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class APQPTemplateController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [Route("api/[controller]/{companyId:guid}")]
    [ApiController]
    public class APQPTemplateController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="APQPTemplateController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public APQPTemplateController(IHandlerFactory handler)
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
            var command = new GetAPQPTemplateCommand() { Id = id };
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
        public async Task<IActionResult> Search([FromBody] APQPTemplateFilterVM model)
        {
            var command = new SearchAPQPTemplateCommand()
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
        public async Task<IActionResult> Post([FromBody] APQPTemplateVM model)
        {
            var command = new SaveAPQPTemplateCommand()
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
        public async Task<IActionResult> Put(Guid id, [FromBody] APQPTemplateVM model)
        {
            var command = new SaveAPQPTemplateCommand()
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
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? companyId, Guid id)
        {
            var command = new DeleteAPQPTemplateCommand()
            {
                Id = id,
                CompanyId = companyId
            };
            await this.handler.Execute(command);

            return this.Ok();
        }

        /// <summary>
        /// Clones the specified company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("clone/{id:guid}/{userId:guid}")]
        public async Task<IActionResult> Clone(Guid? companyId, Guid id, Guid userId)
        {
            var command = new CloneAPQPTemplateCommand()
            {
                CompanyId = companyId,
                Id = id,
                UserId = userId
            };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Apqps the template validation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("TemplateValidation/{id:guid}")]
        public async Task<IActionResult> APQPTemplateValidation(Guid id)
        {
            var command = new APQPTemplateValidationCommand()
            {
                Id = id
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Deactivates the template.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("Deactivate/{id:guid}")]
        public async Task<IActionResult> DeactivateTemplate(Guid? companyId, Guid id)
        {
            var command = new DeactivateAPQPTemplateCommand()
            {
                CompanyId = companyId,
                Id = id
            };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
