﻿// <copyright file="CustomFieldAnswerOptionVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.CustomField
{
    using System;

    /// <summary>
    /// Class CustomFieldAnswerOptionVM.
    /// </summary>
    public class CustomFieldAnswerOptionVM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the custom field.
        /// </summary>
        /// <value>
        /// The custom field.
        /// </value>
        public Guid CustomFieldId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        public string Display { get; set; }
    }
}
