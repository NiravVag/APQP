// <copyright file="ModuleTypeRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.Setup
{
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class ModuleTypeRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.SetupRepositoty{MESHWorksAPQP.Model.Models.Setup.ModuleType}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.Setup.IModuleTypeRepository" />
    public class ModuleTypeRepository : SetupRepositoty<ModuleType>, IModuleTypeRepository
    {
        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleTypeRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="useridentity">The user identity.</param>
        public ModuleTypeRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
        }
    }
}
