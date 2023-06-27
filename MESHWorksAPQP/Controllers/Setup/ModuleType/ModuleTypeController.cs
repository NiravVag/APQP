// <copyright file="ModuleTypeController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup.ModuleType
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.Setup.ModuleType;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class ModuleTypeController.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Controllers.Setup.SetupController{MESHWorksAPQP.Management.Command.Setup.ModuleType.SearchModuleTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM, MESHWorksAPQP.Management.ViewModel.FilterVM, MESHWorksAPQP.Management.Command.Setup.ModuleType.GetModuleTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.ModuleType.SaveModuleTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.ModuleType.DeleteModuleTypeCommand}" />
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleTypeController : SetupController<SearchModuleTypeCommand, SetupListVM, FilterVM, GetModuleTypeCommand, SetupVM, SaveModuleTypeCommand, SetupVM, DeleteModuleTypeCommand>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleTypeController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public ModuleTypeController(IHandlerFactory handler)
            : base(handler)
        {
            this.handler = handler;
        }
    }
}
