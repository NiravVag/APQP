// <copyright file="IPartManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Part
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Part;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Part;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using MESHWorksAPQP.Repository.CustomModel.Part;

    /// <summary>
    /// Interface IPartManager.
    /// </summary>
    public interface IPartManager
    {
        /// <summary>
        /// Gets the specified get part command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>PartVM.</returns>
        Task<PartVM> Get(GetPartCommand command);

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        Task<bool> Delete(DeletePartCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>PartVM.</returns>
        Task<PartVM> Save(SavePartCommand command);

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of PartListVM.</returns>
        Task<Page<PartListVM>> Search(SearchPartCommand command);

        /// <summary>
        /// Gets the part relation.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of PartRelationListVM</returns>
        Task<List<PartRelationListVM>> GetPartRelation(GetPartRelationCommand command);

        /// <summary>
        /// Gets the part apqp.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of part apqp</returns>
        Task<Page<PartAPQPListVM>> GetPartAPQP(GetPartAPQPCommand command);

        /// <summary>
        /// Gets the part relations.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of PartRelationsCM.</returns>
        Task<IList<PartRelationsCM>> GetPartRelations(GetPartRelationsCommand command);

        /// <summary>
        /// Deletes the apqp project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>bool</returns>
        Task<Page<APQPPartDocumentCM>> GetPartDocument(SearchPartDocumentCommand command);
    }
}
