// <copyright file="CloneAPQPTemplate.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.APQPTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class CloneAPQPTemplate.
    /// </summary>
    public class CloneAPQPTemplate
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [APQP].[CloneAPQPTemplate]
				(
					@CompanyId UNIQUEIDENTIFIER = NULL,
					@UserId UNIQUEIDENTIFIER,
					@APQPTemplateId UNIQUEIDENTIFIER,
					@CloneAPQPTemplateId UNIQUEIDENTIFIER
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON

					DECLARE @TemplateName NVARCHAR(50);

					IF (@CompanyId IS NULL)
					BEGIN
						SELECT @TemplateName = [AT].[Name] FROM [APQP].[APQPTemplate] [AT] WHERE [AT].[CompanyId] IS NULL AND [AT].[Id] = @APQPTemplateId AND [AT].[IsDeleted] = 0

						SET @TemplateName = CONCAT('Clone-', @TemplateName);

						INSERT INTO [APQP].[APQPTemplate]  
						(	[Id]
							,[Name]
							,[Description]
							,[CompanyId]
							,[Created]
							,[CreatedBy]
							,[LastModified]
							,[LastModifiedBy]
							,[IsDeleted]
							,[IsActive]
							,[IsSystemDefault]
						)
						SELECT @CloneAPQPTemplateId
							,@TemplateName
							,[AT].[Description]
							,[AT].[CompanyId]
							,GETUTCDATE()
							,@UserId
							,NULL
							,NULL
							,[AT].[IsDeleted]
							,[AT].[IsActive]
							,[AT].[IsSystemDefault]
						FROM [APQP].[APQPTemplate] [AT] 
						WHERE [AT].[Id] = @APQPTemplateId AND @CompanyId IS NULL AND [AT].[IsDeleted] = 0
					END 
					ELSE
					BEGIN
						SELECT @TemplateName = [AT].[Name] FROM [APQP].[APQPTemplate] [AT] WHERE [AT].[CompanyId] = @CompanyId AND [AT].[Id] = @APQPTemplateId AND [AT].[IsDeleted] = 0
		
						SET @TemplateName = CONCAT('Clone-', @TemplateName);

						INSERT INTO [APQP].[APQPTemplate]  
						(	[Id]
							,[Name]
							,[Description]
							,[CompanyId]
							,[Created]
							,[CreatedBy]
							,[LastModified]
							,[LastModifiedBy]
							,[IsDeleted]
							,[IsActive]
							,[IsSystemDefault] 	)	
						SELECT @CloneAPQPTemplateId
							,@TemplateName
							,[AT].[Description]
							,[AT].[CompanyId]
							,GETUTCDATE()
							,@UserId
							,NULL
							,NULL
							,[AT].[IsDeleted]
							,[AT].[IsActive]
							,[AT].[IsSystemDefault]
						FROM [APQP].[APQPTemplate] [AT] 
						WHERE [AT].[Id] = @APQPTemplateId AND @CompanyId = @CompanyId AND [AT].[IsDeleted] = 0
					END
	
					--APQP Template Gates
					DECLARE @Gate TABLE (
						[Id] UNIQUEIDENTIFIER
						,[ReferenceId] UNIQUEIDENTIFIER
						,[Name]	NVARCHAR(50)
						,[Code]	NVARCHAR(50)
						,[Description]	NVARCHAR(MAX)
						,[APQPTemplateId] UNIQUEIDENTIFIER
						,[ReferenceTemplateId] UNIQUEIDENTIFIER
						,[IsDeleted] BIT
						,[SortOrder] INT	)

					INSERT INTO @Gate
					(	[Id] 
						,[ReferenceId]
						,[Name]
						,[Code]
						,[Description]	
						,[APQPTemplateId]
						,[ReferenceTemplateId]
						,[IsDeleted]
						,[SortOrder]	)
					SELECT 
						NEWID()
						,[G].[Id]
						,[G].[Name]
						,[G].[Code]
						,[G].[Description]
						,@CloneAPQPTemplateId
						,[G].[APQPTemplateId]
						,[G].[IsDeleted]
						,[G].[SortOrder]	
					FROM [APQP].[APQPTemplate] [AT] 
					JOIN [APQP].[Gate] [G]
						ON [AT].[Id] = [G].[APQPTemplateId]
					WHERE [AT].[Id] = @APQPTemplateId AND [AT].[IsDeleted] = 0 AND [G].[IsDeleted] = 0
	
					INSERT INTO [APQP].[Gate] 
					(	[Id]
						,[Name]
						,[Code]
						,[Description]
						,[APQPTemplateId]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]
						,[SortOrder]	)
					SELECT [G].[Id]
						,[G].[Name]
						,[G].[Code]
						,[G].[Description]
						,[G].[APQPTemplateId]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[G].[IsDeleted]
						,[G].[SortOrder]
					FROM @Gate [G]

					--Gate Custom Field Mappings
					INSERT INTO [CustomField].[CustomFieldGateMapping]
					(	[Id]
						,[CustomFieldId]
						,[APQPTemplateId]
						,[GateId]
						,[Order]
						,[Row]
						,[Column]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]	)
					SELECT NEWID() 
						,[CFGM].[CustomFieldId]
						,[G].[APQPTemplateId]
						,[G].[Id]
						,[CFGM].[Order]
						,[CFGM].[Row]
						,[CFGM].[Column]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[CFGM].[IsDeleted]	
					FROM @Gate [G]
					JOIN [CustomField].[CustomFieldGateMapping] [CFGM]
						ON [G].[ReferenceId] = [CFGM].[GateId]
						AND [G].[ReferenceTemplateId] = [CFGM].[APQPTemplateId]
					WHERE [CFGM].[IsDeleted] = 0 

					--Gate Closure Settings
					DECLARE @ClosureSetting TABLE (
						[Id] UNIQUEIDENTIFIER
						,[ReferenceId] UNIQUEIDENTIFIER
						,[GateId] UNIQUEIDENTIFIER
						,[GateReferenceId] UNIQUEIDENTIFIER
						,[ClouserType] INT
						,[IsDeleted] BIT
					)

					INSERT INTO @ClosureSetting
					(	[Id] 
						,[ReferenceId]
						,[GateId] 
						,[GateReferenceId]
						,[ClouserType] 
						,[IsDeleted]	)
					SELECT NEWID() 
						,[GCS].[Id]
						,[G].[Id]
						,[GCS].[GateId]
						,[GCS].[ClouserType]
						,[GCS].[IsDeleted]
					FROM @Gate [G]
					JOIN [APQP].[GateClosureSetting] [GCS]
						ON [G].[ReferenceId] = [GCS].[GateId]
					WHERE [GCS].[IsDeleted] = 0 

					INSERT INTO [APQP].[GateClosureSetting]
					(	[Id]
						,[GateId]
						,[ClouserType]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]	)
					SELECT [CS].[Id]
						,[CS].[GateId]
						,[CS].[ClouserType]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[CS].[IsDeleted]
					FROM @ClosureSetting [CS]

					--Gate Closure Approval 
					INSERT INTO [APQP].[GateClosureApproval]
					(	[Id]
						,[GateClosureSettingId]
						,[ApprovalFor]
						,[ApprovedBy]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[UserId]
						,[IsDeleted]	)
					SELECT NEWID()
						,[CS].[Id]
						,[GCA].[ApprovalFor]
						,[GCA].[ApprovedBy]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[GCA].[UserId] 
						,[GCA].[IsDeleted]	
					FROM @ClosureSetting [CS]
					JOIN [APQP].[GateClosureApproval] [GCA]
						ON [CS].[ReferenceId] = [GCA].[GateClosureSettingId]
					WHERE [CS].[ClouserType] = 3 AND [GCA].[IsDeleted] = 0

					--Gate Closure Document
					INSERT INTO [APQP].[GateClosureDocument]
					(	[Id]
						,[GateClosureSettingId]
						,[DocumentTypeId]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]	)
					SELECT NEWID()
						,[CS].[Id]
						,[GCD].[DocumentTypeId]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[GCD].[IsDeleted]	
					FROM @ClosureSetting [CS]
					JOIN [APQP].[GateClosureDocument] [GCD]
						ON [CS].[ReferenceId] = [GCD].[GateClosureSettingId]
					WHERE [CS].[ClouserType] = 2 AND [GCD].[IsDeleted] = 0

					--Gate Closure Email
					INSERT INTO [APQP].[GateClosureEmail]
					(	[Id]
						,[GateClosureSettingId]
						,[To]
						,[From]
						,[Subject]
						,[CC]
						,[BCC]
						,[Message]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]	)
					SELECT NEWID()
						,[CS].[Id]
						,[GCE].[To]
						,[GCE].[From]
						,[GCE].[Subject]
						,[GCE].[CC]
						,[GCE].[BCC]
						,[GCE].[Message]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[GCE].[IsDeleted]	
					FROM @ClosureSetting [CS]
					JOIN [APQP].[GateClosureEmail] [GCE]
						ON [CS].[ReferenceId] = [GCE].[GateClosureSettingId]
					WHERE [CS].[ClouserType] = 1 AND [GCE].[IsDeleted] = 0
				END";

        /// <summary>
        /// The body18052022
        /// </summary>
        public const string Body18052022 = @"CREATE OR ALTER PROCEDURE [APQP].[CloneAPQPTemplate]
				(
					@CompanyId UNIQUEIDENTIFIER = NULL,
					@UserId UNIQUEIDENTIFIER,
					@APQPTemplateId UNIQUEIDENTIFIER,
					@CloneAPQPTemplateId UNIQUEIDENTIFIER
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON

					DECLARE @TemplateName NVARCHAR(50);

					IF (@CompanyId IS NULL)
					BEGIN
						SELECT @TemplateName = [AT].[Name] FROM [APQP].[APQPTemplate] [AT] WHERE [AT].[CompanyId] IS NULL AND [AT].[Id] = @APQPTemplateId AND [AT].[IsDeleted] = 0

						SET @TemplateName = CONCAT('Clone-', @TemplateName);

						INSERT INTO [APQP].[APQPTemplate]  
						(	[Id]
							,[Name]
							,[Description]
							,[CompanyId]
							,[Created]
							,[CreatedBy]
							,[LastModified]
							,[LastModifiedBy]
							,[IsDeleted]
							,[IsActive]
							,[IsSystemDefault]
						)
						SELECT @CloneAPQPTemplateId
							,@TemplateName
							,[AT].[Description]
							,[AT].[CompanyId]
							,GETUTCDATE()
							,@UserId
							,NULL
							,NULL
							,[AT].[IsDeleted]
							,[AT].[IsActive]
							,[AT].[IsSystemDefault]
						FROM [APQP].[APQPTemplate] [AT] 
						WHERE [AT].[Id] = @APQPTemplateId AND @CompanyId IS NULL AND [AT].[IsDeleted] = 0
					END 
					ELSE
					BEGIN
						SELECT @TemplateName = [AT].[Name] FROM [APQP].[APQPTemplate] [AT] WHERE [AT].[CompanyId] = @CompanyId AND [AT].[Id] = @APQPTemplateId AND [AT].[IsDeleted] = 0
		
						SET @TemplateName = CONCAT('Clone-', @TemplateName);

						INSERT INTO [APQP].[APQPTemplate]  
						(	[Id]
							,[Name]
							,[Description]
							,[CompanyId]
							,[Created]
							,[CreatedBy]
							,[LastModified]
							,[LastModifiedBy]
							,[IsDeleted]
							,[IsActive]
							,[IsSystemDefault] 	)	
						SELECT @CloneAPQPTemplateId
							,@TemplateName
							,[AT].[Description]
							,[AT].[CompanyId]
							,GETUTCDATE()
							,@UserId
							,NULL
							,NULL
							,[AT].[IsDeleted]
							,[AT].[IsActive]
							,[AT].[IsSystemDefault]
						FROM [APQP].[APQPTemplate] [AT] 
						WHERE [AT].[Id] = @APQPTemplateId AND @CompanyId = @CompanyId AND [AT].[IsDeleted] = 0
					END
	
					--APQP Template Gates
					DECLARE @Gate TABLE (
						[Id] UNIQUEIDENTIFIER
						,[ReferenceId] UNIQUEIDENTIFIER
						,[Name]	NVARCHAR(50)
						,[Code]	NVARCHAR(50)
						,[Description]	NVARCHAR(MAX)
						,[APQPTemplateId] UNIQUEIDENTIFIER
						,[ReferenceTemplateId] UNIQUEIDENTIFIER
						,[IsDeleted] BIT
						,[SortOrder] INT	)

					INSERT INTO @Gate
					(	[Id] 
						,[ReferenceId]
						,[Name]
						,[Code]
						,[Description]	
						,[APQPTemplateId]
						,[ReferenceTemplateId]
						,[IsDeleted]
						,[SortOrder]	)
					SELECT 
						NEWID()
						,[G].[Id]
						,[G].[Name]
						,[G].[Code]
						,[G].[Description]
						,@CloneAPQPTemplateId
						,[G].[APQPTemplateId]
						,[G].[IsDeleted]
						,[G].[SortOrder]	
					FROM [APQP].[APQPTemplate] [AT] 
					JOIN [APQP].[Gate] [G]
						ON [AT].[Id] = [G].[APQPTemplateId]
					WHERE [AT].[Id] = @APQPTemplateId AND [AT].[IsDeleted] = 0 AND [G].[IsDeleted] = 0
	
					INSERT INTO [APQP].[Gate] 
					(	[Id]
						,[Name]
						,[Code]
						,[Description]
						,[APQPTemplateId]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]
						,[SortOrder]	)
					SELECT [G].[Id]
						,[G].[Name]
						,[G].[Code]
						,[G].[Description]
						,[G].[APQPTemplateId]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[G].[IsDeleted]
						,[G].[SortOrder]
					FROM @Gate [G]

					--Gate Custom Field Mappings
					INSERT INTO [CustomField].[CustomFieldGateMapping]
					(	[Id]
						,[CustomFieldId]
						,[APQPTemplateId]
						,[GateId]
						,[Order]
						,[Row]
						,[Column]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]	)
					SELECT NEWID() 
						,[CFGM].[CustomFieldId]
						,[G].[APQPTemplateId]
						,[G].[Id]
						,[CFGM].[Order]
						,[CFGM].[Row]
						,[CFGM].[Column]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[CFGM].[IsDeleted]	
					FROM @Gate [G]
					JOIN [CustomField].[CustomFieldGateMapping] [CFGM]
						ON [G].[ReferenceId] = [CFGM].[GateId]
						AND [G].[ReferenceTemplateId] = [CFGM].[APQPTemplateId]
					WHERE [CFGM].[IsDeleted] = 0 

					--Gate Closure Settings
					DECLARE @ClosureSetting TABLE (
						[Id] UNIQUEIDENTIFIER
						,[ReferenceId] UNIQUEIDENTIFIER
						,[GateId] UNIQUEIDENTIFIER
						,[GateReferenceId] UNIQUEIDENTIFIER
						,[ClouserType] INT
						,[IsDeleted] BIT
					)

					INSERT INTO @ClosureSetting
					(	[Id] 
						,[ReferenceId]
						,[GateId] 
						,[GateReferenceId]
						,[ClouserType] 
						,[IsDeleted]	)
					SELECT NEWID() 
						,[GCS].[Id]
						,[G].[Id]
						,[GCS].[GateId]
						,[GCS].[ClouserType]
						,[GCS].[IsDeleted]
					FROM @Gate [G]
					JOIN [APQP].[GateClosureSetting] [GCS]
						ON [G].[ReferenceId] = [GCS].[GateId]
					WHERE [GCS].[IsDeleted] = 0 

					INSERT INTO [APQP].[GateClosureSetting]
					(	[Id]
						,[GateId]
						,[ClouserType]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]	)
					SELECT [CS].[Id]
						,[CS].[GateId]
						,[CS].[ClouserType]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[CS].[IsDeleted]
					FROM @ClosureSetting [CS]

					--Gate Closure Approval 
					DECLARE @ClosureApproval TABLE (
						[Id] UNIQUEIDENTIFIER
						,[ReferenceId] UNIQUEIDENTIFIER
						,[GateClosureSettingId] UNIQUEIDENTIFIER
						,[GateClosureSettingReferenceId] UNIQUEIDENTIFIER
						,[ApprovalFor] NVARCHAR(100)
						,[ApprovedBy] NVARCHAR(50)
						,[UserId] UNIQUEIDENTIFIER
						,[IsDeleted] BIT
						,[ApprovalType] INT
						,[MinApprover] INT
					)

					INSERT INTO @ClosureApproval
					(	[Id] 
						,[ReferenceId]
						,[GateClosureSettingId]
						,[GateClosureSettingReferenceId]
						,[ApprovalFor]
						,[ApprovedBy]
						,[UserId] 
						,[IsDeleted]
						,[ApprovalType]
						,[MinApprover])
					SELECT NEWID() 
						,[GCA].[Id]
						,[CS].[Id]
						,[GCA].[GateClosureSettingId]
						,[GCA].[ApprovalFor]
						,[GCA].[ApprovedBy]
						,[GCA].[UserId] 
						,[GCA].[IsDeleted]
						,[GCA].[ApprovalType]
						,[GCA].[MinApprover]
					FROM @ClosureSetting [CS]
					JOIN [APQP].[GateClosureApproval] [GCA]
						ON [CS].[ReferenceId] = [GCA].[GateClosureSettingId]
					WHERE [CS].[ClouserType] = 3 AND [GCA].[IsDeleted] = 0

					INSERT INTO [APQP].[GateClosureApproval]
					(	[Id]
						,[GateClosureSettingId]
						,[ApprovalFor]
						,[ApprovedBy]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[UserId]
						,[IsDeleted]
						,[ApprovalType]
						,[MinApprover])
					SELECT [CA].[Id]
						,[CA].[GateClosureSettingId]
						,[CA].[ApprovalFor]
						,[CA].[ApprovedBy]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[CA].[UserId] 
						,[CA].[IsDeleted]
						,[CA].[ApprovalType]
						,[CA].[MinApprover]
					FROM  @ClosureApproval [CA]

					-- Approver
					INSERT INTO [APQP].[Approver](
					[Id],
					[GateClosureApprovalId],
					[UserId],
					[RequiredApprover],
					[ChainOrder],
					[Created],
					[CreatedBy],
					[LastModified],
					[LastModifiedBy],
					[IsDeleted])
					SELECT NEWID() 
						,[CA].[Id]
						,[A].[UserId]
						,[A].[RequiredApprover]
						,[A].[ChainOrder]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[A].[IsDeleted]
					FROM @ClosureApproval [CA]
					JOIN [APQP].[Approver] [A]
						ON [CA].[ReferenceId] = [A].[GateClosureApprovalId]
					WHERE [A].[IsDeleted] = 0

					--Gate Closure Document
					INSERT INTO [APQP].[GateClosureDocument]
					(	[Id]
						,[GateClosureSettingId]
						,[DocumentTypeId]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]	)
					SELECT NEWID()
						,[CS].[Id]
						,[GCD].[DocumentTypeId]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[GCD].[IsDeleted]	
					FROM @ClosureSetting [CS]
					JOIN [APQP].[GateClosureDocument] [GCD]
						ON [CS].[ReferenceId] = [GCD].[GateClosureSettingId]
					WHERE [CS].[ClouserType] = 2 AND [GCD].[IsDeleted] = 0

					--Gate Closure Email
					INSERT INTO [APQP].[GateClosureEmail]
					(	[Id]
						,[GateClosureSettingId]
						,[To]
						,[From]
						,[Subject]
						,[CC]
						,[BCC]
						,[Message]
						,[Created]
						,[CreatedBy]
						,[LastModified]
						,[LastModifiedBy]
						,[IsDeleted]	)
					SELECT NEWID()
						,[CS].[Id]
						,[GCE].[To]
						,[GCE].[From]
						,[GCE].[Subject]
						,[GCE].[CC]
						,[GCE].[BCC]
						,[GCE].[Message]
						,GETUTCDATE()
						,@UserId
						,NULL
						,NULL
						,[GCE].[IsDeleted]	
					FROM @ClosureSetting [CS]
					JOIN [APQP].[GateClosureEmail] [GCE]
						ON [CS].[ReferenceId] = [GCE].[GateClosureSettingId]
					WHERE [CS].[ClouserType] = 1 AND [GCE].[IsDeleted] = 0
				END";
    }
}
