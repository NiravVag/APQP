// <copyright file="ServiceCollectionExtensions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using EmailProvider.Interface.Managers;
    using EmailProvider.Interface.Providers;
    using EmailProvider.Interface.Settings;
    using EmailProvider.Managers;
    using EmailProvider.Providers;
    using EmailProvider.Settings;
    using Microsoft.Extensions.Configuration;
    using SimpleInjector;

    /// <summary>
    /// Class ServiceCollectionExtensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the service.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Container.</returns>
        public static Container RegisterEmailProviderService(this Container container, IConfiguration configuration)
        {
            container.Register<IEmailManager, EmailManager>();
            container.Register<IMailKitProvider, MailKitProvider>();
            container.RegisterInstance<ISmtpSetting>(configuration.GetSection("AppSettings:SmtpSetting").Get<SmtpSetting>());

            return container;
        }
    }
}
