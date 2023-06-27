// <copyright file="GetAPQPDiscussions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.APQP
{
    /// <summary>
    /// Class GetAPQPDiscussions.
    /// </summary>
    public class GetAPQPDiscussions
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [APQP].[GetAPQPDiscussions]
				(
					@APQPId UNIQUEIDENTIFIER,
					@CompanyId uniqueidentifier
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON

						SELECT 
							[D].[Id]
							,[D].[CompanyId]
							,[D].[APQPId]
							,[A].[Name] [APQPName]
							,[D].[ParentDiscussionId]
							,NULL [ParentNotes]
							,[D].[Notes]
							,[D].[UserId]
							,[D].[Created]
						FROM [APQP].[APQP] [A]
						JOIN [APQP].[Discussion] [D]
							ON [A].[Id] = [D].[APQPId]
						WHERE [A].[Id] = @APQPId AND [A].[CompanyId] = @CompanyId AND [A].[IsDeleted] = 0 
							AND [D].[IsDeleted] = 0 AND [D].[ParentDiscussionId] IS NULL

						UNION ALL

						SELECT 
							[D].[Id]
							,[D].[CompanyId]
							,[D].[APQPId]
							,[A].[Name] [APQPName]
							,[D].[ParentDiscussionId]
							,(SELECT [PD].[Notes] FROM [APQP].[Discussion] [PD] WHERE [PD].[Id] = [D].[ParentDiscussionId]) [ParentNotes]
							,[D].[Notes]
							,[D].[UserId]
							,[D].[Created]
						FROM [APQP].[APQP] [A]
						JOIN [APQP].[Discussion] [D]
							ON [A].[Id] = [D].[APQPId]
						WHERE [A].[Id] = @APQPId AND [A].[CompanyId] = @CompanyId AND [A].[IsDeleted] = 0 
							AND [D].[IsDeleted] = 0 AND [D].[ParentDiscussionId] IS NOT NULL
						ORDER BY [D].[Created] ASC

						-- APQP Discussion Attachments

						SELECT 
							[DA].[Id]
							,[DA].[CompanyId]
							,[DA].[DocumentTypeId]
							,[DA].[EntityId]
							,[DA].[FileName]
							,[DA].[FilePath]
							,[DA].[ContentType]
							,[DA].[FileSize]
						FROM [APQP].[APQP] [A]
						JOIN [APQP].[Discussion] [D]
							ON [A].[Id] = [D].[APQPId]
						JOIN [Document].[Document] [DA]
							ON [DA].[EntityId] = [D].[Id] 
						JOIN [Setup].[DocumentType] [DT]
							ON [DA].[DocumentTypeId] = [DT].[Id] 
						WHERE [A].[Id] = @APQPId AND [A].[CompanyId] = @CompanyId AND [A].[IsDeleted] = 0 
							AND [D].[IsDeleted] = 0 AND [D].[ParentDiscussionId] IS NULL 
							AND [DA].[IsDeleted] = 0 
							AND [DT].[Code] = 'Discussion' AND [DT].[IsDeleted] = 0

						UNION ALL

						SELECT 
							[DA].[Id]
							,[DA].[CompanyId]
							,[DA].[DocumentTypeId]
							,[DA].[EntityId]
							,[DA].[FileName]
							,[DA].[FilePath]
							,[DA].[ContentType]
							,[DA].[FileSize]
						FROM [APQP].[APQP] [A]
						JOIN [APQP].[Discussion] [D]
							ON [A].[Id] = [D].[APQPId]
						JOIN [Document].[Document] [DA]
							ON [DA].[EntityId] = [D].[Id] 
						JOIN [Setup].[DocumentType] [DT]
							ON [DA].[DocumentTypeId] = [DT].[Id] 
						WHERE [A].[Id] = @APQPId AND [A].[CompanyId] = @CompanyId AND [A].[IsDeleted] = 0 
							AND [D].[IsDeleted] = 0 AND [D].[ParentDiscussionId] IS NOT NULL
							AND [DA].[IsDeleted] = 0 
							AND [DT].[Code] = 'Discussion' AND [DT].[IsDeleted] = 0
				END";
    }
}
