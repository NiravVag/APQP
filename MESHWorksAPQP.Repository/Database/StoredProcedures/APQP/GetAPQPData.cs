// <copyright file="GetAPQPData.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.APQP
{
    /// <summary>
    /// Class GetAPQPData.
    /// </summary>
    public class GetAPQPData
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [APQP].[GetAPQPData]
									(
									   @id uniqueidentifier
									)
									AS
									BEGIN
										SET NOCOUNT ON
	
											SELECT [Id]
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
												  ,[IsDeleted]
											  FROM [APQP].[APQPData]
											  WHERE APQPId =@id
											  AND IsDeleted = 0;

											SELECT 
												id,
												CompanyId,
												CustomFieldId,
												EntityId APQPId,
												AnswerValue
											FROM CustomField.CustomFieldAnswer
											WHERE IsDeleted = 0
											AND EntityId = @id;
									END";
    }
}
