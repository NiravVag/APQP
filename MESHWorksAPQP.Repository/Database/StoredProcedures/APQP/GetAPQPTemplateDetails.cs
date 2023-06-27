// <copyright file="GetAPQPTemplateDetails.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.APQP
{
    /// <summary>
    /// Class GetAPQPTemplateDetails.
    /// </summary>
    public class GetAPQPTemplateDetails
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [APQP].[GetAPQPTemplateDetails]
									(
										@APQPId uniqueidentifier
									)
									AS
									BEGIN
										SET NOCOUNT ON

													Declare @APQPTemplateId uniqueidentifier;
													Declare @PartId uniqueidentifier;
													Declare @CompanyId uniqueidentifier;
													SELECT @APQPTemplateId = APQPTemplateId,@PartId = PartId , @CompanyId = CompanyId
													FROM APQP.APQP
													WHERE Id = @APQPId
													AND  IsDeleted = 0;
	
													-- APQP 
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId,
															 PartId,
															 APQPTemplateId,
															 ActiveGateId,
															 ActiveGateName
													FROM	APQP.APQP
													WHERE	Id = @APQPId
															AND IsDeleted = 0;

													-- APQPTemplate
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId
													FROM	APQP.APQPTemplate
													WHERE	Id = @APQPTemplateId
															AND IsDeleted = 0;
				
													 -- Part
													SELECT   [P].[Id]
															  ,[P].[CompanyId]
															  ,[P].[PartNumber]
															  ,[P].[Description]
															  ,[P].[DrawingNumber]
															  ,[P].[CommodityId]
															  ,[P].[ProcessId]
															  ,[P].[MaterialTypeId]
															  ,[P].[SAM]
															  ,[P].[InitialRevLevel]
															  ,[P].[InitialRevDate]
															  ,[P].[EstimatedWeight]
															  ,[P].[EAU]
															  ,[P].[CustomerName]
															  ,[P].[CustomerEmail]
															  ,[P].[CustomerPhone]
															  ,[P].[IsDeleted]
															  ,[P].[Customer]
															  ,[P].[OtherMaterialTypeName]
															  ,[P].[OtherProcessName]
															  ,[PR].[ParentPartId]
															  ,(SELECT [PartNumber] FROM [APQP].[Part] WHERE [Id] = [PR].[ParentPartId] AND [IsDeleted] = 0) [ParentPartNumber]
														  FROM [APQP].[Part] [P]
														  LEFT JOIN [APQP].[PartRelation] [PR]
															ON [P].[Id] = [PR].[PartId]	
														  WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 AND [PR].[IsDeleted] = 0
														  
														  UNION ALL 

														  SELECT   [P].[Id]
															  ,[P].[CompanyId]
															  ,[P].[PartNumber]
															  ,[P].[Description]
															  ,[P].[DrawingNumber]
															  ,[P].[CommodityId]
															  ,[P].[ProcessId]
															  ,[P].[MaterialTypeId]
															  ,[P].[SAM]
															  ,[P].[InitialRevLevel]
															  ,[P].[InitialRevDate]
															  ,[P].[EstimatedWeight]
															  ,[P].[EAU]
															  ,[P].[CustomerName]
															  ,[P].[CustomerEmail]
															  ,[P].[CustomerPhone]
															  ,[P].[IsDeleted]
															  ,[P].[Customer]
															  ,[P].[OtherMaterialTypeName]
															  ,[P].[OtherProcessName]
															  ,NULL [ParentPartId]
															  ,NULL [ParentPartNumber]
														  FROM [APQP].[Part] [P]
														  WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 

													--Gates
													SELECT	 Id,
															 Name,
															 Description			
													FROM	APQP.Gate 
													WHERE	APQPTemplateId = @APQPTemplateId
															AND IsDeleted = 0
													ORDER By SortOrder;

													--Gates clouser
													SELECT  C.Id, 
															S.GateId, 
															C.GateClosureSettingId, 
															C.ClouserType,
															C.IsCompleted,
															C.ClosureReferenceId
													FROM APQP.GateClosure C
														JOIN APQP.GateClosureSetting S
															ON C.GateClosureSettingId = S.Id
														JOIN APQP.Gate G
															ON G.Id = S.GateId 
														WHERE G.APQPTemplateId = @APQPTemplateId
														AND C.IsDeleted = 0
														AND G.IsDeleted = 0
														AND S.IsDeleted = 0;

													-- CustomField
													SELECT	M.GateId,  
															C.Id,
															C.Name,
															C.FieldType,
															C.Tooltip,
															C.IsRequired,
															C.ValidationMessage,
															C.ValidationRegex,
															C.ParentFeildId,
															C.IsPredefindField,
															C.PredefindFieldName,
															C.FieldAnswerOptionsBindingId,
															C.ModuleId,
															C.IsVisibleOnSelection,
															M.[Row],
															M.[Column] 
														FROM CustomField.CustomField C
														JOIN CustomField.CustomFieldGateMapping M
														ON C.Id=M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND C.CompanyId = @CompanyId
														AND C.IsDeleted = 0
														AND M.IsDeleted = 0;

													-- CustomFieldAnswerOption
													SELECT  AO.Id,
															AO.Value, 
															AO.IsDefault, 
															AO.SortOrder,
															AO.CustomFieldId  
														FROM  CustomField.CustomFieldAnswerOption AO
														JOIN CustomField.CustomFieldGateMapping M
														ON AO.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND AO.IsDeleted = 0
														AND M.IsDeleted = 0;

													--FieldAnswerOptionsBinding
													SELECT  B.Id,
															B.CustomFieldId,
															B.Bindingfunction
														FROM CustomField.FieldAnswerOptionsBinding B
														JOIN CustomField.CustomFieldGateMapping M
														ON B.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND B.IsDeleted = 0
														AND M.IsDeleted = 0;
											END";

        /// <summary>
        /// The body03032022
        /// </summary>
        public const string Body03032022 = @"ALTER PROCEDURE [APQP].[GetAPQPTemplateDetails]
											(
												@APQPId uniqueidentifier
											)
											AS
											BEGIN
												SET NOCOUNT ON

													Declare @APQPTemplateId uniqueidentifier;
													Declare @PartId uniqueidentifier;
													Declare @CompanyId uniqueidentifier;
													SELECT @APQPTemplateId = APQPTemplateId,@PartId = PartId , @CompanyId = CompanyId
													FROM APQP.APQP
													WHERE Id = @APQPId
													AND  IsDeleted = 0;
	
													-- APQP 
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId,
															 PartId,
															 APQPTemplateId
													FROM	APQP.APQP
													WHERE	Id = @APQPId
															AND IsDeleted = 0;

													-- APQPTemplate
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId
													FROM	APQP.APQPTemplate
													WHERE	Id = @APQPTemplateId
															AND IsDeleted = 0;
				
													 -- Part
													SELECT   [Id]
															  ,[CompanyId]
															  ,[PartNumber]
															  ,[Description]
															  ,[DrawingNumber]
															  ,[CommodityId]
															  ,[ProcessId]
															  ,[MaterialTypeId]
															  ,[SAM]
															  ,[InitialRevLevel]
															  ,[InitialRevDate]
															  ,[EstimatedWeight]
															  ,[EAU]
															  ,[CustomerName]
															  ,[CustomerEmail]
															  ,[CustomerPhone]
															  ,[IsDeleted]
															  ,[Customer]
															  ,[OtherMaterialTypeName]
															  ,[OtherProcessName]
														  FROM [APQP].[Part]
														  WHERE Id= @PartId
														  AND IsDeleted = 0

													--Gates
													SELECT	 Id,
															 Name,
															 Description			
													FROM	APQP.Gate 
													WHERE	APQPTemplateId = @APQPTemplateId
															AND IsDeleted = 0
													ORDER By SortOrder;

													--Gates clouser
													SELECT  C.Id, 
															S.GateId, 
															C.GateClosureSettingId, 
															C.ClouserType,
															C.IsCompleted
													FROM APQP.GateClosure C
														JOIN APQP.GateClosureSetting S
															ON C.GateClosureSettingId = S.Id
														JOIN APQP.Gate G
															ON G.Id = S.GateId 
														WHERE G.APQPTemplateId = @APQPTemplateId
														AND C.IsDeleted = 0
														AND G.IsDeleted = 0
														AND S.IsDeleted = 0;

													-- CustomField
													SELECT	M.GateId,  
															C.Id,
															C.Name,
															C.FieldType,
															C.Tooltip,
															C.IsRequired,
															C.ValidationMessage,
															C.ParentFeildId,
															C.IsPredefindField,
															C.PredefindFieldName,
															C.FieldAnswerOptionsBindingId,
															C.ModuleId,
															C.IsVisibleOnSelection
														FROM CustomField.CustomField C
														JOIN CustomField.CustomFieldGateMapping M
														ON C.Id=M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND C.CompanyId = @CompanyId
														AND C.IsDeleted = 0
														AND M.IsDeleted = 0;

													-- CustomFieldAnswerOption
													SELECT  AO.Id,
															AO.Value, 
															AO.IsDefault, 
															AO.SortOrder,
															AO.CustomFieldId  
														FROM  CustomField.CustomFieldAnswerOption AO
														JOIN CustomField.CustomFieldGateMapping M
														ON AO.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND AO.IsDeleted = 0
														AND M.IsDeleted = 0;

													--FieldAnswerOptionsBinding
													SELECT  B.Id,
															B.CustomFieldId,
															B.Bindingfunction
														FROM CustomField.FieldAnswerOptionsBinding B
														JOIN CustomField.CustomFieldGateMapping M
														ON B.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND B.IsDeleted = 0
														AND M.IsDeleted = 0;
											END";

        /// <summary>
        /// The body13032022
        /// </summary>
        public const string Body13032022 = @"ALTER PROCEDURE [APQP].[GetAPQPTemplateDetails]
											(
												@APQPId uniqueidentifier
											)
											AS
											BEGIN
												SET NOCOUNT ON

													Declare @APQPTemplateId uniqueidentifier;
													Declare @PartId uniqueidentifier;
													Declare @CompanyId uniqueidentifier;
													SELECT @APQPTemplateId = APQPTemplateId,@PartId = PartId , @CompanyId = CompanyId
													FROM APQP.APQP
													WHERE Id = @APQPId
													AND  IsDeleted = 0;
	
													-- APQP 
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId,
															 PartId,
															 APQPTemplateId
													FROM	APQP.APQP
													WHERE	Id = @APQPId
															AND IsDeleted = 0;

													-- APQPTemplate
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId
													FROM	APQP.APQPTemplate
													WHERE	Id = @APQPTemplateId
															AND IsDeleted = 0;
				
													 -- Part
													SELECT   [Id]
															  ,[CompanyId]
															  ,[PartNumber]
															  ,[Description]
															  ,[DrawingNumber]
															  ,[CommodityId]
															  ,[ProcessId]
															  ,[MaterialTypeId]
															  ,[SAM]
															  ,[InitialRevLevel]
															  ,[InitialRevDate]
															  ,[EstimatedWeight]
															  ,[EAU]
															  ,[CustomerName]
															  ,[CustomerEmail]
															  ,[CustomerPhone]
															  ,[IsDeleted]
															  ,[Customer]
															  ,[OtherMaterialTypeName]
															  ,[OtherProcessName]
														  FROM [APQP].[Part]
														  WHERE Id= @PartId
														  AND IsDeleted = 0

													--Gates
													SELECT	 Id,
															 Name,
															 Description			
													FROM	APQP.Gate 
													WHERE	APQPTemplateId = @APQPTemplateId
															AND IsDeleted = 0
													ORDER By SortOrder;

													--Gates clouser
													SELECT  C.Id, 
															S.GateId, 
															C.GateClosureSettingId, 
															C.ClouserType,
															C.IsCompleted
													FROM APQP.GateClosure C
														JOIN APQP.GateClosureSetting S
															ON C.GateClosureSettingId = S.Id
														JOIN APQP.Gate G
															ON G.Id = S.GateId 
														WHERE G.APQPTemplateId = @APQPTemplateId
														AND C.IsDeleted = 0
														AND G.IsDeleted = 0
														AND S.IsDeleted = 0;

													-- CustomField
													SELECT	M.GateId,  
															C.Id,
															C.Name,
															C.FieldType,
															C.Tooltip,
															C.IsRequired,
															C.ValidationMessage,
															C.ParentFeildId,
															C.IsPredefindField,
															C.PredefindFieldName,
															C.FieldAnswerOptionsBindingId,
															C.ModuleId,
															C.IsVisibleOnSelection,
															M.[Row],
															M.[Column] 
														FROM CustomField.CustomField C
														JOIN CustomField.CustomFieldGateMapping M
														ON C.Id=M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND C.CompanyId = @CompanyId
														AND C.IsDeleted = 0
														AND M.IsDeleted = 0;

													-- CustomFieldAnswerOption
													SELECT  AO.Id,
															AO.Value, 
															AO.IsDefault, 
															AO.SortOrder,
															AO.CustomFieldId  
														FROM  CustomField.CustomFieldAnswerOption AO
														JOIN CustomField.CustomFieldGateMapping M
														ON AO.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND AO.IsDeleted = 0
														AND M.IsDeleted = 0;

													--FieldAnswerOptionsBinding
													SELECT  B.Id,
															B.CustomFieldId,
															B.Bindingfunction
														FROM CustomField.FieldAnswerOptionsBinding B
														JOIN CustomField.CustomFieldGateMapping M
														ON B.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND B.IsDeleted = 0
														AND M.IsDeleted = 0;
											END";

        /// <summary>
        /// The body28032022.
        /// </summary>
        public const string Body28032022 = @"ALTER PROCEDURE [APQP].[GetAPQPTemplateDetails]
											(
												@APQPId uniqueidentifier
											)
											AS
											BEGIN
												SET NOCOUNT ON

													Declare @APQPTemplateId uniqueidentifier;
													Declare @PartId uniqueidentifier;
													Declare @CompanyId uniqueidentifier;
													SELECT @APQPTemplateId = APQPTemplateId,@PartId = PartId , @CompanyId = CompanyId
													FROM APQP.APQP
													WHERE Id = @APQPId
													AND  IsDeleted = 0;
	
													-- APQP 
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId,
															 PartId,
															 APQPTemplateId,
															 ActiveGateId,
															 ActiveGateName
													FROM	APQP.APQP
													WHERE	Id = @APQPId
															AND IsDeleted = 0;

													-- APQPTemplate
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId
													FROM	APQP.APQPTemplate
													WHERE	Id = @APQPTemplateId
															AND IsDeleted = 0;
				
													 -- Part
													SELECT   [Id]
															  ,[CompanyId]
															  ,[PartNumber]
															  ,[Description]
															  ,[DrawingNumber]
															  ,[CommodityId]
															  ,[ProcessId]
															  ,[MaterialTypeId]
															  ,[SAM]
															  ,[InitialRevLevel]
															  ,[InitialRevDate]
															  ,[EstimatedWeight]
															  ,[EAU]
															  ,[CustomerName]
															  ,[CustomerEmail]
															  ,[CustomerPhone]
															  ,[IsDeleted]
															  ,[Customer]
															  ,[OtherMaterialTypeName]
															  ,[OtherProcessName]
														  FROM [APQP].[Part]
														  WHERE Id= @PartId
														  AND IsDeleted = 0

													--Gates
													SELECT	 Id,
															 Name,
															 Description			
													FROM	APQP.Gate 
													WHERE	APQPTemplateId = @APQPTemplateId
															AND IsDeleted = 0
													ORDER By SortOrder;

													--Gates clouser
													SELECT  C.Id, 
															S.GateId, 
															C.GateClosureSettingId, 
															C.ClouserType,
															C.IsCompleted,
															C.ClosureReferenceId
													FROM APQP.GateClosure C
														JOIN APQP.GateClosureSetting S
															ON C.GateClosureSettingId = S.Id
														JOIN APQP.Gate G
															ON G.Id = S.GateId 
														WHERE G.APQPTemplateId = @APQPTemplateId
														AND C.IsDeleted = 0
														AND G.IsDeleted = 0
														AND S.IsDeleted = 0;

													-- CustomField
													SELECT	M.GateId,  
															C.Id,
															C.Name,
															C.FieldType,
															C.Tooltip,
															C.IsRequired,
															C.ValidationMessage,
															C.ValidationRegex,
															C.ParentFeildId,
															C.IsPredefindField,
															C.PredefindFieldName,
															C.FieldAnswerOptionsBindingId,
															C.ModuleId,
															C.IsVisibleOnSelection,
															M.[Row],
															M.[Column] 
														FROM CustomField.CustomField C
														JOIN CustomField.CustomFieldGateMapping M
														ON C.Id=M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND C.CompanyId = @CompanyId
														AND C.IsDeleted = 0
														AND M.IsDeleted = 0;

													-- CustomFieldAnswerOption
													SELECT  AO.Id,
															AO.Value, 
															AO.IsDefault, 
															AO.SortOrder,
															AO.CustomFieldId  
														FROM  CustomField.CustomFieldAnswerOption AO
														JOIN CustomField.CustomFieldGateMapping M
														ON AO.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND AO.IsDeleted = 0
														AND M.IsDeleted = 0;

													--FieldAnswerOptionsBinding
													SELECT  B.Id,
															B.CustomFieldId,
															B.Bindingfunction
														FROM CustomField.FieldAnswerOptionsBinding B
														JOIN CustomField.CustomFieldGateMapping M
														ON B.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND B.IsDeleted = 0
														AND M.IsDeleted = 0;
											END
";

        /// <summary>
        /// The body17052022
        /// </summary>
        public const string Body17052022 = @"CREATE OR ALTER PROCEDURE [APQP].[GetAPQPTemplateDetails]
											(
												@APQPId uniqueidentifier
											)
											AS
											BEGIN
												SET NOCOUNT ON

													Declare @APQPTemplateId uniqueidentifier;
													Declare @PartId uniqueidentifier;
													Declare @CompanyId uniqueidentifier;
													SELECT @APQPTemplateId = APQPTemplateId,@PartId = PartId , @CompanyId = CompanyId
													FROM APQP.APQP
													WHERE Id = @APQPId
													AND  IsDeleted = 0;
	
													-- APQP 
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId,
															 PartId,
															 APQPTemplateId,
															 ActiveGateId,
															 ActiveGateName
													FROM	APQP.APQP
													WHERE	Id = @APQPId
															AND IsDeleted = 0;

													-- APQPTemplate
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId
													FROM	APQP.APQPTemplate
													WHERE	Id = @APQPTemplateId
															AND IsDeleted = 0;
				
													 -- Part
													SELECT   [P].[Id]
															  ,[P].[CompanyId]
															  ,[P].[PartNumber]
															  ,[P].[Description]
															  ,[P].[DrawingNumber]
															  ,[P].[CommodityId]
															  ,[P].[ProcessId]
															  ,[P].[MaterialTypeId]
															  ,[P].[SAM]
															  ,[P].[InitialRevLevel]
															  ,[P].[InitialRevDate]
															  ,[P].[EstimatedWeight]
															  ,[P].[EAU]
															  ,[P].[CustomerName]
															  ,[P].[CustomerEmail]
															  ,[P].[CustomerPhone]
															  ,[P].[IsDeleted]
															  ,[P].[Customer]
															  ,[P].[OtherMaterialTypeName]
															  ,[P].[OtherProcessName]
															  ,[PR].[ParentPartId]
															  ,(SELECT [PartNumber] FROM [APQP].[Part] WHERE [Id] = [PR].[ParentPartId] AND [IsDeleted] = 0) [ParentPartNumber]
														  FROM [APQP].[Part] [P]
														  LEFT JOIN [APQP].[PartRelation] [PR]
															ON [P].[Id] = [PR].[PartId]	
														  WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 AND [PR].[IsDeleted] = 0
														  
														  UNION ALL 

														  SELECT   [P].[Id]
															  ,[P].[CompanyId]
															  ,[P].[PartNumber]
															  ,[P].[Description]
															  ,[P].[DrawingNumber]
															  ,[P].[CommodityId]
															  ,[P].[ProcessId]
															  ,[P].[MaterialTypeId]
															  ,[P].[SAM]
															  ,[P].[InitialRevLevel]
															  ,[P].[InitialRevDate]
															  ,[P].[EstimatedWeight]
															  ,[P].[EAU]
															  ,[P].[CustomerName]
															  ,[P].[CustomerEmail]
															  ,[P].[CustomerPhone]
															  ,[P].[IsDeleted]
															  ,[P].[Customer]
															  ,[P].[OtherMaterialTypeName]
															  ,[P].[OtherProcessName]
															  ,NULL [ParentPartId]
															  ,NULL [ParentPartNumber]
														  FROM [APQP].[Part] [P]
														  WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 

													--Gates
													SELECT	 Id,
															 Name,
															 Description			
													FROM	APQP.Gate 
													WHERE	APQPTemplateId = @APQPTemplateId
															AND IsDeleted = 0
													ORDER By SortOrder;

													--Gates clouser
													SELECT  C.Id, 
															S.GateId, 
															C.GateClosureSettingId, 
															C.ClouserType,
															C.IsCompleted,
															C.ClosureReferenceId
													FROM APQP.GateClosure C
														JOIN APQP.GateClosureSetting S
															ON C.GateClosureSettingId = S.Id
														JOIN APQP.Gate G
															ON G.Id = S.GateId 
														WHERE G.APQPTemplateId = @APQPTemplateId
														AND C.IsDeleted = 0
														AND G.IsDeleted = 0
														AND S.IsDeleted = 0;

													-- CustomField
													SELECT	M.GateId,  
															C.Id,
															C.Name,
															C.FieldType,
															C.Tooltip,
															C.IsRequired,
															C.ValidationMessage,
															C.ValidationRegex,
															C.ParentFeildId,
															C.IsPredefindField,
															C.PredefindFieldName,
															C.FieldAnswerOptionsBindingId,
															C.ModuleId,
															C.IsVisibleOnSelection,
															M.[Row],
															M.[Column] 
														FROM CustomField.CustomField C
														JOIN CustomField.CustomFieldGateMapping M
														ON C.Id=M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND C.CompanyId = @CompanyId
														AND C.IsDeleted = 0
														AND M.IsDeleted = 0;

													-- CustomFieldAnswerOption
													SELECT  AO.Id,
															AO.Value, 
															AO.IsDefault, 
															AO.SortOrder,
															AO.CustomFieldId,
															M.GateId
														FROM  CustomField.CustomFieldAnswerOption AO
														JOIN CustomField.CustomFieldGateMapping M
														ON AO.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND AO.IsDeleted = 0
														AND M.IsDeleted = 0;

													--FieldAnswerOptionsBinding
													   SELECT  B.Id,
															--M.CustomFieldId,
															B.Bindingfunction
														FROM CustomField.FieldAnswerOptionsBinding B
														where B.Id in (SELECT	c.FieldAnswerOptionsBindingId 
														FROM CustomField.CustomField C
														JOIN CustomField.CustomFieldGateMapping M
														ON C.Id=M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND M.IsDeleted= 0)
														AND B.IsDeleted = 0
											END";

        /// <summary>
        /// The body30052022
        /// </summary>
        public const string Body30052022 = @"ALTER   PROCEDURE [APQP].[GetAPQPTemplateDetails]
											(
												@APQPId uniqueidentifier
											)
											AS
											BEGIN
												SET NOCOUNT ON

													Declare @APQPTemplateId uniqueidentifier;
													Declare @PartId uniqueidentifier;
													Declare @CompanyId uniqueidentifier;
													SELECT @APQPTemplateId = APQPTemplateId,@PartId = PartId , @CompanyId = CompanyId
													FROM APQP.APQP
													WHERE Id = @APQPId
													AND  IsDeleted = 0;
	
													-- APQP 
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId,
															 PartId,
															 APQPTemplateId,
															 ActiveGateId,
															 ActiveGateName,
															 [Status]
													FROM	APQP.APQP
													WHERE	Id = @APQPId
															AND IsDeleted = 0;

													-- APQPTemplate
													SELECT	 Id,
															 Name,
															 Description,
															 CompanyId
													FROM	APQP.APQPTemplate
													WHERE	Id = @APQPTemplateId
															AND IsDeleted = 0;
				
													 -- Part
													SELECT   [P].[Id]
															  ,[P].[CompanyId]
															  ,[P].[PartNumber]
															  ,[P].[Description]
															  ,[P].[DrawingNumber]
															  ,[P].[CommodityId]
															  ,[P].[ProcessId]
															  ,[P].[MaterialTypeId]
															  ,[P].[SAM]
															  ,[P].[InitialRevLevel]
															  ,[P].[InitialRevDate]
															  ,[P].[EstimatedWeight]
															  ,[P].[EAU]
															  ,[P].[CustomerName]
															  ,[P].[CustomerEmail]
															  ,[P].[CustomerPhone]
															  ,[P].[IsDeleted]
															  ,[P].[Customer]
															  ,[P].[OtherMaterialTypeName]
															  ,[P].[OtherProcessName]
															  ,[PR].[ParentPartId]
															  ,(SELECT [PartNumber] FROM [APQP].[Part] WHERE [Id] = [PR].[ParentPartId] AND [IsDeleted] = 0) [ParentPartNumber]
														  FROM [APQP].[Part] [P]
														  LEFT JOIN [APQP].[PartRelation] [PR]
															ON [P].[Id] = [PR].[PartId]	
														  WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 AND [PR].[IsDeleted] = 0
														  
														  UNION ALL 

														  SELECT   [P].[Id]
															  ,[P].[CompanyId]
															  ,[P].[PartNumber]
															  ,[P].[Description]
															  ,[P].[DrawingNumber]
															  ,[P].[CommodityId]
															  ,[P].[ProcessId]
															  ,[P].[MaterialTypeId]
															  ,[P].[SAM]
															  ,[P].[InitialRevLevel]
															  ,[P].[InitialRevDate]
															  ,[P].[EstimatedWeight]
															  ,[P].[EAU]
															  ,[P].[CustomerName]
															  ,[P].[CustomerEmail]
															  ,[P].[CustomerPhone]
															  ,[P].[IsDeleted]
															  ,[P].[Customer]
															  ,[P].[OtherMaterialTypeName]
															  ,[P].[OtherProcessName]
															  ,NULL [ParentPartId]
															  ,NULL [ParentPartNumber]
														  FROM [APQP].[Part] [P]
														  WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 

													--Gates
													SELECT	 Id,
															 Name,
															 Description			
													FROM	APQP.Gate 
													WHERE	APQPTemplateId = @APQPTemplateId
															AND IsDeleted = 0
													ORDER By SortOrder;

													--Gates clouser
													SELECT  C.Id, 
															S.GateId, 
															C.GateClosureSettingId, 
															C.ClouserType,
															C.IsCompleted,
															C.ClosureReferenceId
													FROM APQP.GateClosure C
														JOIN APQP.GateClosureSetting S
															ON C.GateClosureSettingId = S.Id
														JOIN APQP.Gate G
															ON G.Id = S.GateId 
														WHERE G.APQPTemplateId = @APQPTemplateId
														AND C.IsDeleted = 0
														AND G.IsDeleted = 0
														AND S.IsDeleted = 0;

													-- CustomField
													SELECT	M.GateId,  
															C.Id,
															C.Name,
															C.FieldType,
															C.Tooltip,
															C.IsRequired,
															C.ValidationMessage,
															C.ValidationRegex,
															C.ParentFeildId,
															C.IsPredefindField,
															C.PredefindFieldName,
															C.FieldAnswerOptionsBindingId,
															C.ModuleId,
															C.IsVisibleOnSelection,
															M.[Row],
															M.[Column] 
														FROM CustomField.CustomField C
														JOIN CustomField.CustomFieldGateMapping M
														ON C.Id=M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND C.CompanyId = @CompanyId
														AND C.IsDeleted = 0
														AND M.IsDeleted = 0;

													-- CustomFieldAnswerOption
													SELECT  AO.Id,
															AO.Value, 
															AO.IsDefault, 
															AO.SortOrder,
															AO.CustomFieldId,
															M.GateId
														FROM  CustomField.CustomFieldAnswerOption AO
														JOIN CustomField.CustomFieldGateMapping M
														ON AO.CustomFieldId = M.CustomFieldId 
														WHERE M.APQPTemplateId = @APQPTemplateId
														AND AO.IsDeleted = 0
														AND M.IsDeleted = 0;

					--FieldAnswerOptionsBinding
						SELECT  B.Id,
							--M.CustomFieldId,
							B.Bindingfunction
						FROM CustomField.FieldAnswerOptionsBinding B
						where B.Id in (SELECT	c.FieldAnswerOptionsBindingId 
						FROM CustomField.CustomField C
						JOIN CustomField.CustomFieldGateMapping M
						ON C.Id=M.CustomFieldId 
						WHERE M.APQPTemplateId = @APQPTemplateId
						AND M.IsDeleted= 0)
						AND B.IsDeleted = 0
				END";

		public const string Body07062022 = @"CREATE OR ALTER PROCEDURE [APQP].[GetAPQPTemplateDetails]
				(
					@APQPId uniqueidentifier
				)
				AS
				BEGIN
					SET NOCOUNT ON

					Declare @APQPTemplateId uniqueidentifier;
					Declare @PartId uniqueidentifier;
					Declare @CompanyId uniqueidentifier;
					SELECT @APQPTemplateId = APQPTemplateId,@PartId = PartId , @CompanyId = CompanyId
					FROM APQP.APQP
					WHERE Id = @APQPId
					AND  IsDeleted = 0;
	
					-- APQP 
					SELECT	 Id,
								Name,
								Description,
								CompanyId,
								PartId,
								APQPTemplateId,
								ActiveGateId,
								ActiveGateName
					FROM	APQP.APQP
					WHERE	Id = @APQPId
							AND IsDeleted = 0;

					-- APQPTemplate
					SELECT	 Id,
								Name,
								Description,
								CompanyId
					FROM	APQP.APQPTemplate
					WHERE	Id = @APQPTemplateId
							AND IsDeleted = 0;
				
						-- Part
					SELECT   [P].[Id]
								,[P].[CompanyId]
								,[P].[PartNumber]
								,[P].[Description]
								,[P].[DrawingNumber]
								,[P].[CommodityId]
								,[P].[ProcessId]
								,[P].[MaterialTypeId]
								,[P].[SAM]
								,[P].[InitialRevLevel]
								,[P].[InitialRevDate]
								,[P].[EstimatedWeight]
								,[P].[EAU]
								,[P].[CustomerName]
								,[P].[CustomerEmail]
								,[P].[CustomerPhone]
								,[P].[IsDeleted]
								,[P].[Customer]
								,[P].[OtherMaterialTypeName]
								,[P].[OtherProcessName]
								,[PR].[ParentPartId]
								,(SELECT [PartNumber] FROM [APQP].[Part] WHERE [Id] = [PR].[ParentPartId] AND [IsDeleted] = 0) [ParentPartNumber]
							FROM [APQP].[Part] [P]
							LEFT JOIN [APQP].[PartRelation] [PR]
							ON [P].[Id] = [PR].[PartId]	
							WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 AND [PR].[IsDeleted] = 0
														  
							UNION ALL 

							SELECT   [P].[Id]
								,[P].[CompanyId]
								,[P].[PartNumber]
								,[P].[Description]
								,[P].[DrawingNumber]
								,[P].[CommodityId]
								,[P].[ProcessId]
								,[P].[MaterialTypeId]
								,[P].[SAM]
								,[P].[InitialRevLevel]
								,[P].[InitialRevDate]
								,[P].[EstimatedWeight]
								,[P].[EAU]
								,[P].[CustomerName]
								,[P].[CustomerEmail]
								,[P].[CustomerPhone]
								,[P].[IsDeleted]
								,[P].[Customer]
								,[P].[OtherMaterialTypeName]
								,[P].[OtherProcessName]
								,NULL [ParentPartId]
								,NULL [ParentPartNumber]
							FROM [APQP].[Part] [P]
							WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 

					--Gates
					SELECT	 Id,
								Name,
								Description,
								AlwaysEditable
					FROM	APQP.Gate 
					WHERE	APQPTemplateId = @APQPTemplateId
							AND IsDeleted = 0
					ORDER By SortOrder;

					--Gates clouser
					SELECT  C.Id, 
							S.GateId, 
							C.GateClosureSettingId, 
							C.ClouserType,
							C.IsCompleted,
							C.ClosureReferenceId
					FROM APQP.GateClosure C
						JOIN APQP.GateClosureSetting S
							ON C.GateClosureSettingId = S.Id
						JOIN APQP.Gate G
							ON G.Id = S.GateId 
						WHERE G.APQPTemplateId = @APQPTemplateId
						AND C.IsDeleted = 0
						AND G.IsDeleted = 0
						AND S.IsDeleted = 0;

					-- CustomField
					DEClARE @CustomFieldGateMapping TABLE
					(
						[Id] UNIQUEIDENTIFIER
						,[APQPTemplateId] UNIQUEIDENTIFIER
						,[GateId] UNIQUEIDENTIFIER
						,[CustomFieldId] UNIQUEIDENTIFIER
						,[Row] INT
						,[Column] INT
						,[Name] NVARCHAR(100)
						,[FieldType] INT 
						,[IsPredefindField] BIT
						,[PredefindFieldName] NVARCHAR(100)
						,[FieldAnswerOptionsBindingId] UNIQUEIDENTIFIER
						,[ModuleId] UNIQUEIDENTIFIER 
					)

					INSERT INTO @CustomFieldGateMapping
					(
						[Id]
						,[APQPTemplateId]
						,[GateId]
						,[CustomFieldId] 
						,[Row]
						,[Column] 
						,[Name]
						,[FieldType]
						,[IsPredefindField]
						,[PredefindFieldName]
						,[FieldAnswerOptionsBindingId]
						,[ModuleId]
					)
					SELECT	
						[M].[Id]
						,[M].[APQPTemplateId]
						,[M].[GateId] 
						,[M].[CustomFieldId]
						,[M].[Row]
						,[M].[Column] 
						,[C].[Name]
						,[C].[FieldType]
						,[C].[IsPredefindField]
						,[C].[PredefindFieldName]
						,[C].[FieldAnswerOptionsBindingId]
						,[C].[ModuleId]
					FROM [CustomField].[CustomField] [C]
					JOIN [CustomField].[CustomFieldGateMapping] [M]
						ON [C].[Id] = [M].[CustomFieldId]
					JOIN [APQP].[APQPTemplate] [AT]
						ON [M].[APQPTemplateId] = [AT].[Id]
					WHERE [M].[APQPTemplateId] = @APQPTemplateId AND [M].[IsDeleted] = 0
					AND [C].[CompanyId] = @CompanyId AND [C].[IsDeleted] = 0 
					AND [AT].[CompanyId] = @CompanyId AND [AT].[Id] = @APQPTemplateId AND [AT].[IsDeleted] = 0 AND [AT].[IsActive] = 1

					IF OBJECT_ID('tempdb..#OverrideFields') IS NOT NULL  
					DROP TABLE #OverrideFields

					SELECT 
						[CFGM].[GateId]
						,[CFGM].[CustomFieldId] [Id]
						,[CFGM].[Name]
						,[CFGM].[FieldType]
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
						,[CFGM].[IsPredefindField]
						,[CFGM].[PredefindFieldName]
						,[CFGM].[FieldAnswerOptionsBindingId]
						,[CFGM].[ModuleId]
						,[CFGM].[Row]
						,[CFGM].[Column] 
						,1 [IsOverrideField]
					INTO #OverrideFields
					FROM @CustomFieldGateMapping [CFGM] 
					JOIN [CustomField].[CustomFieldPropertiesOverride] [CFPO]
						ON [CFGM].[CustomFieldId] = [CFPO].[CustomFieldId]
						AND [CFGM].[GateId] = [CFPO].[GateId]
						AND [CFGM].[APQPTemplateId] = [CFPO].[APQPTemplateId]
					WHERE [CFPO].[IsDeleted] = 0 

					IF OBJECT_ID('tempdb..#CustomFields') IS NOT NULL  
					DROP TABLE #CustomFields

					SELECT 
						[CFGM].[GateId]
						,[CF].[Id]
						,[CF].[Name]
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
						,[CF].[IsPredefindField]
						,[CF].[PredefindFieldName]
						,[CF].[FieldAnswerOptionsBindingId]
						,[CF].[ModuleId]
						,[CFGM].[Row]
						,[CFGM].[Column] 
						,0 [IsOverrideField]
					INTO #CustomFields
					FROM @CustomFieldGateMapping [CFGM] 
					JOIN [CustomField].[CustomField] [CF]
						ON [CFGM].[CustomFieldId] = [CF].[Id]
					WHERE [CF].[IsDeleted] = 0

					UPDATE #CustomFields Set [IsOverrideField] = 1
					WHERE [Id] NOT IN (SELECT [Id] FROM #OverrideFields [OF] WHERE [GateId] = [OF].[GateId])

					SELECT * FROM #OverrideFields

					UNION ALL

					SELECT * FROM #CustomFields WHERE [IsOverrideField] = 1

					IF OBJECT_ID('tempdb..#OverrideFields') IS NOT NULL  
					DROP TABLE #OverrideFields
	

					IF OBJECT_ID('tempdb..#CustomFields') IS NOT NULL  
					DROP TABLE #CustomFields
													
					-- CustomFieldAnswerOption
					SELECT  AO.Id,
							AO.Value, 
							AO.IsDefault, 
							AO.SortOrder,
							AO.CustomFieldId,
							M.GateId
						FROM  CustomField.CustomFieldAnswerOption AO
						JOIN CustomField.CustomFieldGateMapping M
						ON AO.CustomFieldId = M.CustomFieldId 
						WHERE M.APQPTemplateId = @APQPTemplateId
						AND AO.IsDeleted = 0
						AND M.IsDeleted = 0;

					--FieldAnswerOptionsBinding
						SELECT  B.Id,
							--M.CustomFieldId,
							B.Bindingfunction
						FROM CustomField.FieldAnswerOptionsBinding B
						where B.Id in (SELECT	c.FieldAnswerOptionsBindingId 
						FROM CustomField.CustomField C
						JOIN CustomField.CustomFieldGateMapping M
						ON C.Id=M.CustomFieldId 
						WHERE M.APQPTemplateId = @APQPTemplateId
						AND M.IsDeleted= 0)
						AND B.IsDeleted = 0
				END";

		public const string Body08062022 = @"CREATE OR ALTER PROCEDURE [APQP].[GetAPQPTemplateDetails]
				(
					@APQPId uniqueidentifier
				)
				AS
				BEGIN
					SET NOCOUNT ON

					Declare @APQPTemplateId uniqueidentifier;
					Declare @PartId uniqueidentifier;
					Declare @CompanyId uniqueidentifier;
					SELECT @APQPTemplateId = APQPTemplateId,@PartId = PartId , @CompanyId = CompanyId
					FROM APQP.APQP
					WHERE Id = @APQPId
					AND  IsDeleted = 0;
	
					-- APQP 
					SELECT	 Id,
								Name,
								Description,
								CompanyId,
								PartId,
								APQPTemplateId,
								ActiveGateId,
								ActiveGateName
					FROM	APQP.APQP
					WHERE	Id = @APQPId
							AND IsDeleted = 0;

					-- APQPTemplate
					SELECT	 Id,
								Name,
								Description,
								CompanyId
					FROM	APQP.APQPTemplate
					WHERE	Id = @APQPTemplateId
							AND IsDeleted = 0;
				
						-- Part
					SELECT   [P].[Id]
								,[P].[CompanyId]
								,[P].[PartNumber]
								,[P].[Description]
								,[P].[DrawingNumber]
								,[P].[CommodityId]
								,[P].[ProcessId]
								,[P].[MaterialTypeId]
								,[P].[SAM]
								,[P].[InitialRevLevel]
								,[P].[InitialRevDate]
								,[P].[EstimatedWeight]
								,[P].[EAU]
								,[P].[CustomerName]
								,[P].[CustomerEmail]
								,[P].[CustomerPhone]
								,[P].[IsDeleted]
								,[P].[Customer]
								,[P].[OtherMaterialTypeName]
								,[P].[OtherProcessName]
								,[PR].[ParentPartId]
								,(SELECT [PartNumber] FROM [APQP].[Part] WHERE [Id] = [PR].[ParentPartId] AND [IsDeleted] = 0) [ParentPartNumber]
							FROM [APQP].[Part] [P]
							LEFT JOIN [APQP].[PartRelation] [PR]
							ON [P].[Id] = [PR].[PartId]	
							WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 AND [PR].[IsDeleted] = 0
														  
							UNION ALL 

							SELECT   [P].[Id]
								,[P].[CompanyId]
								,[P].[PartNumber]
								,[P].[Description]
								,[P].[DrawingNumber]
								,[P].[CommodityId]
								,[P].[ProcessId]
								,[P].[MaterialTypeId]
								,[P].[SAM]
								,[P].[InitialRevLevel]
								,[P].[InitialRevDate]
								,[P].[EstimatedWeight]
								,[P].[EAU]
								,[P].[CustomerName]
								,[P].[CustomerEmail]
								,[P].[CustomerPhone]
								,[P].[IsDeleted]
								,[P].[Customer]
								,[P].[OtherMaterialTypeName]
								,[P].[OtherProcessName]
								,NULL [ParentPartId]
								,NULL [ParentPartNumber]
							FROM [APQP].[Part] [P]
							WHERE [P].[Id]= @PartId AND [P].[IsDeleted] = 0 

					--Gates
					SELECT	 Id,
								Name,
								Description,
								IsAlwaysEditable
					FROM	APQP.Gate 
					WHERE	APQPTemplateId = @APQPTemplateId
							AND IsDeleted = 0
					ORDER By SortOrder;

					--Gates clouser
					SELECT  C.Id, 
							S.GateId, 
							C.GateClosureSettingId, 
							C.ClouserType,
							C.IsCompleted,
							C.ClosureReferenceId
					FROM APQP.GateClosure C
						JOIN APQP.GateClosureSetting S
							ON C.GateClosureSettingId = S.Id
						JOIN APQP.Gate G
							ON G.Id = S.GateId 
						WHERE G.APQPTemplateId = @APQPTemplateId
						AND C.IsDeleted = 0
						AND G.IsDeleted = 0
						AND S.IsDeleted = 0;

					-- CustomField
					DEClARE @CustomFieldGateMapping TABLE
					(
						[Id] UNIQUEIDENTIFIER
						,[APQPTemplateId] UNIQUEIDENTIFIER
						,[GateId] UNIQUEIDENTIFIER
						,[CustomFieldId] UNIQUEIDENTIFIER
						,[Row] INT
						,[Column] INT
						,[Name] NVARCHAR(100)
						,[FieldType] INT 
						,[IsPredefindField] BIT
						,[PredefindFieldName] NVARCHAR(100)
						,[FieldAnswerOptionsBindingId] UNIQUEIDENTIFIER
						,[ModuleId] UNIQUEIDENTIFIER 
					)

					INSERT INTO @CustomFieldGateMapping
					(
						[Id]
						,[APQPTemplateId]
						,[GateId]
						,[CustomFieldId] 
						,[Row]
						,[Column] 
						,[Name]
						,[FieldType]
						,[IsPredefindField]
						,[PredefindFieldName]
						,[FieldAnswerOptionsBindingId]
						,[ModuleId]
					)
					SELECT	
						[M].[Id]
						,[M].[APQPTemplateId]
						,[M].[GateId] 
						,[M].[CustomFieldId]
						,[M].[Row]
						,[M].[Column] 
						,[C].[Name]
						,[C].[FieldType]
						,[C].[IsPredefindField]
						,[C].[PredefindFieldName]
						,[C].[FieldAnswerOptionsBindingId]
						,[C].[ModuleId]
					FROM [CustomField].[CustomField] [C]
					JOIN [CustomField].[CustomFieldGateMapping] [M]
						ON [C].[Id] = [M].[CustomFieldId]
					JOIN [APQP].[APQPTemplate] [AT]
						ON [M].[APQPTemplateId] = [AT].[Id]
					WHERE [M].[APQPTemplateId] = @APQPTemplateId AND [M].[IsDeleted] = 0
					AND [C].[CompanyId] = @CompanyId AND [C].[IsDeleted] = 0 
					AND [AT].[CompanyId] = @CompanyId AND [AT].[Id] = @APQPTemplateId AND [AT].[IsDeleted] = 0 AND [AT].[IsActive] = 1

					IF OBJECT_ID('tempdb..#OverrideFields') IS NOT NULL  
					DROP TABLE #OverrideFields

					SELECT 
						[CFGM].[GateId]
						,[CFGM].[CustomFieldId] [Id]
						,[CFGM].[Name]
						,[CFGM].[FieldType]
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
						,[CFGM].[IsPredefindField]
						,[CFGM].[PredefindFieldName]
						,[CFGM].[FieldAnswerOptionsBindingId]
						,[CFGM].[ModuleId]
						,[CFGM].[Row]
						,[CFGM].[Column] 
						,1 [IsOverrideField]
					INTO #OverrideFields
					FROM @CustomFieldGateMapping [CFGM] 
					JOIN [CustomField].[CustomFieldPropertiesOverride] [CFPO]
						ON [CFGM].[CustomFieldId] = [CFPO].[CustomFieldId]
						AND [CFGM].[GateId] = [CFPO].[GateId]
						AND [CFGM].[APQPTemplateId] = [CFPO].[APQPTemplateId]
					WHERE [CFPO].[IsDeleted] = 0 

					IF OBJECT_ID('tempdb..#CustomFields') IS NOT NULL  
					DROP TABLE #CustomFields

					SELECT 
						[CFGM].[GateId]
						,[CF].[Id]
						,[CF].[Name]
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
						,[CF].[IsPredefindField]
						,[CF].[PredefindFieldName]
						,[CF].[FieldAnswerOptionsBindingId]
						,[CF].[ModuleId]
						,[CFGM].[Row]
						,[CFGM].[Column] 
						,0 [IsOverrideField]
					INTO #CustomFields
					FROM @CustomFieldGateMapping [CFGM] 
					JOIN [CustomField].[CustomField] [CF]
						ON [CFGM].[CustomFieldId] = [CF].[Id]
					WHERE [CF].[IsDeleted] = 0

					UPDATE #CustomFields Set [IsOverrideField] = 1
					WHERE [Id] NOT IN (SELECT [Id] FROM #OverrideFields [OF] WHERE [GateId] = [OF].[GateId])

					SELECT * FROM #OverrideFields

					UNION ALL

					SELECT * FROM #CustomFields WHERE [IsOverrideField] = 1

					IF OBJECT_ID('tempdb..#OverrideFields') IS NOT NULL  
					DROP TABLE #OverrideFields
	

					IF OBJECT_ID('tempdb..#CustomFields') IS NOT NULL  
					DROP TABLE #CustomFields
													
					-- CustomFieldAnswerOption
					SELECT  AO.Id,
							AO.Value, 
							AO.IsDefault, 
							AO.SortOrder,
							AO.CustomFieldId,
							M.GateId
						FROM  CustomField.CustomFieldAnswerOption AO
						JOIN CustomField.CustomFieldGateMapping M
						ON AO.CustomFieldId = M.CustomFieldId 
						WHERE M.APQPTemplateId = @APQPTemplateId
						AND AO.IsDeleted = 0
						AND M.IsDeleted = 0;

					--FieldAnswerOptionsBinding
						SELECT  B.Id,
							--M.CustomFieldId,
							B.Bindingfunction
						FROM CustomField.FieldAnswerOptionsBinding B
						where B.Id in (SELECT	c.FieldAnswerOptionsBindingId 
						FROM CustomField.CustomField C
						JOIN CustomField.CustomFieldGateMapping M
						ON C.Id=M.CustomFieldId 
						WHERE M.APQPTemplateId = @APQPTemplateId
						AND M.IsDeleted= 0)
						AND B.IsDeleted = 0
				END";
	}
}
