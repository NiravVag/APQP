// <copyright file="ActivityController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Activity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Activity;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.Activity;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class ActivityController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        /// <summary>
        /// The handler
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public ActivityController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [Route("activity")]
        public virtual async Task<IActionResult> GetActivity([FromBody] ActivityFilterVM model)
        {
            var command = new GetActivityCommand()
            {
                Filter = model
            };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
