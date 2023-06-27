// <copyright file="ICustomFieldRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.CustomField
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Repository.CustomModel.CustomField;

    /// <summary>
    /// Interface ICustomFieldRepository.
    /// </summary>
     /// <seealso cref="MESHWorksAPQP.Repository.Repository.GenericRepository{MESHWorksAPQP.Model.Models.CustomField.CustomField}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.CustomField.ICustomFieldRepository" />
    public interface ICustomFieldRepository : IGenericRepository<CustomField>
    {
        /// <summary>
        /// Gets the custom fields.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="searchText">The search text.</param>
        /// <param name="isDeleted">if set to <c>true</c> [is deleted].</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortBy">Sort the page by column.</param>
        /// <param name="sortOrder">Sort the page by order.</param>
        /// <returns>
        /// List of CustomFieldListCM.
        /// </returns>
        Task<(IList<CustomFieldListCM>, int totalRecord)> GetCustomFields(Guid companyId, string searchText, bool isDeleted, int pageNumber, int pageSize, string sortBy, string sortOrder);

        /// <summary>
        /// Gets the active custom fields.
        /// </summary>
        /// <param name="companyId">
        /// The company identifier.
        /// </param>
        /// <param name="apqpTemplateId">
        /// The apqp template identifier.
        /// </param>
        /// <returns>
        /// List of CustomFieldCM.
        /// </returns>
        Task<IList<CustomFieldCM>> GetActiveCustomFields(Guid? companyId, Guid? apqpTemplateId);
    }
}
