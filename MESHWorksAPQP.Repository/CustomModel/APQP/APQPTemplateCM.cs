// <copyright file="APQPTemplateCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// class APQPTemplateCM.
    /// </summary>
    public class APQPTemplateCM
    {
        /// <summary>
        /// Gets or sets the apqp template identifier.
        /// </summary>
        /// <value>
        /// The apqp template identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the apqp template.
        /// </summary>
        /// <value>
        /// The name of the apqp template.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the apqp template description.
        /// </summary>
        /// <value>
        /// The apqp template description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the gate.
        /// </summary>
        /// <value>
        /// The gate.
        /// </value>
        public List<GateCM> Gates { get; set; }
    }
}