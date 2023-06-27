// <copyright file="IBlobStorageProvider.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace StorageManager.Interface.Providers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface IBlobStorageProvider.
    /// </summary>
    public interface IBlobStorageProvider
    {
        /// <summary>
        /// Gets the document stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Stream.</returns>
        Task<Stream> GetDocumentStream(string fileName);

        /// <summary>
        /// Gets the document bytes.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>bytes.</returns>
        Task<byte[]> GetDocumentBytes(string fileName);

        /// <summary>
        /// Saves the document.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileContents">The file contents.</param>
        /// <returns>Task.</returns>
        Task SaveDocument(string fileName, byte[] fileContents);

        /// <summary>
        /// Removes the document.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Task.</returns>
        Task RemoveDocument(string fileName);

        /// <summary>
        /// Documents the exists.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>bool.</returns>
        Task<bool> DocumentExists(string fileName);

        /// <summary>
        /// Clones the document.
        /// </summary>
        /// <param name="sourceFileName">Name of the source file.</param>
        /// <param name="destinationFileName">Name of the destination file.</param>
        /// <returns>Task.</returns>
        Task CloneDocument(string sourceFileName, string destinationFileName);
    }
}
