// <copyright file="APQPListTemplateVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP
{
    using System;

    /// <summary>
    /// class APQPListTemplateVM.
    /// </summary>
    public class APQPListTemplateVM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the parts identifier.
        /// </summary>
        /// <value>
        /// The parts identifier.
        /// </value>
        public Guid PartId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the apqp template identifier.
        /// </summary>
        /// <value>
        /// The apqp template identifier.
        /// </value>
        public Guid APQPTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the name of the apqp template.
        /// </summary>
        /// <value>
        /// The name of the apqp template.
        /// </value>
        public string APQPTemplateName { get; set; }
    }
}
