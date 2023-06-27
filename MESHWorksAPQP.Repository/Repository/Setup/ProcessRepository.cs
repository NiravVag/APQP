// <copyright file="ProcessRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.Setup
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Class ProcessRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.SetupRepositoty{Process}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.Setup.IProcessRepository" />
    public class ProcessRepository : SetupRepositoty<Process>, IProcessRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// The user identity
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public ProcessRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the material processes.
        /// </summary>
        /// <param name="commodityId">The commodity identifier.</param>
        /// <returns>
        /// LookupVM.
        /// </returns>
        public async Task<IList<LookupVM>> GetProcesses(Guid? commodityId)
        {
            IList<LookupVM> data = null;
            await this.dbContext.LoadStoredProc("[Setup].[GetProcesses]")
               .WithSqlParam("CommodityId", commodityId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   data = handler.ReadToList<LookupVM>();
               });

            return data;
        }
    }
}
