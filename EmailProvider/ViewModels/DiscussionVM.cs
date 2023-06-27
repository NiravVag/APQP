// <copyright file="DiscussionVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.ViewModels
{
    using EmailProvider.ViewModels.Abstract;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class DiscussionVM.
    /// </summary>
    /// <seealso cref="EmailProvider.ViewModels.Abstract.BaseEmailVM" />
    public class DiscussionVM : BaseEmailVM
    {
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the quote link.
        /// </summary>
        /// <value>
        /// The quote link.
        /// </value>
        public string QuoteLink { get; set; }

        /// <summary>
        /// Gets the type of the email.
        /// </summary>
        /// <value>
        /// The type of the email.
        /// </value>
        public override EmailTemplateType EmailTemplateType { get => EmailTemplateType.Discussion; }
    }
}
