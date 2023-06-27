// <copyright file="CustomFieldController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.CustomField
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Commands.CustomField;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class CustomFieldController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public CustomFieldController(IHandlerFactory handler)
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
        public async Task<IActionResult> Get(Guid id)
        {
            var command = new GetCustomFieldCommand()
            {
                Id = id,
            };
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
        public async Task<IActionResult> Search([FromBody] CustomFieldFilterVM model)
        {
            var command = new SearchCustomFieldCommand()
            {
                Filter = model,
            };

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
        public async Task<IActionResult> Post([FromBody] CustomFieldVM model)
        {
            var command = new SaveCustomFieldCommand()
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
        public async Task<IActionResult> Put(Guid id, [FromBody] CustomFieldVM model)
        {
            var command = new SaveCustomFieldCommand()
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
        /// <param name="companyId">The company identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete]
        [Route("{id:guid}/{companyId:guid}")]
        public async Task<IActionResult> Delete(Guid id, Guid? companyId)
        {
            var command = new DeleteCustomFieldCommand()
            {
                Id = id,
                CompanyId = companyId
            };
            await this.handler.Execute(command);

            return this.Ok();
        }

        /// <summary>
        /// Gets the custom fields.
        /// </summary>
        /// <param name="apqpTemplateId">
        /// The apqp template identifier.
        /// </param>
        /// <returns>
        /// IActionResult.
        /// </returns>
        [HttpGet]
        [Route("CustomFields")]
        [Route("CustomFields/{apqpTemplateId:guid}")]
        public async Task<IActionResult> GetCustomFields(Guid? apqpTemplateId)
        {
            var command = new GetActiveCustomFieldCommand()
            {
                APQPTemplateId = apqpTemplateId
            };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
