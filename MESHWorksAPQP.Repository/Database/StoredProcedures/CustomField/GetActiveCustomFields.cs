// <copyright file="GetActiveCustomFields.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.CustomField
{
    /// <summary>
    /// Class GetActiveCustomFields.
    /// </summary>
    public class GetActiveCustomFields
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [CustomField].[GetActiveCustomFields]
				(
				   @CompanyId UNIQUEIDENTIFIER = NULL
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON
					DECLARE @CustomField TABLE (
						[Id] UNIQUEIDENTIFIER
						,[Name] NVARCHAR(100)
						,[CompanyId] UNIQUEIDENTIFIER NULL
						,[FieldType] INT
						,[Tooltip] NVARCHAR(200)
						,[IsRequired] BIT
						,[ValidationRegex] NVARCHAR(200)
						,[ValidationMessage] NVARCHAR(200)
						,[DefaultValue] NVARCHAR(100)
						,[ParentFeildId] UNIQUEIDENTIFIER NULL
						,[IsPredefindField] BIT
						,[PredefindFieldName] NVARCHAR(100)
						,[FieldAnswerOptionsBindingId] UNIQUEIDENTIFIER NULL
						,[IsVisibleOnSelection] BIT
						,[IsActive] BIT
						,[AnswerOptionsBindingId] UNIQUEIDENTIFIER NULL
						,[Bindingfunction] NVARCHAR(MAX)
					)

					-- Active Custom Fields
					IF (@CompanyId IS NULL)
					BEGIN
						INSERT INTO @CustomField
						SELECT
							[CF].[Id]
							,[CF].[Name]
							,[CF].[CompanyId]
							,[CF].[FieldType]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsPredefindField]
							,[CF].[PredefindFieldName]
							,[CF].[FieldAnswerOptionsBindingId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[IsActive]
							,[FAOB].[Id] [AnswerOptionsBindingId]
							,[FAOB].[Bindingfunction]
						FROM [CustomField].[CustomField] [CF]
						LEFT JOIN [CustomField].[FieldAnswerOptionsBinding] [FAOB] 
							ON [CF].[FieldAnswerOptionsBindingId] = [FAOB].[Id]
						WHERE [CF].[CompanyId] IS NULL AND [CF].[IsDeleted] = 0 AND [CF].[IsActive] = 1 AND [CF].[FieldAnswerOptionsBindingId] IS NOT NULL AND [FAOB].[IsDeleted] = 0
						UNION ALL
						SELECT
							[CF].[Id]
							,[CF].[Name]
							,[CF].[CompanyId]
							,[CF].[FieldType]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsPredefindField]
							,[CF].[PredefindFieldName]
							,[CF].[FieldAnswerOptionsBindingId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[IsActive]
							,NULL [AnswerOptionsBindingId]
							,NULL [Bindingfunction]
						FROM [CustomField].[CustomField] [CF]
						WHERE [CF].[CompanyId] IS NULL AND [CF].[IsDeleted] = 0 AND [CF].[IsActive] = 1 AND [CF].[FieldAnswerOptionsBindingId] IS NULL
					END
					ELSE
					BEGIN
						INSERT INTO @CustomField
						SELECT
							[CF].[Id]
							,[CF].[Name]
							,[CF].[CompanyId]
							,[CF].[FieldType]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsPredefindField]
							,[CF].[PredefindFieldName]
							,[CF].[FieldAnswerOptionsBindingId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[IsActive]
							,[FAOB].[Id] [AnswerOptionsBindingId]
							,[FAOB].[Bindingfunction]
						FROM [CustomField].[CustomField] [CF]
						LEFT JOIN [CustomField].[FieldAnswerOptionsBinding] [FAOB] 
							ON [CF].[FieldAnswerOptionsBindingId] = [FAOB].[Id]
						WHERE ( [CF].[CompanyId] IS NULL OR [CF].[CompanyId] = @CompanyId ) AND [CF].[IsDeleted] = 0 AND [CF].[IsActive] = 1 AND [CF].[FieldAnswerOptionsBindingId] IS NOT NULL AND [FAOB].[IsDeleted] = 0						
						UNION ALL
						SELECT
							[CF].[Id]
							,[CF].[Name]
							,[CF].[CompanyId]
							,[CF].[FieldType]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsPredefindField]
							,[CF].[PredefindFieldName]
							,[CF].[FieldAnswerOptionsBindingId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[IsActive]
							,NULL [AnswerOptionsBindingId]
							,NULL [Bindingfunction]
						FROM [CustomField].[CustomField] [CF]
						WHERE ( [CF].[CompanyId] IS NULL OR [CF].[CompanyId] = @CompanyId ) AND [CF].[IsDeleted] = 0 AND [CF].[IsActive] = 1 AND [CF].[FieldAnswerOptionsBindingId] IS NULL
					END 

					SELECT * FROM @CustomField ORDER BY [Name]

					-- Custom Field Answer Options
					SELECT 
						[AO].[Id] 
						,[AO].[CustomFieldId]
						,[AO].[Value]
						,[AO].[Display]
						,[AO].[IsDefault]
						,[AO].[SortOrder]
					FROM @CustomField [CF]
					JOIN [CustomField].[CustomFieldAnswerOption] [AO]
						ON [CF].[Id] = [AO].[CustomFieldId]
					WHERE [CF].[IsActive] = 1 AND [AO].[IsDeleted] = 0
					ORDER BY [AO].[CustomFieldId], [AO].[SortOrder]

					-- Custom Field Properties Override
					IF (@APQPTemplateId IS NOT NULL)
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
						FROM @CustomField  [CF] 
						JOIN [CustomField].[CustomFieldPropertiesOverride] [CFPO]
							ON [CFPO].[CustomFieldId] = [CF].[Id]
						JOIN [APQP].[APQPTemplate] [AT]
							ON [CFPO].[APQPTemplateId] = [AT].[Id]
						WHERE [CFPO].[IsDeleted] = 0 AND [AT].[IsDeleted] = 0
					END
				END";

        /// <summary>
        /// The body18052022
        /// </summary>
        public const string Body18052022 = @"CREATE OR ALTER PROCEDURE [CustomField].[GetActiveCustomFields]
				(
				   @CompanyId UNIQUEIDENTIFIER = NULL
				   ,@APQPTemplateId UNIQUEIDENTIFIER = NULL
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.

					SET NOCOUNT ON
					DECLARE @CustomField TABLE (
						[Id] UNIQUEIDENTIFIER
						,[Name] NVARCHAR(100)
						,[CompanyId] UNIQUEIDENTIFIER NULL
						,[FieldType] INT
						,[Tooltip] NVARCHAR(200)
						,[IsRequired] BIT
						,[ValidationRegex] NVARCHAR(200)
						,[ValidationMessage] NVARCHAR(200)
						,[DefaultValue] NVARCHAR(100)
						,[ParentFeildId] UNIQUEIDENTIFIER NULL
						,[IsPredefindField] BIT
						,[PredefindFieldName] NVARCHAR(100)
						,[FieldAnswerOptionsBindingId] UNIQUEIDENTIFIER NULL
						,[IsVisibleOnSelection] BIT
						,[IsActive] BIT
						,[AnswerOptionsBindingId] UNIQUEIDENTIFIER NULL
						,[Bindingfunction] NVARCHAR(MAX)
					)

					-- Active Custom Fields
					IF (@CompanyId IS NULL)
					BEGIN
						INSERT INTO @CustomField
						SELECT
							[CF].[Id]
							,[CF].[Name]
							,[CF].[CompanyId]
							,[CF].[FieldType]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsPredefindField]
							,[CF].[PredefindFieldName]
							,[CF].[FieldAnswerOptionsBindingId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[IsActive]
							,[FAOB].[Id] [AnswerOptionsBindingId]
							,[FAOB].[Bindingfunction]
						FROM [CustomField].[CustomField] [CF]
						LEFT JOIN [CustomField].[FieldAnswerOptionsBinding] [FAOB] 
							ON [CF].[FieldAnswerOptionsBindingId] = [FAOB].[Id]
						WHERE [CF].[CompanyId] IS NULL AND [CF].[IsDeleted] = 0 AND [CF].[IsActive] = 1 AND [CF].[FieldAnswerOptionsBindingId] IS NOT NULL AND [FAOB].[IsDeleted] = 0
						UNION ALL
						SELECT
							[CF].[Id]
							,[CF].[Name]
							,[CF].[CompanyId]
							,[CF].[FieldType]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsPredefindField]
							,[CF].[PredefindFieldName]
							,[CF].[FieldAnswerOptionsBindingId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[IsActive]
							,NULL [AnswerOptionsBindingId]
							,NULL [Bindingfunction]
						FROM [CustomField].[CustomField] [CF]
						WHERE [CF].[CompanyId] IS NULL AND [CF].[IsDeleted] = 0 AND [CF].[IsActive] = 1 AND [CF].[FieldAnswerOptionsBindingId] IS NULL
					END
					ELSE
					BEGIN
						INSERT INTO @CustomField
						SELECT
							[CF].[Id]
							,[CF].[Name]
							,[CF].[CompanyId]
							,[CF].[FieldType]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsPredefindField]
							,[CF].[PredefindFieldName]
							,[CF].[FieldAnswerOptionsBindingId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[IsActive]
							,[FAOB].[Id] [AnswerOptionsBindingId]
							,[FAOB].[Bindingfunction]
						FROM [CustomField].[CustomField] [CF]
						LEFT JOIN [CustomField].[FieldAnswerOptionsBinding] [FAOB] 
							ON [CF].[FieldAnswerOptionsBindingId] = [FAOB].[Id]
						WHERE ( [CF].[CompanyId] IS NULL OR [CF].[CompanyId] = @CompanyId ) AND [CF].[IsDeleted] = 0 AND [CF].[IsActive] = 1 AND [CF].[FieldAnswerOptionsBindingId] IS NOT NULL AND [FAOB].[IsDeleted] = 0						
						UNION ALL
						SELECT
							[CF].[Id]
							,[CF].[Name]
							,[CF].[CompanyId]
							,[CF].[FieldType]
							,[CF].[Tooltip]
							,[CF].[IsRequired]
							,[CF].[ValidationRegex]
							,[CF].[ValidationMessage]
							,[CF].[DefaultValue]
							,[CF].[ParentFeildId]
							,[CF].[IsPredefindField]
							,[CF].[PredefindFieldName]
							,[CF].[FieldAnswerOptionsBindingId]
							,[CF].[IsVisibleOnSelection]
							,[CF].[IsActive]
							,NULL [AnswerOptionsBindingId]
							,NULL [Bindingfunction]
						FROM [CustomField].[CustomField] [CF]
						WHERE ( [CF].[CompanyId] IS NULL OR [CF].[CompanyId] = @CompanyId ) AND [CF].[IsDeleted] = 0 AND [CF].[IsActive] = 1 AND [CF].[FieldAnswerOptionsBindingId] IS NULL
					END 

					SELECT * FROM @CustomField ORDER BY [Name]

					-- Custom Field Answer Options
					SELECT 
						[AO].[Id] 
						,[AO].[CustomFieldId]
						,[AO].[Value]
						,[AO].[Display]
						,[AO].[IsDefault]
						,[AO].[SortOrder]
					FROM @CustomField [CF]
					JOIN [CustomField].[CustomFieldAnswerOption] [AO]
						ON [CF].[Id] = [AO].[CustomFieldId]
					WHERE [CF].[IsActive] = 1 AND [AO].[IsDeleted] = 0
					ORDER BY [AO].[CustomFieldId], [AO].[SortOrder]

					-- Custom Field Properties Override
					IF (@APQPTemplateId IS NOT NULL)
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
						FROM @CustomField  [CF] 
						JOIN [CustomField].[CustomFieldPropertiesOverride] [CFPO]
							ON [CFPO].[CustomFieldId] = [CF].[Id]
						JOIN [APQP].[APQPTemplate] [AT]
							ON [CFPO].[APQPTemplateId] = [AT].[Id]
						WHERE [CFPO].[IsDeleted] = 0 AND [AT].[IsDeleted] = 0
					END
				END";
    }
}