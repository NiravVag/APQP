// <copyright file="PageTypeController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup.PageType
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.Setup.PageType;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.PageType;
    using MESHWorksAPQP.Shared.Enum;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class The PageTypeController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class PageTypeController : SetupController<SearchPageTypeCommand, SetupListVM, PageTypeFilterVM, GetPageTypeCommand, SetupVM, SavePageTypeCommand, PageTypeVM, DeletePageTypeCommand>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageTypeController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public PageTypeController(IHandlerFactory handler)
            : base(handler)
        {
            this.handler = handler;
        }
    }
}
