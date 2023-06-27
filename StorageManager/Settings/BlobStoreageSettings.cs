// <copyright file="BlobStoreageSettings.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace StorageManager.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using StorageManager.Interface.Settings;

    /// <summary>
    /// Class BlobStoreageSettings.
    /// </summary>
    /// <seealso cref="StorageManager.Interface.Settings.IBlobStoreageSettings" />
    public class BlobStoreageSettings : IBlobStoreageSettings
    {
        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the account key.
        /// </summary>
        /// <value>
        /// The account key.
        /// </value>
        public string AccountKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the container.
        /// </summary>
        /// <value>
        /// The name of the container.
        /// </value>
        public string ContainerName { get; set; }
    }
}
