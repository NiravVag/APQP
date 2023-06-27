// <copyright file="GateClosureEmailVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.ViewModels
{
    using EmailProvider.ViewModels.Abstract;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    ///  class GateClosureEmailVM.
    /// </summary>
    /// <seealso cref="EmailProvider.ViewModels.Abstract.BaseEmailVM" />
    public class GateClosureEmailVM : BaseEmailVM
    {
        /// <summary>
        /// Gets or sets the closure email recipient.
        /// </summary>
        /// <value>
        /// The closure email recipient.
        /// </value>
        public string ClosureEmailRecipient { get; set; }

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
        /// Gets or sets the closure email sender.
        /// </summary>
        /// <value>
        /// The closure email sender.
        /// </value>
        public string ClosureEmailSender { get; set; }

        /// <summary>
        /// Gets the type of the email.
        /// </summary>
        /// <value>
        /// The type of the email.
        /// </value>
        public override EmailTemplateType EmailTemplateType { get => EmailTemplateType.GateClosureEmail; }
    }
}
