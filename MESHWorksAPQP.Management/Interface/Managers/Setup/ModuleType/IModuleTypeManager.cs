

namespace MESHWorksAPQP.Management.Interface.Managers.Setup.ModuleType
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.ModuleType;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;

    /// <summary>
    /// Interface IModuleTypeManager.
    /// </summary>
    public interface IModuleTypeManager
    {
        /// <summary>
        /// Gets the specified get part command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>PartVM.</returns>
        Task<SetupVM> Get(GetModuleTypeCommand command);

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// bool.
        /// </returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>PartVM.</returns>
        Task<SetupVM> Save(SaveModuleTypeCommand command);

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of PartListVM.</returns>
        Task<Page<SetupListVM>> Search(SearchModuleTypeCommand command);
    }
}
