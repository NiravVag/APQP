// <copyright file="IAuthenticationHelper.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Helpers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Interface IAuthenticationHelper.
    /// </summary>
    public interface IAuthenticationHelper
    {
        /// <summary>
        /// Handles the authenticate.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="claims">The claims.</param>
        /// <returns>The AuthenticateResult.</returns>
        Task<AuthenticateResult> HandleAuthenticate(HttpContext context, List<Claim> claims);
    }
}
