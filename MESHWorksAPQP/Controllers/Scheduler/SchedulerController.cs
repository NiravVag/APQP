// <copyright file="SchedulerController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Scheduler;
    using MESHWorksAPQP.Management.Interface.Factories;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class SchedulerController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulerController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public SchedulerController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Processes the email.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("ProcessEmail")]
        public async Task<IActionResult> ProcessEmail()
        {
            var command = new EmailSchedulerCommand();
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
