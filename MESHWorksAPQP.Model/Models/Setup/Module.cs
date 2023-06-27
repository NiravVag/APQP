// <copyright file="Module.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Setup
{
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Interface;

    /// <summary>
    /// Class Module.
    /// </summary>
    /// <seealso cref="MESHWorks.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("Module", Schema = "Setup")]
    public class Module : SetupBaseEntity, ISetupBaseEntity
    {
    }
}