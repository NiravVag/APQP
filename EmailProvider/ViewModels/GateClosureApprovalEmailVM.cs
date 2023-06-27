// <copyright file="GateClosureApprovalEmailVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.ViewModels
{
    using System.Collections.Generic;
    using EmailProvider.ViewModels.Abstract;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    ///  class GateClosureApprovalEmailVM.
    /// </summary>
    /// <seealso cref="EmailProvider.ViewModels.Abstract.BaseEmailVM" />
    public class GateClosureApprovalEmailVM : BaseEmailVM
    {
        /// <summary>
        /// Gets or sets the name of the apqp project.
        /// </summary>
        /// <value>
        /// The name of the apqp project.
        /// </value>
        public string APQPProjectName { get; set; }

        /// <summary>
        /// Gets or sets the name of the gate.
        /// </summary>
        /// <value>
        /// The name of the gate.
        /// </value>
        public string GateName { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public string ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the apqp project link.
        /// </summary>
        /// <value>
        /// The apqp project link.
        /// </value>
        public string ApqpProjectLink { get; set; }

        /// <summary>
        /// Gets the type of the email.
        /// </summary>
        /// <value>
        /// The type of the email.
        /// </value>
        public override EmailTemplateType EmailTemplateType { get => EmailTemplateType.GateClosureApprovalEmail; }
    }
}
