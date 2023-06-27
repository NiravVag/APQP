// <copyright file="IProcessRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.Setup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Interface IProcessRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.ISetupRepositoty{MESHWorksAPQP.Model.Models.Setup.Process}" />
    public interface IProcessRepository : ISetupRepositoty<Process>
    {
        /// <summary>
        /// Gets the material processes.
        /// </summary>
        /// <param name="commodityId">The commodity identifier.</param>
        /// <returns>
        /// LookupVM.
        /// </returns>
        Task<IList<LookupVM>> GetProcesses(Guid? commodityId);
    }
}
