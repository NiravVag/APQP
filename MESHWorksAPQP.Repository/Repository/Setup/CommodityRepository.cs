// <copyright file="CommodityRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.Setup
{
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class CommodityRepository.
    /// </summary>
    public class CommodityRepository : SetupRepositoty<Commodity>, ICommodityRepository
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
        /// Initializes a new instance of the <see cref="CommodityRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public CommodityRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.dbContext = dbContext;
            this.userIdentity = userIdentity;
        }
    }
}
