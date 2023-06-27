// <copyright file="APQPDiscussionController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.APQP
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.APQP.APQPDiscussion;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP.Discussion;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class APQPDiscussionController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/{companyId:guid}/APQP/{apqpId:guid}/Discussion")]
    [ApiController]
    public class APQPDiscussionController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="APQPDiscussionController" /> class.
        /// </summary>
        /// <param name="handler">
        /// The handler.
        /// </param>
        public APQPDiscussionController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Searches the specified apqp identifier.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("Search")]
        public virtual async Task<IActionResult> Search(Guid apqpId, Guid companyId, [FromBody] FilterVM model)
        {
            var command = new SearchAPQPDiscussionCommand()
            {
                APQPId = apqpId,
                CompanyId = companyId,
                Filter = model
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id, Guid apqpId, Guid companyId)
        {
            var command = new GetAPQPDiscussionCommand()
            {
                Id = id,
                APQPId = apqpId,
                CompanyId = companyId
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Posts the specified identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post(Guid companyId, Guid apqpId, [FromBody] APQPDiscussionVM model)
        {
            var command = new SaveAPQPDiscussionCommand()
            {
                APQPId = apqpId,
                CompanyId = companyId,
                Entity = model
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Put(Guid companyId, Guid id, Guid apqpId, [FromBody] APQPDiscussionVM model)
        {
            var command = new SaveAPQPDiscussionCommand()
            {
                Id = id,
                APQPId = apqpId,
                CompanyId = companyId,
                Entity = model
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Deletes the specified company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("Delete/{id:guid}/{userId:guid}")]
        public async Task<IActionResult> Delete(Guid companyId, Guid id, Guid apqpId, Guid userId)
        {
            var command = new DeleteAPQPDiscussionCommand()
            {
                Id = id,
                CompanyId = companyId,
                APQPId = apqpId,
                UserId = userId
            };
            await this.handler.Execute(command);

            return this.Ok();
        }
    }
}
