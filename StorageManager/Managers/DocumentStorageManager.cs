// <copyright file="DocumentStorageManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace StorageManager.Managers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using StorageManager.Interface;
    using StorageManager.Interface.Providers;

    /// <summary>
    /// Class DocumentStorageManager.
    /// </summary>
    /// <seealso cref="StorageManager.Interface.IDocumentStorageManager" />
    public class DocumentStorageManager : IDocumentStorageManager
    {
        /// <summary>
        /// The BLOB storage provider.
        /// </summary>
        private readonly IBlobStorageProvider blobStorageProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentStorageManager"/> class.
        /// </summary>
        /// <param name="blobStorageProvider">The BLOB storage provider.</param>
        public DocumentStorageManager(IBlobStorageProvider blobStorageProvider)
        {
            this.blobStorageProvider = blobStorageProvider;
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
                return await this.blobStorageProvider.DocumentExists(fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the document bytes.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// bytes.
        /// </returns>
        public async Task<byte[]> GetDocumentBytes(string fileName)
        {
            try
            {
                return await this.blobStorageProvider.GetDocumentBytes(fileName);
            }
            catch (Exception)
            {
                throw;
            }
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
                return await this.blobStorageProvider.GetDocumentStream(fileName);
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
                if (await this.blobStorageProvider.DocumentExists(fileName))
                {
                    await this.blobStorageProvider.RemoveDocument(fileName);
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
                if (fileContents != null && fileContents.Length > 0)
                {
                    await this.blobStorageProvider.SaveDocument(fileName, fileContents);
                }
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
        /// <returns>Task.</returns>
        public async Task CloneDocument(string sourceFileName, string destinationFileName)
        {
            try
            {
                await this.blobStorageProvider.CloneDocument(sourceFileName, destinationFileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
