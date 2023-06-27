// <copyright file="ProcessVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup.Process
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MESHWorksAPQP.Management.Interface.ViewModel;

    /// <summary>
    /// class ProcessVM.
    /// </summary>
    public class ProcessVM: ISaveResult
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        public Guid Id { get; set; }


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [MaxLength(50)]
        public string Code { get; set; }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [MaxLength(3000)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the sortorder.
        /// </summary>
        /// <value>
        /// The sortorder.
        /// </value>
        public int SortOrder { get; set; }
    }
}
