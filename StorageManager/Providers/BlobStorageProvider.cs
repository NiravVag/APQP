// <copyright file="BlobStorageProvider.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace StorageManager.Providers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;
    using StorageManager.Interface.Providers;
    using StorageManager.Interface.Settings;

    /// <summary>
    /// Class BlobStorageProvider.
    /// </summary>
    public class BlobStorageProvider : IBlobStorageProvider
    {
        /// <summary>
        /// The BLOB service client.
        /// </summary>
        private readonly BlobServiceClient blobServiceClient;

        /// <summary>
        /// The BLOB storeage settings.
        /// </summary>
        private readonly IBlobStoreageSettings blobStoreageSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobStorageProvider"/> class.
        /// </summary>
        /// <param name="blobStoreageSettings">The BLOB storeage settings.</param>
        public BlobStorageProvider(IBlobStoreageSettings blobStoreageSettings)
        {
            this.blobStoreageSettings = blobStoreageSettings;

            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={blobStoreageSettings.AccountName};AccountKey={blobStoreageSettings.AccountKey};EndpointSuffix=core.windows.net";
            this.blobServiceClient = new BlobServiceClient(connectionString);
        }

        /// <summary>
        /// Gets the document stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// Stream.
        /// </returns>
        public async Task<Stream> GetDocumentStream(string fileName)
        {
            try
            {
                BlobContainerClient containerClient = this.blobServiceClient.GetBlobContainerClient(this.blobStoreageSettings.ContainerName);
                containerClient.GetBlobClient(fileName);

                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                if (await blobClient.ExistsAsync())
                {
                    var memoryStream = new MemoryStream();
                    await blobClient.DownloadToAsync(memoryStream);
                    memoryStream.Position = 0;
                    return memoryStream;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        /// <summary>
        /// Gets the document bytes.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>bytes.</returns>
        public async Task<byte[]> GetDocumentBytes(string fileName)
        {
            try
            {
                using (var fileStream = await this.GetDocumentStream(fileName))
                {
                    return ((MemoryStream)fileStream).ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Saves the document.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileContents">The file contents.</param>
        /// <returns>Task.</returns>
        public async Task SaveDocument(string fileName, byte[] fileContents)
        {
            try
            {
                using (var stream = new MemoryStream(fileContents))
                {
                    BlobContainerClient containerClient = this.blobServiceClient.GetBlobContainerClient(this.blobStoreageSettings.ContainerName);
                    BlobClient blobClient = containerClient.GetBlobClient(fileName);
                    await blobClient.UploadAsync(stream, true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Removes the document.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Task.</returns>
        public async Task RemoveDocument(string fileName)
        {
            try
            {
                BlobContainerClient containerClient = this.blobServiceClient.GetBlobContainerClient(this.blobStoreageSettings.ContainerName);
                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                await blobClient.DeleteIfExistsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Documents the exists.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// bool.
        /// </returns>
        public async Task<bool> DocumentExists(string fileName)
        {
            try
            {
                BlobContainerClient containerClient = this.blobServiceClient.GetBlobContainerClient(this.blobStoreageSettings.ContainerName);
                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                return await blobClient.ExistsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Clones the document.
        /// </summary>
        /// <param name="sourceFileName">Name of the source file.</param>
        /// <param name="destinationFileName">Name of the destination file.</param>
        /// <returns>Task</returns>
        public async Task CloneDocument(string sourceFileName, string destinationFileName)
        {
            try
            {
                BlobContainerClient containerClient = this.blobServiceClient.GetBlobContainerClient(this.blobStoreageSettings.ContainerName);
                BlobClient blobClient = containerClient.GetBlobClient(sourceFileName);

                BlobClient copyBlockBlob = containerClient.GetBlobClient(destinationFileName);
                await copyBlockBlob.StartCopyFromUriAsync(blobClient.Uri);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
