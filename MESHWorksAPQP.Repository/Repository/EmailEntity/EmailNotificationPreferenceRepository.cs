// <copyright file="EmailNotificationPreferenceRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.EmailEntity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Email;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel.Email;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.Email;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class EmailNotificationPreferenceRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.GenericRepository{MESHWorksAPQP.Model.Models.Email.EmailNotificationPreference}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.Email.IEmailNotificationPreferenceRepository" />
    public class EmailNotificationPreferenceRepository : GenericRepository<EmailNotificationPreference>, IEmailNotificationPreferenceRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificationPreferenceRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public EmailNotificationPreferenceRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>
        /// NotificationPreferenceDetail.
        /// </returns>
        public async Task<IList<RoleDetail>> GetEmailNotificationPreference(Guid? companyId)
        {
            IList<RoleDetail> notificationPreferenceDetails = null;
            IList<UserDetail> userDetails = null;

            await this.dbContext.LoadStoredProc("Email.GetEmailNotificationPreference")
               .WithSqlParam("CompanyId", companyId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   notificationPreferenceDetails = handler.ReadToList<RoleDetail>();
                   handler.NextResult();
                   userDetails = handler.ReadToList<UserDetail>();
                   handler.NextResult();
               });

            if (notificationPreferenceDetails != null && notificationPreferenceDetails.Any() && userDetails != null && userDetails.Any())
            {
                foreach (var notificationPreference in notificationPreferenceDetails)
                {
                    notificationPreference.Users = userDetails.Where(x => x.RoleId == notificationPreference.Id).ToList();
                }
            }

            return notificationPreferenceDetails;
        }
    }
}
