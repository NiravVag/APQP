// <copyright file="MaterialTypeController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup.MaterialType
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.Setup.MaterialType;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Shared.Enum;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class The MaterialTypeController.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Controllers.Setup.SetupController{MESHWorksAPQP.Management.Command.Setup.MaterialType.SearchMaterialTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM, MESHWorksAPQP.Management.ViewModel.Setup.MaterialFilterVM, MESHWorksAPQP.Management.Command.Setup.MaterialType.GetMaterialTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.MaterialType.SaveMaterialTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.MaterialType.DeleteMaterialTypeCommand}" />
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypeController : SetupController<SearchMaterialTypeCommand, SetupListVM, MaterialFilterVM, GetMaterialTypeCommand, MaterialVM, SaveMaterialTypeCommand, MaterialVM, DeleteMaterialTypeCommand>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialTypeController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public MaterialTypeController(IHandlerFactory handler)
            : base(handler)
        {
            this.handler = handler;
        }
    }
}
