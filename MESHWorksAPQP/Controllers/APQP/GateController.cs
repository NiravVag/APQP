// <copyright file="GateController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.APQP
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class GateController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GateController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public GateController(IHandlerFactory handler)
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
            var command = new GetGateCommand() { Id = id };
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
        public async Task<IActionResult> Post([FromBody] GateVM model)
        {
            var command = new SaveGateCommand()
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
        public async Task<IActionResult> Put(Guid id, [FromBody] GateVM model)
        {
            var command = new SaveGateCommand()
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
        /// <param name="apqpTemplateId">The apqp template identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete]
        [Route("{id:guid}/{apqpTemplateId:guid}")]
        public async Task<IActionResult> Delete(Guid id, Guid apqpTemplateId)
        {
            var command = new DeleteGateCommand()
            {
                Id = id,
                APQPTemplateId = apqpTemplateId
            };
            await this.handler.Execute(command);

            return this.Ok();
        }
    }
}
