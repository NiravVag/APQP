// <copyright file="ServiceCollectionExtensions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Repository;
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
        public static Container RegisterRepositoryService(this Container container, IConfiguration configuration)
        {
            var assembly = typeof(GenericRepository<>).Assembly;
            RegisterContainers(container, assembly, "MESHWorksAPQP.Repository.Repository.Setup");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Repository.Repository.Part");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Repository.Repository.Document");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Repository.Repository.CustomField");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Repository.Repository.APQPTemplate");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Repository.Repository.APQP");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Repository.Repository.EmailEntity");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Repository.Repository.Role");
            RegisterContainers(container, assembly, "MESHWorksAPQP.Repository.Repository.User");

            container.Register(typeof(ISetupRepositoty<>), typeof(SetupRepositoty<>));
            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));
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
                                    select new { Service = type.GetInterfaces().LastOrDefault(), Implementation = type };

                foreach (var reg in registrations)
                {
                    container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
                }
            }
        }
    }
}
