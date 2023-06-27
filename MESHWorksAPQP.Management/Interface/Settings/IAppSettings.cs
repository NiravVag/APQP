// <copyright file="IAppSettings.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface IAppSettings.
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Gets or sets the frontend URL.
        /// </summary>
        /// <value>
        /// The frontend URL.
        /// </value>
        string FrontendURL { get; set; }

        /// <summary>
        /// Gets or sets the BLOB storage URL.
        /// </summary>
        /// <value>
        /// The BLOB storage URL.
        /// </value>
        string BlobStorageURL { get; set; }

        /// <summary>
        /// Gets or sets the mesh portal API base URL.
        /// </summary>
        /// <value>
        /// The mesh portal API base URL.
        /// </value>
        string MeshPortalApiBaseUrl { get; set; }
    }
}
