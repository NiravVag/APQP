// <copyright file="PageTypeRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.Setup
{
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class PageTypeRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.SetupRepositoty{MESHWorksAPQP.Model.Models.Setup.PageType}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.Setup.IPageTypeRepository" />
    public class PageTypeRepository : SetupRepositoty<PageType>, IPageTypeRepository
    {
        /// <summary>
        /// The user identity
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageTypeRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public PageTypeRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
        }
    }
}
