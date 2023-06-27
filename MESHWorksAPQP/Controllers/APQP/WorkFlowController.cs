// <copyright file="WorkFlowController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.APQP
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.APQP.WorkFlow;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class WorkFlowController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [Route("api/[controller]/{companyId:guid}")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkFlowController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public WorkFlowController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Sends the gate closure email.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateModel]
        [Route("apqp/{id:Guid}/GateClosure")]
        public async Task<IActionResult> GateClosure([FromBody] GateClosureSettingVM model, Guid id, Guid? companyId)
        {
            var command = new GateClosureCommand()
            {
                Id = id,
                Entity = model,
                APQPId = id,
                CompanyId = companyId
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Gets the gate closure status.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="gateId">The gate identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("apqp/{id:Guid}/gate/{gateId:Guid}")]
        public async Task<IActionResult> GetGateClosureStatus(Guid id, Guid gateId)
        {
            var command = new GetGateClosureStatusCommand()
            {
                Id = id,
                GateId = gateId,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Updates the active gate identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="gateId">The gate identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        [Route("apqp/{id:Guid}/gate/{gateId:Guid}")]
        public async Task<IActionResult> UpdateActiveGateId(Guid id, Guid gateId)
        {
            var command = new UpdateActiveGateIdCommand()
            {
                Id = id,
                GateId = gateId,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Requests the gate closure approval.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateModel]
        [Route("requestGateClosureApproval")]
        public async Task<IActionResult> RequestGateClosureApproval([FromBody] RequestGateClosureApprovalVM model)
        {
            var command = new RequestGateClosureApprovalCommand()
            {
                Entity = model,
                CompanyId = model.CompanyId,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Saves the approver action.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [ValidateModel]
        [Route("apqp/{id:Guid}/saveApproverAction")]
        public async Task<IActionResult> SaveApproverAction([FromBody] GateClosureSettingVM model, Guid id, Guid companyId)
        {
            var command = new GateClosureCommand()
            {
                APQPId = id,
                Entity = model,
                CompanyId = companyId
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Requests the gate closure approval.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateModel]
        [Route("reopengate")]
        public async Task<IActionResult> ReOpenGate([FromBody] ReOpenGateVM model)
        {
            var command = new ReOpenGateCommand()
            {
                Entity = model,
                CompanyId = model.CompanyId,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Saves the approver action.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult</returns>
        [HttpPost]       
        [Route("apqp/{id:Guid}/UpdateAPQPStatus")]
        public async Task<IActionResult> UpdateAPQPStatus([FromBody] APQPVM model, Guid id)
        {
            var command = new UpdateGateStatusCommand()
            {
                Id = id,
                Entity = model,
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
