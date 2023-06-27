// <copyright file="LoggedInUserInfoMiddleware.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Middlewares
{
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Interface.Helpers;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Class LoggedInUserInfoMiddleware.
    /// </summary>
    public class LoggedInUserInfoMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggedInUserInfoMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public LoggedInUserInfoMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authenticationHelper">The authentication helper.</param>
        /// <returns>Task.</returns>
        public async Task Invoke(HttpContext context, IAuthenticationHelper authenticationHelper)
        {
            var jwt = context.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrWhiteSpace(jwt))
            {
                var jwtEncodedString = jwt.Substring(7);
                var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
                List<Claim> claims = token.Claims?.ToList();
                await authenticationHelper.HandleAuthenticate(context, claims);
            }

            await this.next.Invoke(context);
        }
    }
}
