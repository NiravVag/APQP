// <copyright file="IUserIdentity.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface IUserIdentity.
    /// </summary>
    public interface IUserIdentity
    {
        ///// <summary>
        ///// Gets the current username.
        ///// </summary>
        ///// <returns>string.</returns>
        // string GetCurrentUsername();

        ///// <summary>
        ///// Gets the current user identifier.
        ///// </summary>
        ///// <returns>Guid.</returns>
        // Guid GetCurrentUserId();

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <value>The user information.</value>
        IUserInfo UserInfo { get; }
    }
}
