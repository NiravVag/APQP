// <copyright file="FieldAnswerOptionsBinding.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.CustomField
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;

    /// <summary>
    /// class FieldAnswerOptionsBinding.
    /// </summary>
    [Table("FieldAnswerOptionsBinding", Schema = "CustomField")]
    public class FieldAnswerOptionsBinding : BaseEntity
    {
        /// <summary>
        /// Gets or sets the bindingfunction.
        /// </summary>
        /// <value>
        /// The bindingfunction.
        /// </value>
        public string Bindingfunction { get; set; }
    }
}
