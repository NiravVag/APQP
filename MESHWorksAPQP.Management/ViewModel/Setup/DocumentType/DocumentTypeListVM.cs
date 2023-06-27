// <copyright file="DocumentTypeListVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup.DocumentType
{
    using System;

    /// <summary>
    /// Class DocumentTypeListVM.
    /// </summary>
    public class DocumentTypeListVM : SetupListVM
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }
    }
}
