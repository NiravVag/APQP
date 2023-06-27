// <copyright file="ProcessController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup.Process
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.Setup.Process;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.Process;
    using MESHWorksAPQP.Shared.Enum;
    using MESHWorksAPQP.Shared.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class The ProcessController.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Controllers.Setup.SetupController{MESHWorksAPQP.Management.Command.Setup.Process.SearchProcessCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM, MESHWorksAPQP.Management.ViewModel.Setup.Process.ProcessFilterVM, MESHWorksAPQP.Management.Command.Setup.Process.GetProcessCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.Process.SaveProcessCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.Process.DeleteProcessCommand}" />
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController: SetupController<SearchProcessCommand, SetupListVM, ProcessFilterVM, GetProcessCommand, SetupVM, SaveProcessCommand, SetupVM, DeleteProcessCommand>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public ProcessController(IHandlerFactory handler)
            : base(handler)
        {
            this.handler = handler;
        }
    }
}
