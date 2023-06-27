// <copyright file="AttachmentController.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Document;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.Interface.Managers.Document;
    using MESHWorksAPQP.Management.ViewModel.Document;
    using MESHWorksAPQP.Shared.Enum;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;

    /// <summary>
    /// Class AttachmentController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [Route("api/[controller]/{companyId:guid}")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IDocumentAttachmentManager manager;

        /// <summary>
        /// The handler.
        /// </summary>
        private readonly IHandlerFactory handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentController" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="handler">The handler.</param>
        public AttachmentController(IDocumentAttachmentManager manager, IHandlerFactory handler)
        {
            this.manager = manager;
            this.handler = handler;
        }

        /// <summary>
        /// Uploads the files.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="documenType">Type of the documen.</param>
        /// <param name="documentTypeId">The document type identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="referanceId">The referance identifier.</param>
        /// <returns>IActionResult</returns>
        [HttpPost("Upload/{DocumenType}")]
        [HttpPost("Upload/{apqpId:guid}/{DocumenType}")]
        [HttpPost("Upload/{DocumenType}/{entityId:guid}")]
        [HttpPost("Upload/{DocumenType}/{documentTypeId:Guid}/{entityId:guid}")]
        [HttpPost("Upload/{apqpId:guid}/{DocumenType}/{documentTypeId:Guid}/{entityId:guid}/{referanceId:guid}")]
        [HttpPost("Upload/{apqpId:guid}/{DocumenType}/{documentTypeId:Guid}/{entityId:guid}")]
        [RequestFormLimits(MultipartBodyLengthLimit = 504857600)]
        public async Task<IActionResult> UploadFiles(Guid? companyId, Guid? apqpId, DocumenType documenType, Guid documentTypeId, Guid? entityId, Guid? referanceId)
        {
            IFormFile file = Request.Form.Files[0];
            if (file == null)
            {
                return this.BadRequest("No file provided");
            }

            var attachment = new UploadAttachmentVM()
            {
                File = file,
                AttachmentType = documenType,
                EntityId = entityId,
                DocumenTypeId = documentTypeId,
                APQPId = apqpId,
                ReferanceId = referanceId
            };

            var command = new UploadAttachmentCommand()
            {
                Entity = attachment,
                CompanyId = companyId,
                APQPId = apqpId
            };

            await this.handler.Execute(command);

            return this.Ok(command.Result);
        }

        /// <summary>
        /// Downloads the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// IActionResult.
        /// </returns>
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.manager.Delete(id);
            return this.Ok();
        }

        /// <summary>
        /// Downloads the specified identifier.
        /// </summary>
        /// <param name="documenType">Type of the document attachment.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// File.
        /// </returns>
        [Route("DownloadFile/{DocumenType}/{id}")]
        [HttpGet]
        public async Task<FileResult> Download(DocumenType documenType, Guid id)
        {
            var file = await this.manager.DownloadAttachment(documenType, id);
            return this.File(file.FileContent, file.ContentType, file.FileName);
        }

        /// <summary>
        /// Gets the form values.
        /// </summary>
        /// <returns>The form values.</returns>
        private Dictionary<string, string> GetFormValues(IFormCollection formCollection)
        {
            var formValues = new Dictionary<string, string>();
            foreach (var key in formCollection.Keys)
            {
                this.Request.Form.TryGetValue(key, out StringValues value);
                formValues.Add(key, value.First());
            }

            return formValues;
        }
    }
}
