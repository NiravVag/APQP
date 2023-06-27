// <copyright file="SaveGateFieldsData.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.APQP
{
    /// <summary>
    /// Class SaveGateFieldsData.
    /// </summary>
    public class SaveGateFieldsData
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [APQP].[SaveGateFieldsData]
									(
									   @CustomFieldAnswersJson NVARCHAR(MAX),
									   @PredefinedFieldAnswersJson NVARCHAR(MAX)
									)
									AS
									BEGIN
										SET NOCOUNT ON

										INSERT INTO CustomField.CustomFieldAnswer (
										  id,
										  CompanyId, 
										  CustomFieldId, 
										  EntityId, 
										  AnswerValue,
										  Created,
										  CreatedBy,
										  LastModified,
										  LastModifiedBy,
										  IsDeleted
										 )
										  SELECT 
											  id, 
											  CompanyId, 
											  CustomFieldId, 
											  EntityId, 
											  AnswerValue,
											  Created,
											  CreatedBy,
											  LastModified,
											  LastModifiedBy,
											  IsDeleted
										  FROM OPENJSON(@CustomFieldAnswersJson)
											   WITH (
														Id uniqueidentifier, 
														CompanyId uniqueidentifier, 
														CustomFieldId uniqueidentifier,
														EntityId uniqueidentifier,
														AnswerValue nvarchar(max),
														Created datetime2,
														CreatedBy nvarchar(36),
														LastModified datetime2,
														LastModifiedBy nvarchar(36),
														IsDeleted bit
													);

											INSERT INTO [APQP].[APQPData](
												[Id]
											   ,[APQPId]
											   ,[APQPEngineerId]
											   ,[ManufacturerId]
											   ,[InitialPieceCost]
											   ,[SCCId]
											   ,[ToolingSupplierId]
											   ,[InitialPiecePrice]
											   ,[PlannerId]
											   ,[MinOrderQTY]
											   ,[InitialToolingCost]
											   ,[CustomerEngineer]
											   ,[ToolingCavity]
											   ,[InitialToolingPrice]
											   ,[CEEmail]
											   ,[ToolingLeadTime]
											   ,[ToolingTypeId]
											   ,[CEPhoneNumber]
											   ,[ProductionLeadtime]
											   ,[StartOfProduction]
											   ,[ToolingPOreceived]
											   ,[PPAPSubmissionId]
											   ,[UpdatePPAPSubmission]
											   ,[CustToolingPONumber]
											   ,[NumOfSamples]
											   ,[ProjectNotes]
											   ,[CustmfgLocation]
											   ,[RawMaterialInput]
											   ,[MESWarehouseId]
											   ,[RawMaterialCost]
											   ,[Gate2RevLevel]
											   ,[SupplierQualityId]
											   ,[Gate2RevisionDate]
											   ,[SupplierQualityLeadId]
											   ,[Gate2DrawingNumber]
											   ,[SupplierCountryManagerId]
											   ,[StatusId]
											   ,[ToolingEngineerId]
											   ,[ToolingKickOfDate]
											   ,[NewProductDeveloperId]
											   ,[PlanToolingCompletion]
											   ,[DesignReviewNotes]
											   ,[PlanPPAPSubmission]
											   ,[Gate3RevLevel]
											   ,[ToolBuildStatusId]
											   ,[Gate3RevisionDate]
											   ,[PPAPSubmissionDateUpdateNotes]
											   ,[ToolCompletionDateUpdateNotes]
											   ,[ActualToolCompletion]
											   ,[ApprovalNotes]
											   ,[IsApproved]
											   ,[Created]
											   ,[CreatedBy]
											   ,[LastModified]
											   ,[LastModifiedBy]
											   ,[IsDeleted])
												SELECT 
													[Id]
												   ,[APQPId]
												   ,[APQPEngineerId]
												   ,[ManufacturerId]
												   ,[InitialPieceCost]
												   ,[SCCId]
												   ,[ToolingSupplierId]
												   ,[InitialPiecePrice]
												   ,[PlannerId]
												   ,[MinOrderQTY]
												   ,[InitialToolingCost]
												   ,[CustomerEngineer]
												   ,[ToolingCavity]
												   ,[InitialToolingPrice]
												   ,[CEEmail]
												   ,[ToolingLeadTime]
												   ,[ToolingTypeId]
												   ,[CEPhoneNumber]
												   ,[ProductionLeadtime]
												   ,[StartOfProduction]
												   ,[ToolingPOreceived]
												   ,[PPAPSubmissionId]
												   ,[UpdatePPAPSubmission]
												   ,[CustToolingPONumber]
												   ,[NumOfSamples]
												   ,[ProjectNotes]
												   ,[CustmfgLocation]
												   ,[RawMaterialInput]
												   ,[MESWarehouseId]
												   ,[RawMaterialCost]
												   ,[Gate2RevLevel]
												   ,[SupplierQualityId]
												   ,[Gate2RevisionDate]
												   ,[SupplierQualityLeadId]
												   ,[Gate2DrawingNumber]
												   ,[SupplierCountryManagerId]
												   ,[StatusId]
												   ,[ToolingEngineerId]
												   ,[ToolingKickOfDate]
												   ,[NewProductDeveloperId]
												   ,[PlanToolingCompletion]
												   ,[DesignReviewNotes]
												   ,[PlanPPAPSubmission]
												   ,[Gate3RevLevel]
												   ,[ToolBuildStatusId]
												   ,[Gate3RevisionDate]
												   ,[PPAPSubmissionDateUpdateNotes]
												   ,[ToolCompletionDateUpdateNotes]
												   ,[ActualToolCompletion]
												   ,[ApprovalNotes]
												   ,[IsApproved]
												   ,[Created]
												   ,[CreatedBy]
												   ,[LastModified]
												   ,[LastModifiedBy]
												   ,[IsDeleted] 
												FROM OPENJSON(@PredefinedFieldAnswersJson)
												WITH (
														Id uniqueidentifier
													   ,APQPId uniqueidentifier
													   ,APQPEngineerId uniqueidentifier
													   ,ManufacturerId uniqueidentifier
													   ,InitialPieceCost  decimal(18,6) 
													   ,SCCId uniqueidentifier
													   ,ToolingSupplierId uniqueidentifier
													   ,InitialPiecePrice decimal(18,6) 
													   ,PlannerId uniqueidentifier
													   ,MinOrderQTY int 
													   ,InitialToolingCost decimal(18,6) 
													   ,CustomerEngineer nvarchar(100) 
													   ,ToolingCavity int 
													   ,InitialToolingPrice decimal(18,6) 
													   ,CEEmail nvarchar(100) 
													   ,ToolingLeadTime int 
													   ,ToolingTypeId uniqueidentifier
													   ,CEPhoneNumber nvarchar(50) 
													   ,ProductionLeadtime int 
													   ,StartOfProduction datetime2  
													   ,ToolingPOreceived datetime2  
													   ,PPAPSubmissionId uniqueidentifier
													   ,UpdatePPAPSubmission datetime2  
													   ,CustToolingPONumber nvarchar(100) 
													   ,NumOfSamples int 
													   ,ProjectNotes nvarchar(300)
													   ,CustmfgLocation nvarchar(100)
													   ,RawMaterialInput decimal(18,6)
													   ,MESWarehouseId uniqueidentifier
													   ,RawMaterialCost decimal(18,6)
													   ,Gate2RevLevel nvarchar(50)
													   ,SupplierQualityId uniqueidentifier
													   ,Gate2RevisionDate datetime2 
													   ,SupplierQualityLeadId uniqueidentifier
													   ,Gate2DrawingNumber nvarchar(50)
													   ,SupplierCountryManagerId uniqueidentifier
													   ,StatusId uniqueidentifier
													   ,ToolingEngineerId uniqueidentifier
													   ,ToolingKickOfDate datetime2 
													   ,NewProductDeveloperId uniqueidentifier
													   ,PlanToolingCompletion datetime2 
													   ,DesignReviewNotes nvarchar(300)
													   ,PlanPPAPSubmission nvarchar(50)
													   ,Gate3RevLevel nvarchar(50)
													   ,ToolBuildStatusId uniqueidentifier
													   ,Gate3RevisionDate datetime2 
													   ,PPAPSubmissionDateUpdateNotes nvarchar(300)
													   ,ToolCompletionDateUpdateNotes nvarchar(300)
													   ,ActualToolCompletion datetime2 
													   ,ApprovalNotes nvarchar(300)
													   ,IsApproved bit 
													   ,Created datetime2 
													   ,CreatedBy nvarchar(36)
													   ,LastModified datetime2 
													   ,LastModifiedBy nvarchar(36) 
													   ,IsDeleted bit);
									 END";

        /// <summary>
        /// The body13032022
        /// </summary>
        public const string Body13032022 = @"CREATE OR ALTER PROCEDURE [APQP].[SaveGateFieldsData]
											(
											   @CompanyId uniqueidentifier,
											   @GateId  uniqueidentifier,
											   @EntityId  uniqueidentifier,
											   @CustomFieldAnswersJson NVARCHAR(MAX)
											)
											AS
											BEGIN
												SET NOCOUNT ON

												DELETE FROM CustomField.CustomFieldAnswer
												WHERE CompanyId= @CompanyId 
												AND EntityId = @EntityId
												AND CustomFieldId in (SELECT CustomFieldId FROM CustomField.CustomFieldGateMapping
																		WHERE GateId =  @GateId);

												INSERT INTO CustomField.CustomFieldAnswer (
												  id,
												  CompanyId, 
												  CustomFieldId, 
												  EntityId, 
												  AnswerValue,
												  Created,
												  CreatedBy,
												  LastModified,
												  LastModifiedBy,
												  IsDeleted
												 )
												  SELECT 
													  id, 
													  CompanyId, 
													  CustomFieldId, 
													  EntityId, 
													  AnswerValue,
													  Created,
													  CreatedBy,
													  LastModified,
													  LastModifiedBy,
													  IsDeleted
												  FROM OPENJSON(@CustomFieldAnswersJson)
													   WITH (
																Id uniqueidentifier, 
																CompanyId uniqueidentifier, 
																CustomFieldId uniqueidentifier,
																EntityId uniqueidentifier,
																AnswerValue nvarchar(max),
																Created datetime2,
																CreatedBy nvarchar(36),
																LastModified datetime2,
																LastModifiedBy nvarchar(36),
																IsDeleted bit
															);
											 END";
    }
}
