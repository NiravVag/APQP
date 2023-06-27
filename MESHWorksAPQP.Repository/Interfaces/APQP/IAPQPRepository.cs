// <copyright file="IAPQPRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.APQP
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Repository.CustomModel.APQP;

    /// <summary>
    /// Interface IAPQPRepository.
    /// </summary>
    public interface IAPQPRepository : IGenericRepository<APQP>
    {
        /// <summary>
        /// Gets the custom fields.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <returns>APQPCM.</returns>
        Task<APQPCM> GetAPQPTemplateDeatils(Guid apqpId);

        /// <summary>
        /// Gets the apqp data.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>APQPDataCM.</returns>
        Task<APQPDataCM> GetAPQPData(Guid id);

        /// <summary>
        /// Saves the apqp template deatils.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="gateId">The gate identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="customFieldsDataJson">The custom fields data json.</param>
        /// <returns>Task.</returns>
        Task SaveAPQPTemplateDeatils(Guid companyId, Guid gateId, Guid entityId, string customFieldsDataJson);

        /// <summary>
        /// Gets the apqp discussions.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>List of APQPDiscussionCM.</returns>
        Task<IList<APQPDiscussionCM>> GetAPQPDiscussions(Guid apqpId, Guid companyId);

        /// <summary>
        /// Gets the apqp documents.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        ///  <param name="searchText">The search text.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <returns> APQPPartDocumentCM </returns>
        Task<(IList<APQPPartDocumentCM>, int totalRecord)> GetAPQPDocuments(Guid apqpId, string searchText, int pageNumber, int pageSize, string sortBy, string sortOrder);
    }
}
