// <copyright file="EmailNotification.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Setup
{
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Interface;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class EmalNotification.
    /// </summary>
    [Table("EmailNotification", Schema = "Setup")]
    public class EmailNotification : SetupBaseEntity, ISetupBaseEntity
    {
        /// <summary>
        /// Gets or sets the type of the company.
        /// </summary>
        /// <value>
        /// The type of the company.
        /// </value>
        public CompanyType CompanyType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is owner option available.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is owner option available; otherwise, <c>false</c>.
        /// </value>
        public bool IsOwnerOptionAvailable { get; set; }
    }
}
