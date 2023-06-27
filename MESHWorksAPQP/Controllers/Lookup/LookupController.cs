// <copyright file="LookupController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Lookup;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.Lookup;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class LookupController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]

    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LookupController : ControllerBase
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public LookupController(IHandlerFactory handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Gets the lookup.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GetLookup(List<LookupQuery> filters)
        {
            var command = new GetLookupCommand()
            {
                Filters = filters,
            };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Gets the grouped lookup.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("groupedlookup")]
        public async Task<IActionResult> GetGroupedLookup(LookupQuery filters)
        {
            var command = new GetGroupedLookupCommand()
            {
                Filters = filters,
            };
            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }
    }
}
