// <copyright file="APQPDiscussionListVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.Discussion
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Class APQPDiscussionVM.
    /// </summary>
    public class APQPDiscussionListVM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the apqp identifier.
        /// </summary>
        /// <value>
        /// The apqp identifier.
        /// </value>
        public Guid APQPId { get; set; }

        /// <summary>
        /// Gets or sets the name of the apqp.
        /// </summary>
        /// <value>
        /// The name of the apqp.
        /// </value>
        public string APQPName { get; set; }

        /// <summary>
        /// Gets or sets the parent discussion identifier.
        /// </summary>
        /// <value>
        /// The parent discussion identifier.
        /// </value>
        public Guid ParentDiscussionId { get; set; }

        /// <summary>
        /// Gets or sets the parent notes.
        /// </summary>
        /// <value>
        /// The parent notes.
        /// </value>
        public string ParentNotes { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the attachment.
        /// </summary>
        /// <value>
        /// The attachment.
        /// </value>
        public List<AttachmentDetailVM> Attachments { get; set; }
    }
}
