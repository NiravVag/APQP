// <copyright file="DesignationController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup.Designation
{
    using MESHWorksAPQP.Management.Command.Setup.Designation;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class DesignationController.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Controllers.Setup.SetupController&lt;MESHWorksAPQP.Management.Command.Setup.Designation.SearchDesignationCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM, MESHWorksAPQP.Management.ViewModel.Setup.SetupFilterVM, MESHWorksAPQP.Management.Command.Setup.Designation.GetDesignationCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.Designation.SaveDesignationCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.Designation.DeleteDesignationCommand&gt;" />
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : SetupController<SearchDesignationCommand, SetupListVM, SetupFilterVM, GetDesignationCommand, SetupVM, SaveDesignationCommand, SetupVM, DeleteDesignationCommand>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DesignationController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public DesignationController(IHandlerFactory handler)
            : base(handler)
        {
            this.handler = handler;
        }
    }
}
