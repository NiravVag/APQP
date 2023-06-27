// <copyright file="ModuleTypeManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Setup.ModuleType
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Command.Setup.ModuleType;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.ModuleType;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;

    /// <summary>
    /// Class ModuleTypeManager.
    /// </summary>
    public class ModuleTypeManager : SetupBaseManager<ModuleType, SearchModuleTypeCommand, SetupListVM, GetModuleTypeCommand, SetupVM, SaveModuleTypeCommand, SetupVM, FilterVM>, IModuleTypeManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ISetupRepositoty<ModuleType> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleTypeManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        public ModuleTypeManager(
            IMapper mapper,
            ISetupRepositoty<ModuleType> repository)
             : base(mapper, repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
    }
}
