// <copyright file="CommodityController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>
namespace MESHWorksAPQP.Controllers.Setup.Commodity
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.Setup.Commodity;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class CommodityController.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Controllers.Setup.SetupController{MESHWorksAPQP.Management.Command.Setup.Commodity.SearchCommodityCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM, MESHWorksAPQP.Management.ViewModel.FilterVM, MESHWorksAPQP.Management.Command.Setup.Commodity.GetCommodityCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.Commodity.SaveCommodityCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.Commodity.DeleteCommodityCommand}" />
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : SetupController<SearchCommodityCommand, SetupListVM, SetupFilterVM, GetCommodityCommand, SetupVM, SaveCommodityCommand, SetupVM, DeleteCommodityCommand>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommodityController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public CommodityController(IHandlerFactory handler)
            : base(handler)
        {
            this.handler = handler;
        }
    }
}
