// <copyright file="AuthenticationHelper.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Interface.Helpers;
    using MESHWorksAPQP.Shared.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Class AuthenticationHelper.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Helpers.IAuthenticationHelper" />
    public class AuthenticationHelper : IAuthenticationHelper
    {
        /// <summary>
        /// The default error message
        /// </summary>
        public const string DefaultErrorMessage = "Token Invalid.";

        /// <summary>
        /// The user information
        /// </summary>
        public const string Key = "UserInfo";

        /// <summary>
        /// The sub
        /// </summary>
        public const string Sub = "sub";

        /// <summary>
        /// The user name
        /// </summary>
        public const string UserName = "UserName";

        /// <summary>
        /// The full name
        /// </summary>
        public const string FullName = "FullName";

        /// <summary>
        /// The company name
        /// </summary>
        public const string CompanyName = "CompanyName";

        /// <summary>
        /// The company identifier
        /// </summary>
        public const string CompanyId = "CompanyId";

        /// <summary>
        /// Handles the authenticate.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="claims">The claims.</param>
        /// <returns>
        /// AuthenticateResult.
        /// </returns>
        public async Task<AuthenticateResult> HandleAuthenticate(HttpContext context, List<Claim> claims)
        {
            var userId = claims?.FirstOrDefault(x => x.Type == Sub).Value;
            var userName = claims?.FirstOrDefault(x => x.Type == UserName).Value;
            var fullName = claims?.FirstOrDefault(x => x.Type == FullName).Value;
            var companyName = claims?.FirstOrDefault(x => x.Type == CompanyName).Value;
            var companyId = claims?.FirstOrDefault(x => x.Type == CompanyId).Value;

            if (string.IsNullOrWhiteSpace(userId))
            {
                context.Response.StatusCode = 401;  // Unauthorized
                await context.Response.WriteAsync(DefaultErrorMessage);
                return AuthenticateResult.Fail(DefaultErrorMessage);
            }

            var userInfo = new UserInfo()
            {
                Id = new Guid(userId),
                UserName = userName,
                FullName = fullName,
                CompanyId = new Guid(companyId),
                CompanyName = companyName
            };

            context.Items.Add(new KeyValuePair<object, object>(Key, userInfo));

            return AuthenticateResult.Success(new AuthenticationTicket(context.User, context.Request.Scheme));
        }
    }
}
