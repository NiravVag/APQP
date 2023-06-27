// <copyright file="GetPartAPQPDocuments.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.APQP
{
    /// <summary>
    /// Class GetPartAPQPDocuments.
    /// </summary>
    public class GetPartAPQPDocuments
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE OR ALTER PROCEDURE [APQP].[GetPartAPQPDocuments]
									(
										@APQPTemplateId UNIQUEIDENTIFIER
									)
									AS
									BEGIN
	
										SET NOCOUNT ON

												SELECT [D].[Id]
												,[A].[Name]
												,[D].[EntityId]
												,[D].[ReferanceId]
												,[D].[Created]
												,[D].[CreatedBy]
												,[D].[DocumentTypeId]
												,[D].[FileName]
												,[D].[FilePath]
												,[D].[LastModified]
												,[D].[LastModifiedBy]
												,[DT].[Name] as DocumentType
												FROM [Document].[Document] D
											LEFT OUTER JOIN [APQP].[Gate] A ON [D].[ReferanceId] = [A].[Id]
											JOIN [Setup].[DocumentType] DT ON [D].[DocumentTypeId] = [DT].[Id]
											WHERE [EntityId] = @APQPTemplateId AND [D].[IsDeleted]=0
											END";
    }
}
