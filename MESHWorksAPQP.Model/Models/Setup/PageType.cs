// <copyright file="PageType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Setup
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Interface;

    /// <summary>
    /// Class Country.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("PageType", Schema = "Setup")]
    public class PageType : SetupBaseEntity, ISetupBaseEntity
    {
        /// <summary>
        /// Gets or sets the ModuleType identifier.
        /// </summary>
        /// <value>
        /// The ModuleType identifier.
        /// </value>
        public Guid ModuleTypeId { get; set; }

        /// <summary>
        /// Gets or sets the page URL.
        /// </summary>
        /// <value>
        /// The page URL.
        /// </value>
        [MaxLength(300)]
        public string PageUrl { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is menu item.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is menu item; otherwise, <c>false</c>.
        /// </value>
        public bool IsMenuItem { get; set; }

        /// <summary>
        /// Gets or sets the menu icon.
        /// </summary>
        /// <value>
        /// The menu icon.
        /// </value>
        [MaxLength(50)]
        public string MenuIcon { get; set; }

        /// <summary>
        /// Gets or sets the ModuleType.
        /// </summary>
        /// <value>
        /// The ModuleType.
        /// </value>
        public virtual ModuleType ModuleType { get; set; }
    }
}
