// <copyright file="ServiceCollectionExtensions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace StorageManager.Extensions
{
    using Microsoft.Extensions.Configuration;
    using SimpleInjector;
    using StorageManager.Interface;
    using StorageManager.Interface.Providers;
    using StorageManager.Interface.Settings;
    using StorageManager.Managers;
    using StorageManager.Providers;
    using StorageManager.Settings;

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
        public static Container RegisterStorageManagerService(this Container container, IConfiguration configuration)
        {
            container.RegisterInstance<IBlobStoreageSettings>(configuration.GetSection("AppSettings:BlobStorage").Get<BlobStoreageSettings>());
            container.Register<IDocumentStorageManager, DocumentStorageManager>();
            container.Register<IBlobStorageProvider, BlobStorageProvider>();

            return container;
        }
    }
}
