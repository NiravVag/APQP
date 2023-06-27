// <copyright file="DocumentTypeController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers.Setup.DocumentType
{
    using MESHWorksAPQP.Management.Command.Setup.DocumentType;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class DocumentTypeController.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Controllers.Setup.SetupController{MESHWorksAPQP.Management.Command.Setup.DocumentType.SearchDocumentTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.DocumentType.DocumentTypeListVM, MESHWorksAPQP.Management.ViewModel.FilterVM, MESHWorksAPQP.Management.Command.Setup.DocumentType.GetDocumentTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.DocumentType.DocumentTypeVM, MESHWorksAPQP.Management.Command.Setup.DocumentType.SaveDocumentTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.DocumentType.DocumentTypeVM, MESHWorksAPQP.Management.Command.Setup.DocumentType.DeleteDocumentTypeCommand}" />
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : SetupController<SearchDocumentTypeCommand, SetupListVM, SetupFilterVM, GetDocumentTypeCommand, SetupVM, SaveDocumentTypeCommand, SetupVM, DeleteDocumentTypeCommand>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTypeController"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public DocumentTypeController(IHandlerFactory handler)
            : base(handler)
        {
            this.handler = handler;
        }
    }
}
