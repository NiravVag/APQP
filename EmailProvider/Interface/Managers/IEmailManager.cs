// <copyright file="IEmailManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.Interface.Managers
{
    using System.Threading.Tasks;
    using EmailProvider.ViewModels;

    /// <summary>
    /// Interface IEmailManager.
    /// </summary>
    public interface IEmailManager
    {
        /// <summary>
        /// Customer discussion.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Task.
        /// </returns>
        Task Discussion(DiscussionVM model);

        /// <summary>
        /// Contacts the us to mesh.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task ContactUsToAdmin(ContactUsToAdminVM model);

        /// <summary>
        /// Processes the email.
        /// </summary>
        /// <returns>Task.</returns>
        Task ProcessEmail();

        /// <summary>
        /// Sends the gate closure email.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task SendGateClosureEmail(GateClosureEmailVM model);

        /// <summary>
        /// Gates the closure approval email.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task GateClosureApprovalEmail(GateClosureApprovalEmailVM model);

        /// <summary>
        /// Raises the gate closure approval email.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Task.
        /// </returns>
        Task RaiseGateClosureApprovalEmail(RaiseGateClosureApprovalEmailVM model);
    }
}
