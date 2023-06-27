// <copyright file="EmailConfigurationRepository.cs" company="MESHWorksAPQP">
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
    using MESHWorksAPQP.Repository.Interfaces.Email;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class EmailConfigurationRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.GenericRepository{MESHWorksAPQP.Model.Models.Email.EmailConfiguration}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.Email.IEmailConfigurationRepository" />
    public class EmailConfigurationRepository : GenericRepository<EmailConfiguration>, IEmailConfigurationRepository
    {
        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailConfigurationRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public EmailConfigurationRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
        }
    }
}
