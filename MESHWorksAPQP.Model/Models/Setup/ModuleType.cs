// <copyright file="ModuleType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Setup
{
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Interface;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class Currency.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("ModuleType", Schema = "Setup")]
    public class ModuleType : SetupBaseEntity, ISetupBaseEntity
    {
        /// <summary>
        /// Gets or sets the module for.
        /// </summary>
        /// <value>
        /// The module for.
        /// </value>
        public ModuleFor ModuleFor { get; set; }
    }
}
