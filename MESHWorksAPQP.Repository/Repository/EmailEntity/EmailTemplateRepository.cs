// <copyright file="EmailTemplateRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.EmailEntity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Email;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel;
    using MESHWorksAPQP.Repository.CustomModel.Email;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.Email;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class EmailTemplateRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.GenericRepository{MESHWorksAPQP.Model.Models.Email.EmailTemplate}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.Email.IEmailTemplateRepository" />
    public class EmailTemplateRepository : GenericRepository<EmailTemplate>, IEmailTemplateRepository
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
        /// Initializes a new instance of the <see cref="EmailTemplateRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public EmailTemplateRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext,  userIdentity)
        {
            this.userIdentity = userIdentity;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the email notification users.
        /// </summary>
        /// <param name="emailNotificationId">The email notification identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="ownerUserId">The owner user identifier.</param>
        /// <returns>
        /// List of EmailNotificationUser.
        /// </returns>
        public async Task<IList<EmailNotificationUser>> GetEmailNotificationUsers(Guid emailNotificationId, Guid? companyId, Guid? ownerUserId)
        {
            IList<EmailNotificationUser> emailUsers = null;

            await this.dbContext.LoadStoredProc("Email.GetEmailNotificationUsers")
               .WithSqlParam("EmailNotificationId", emailNotificationId)
               .WithSqlParam("CompanyId", companyId)
               .WithSqlParam("OwnerUserId", ownerUserId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   emailUsers = handler.ReadToList<EmailNotificationUser>();
               });

            return emailUsers;
        }
    }
}
