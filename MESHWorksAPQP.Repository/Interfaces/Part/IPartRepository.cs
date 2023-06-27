// <copyright file="IPartRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.Part
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using MESHWorksAPQP.Repository.CustomModel.Part;

    /// <summary>
    /// Interface IPartRepository
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.GenericRepository{MESHWorksAPQP.Model.Models.Parts.Part}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.Part.IPartRepository" />
    public interface IPartRepository : IGenericRepository<Part>
    {
        /// <summary>
        /// Gets the part relations.
        /// </summary>
        /// <param name="partId">The part identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>List of PartRelationsCM.</returns>
        Task<IList<PartRelationsCM>> GetPartRelations(Guid partId, Guid companyId);

        /// <summary>
        /// Gets the part relations.
        /// </summary>
        /// <param name="partId">The part identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>List of PartRelationsCM.</returns>
        Task<IList<PartRelationsCM>> GetPartRelationsForParent(Guid partId, Guid companyId);

        /// <summary>
        /// Gets the apqp part documents.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <returns> PartDocumentCM </returns>
        Task<(IList<APQPPartDocumentCM>, int totalRecord)> GetPartDocuments(Guid apqpId, int pageNumber, int pageSize, string sortBy, string sortOrder);
    }
}
