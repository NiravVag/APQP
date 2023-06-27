// <copyright file="IBlobStoreageSettings.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace StorageManager.Interface.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Interface IBlobStoreageSettings.
    /// </summary>
    public interface IBlobStoreageSettings
    {
        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the account key.
        /// </summary>
        /// <value>
        /// The account key.
        /// </value>
        string AccountKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the container.
        /// </summary>
        /// <value>
        /// The name of the container.
        /// </value>
        string ContainerName { get; set; }
    }
}
