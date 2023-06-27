// <copyright file="CustomFieldPropertiesOverrideController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.CustomField
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.CustomField.CustomFieldPropertiesOverride;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class CustomFieldPropertiesOverrideController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldPropertiesOverrideController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldPropertiesOverrideController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public CustomFieldPropertiesOverrideController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Gets the specified apqp template identifier.
        /// </summary>
        /// <param name="apqpTemplateId">The apqp template identifier.</param>
        /// <param name="gateId">The gate identifier.</param>
        /// <param name="customFieldId">The custom field identifier.</param>
        /// <returns>
        /// IActionResult.
        /// </returns>
        [HttpGet]
        [Route("{apqpTemplateId:guid}/{gateId:guid}/{customFieldId:guid}")]
        public async Task<IActionResult> Get(Guid apqpTemplateId, Guid gateId, Guid customFieldId)
        {
            var command = new GetCustomFieldPropertiesOverrideCommand()
            {
                APQPTemplateId = apqpTemplateId,
                CustomFieldId = customFieldId,
                GateId = gateId
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
        public async Task<IActionResult> Post([FromBody] CustomFieldPropertiesOverrideVM model)
        {
            var command = new SaveCustomFieldPropertiesOverrideCommand()
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
        public async Task<IActionResult> Put(Guid id, [FromBody] CustomFieldPropertiesOverrideVM model)
        {
            var command = new SaveCustomFieldPropertiesOverrideCommand()
            {
                Id = id,
                Entity = model,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
