// <copyright file="GateVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.Gates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;
    using MESHWorksAPQP.Management.ViewModel.CustomField;

    /// <summary>
    /// class GateVM.
    /// </summary>
    public class GateVM : ISaveResult
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
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

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>
        /// The custom fields.
        /// </value>
        public List<CustomFieldGateMappingVM> CustomFieldGateMappings { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>
        /// The custom fields.
        /// </value>
        public List<CustomFieldVM> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the gate closure settings.
        /// </summary>
        /// <value>
        /// The gate closure settings.
        /// </value>
        public List<GateClosureSettingVM> GateClosureSettings { get; set; }

        /// <summary>
        /// Gets or sets the gate clousers.
        /// </summary>
        /// <value>
        /// The gate clousers.
        /// </value>
        public List<GateClouserVM> GateClousers { get; set; }
    }
}
