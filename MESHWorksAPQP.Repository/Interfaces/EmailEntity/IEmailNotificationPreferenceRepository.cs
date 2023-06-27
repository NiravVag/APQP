// <copyright file="IEmailNotificationPreferenceRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.Email
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Email;
    using MESHWorksAPQP.Repository.CustomModel.Email;

    /// <summary>
    /// Interface IEmailNotificationPreferenceRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.IGenericRepository{MESHWorksAPQP.Model.Models.Email.EmailNotificationPreference}" />
    public interface IEmailNotificationPreferenceRepository : IGenericRepository<EmailNotificationPreference>
    {
        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>
        /// EmailNotificationPreferenceDetail.
        /// </returns>
        Task<IList<RoleDetail>> GetEmailNotificationPreference(Guid? companyId);
    }
}
