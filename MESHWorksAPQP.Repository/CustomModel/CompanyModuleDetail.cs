// <copyright file="CompanyModuleDetail.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class CompanyModuleDetail.
    /// </summary>
    public class CompanyModuleDetail
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the moduletype.
        /// </summary>
        /// <value>
        /// The name of the moduletype.
        /// </value>
        public string ModuleType { get; set; }

        /// <summary>
        /// Gets or sets the moduletype identifier.
        /// </summary>
        /// <value>
        /// The moduletype identifier.
        /// </value>
        public Guid ModuleTypeId { get; set; }
    }
}
