// <copyright file="GateCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// class GateCM.
    /// </summary>
    public class GateCM
    {
        /// <summary>
        /// Gets or sets the apqp template identifier.
        /// </summary>
        /// <value>
        /// The apqp template identifier.
        /// </value>
        public Guid Id { get; set; }

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
        /// Gets or sets a value indicating whether gets or sets the Always Editable.
        /// </summary>
        /// <value>
        /// The always editable identifier.
        /// </value>
        public bool IsAlwaysEditable { get; set; }

        /// <summary>
        /// Gets or sets the gate closures.
        /// </summary>
        /// <value>
        /// The gate closures.
        /// </value>
        public List<GateClosureCM> GateClosures { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>
        /// The custom fields.
        /// </value>
        public List<CustomFieldCM> CustomFields { get; set; }

          /// <summary>
        /// Gets or sets the gate closure settings.
        /// </summary>
        /// <value>
        /// The gate closure settings.
        /// </value>
        public List<GateClosureSettingCM> GateClosureSettings { get; set; }
    }
}