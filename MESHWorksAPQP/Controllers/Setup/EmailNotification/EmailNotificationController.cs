// <copyright file="EmailNotificationController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup.EmailNotification
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Attributes;
    using MESHWorksAPQP.Management.Command.Setup.EmailNotification;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class EmailNotificationController.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Controllers.Setup.SetupController{MESHWorksAPQP.Management.Command.Setup.EmailNotification.SearchEmailNotificationCommand, MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification.EmailNotificationListVM, MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification.EmailNotificationFilterVM, MESHWorksAPQP.Management.Command.Setup.EmailNotification.GetEmailNotificationCommand, MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification.EmailNotificationVM, MESHWorksAPQP.Management.Command.Setup.EmailNotification.SaveEmailNotificationCommand, MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification.EmailNotificationVM, MESHWorksAPQP.Management.Command.Setup.EmailNotification.DeleteEmailNotificationCommand}" />
    [Route("api/[controller]")]
    [ApiController]
    public class EmailNotificationController : SetupController<SearchEmailNotificationCommand, EmailNotificationListVM, EmailNotificationFilterVM, GetEmailNotificationCommand, EmailNotificationVM, SaveEmailNotificationCommand, EmailNotificationVM, DeleteEmailNotificationCommand>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificationController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public EmailNotificationController(IHandlerFactory handler)
            : base(handler)
        {
            this.handler = handler;
        }
    }
}
