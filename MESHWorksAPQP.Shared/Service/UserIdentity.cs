// <copyright file="UserIdentity.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Service
{
    using System;
    using MESHWorksAPQP.Shared.Interface;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// class UserIdentity.
    /// </summary>
    public class UserIdentity : IUserIdentity
    {
        /// <summary>
        /// The HTTP context accessor.
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdentity"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <exception cref="ArgumentNullException">httpContextAccessor.</exception>
        public UserIdentity(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <value>
        /// The user information.
        /// </value>
        public IUserInfo UserInfo
        {
            get
            {
                if (this.httpContextAccessor?.HttpContext?.Items == null)
                {
                    return null;
                }

                if (!this.httpContextAccessor.HttpContext.Items.ContainsKey("UserInfo"))
                {
                    return null;
                }

                return this.httpContextAccessor?.HttpContext?.Items?["UserInfo"] as IUserInfo;
            }
        }
    }
}
