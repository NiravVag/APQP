// <copyright file="ILookupManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Lookup
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using MESHWorksAPQP.Management.ViewModel.Lookup;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Interface ILookupManager.
    /// </summary>
    public interface ILookupManager
    {
        /// <summary>
        /// Gets the lookups.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <returns>
        /// List of LookupVM.
        /// </returns>
        Task<List<LookupCollectionVM>> GetLookups(List<LookupQuery> filters);

        /// <summary>
        /// Gets the grouped lookup.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Lis of GroupedLookupVM.</returns>
        Task<List<GroupedLookupVM>> GetGroupedLookup(LookupQuery filter);

        /// <summary>
        /// Get lookup
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<LookupVM>> GetLookup(LookupQuery filter);

        /// <summary>
        /// GetCustomFieldAnswerOption list
        /// </summary>
        /// <param name="bindingfunction">bindingfunction</param>
        /// <param name="customFieldId">customFieldId</param>
        /// <returns>List of CustomFieldAnswerOptionCM <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<CustomFieldAnswerOptionVM>> GetCustomFieldAnswerOption(string bindingfunction, Guid customFieldId);
    }
}
