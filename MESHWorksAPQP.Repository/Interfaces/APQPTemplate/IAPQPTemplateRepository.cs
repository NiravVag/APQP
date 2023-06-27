// <copyright file="IAPQPTemplateRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.APQPTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Repository.CustomModel.APQPTemplate;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Interface IAPQPRepository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.IGenericRepository{TEntity}" />
    public interface IAPQPTemplateRepository : IGenericRepository<APQPTemplate>
    {
        /// <summary>
        /// Create APQP Template.
        /// </summary>
        /// <param name="entity">The APQP.</param>
        /// <param name="dt">The New Gate DataTable.</param>
        void CreateAPQPTemplate(APQP entity, DataTable dt);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="entity">The APQP.</param>
        /// <param name="dt">The DataTable.</param>
        /// <param name="removeGateIds">The remove gate ids DataTable.</param>
        /// <param name="dtNewGateIds">The add new gate DataTable.</param>
        void UpdateAPQPTemplate(APQP entity, DataTable dt, DataTable removeGateIds, DataTable dtNewGateIds);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="commodityId">The commodityId.</param>
        /// <returns>IList LookupVM.</returns>
        Task<IList<LookupVM>> GetAPQPTemplate(Guid? commodityId);

        /// <summary>
        /// Gets the apqp templates.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="searchText">The search text.</param>
        /// <param name="isDeleted">if set to <c>true</c> [is deleted].</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <returns>IList of APQPListCM.</returns>
        Task<(IList<APQPTemplateListCM>, int totalRecord)> GetAPQPTemplates(Guid? companyId, string searchText, bool isDeleted, int pageNumber, int pageSize, string sortBy, string sortOrder);

        /// <summary>
        /// Clones the apqp template.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="apqpTemplateId">The apqp template identifier.</param>
        /// <param name="cloneAPQPTemplateId">The clone apqp template identifier.</param>
        /// <returns>GetAPQPTemplateDetails.</returns>
        Task CloneAPQPTemplate(Guid? companyId, Guid userId, Guid apqpTemplateId, Guid cloneAPQPTemplateId);
    }
}
