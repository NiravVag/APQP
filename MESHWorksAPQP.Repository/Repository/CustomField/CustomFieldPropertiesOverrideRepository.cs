// <copyright file="CustomFieldPropertiesOverrideRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.CustomField
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel.CustomField;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.CustomField;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class CustomFieldPropertiesOverrideRepositor.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.GenericRepository{MESHWorksAPQP.Model.Models.CustomField.CustomFieldPropertiesOverride}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.CustomField.ICustomFieldPropertiesOverrideRepository" />
    public class CustomFieldPropertiesOverrideRepository : GenericRepository<CustomFieldPropertiesOverride>, ICustomFieldPropertiesOverrideRepository
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
        /// Initializes a new instance of the <see cref="CustomFieldPropertiesOverrideRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public CustomFieldPropertiesOverrideRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the custom field properties override.
        /// </summary>
        /// <param name="apqpTemplateId">The apqp template identifier.</param>
        /// <param name="gateId">The gate identifier.</param>
        /// <param name="customFieldId">The custom field identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The CustomFieldPropertiesOverrideCM.
        /// </returns>
        public async Task<CustomFieldPropertiesOverrideCM> GetCustomFieldPropertiesOverride(Guid apqpTemplateId, Guid gateId, Guid customFieldId, Guid? companyId)
        {
            IList<CustomFieldPropertiesOverrideCM> customFieldPropertiesOverrides = null;

            await this.dbContext.LoadStoredProc("[CustomField].[GetCustomFieldPropertiesOverride]")
               .WithSqlParam("CompanyId", companyId)
               .WithSqlParam("APQPTemplateId", apqpTemplateId)
               .WithSqlParam("GateId", gateId)
               .WithSqlParam("CustomFieldId", customFieldId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   customFieldPropertiesOverrides = handler.ReadToList<CustomFieldPropertiesOverrideCM>();
                   handler.NextResult();
               });

            if (customFieldPropertiesOverrides != null && customFieldPropertiesOverrides.Any())
            {
                CustomFieldPropertiesOverrideCM customFieldPropertiesOverride = customFieldPropertiesOverrides.FirstOrDefault();
                return customFieldPropertiesOverride;
            }

            return null;
        }
    }
}
