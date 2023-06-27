// <copyright file="IEmailTemplateRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.Email
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Email;
    using MESHWorksAPQP.Repository.CustomModel;
    using MESHWorksAPQP.Repository.CustomModel.Email;

    /// <summary>
    /// Interface IEmailTemplateRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.IGenericRepository{MESHWorksAPQP.Model.Models.Email.EmailTemplate}" />
    public interface IEmailTemplateRepository : IGenericRepository<EmailTemplate>
    {
        /// <summary>
        /// Gets the email notification users.
        /// </summary>
        /// <param name="emailNotificationId">The email notification identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="ownerUserId">The owner user identifier.</param>
        /// <returns>
        /// List of EmailNotificationUser.
        /// </returns>
        Task<IList<EmailNotificationUser>> GetEmailNotificationUsers(Guid emailNotificationId, Guid? companyId, Guid? ownerUserId);
    }
}
