// <copyright file="ServiceCollectionExtensions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Extensions
{
    using System.Linq;
    using System.Reflection;
    using MESHWorksAPQP.Management.Factories;
    using MESHWorksAPQP.Management.Handlers;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.Interface.Handlers;
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
        public static Container RegisterManagementService(this Container container, IConfiguration configuration)
        {
            var assembly = typeof(HandlerFactory).Assembly;

            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.Commodity");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.Designation");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.Process");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Lookup");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Part");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Document");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Providers");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.APQP");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.CustomField");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Custom");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.MaterialType");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.Role");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.DocumentType");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.ModuleType");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.EmailNotification");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.PageType");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.User");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Role");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Commands.User");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Scheduler");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Activity");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Management.Managers.Setup.UserManagement");

            container.Register(typeof(ICommandHandler<>), new[] { assembly });
            container.Register(typeof(ICommandResponseHandler<,>), typeof(CommandResponseHandler<,,>));
            container.Register(typeof(IHandlerFactory), typeof(HandlerFactory));

            return container;
        }

        /// <summary>
        /// Registers the containers.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="nameSpace">The name space.</param>
        private static void RegisterContainers(Container container, Assembly assembly, string nameSpace)
        {
            if (assembly != null)
            {
                var registrations = from type in assembly.GetExportedTypes()
                                    where type.Namespace == nameSpace
                                    where type.GetInterfaces().Any()
                                    select new { Service = type.GetInterfaces().First(), Implementation = type };

                foreach (var reg in registrations)
                {
                    container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
                }
            }
        }
    }
}
