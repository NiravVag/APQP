// <copyright file="CompanyType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Enum
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Enum CompanyType.
    /// </summary>
    public enum CompanyType
    {
        /// <summary>
        /// The supplier
        /// </summary>
        [Display(Name = "Supplier")]
        Supplier = 1,

        /// <summary>
        /// The customer
        /// </summary>
        [Display(Name = "Customer")]
        Customer = 2,
    }
}
