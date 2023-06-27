// <copyright file="APQPRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.APQP
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.APQP;
    using MESHWorksAPQP.Shared.Interface;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Interface APQPRepository.
    /// </summary>
    public class APQPRepository : GenericRepository<APQP>, IAPQPRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// The user identity.
        /// </summary>

        private readonly IUserIdentity userIdentity;
        /// <summary>
        /// Initializes a new instance of the <see cref="APQPRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public APQPRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the apqp data.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>APQPDataCM./returns>
        public async Task<APQPDataCM> GetAPQPData(Guid id)
        {
            IList<APQPDataCM> predefinedFieldAnswers = null;
            IList<CustomFieldAnswerCM> customFieldAnswers = null;
            await this.dbContext.LoadStoredProc("[APQP].[GetAPQPdata]")
               .WithSqlParam("id", id)
               .ExecuteStoredProcAsync((handler) =>
               {
                   predefinedFieldAnswers = handler.ReadToList<APQPDataCM>();
                   handler.NextResult();
                   customFieldAnswers = handler.ReadToList<CustomFieldAnswerCM>();
               });

            var apqpData = new APQPDataCM();

            if (predefinedFieldAnswers != null && predefinedFieldAnswers.Any())
            {
                apqpData = predefinedFieldAnswers.FirstOrDefault();
            }

            if (customFieldAnswers != null)
            {
                apqpData.CustomFieldAnswers = customFieldAnswers.ToList();
            }

            return apqpData;
        }

        /// <summary>
        /// Gets the custom fields.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <returns>
        /// APQPCM.
        /// </returns>
        public async Task<APQPCM> GetAPQPTemplateDeatils(Guid apqpId)
        {
            APQPCM apqpTemplateDeatails = new APQPCM();
            IList<APQPTemplateCM> apqpTemplate = null;
            IList<PartCM> part = null;
            IList<APQPProjectCM> apqpProject = null;
            IList<GateClosureCM> gateClosures = null;
            IList<GateCM> gates = null;
            IList<CustomFieldCM> customFields = null;
            IList<CustomFieldAnswerOptionCM> answerOptions = null;
            IList<FieldAnswerOptionsBindingCM> fieldAnswerOptionsBinding = null;
            await this.dbContext.LoadStoredProc("[APQP].[GetAPQPTemplateDetails]")
               .WithSqlParam("apqpId", apqpId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   apqpProject = handler.ReadToList<APQPProjectCM>();
                   handler.NextResult();
                   apqpTemplate = handler.ReadToList<APQPTemplateCM>();
                   handler.NextResult();
                   part = handler.ReadToList<PartCM>();
                   handler.NextResult();
                   gates = handler.ReadToList<GateCM>();
                   handler.NextResult();
                   gateClosures = handler.ReadToList<GateClosureCM>();
                   handler.NextResult();
                   customFields = handler.ReadToList<CustomFieldCM>();
                   handler.NextResult();
                   answerOptions = handler.ReadToList<CustomFieldAnswerOptionCM>();
                   handler.NextResult();
                   fieldAnswerOptionsBinding = handler.ReadToList<FieldAnswerOptionsBindingCM>();
               });

            if (apqpProject != null)
            {
                apqpTemplateDeatails.APQPProject = apqpProject.FirstOrDefault();
                apqpTemplateDeatails.APQPTemplate = apqpTemplate.FirstOrDefault();
                apqpTemplateDeatails.Part = part.FirstOrDefault();
                apqpTemplateDeatails.APQPTemplate.Gates = gates.ToList();

                if (apqpTemplateDeatails?.APQPTemplate?.Gates != null && apqpTemplateDeatails.APQPTemplate.Gates.Any())
                {
                    foreach (var gate in apqpTemplateDeatails.APQPTemplate.Gates)
                    {
                        gate.GateClosures = gateClosures.Where(x => x.GateId == gate.Id)?.ToList();
                        gate.CustomFields = customFields.Where(x => x.GateId == gate.Id)?.ToList();

                        if (gate.CustomFields != null && gate.CustomFields.Any())
                        {
                            foreach (var cField in gate.CustomFields)
                            {
                                cField.AnswerOptions = answerOptions.Where(x => x.GateId == gate.Id && x.CustomFieldId == cField.Id)?.ToList();
                                cField.Bindingfunction = fieldAnswerOptionsBinding.FirstOrDefault(x => x.Id == cField.FieldAnswerOptionsBindingId)?.Bindingfunction;
                            }
                        }
                    }
                }

                return apqpTemplateDeatails;
            }

            return null;
        }

        /// <summary>
        /// Saves the apqp template deatils.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="gateId">The gateId identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="customFieldsDataJson">The custom fields data json.</param>
        /// <returns>Task.</returns>
        public async Task SaveAPQPTemplateDeatils(Guid companyId, Guid gateId, Guid entityId, string customFieldsDataJson)
        {
            await this.dbContext.LoadStoredProc("[APQP].[SaveGateFieldsData]")
               .WithSqlParam("CompanyId", companyId)
               .WithSqlParam("GateId", gateId)
               .WithSqlParam("EntityId", entityId)
               .WithSqlParam("CustomFieldAnswersJson", customFieldsDataJson)
               .ExecuteStoredNonQueryAsync();
        }

        /// <summary>
        /// Gets the apqp discussions.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>
        /// List of APQPDiscussionCM.
        /// </returns>
        public async Task<IList<APQPDiscussionCM>> GetAPQPDiscussions(Guid apqpId, Guid companyId)
        {
            IList<APQPDiscussionCM> discussions = null;
            IList<AttachmentDetailVM> attachments = null;

            await this.dbContext.LoadStoredProc("[APQP].[GetAPQPDiscussions]")
               .WithSqlParam("APQPId", apqpId)
               .WithSqlParam("CompanyId", companyId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   discussions = handler.ReadToList<APQPDiscussionCM>();
                   handler.NextResult();
                   attachments = handler.ReadToList<AttachmentDetailVM>();
                   handler.NextResult();
               });

            if (discussions != null && discussions.Any() && attachments != null && attachments.Any())
            {
                foreach (var discussion in discussions)
                {
                    discussion.Attachments = attachments.Where(x => x.EntityId == discussion.Id).ToList();
                }
            }

            return discussions;
        }

        /// <summary>
        /// Gets the apqp documents.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="searchText">The search text.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <returns>
        /// List of GetAPQPPartDocuments.
        /// </returns>
        public async Task<(IList<APQPPartDocumentCM>, int totalRecord)> GetAPQPDocuments(Guid apqpId, string searchText, int pageNumber, int pageSize, string sortBy, string sortOrder)
        {
            DbParameter dbTotalRecords = null;
            IList<APQPPartDocumentCM> apqpDocument = null;
            await this.dbContext.LoadStoredProc("[APQP].[GetAPQPDocuments]")
               .WithSqlParam("APQPTemplateId", apqpId)
               .WithSqlParam("SearchText", searchText)
               .WithSqlParam("PageNumber", pageNumber)
               .WithSqlParam("PageSize", pageSize)
               .WithSqlParam("SortBy", sortBy)
               .WithSqlParam("SortOrder", sortOrder)
               .WithSqlParam("TotalRecords", (dbParam) =>
               {
                   dbParam.Direction = System.Data.ParameterDirection.Output;
                   dbParam.DbType = System.Data.DbType.Int32;
                   dbTotalRecords = dbParam;
               })
               .ExecuteStoredProcAsync((handler) =>
               {
                   apqpDocument = handler.ReadToList<APQPPartDocumentCM>();
                   handler.NextResult();
               });
            return (apqpDocument, (int)dbTotalRecords?.Value);
        }
    }
}
