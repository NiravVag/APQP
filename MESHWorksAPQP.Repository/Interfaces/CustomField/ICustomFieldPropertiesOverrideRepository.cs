// <copyright file="ICustomFieldPropertiesOverrideRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.CustomField
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Repository.CustomModel.CustomField;

    /// <summary>
    /// Interface ICustomFieldPropertiesOverrideRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.IGenericRepository{MESHWorksAPQP.Model.Models.CustomField.CustomFieldPropertiesOverride}" />
    public interface ICustomFieldPropertiesOverrideRepository : IGenericRepository<CustomFieldPropertiesOverride>
    {
        /// <summary>
        /// Gets the custom field properties override.
        /// </summary>
        /// <param name="apqpTemplateId">The apqp template identifier.</param>
        /// <param name="gateId">The gate identifier.</param>
        /// <param name="customFieldId">The custom field identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>The CustomFieldPropertiesOverrideCM.</returns>
        Task<CustomFieldPropertiesOverrideCM> GetCustomFieldPropertiesOverride(Guid apqpTemplateId, Guid gateId, Guid customFieldId, Guid? companyId);
    }
}
