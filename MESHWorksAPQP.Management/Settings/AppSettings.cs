// <copyright file="AppSettings.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Settings
{
    using MESHWorksAPQP.Management.Interface.Settings;

    /// <summary>
    /// Class AppSettings.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Settings.IAppSettings" />
    public class AppSettings : IAppSettings
    {
        /// <summary>
        /// Gets or sets the frontend URL.
        /// </summary>
        /// <value>
        /// The frontend URL.
        /// </value>
        public string FrontendURL { get; set; }

        /// <summary>
        /// Gets or sets the BLOB storage URL.
        /// </summary>
        /// <value>
        /// The BLOB storage URL.
        /// </value>
        public string BlobStorageURL { get; set; }

        /// <summary>
        /// Gets or sets the mesh portal API base URL.
        /// </summary>
        /// <value>
        /// The mesh portal API base URL.
        /// </value>
        public string MeshPortalApiBaseUrl { get; set; }
    }
}
