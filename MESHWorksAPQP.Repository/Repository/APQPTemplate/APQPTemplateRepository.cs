// <copyright file="APQPTemplateRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.APQPTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using MESHWorksAPQP.Repository.CustomModel.APQPTemplate;
    using MESHWorksAPQP.Repository.CustomModel.Gate;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.APQPTemplate;
    using MESHWorksAPQP.Shared.Interface;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Class APQPTemplateRepository.
    /// </summary>
    public class APQPTemplateRepository : GenericRepository<APQPTemplate>, IAPQPTemplateRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="APQPTemplateRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public APQPTemplateRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
            this.dbContext = dbContext;
        }

        /// <summary>Creates the apqp template.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="dtGates">The dt gates.</param>
        public async void CreateAPQPTemplate(APQP entity, DataTable dtGates)
        {
            await this.dbContext.LoadStoredProc("[APQP].[SaveAPQPTemplate]")
                  .WithSqlParam("Id", entity.APQPTemplateId)
                   .WithSqlParam("Name", entity.APQPTemplate.Name)
                  .WithSqlParam("Description", entity.APQPTemplate.Description)
                  .WithSqlParam("CompanyId", entity.APQPTemplate.CompanyId)
                  .WithSqlParam("Created", entity.APQPTemplate.Created)
                  .WithSqlParam("CreatedBy", "System")
                  .WithSqlParam("IsDeleted", "false")
                  .WithSqlParam("GateTable", dtGates)
                  .ExecuteStoredNonQueryAsync();

            // await this.dbContext.LoadStoredProc("[APQP].[SaveAPQPGate]")
            //                 .WithSqlParam("GateTable", dtGates)
            //                 .ExecuteStoredNonQueryAsync();
        }

        /// <summary>Updates the apqp template.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="dtGates">The dt gates.</param>
        /// <param name="removeGateIds">The remove gate ids.</param>
        /// <param name="dtNewGateIds">The dt new gate ids.</param>
        public async void UpdateAPQPTemplate(APQP entity, DataTable dtGates, DataTable removeGateIds, DataTable dtNewGateIds)
        {
            await this.dbContext.LoadStoredProc("[APQP].[EditAPQPTemplate]")
                  .WithSqlParam("Id", entity.APQPTemplateId)
                   .WithSqlParam("Name", entity.APQPTemplate.Name.Trim())
                  .WithSqlParam("Description", entity.APQPTemplate.Description.Trim())
                  .WithSqlParam("GateTable", dtGates)
                  .WithSqlParam("List", removeGateIds)
                  .WithSqlParam("GateNewIds", dtNewGateIds)
                  .ExecuteStoredNonQueryAsync();
        }

        /// <summary>Gets the apqp template.</summary>
        /// <param name="partId">The part identifier.</param>
        /// <returns>
        ///   IList Of LookupVM
        /// </returns>
        public async Task<IList<LookupVM>> GetAPQPTemplate(Guid? partId)
        {
            IList<LookupVM> data = null;
            await this.dbContext.LoadStoredProc("[APQP].[GetAPQPTemplate]")
               .WithSqlParam("partId", partId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   data = handler.ReadToList<LookupVM>();
               });

            return data;
        }

        /// <summary>Gets the apqp templates.</summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="searchText">The search text.</param>
        /// <param name="isDeleted">if set to <c>true</c> [is deleted].</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <returns>
        ///  List of APQPTemplateListCM.
        /// </returns>
        public async Task<(IList<APQPTemplateListCM>, int totalRecord)> GetAPQPTemplates(Guid? companyId, string searchText, bool isDeleted, int pageNumber, int pageSize, string sortBy, string sortOrder)
        {
            DbParameter dbTotalRecords = null;
            IList<APQPTemplateListCM> apqpTemplates = null;

            await this.dbContext.LoadStoredProc("APQP.GetAPQPTemplates")
               .WithSqlParam("CompanyId", companyId)
               .WithSqlParam("SearchText", searchText)
               .WithSqlParam("IsDeleted", isDeleted)
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
                   apqpTemplates = handler.ReadToList<APQPTemplateListCM>();
                   handler.NextResult();
               });

            if (apqpTemplates != null && apqpTemplates.Any())
            {
                foreach (var apqpTemplate in apqpTemplates)
                {
                    apqpTemplate.IsAPQPExist = apqpTemplate.AssociatedParts > 0;
                }
            }

            return (apqpTemplates, (int)dbTotalRecords?.Value);
        }

        /// <summary>
        /// Clones the apqp template.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="apqpTemplateId">The apqp template identifier.</param>
        /// <param name="cloneAPQPTemplateId">The clone apqp template identifier.</param>
        /// <returns>Task.</returns>
        public async Task CloneAPQPTemplate(Guid? companyId, Guid userId, Guid apqpTemplateId, Guid cloneAPQPTemplateId)
        {
            await this.dbContext.LoadStoredProc("APQP.CloneAPQPTemplate")
               .WithSqlParam("CompanyId", companyId)
               .WithSqlParam("UserId", userId)
               .WithSqlParam("APQPTemplateId", apqpTemplateId)
               .WithSqlParam("CloneAPQPTemplateId", cloneAPQPTemplateId)
               .ExecuteStoredNonQueryAsync();
        }
    }
}
