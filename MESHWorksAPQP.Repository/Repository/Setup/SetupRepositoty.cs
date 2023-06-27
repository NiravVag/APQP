// <copyright file="SetupRepositoty.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository
{
    using MESHWorksAPQP.Model.Interface;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class SetupRepositoty
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.GenericRepository{TEntity}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.Setup.ISetupRepositoty" />
    public class SetupRepositoty<TEntity> : GenericRepository<TEntity>, ISetupRepositoty<TEntity>
        where TEntity : class, ISetupBaseEntity
    {
        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetupRepositoty{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public SetupRepositoty(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
        }
    }
}
