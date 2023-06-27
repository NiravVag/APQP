// <copyright file="CustomFieldRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.CustomField
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel.CustomField;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.CustomField;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Interface ICustomFieldRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.GenericRepository{MESHWorksAPQP.Model.Models.CustomField.CustomField}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.CustomField.ICustomFieldRepository"/>
    public class CustomFieldRepository : GenericRepository<CustomField>, ICustomFieldRepository
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
        /// Initializes a new instance of the <see cref="CustomFieldRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public CustomFieldRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the custom fields.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="searchText">The search text.</param>
        /// <param name="isDeleted">if set to <c>true</c> [is deleted].</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortBy">Sort the page by column.</param>
        /// <param name="sortOrder">Sort the page by order.</param>
        /// <returns>List of CustomFieldListCM.</returns>
        public async Task<(IList<CustomFieldListCM>, int totalRecord)> GetCustomFields(Guid companyId, string searchText, bool isDeleted, int pageNumber, int pageSize, string sortBy, string sortOrder)
        {
            DbParameter dbTotalRecords = null;
            IList<CustomFieldListCM> customFieldDetails = null;

            await this.dbContext.LoadStoredProc("CustomField.GetCustomFields")
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
                   customFieldDetails = handler.ReadToList<CustomFieldListCM>();
               });

            return (customFieldDetails, (int)dbTotalRecords?.Value);
        }

        /// <summary>
        /// Gets the active custom fields.
        /// </summary>
        /// <param name="companyId">
        /// The company identifier.
        /// </param>
        /// <param name="apqpTemplateId">
        /// The APQP Template identifier.
        /// </param>
        /// <returns>
        /// List of CustomFieldCM.
        /// </returns>
        public async Task<IList<CustomFieldCM>> GetActiveCustomFields(Guid? companyId, Guid? apqpTemplateId)
        {
            IList<CustomFieldCM> activeCustomFields = null;
            IList<FormCustomFieldAnswerOptionCM> customFieldAnswerOptions = null;
            IList<CustomFieldPropertiesOverrideCM> customFieldPropertiesOverrides = null;

            await this.dbContext.LoadStoredProc("[CustomField].[GetActiveCustomFields]")
               .WithSqlParam("CompanyId", companyId)
               .WithSqlParam("APQPTemplateId", apqpTemplateId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   activeCustomFields = handler.ReadToList<CustomFieldCM>();
                   handler.NextResult();
                   customFieldAnswerOptions = handler.ReadToList<FormCustomFieldAnswerOptionCM>();
                   handler.NextResult();
                   customFieldPropertiesOverrides = handler.ReadToList<CustomFieldPropertiesOverrideCM>();
                   handler.NextResult();
               });

            if (activeCustomFields != null && activeCustomFields.Any() && ((customFieldAnswerOptions != null && customFieldAnswerOptions.Any()) || (customFieldPropertiesOverrides != null && customFieldPropertiesOverrides.Any())))
            {
                foreach (var activeCustomField in activeCustomFields)
                {
                    activeCustomField.AnswerOptions = customFieldAnswerOptions?.Where(x => x.CustomFieldId == activeCustomField.Id)?.ToList();
                    activeCustomField.CustomFieldPropertiesOverride = customFieldPropertiesOverrides?.FirstOrDefault(x => x.CustomFieldId == activeCustomField.Id);
                }
            }

            return activeCustomFields;
        }
    }
}
