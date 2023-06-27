// <copyright file="GetCustomFieldPropertiesOverride.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.CustomField
{
    /// <summary>
    /// Class GetCustomFieldPropertiesOverride.
    /// </summary>
    public class GetCustomFieldPropertiesOverride
    {
        /// <summary>
        /// The body
        /// </summary>
        public const string Body18052022 = @"CREATE OR ALTER PROCEDURE [CustomField].[GetCustomFieldPropertiesOverride]
				(
					@CompanyId UNIQUEIDENTIFIER = NULL
					,@APQPTemplateId UNIQUEIDENTIFIER
					,@CustomFieldId UNIQUEIDENTIFIER
					,@Id UNIQUEIDENTIFIER = NULL
				)
				AS
				BEGIN
					IF (@Id IS NOT NULL)
					BEGIN
						SELECT 
							[CFPO].[Id]
							,[CF].[Name] [CustomFieldName]
							,[CFPO].[APQPTemplateId]
							,[AT].[Name] [APQPTemplateName]
							,[CFPO].[CustomFieldId]
							,[CFPO].[Tooltip]
							,[CFPO].[IsRequired]
							,[CFPO].[ValidationRegex]
							,[CFPO].[ValidationMessage]
							,[CFPO].[DefaultValue]
							,[CFPO].[ParentFeildId]
							,[CFPO].[IsVisibleOnSelection]
							,[CFPO].[MinValue]
							,[CFPO].[MaxValue]
							,[CFPO].[MinDate]
							,[CFPO].[MaxDate]
							,[CFPO].[MinLength]
							,[CFPO].[MaxLength]
							,[CFPO].[IsMultiSelect]
						FROM [CustomField].[CustomField] [CF] 
						JOIN [CustomField].[CustomFieldPropertiesOverride] [CFPO]
							ON [CFPO].[CustomFieldId] = [CF].[Id]
						JOIN [APQP].[APQPTemplate] [AT]
							ON [CFPO].[APQPTemplateId] = [AT].[Id]
						WHERE [CFPO].[Id] = @Id AND [CF].[IsDeleted] = 0 AND [CFPO].[IsDeleted] = 0 AND [AT].[IsDeleted] = 0
					END
					ELSE 
					BEGIN
						SELECT 
							NULL [Id]
							,[CF].[Name] [CustomFieldName]
							,@APQPTemplateId [APQPTemplateId]
							,(
								SELECT 
									[AT].[Name] 
								FROM [APQP].[APQPTemplate] [AT]
								WHERE [AT].[Id] = @APQPTemplateId AND ([AT].[CompanyId] IS NULL OR [AT].[CompanyId] = @CompanyId AND [AT].[IsDeleted] = 0)
							) [APQPTemplateName]
							,[CF].[Id] [CustomFieldId]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[MinValue]
							,[CF].[MaxValue]
							,[CF].[MinDate]
							,[CF].[MaxDate]
							,[CF].[MinLength]
							,[CF].[MaxLength]
							,[CF].[IsMultiSelect]
						FROM [CustomField].[CustomField] [CF] 
						WHERE [CF].[Id] = @CustomFieldId AND [CF].[IsDeleted] = 0 
							AND ([CF].[CompanyId] IS NULL OR [CF].[CompanyId] = @CompanyId)
					END
				END";

        /// <summary>
        /// The body24052022
        /// </summary>
        public const string Body24052022 = @"CREATE OR ALTER PROCEDURE [CustomField].[GetCustomFieldPropertiesOverride]
					(
					@CompanyId UNIQUEIDENTIFIER = NULL
					,@APQPTemplateId UNIQUEIDENTIFIER
					,@GateId UNIQUEIDENTIFIER
					,@CustomFieldId UNIQUEIDENTIFIER
				)
				AS
				BEGIN
					DECLARE @Id UNIQUEIDENTIFIER;
					SELECT @Id = [Id] FROM [CustomField].[CustomFieldPropertiesOverride] WHERE [APQPTemplateId] = @APQPTemplateId AND [GateId] = @GateId AND [CustomFieldId] = @CustomFieldId AND [IsDeleted] = 0

					IF (@Id IS NOT NULL)
					BEGIN
						SELECT 
							[CFPO].[Id]
							,[CFPO].[APQPTemplateId]
							,[AT].[Name] [APQPTemplateName]
							,[CFPO].[GateId]
							,[G].[Name] [GateName]
							,[CFPO].[CustomFieldId]
							,[CF].[Name] [CustomFieldName]
							,[CF].[FieldType]
							,[CFPO].[Tooltip]
							,[CFPO].[IsRequired]
							,[CFPO].[ValidationRegex]
							,[CFPO].[ValidationMessage]
							,[CFPO].[DefaultValue]
							,[CFPO].[ParentFeildId]
							,[CFPO].[IsVisibleOnSelection]
							,[CFPO].[MinValue]
							,[CFPO].[MaxValue]
							,[CFPO].[MinDate]
							,[CFPO].[MaxDate]
							,[CFPO].[MinLength]
							,[CFPO].[MaxLength]
							,[CFPO].[IsMultiSelect]
						FROM [CustomField].[CustomField] [CF] 
						JOIN [CustomField].[CustomFieldPropertiesOverride] [CFPO]
							ON [CFPO].[CustomFieldId] = [CF].[Id]
						JOIN [APQP].[APQPTemplate] [AT]
							ON [CFPO].[APQPTemplateId] = [AT].[Id]
						JOIN [APQP].[Gate] [G]
							ON [CFPO].[GateId] = [G].[Id]
							AND [G].[APQPTemplateId] = [AT].[Id]
						WHERE [CFPO].[Id] = @Id AND [CF].[IsDeleted] = 0 AND [CFPO].[IsDeleted] = 0 AND [AT].[IsDeleted] = 0 AND [G].[IsDeleted] = 0
					END
					ELSE 
					BEGIN
						SELECT
							@Id [Id]
							,[AT].[Id] [APQPTemplateId]
							,[AT].[Name] [APQPTemplateName]
							,[G].[Id] [GateId]
							,[G].[Name] [GateName]
							,[CF].[Id] [CustomFieldId]
							,[CF].[Name] [CustomFieldName]
							,[CF].[FieldType]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[MinValue]
							,[CF].[MaxValue]
							,[CF].[MinDate]
							,[CF].[MaxDate]
							,[CF].[MinLength]
							,[CF].[MaxLength]
							,[CF].[IsMultiSelect]
						FROM [CustomField].[CustomField] [CF] 
						LEFT JOIN [APQP].[APQPTemplate] [AT]
							ON [AT].[Id] = @APQPTemplateId
						LEFT JOIN [APQP].[Gate] [G]
							ON [AT].[Id] = [G].[APQPTemplateId]
							AND [G].[APQPTemplateId] = [AT].[Id]
						WHERE [CF].[Id] = @CustomFieldId AND [CF].[IsDeleted] = 0 
							AND ([CF].[CompanyId] IS NULL OR [CF].[CompanyId] = @CompanyId)
							AND [AT].[IsDeleted] = 0 AND [AT].[CompanyId] = @CompanyId
							AND [G].[Id] = @GateId AND [G].[IsDeleted] = 0
					END
				END";
    }
}
