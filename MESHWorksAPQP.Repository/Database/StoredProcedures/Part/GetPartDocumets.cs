// <copyright file="GetPartDocumets.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Part
{
    /// <summary>
    /// Class GetPartDocumets.
    /// </summary>
    public class GetPartDocumets
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"ALTER   PROCEDURE [APQP].[GetPartDocuments]
									(
										@APQPTemplateId UNIQUEIDENTIFIER,
										@PageNumber INT,
										@PageSize INT,
										@SortBy NVARCHAR(25) = NULL,
										@SortOrder NVARCHAR(4) = NULL,
										@TotalRecords INT OUTPUT
									)
									AS
									BEGIN
	
										SET NOCOUNT ON

												SELECT [D].[Id]	
												,[D].[EntityId]
												,[D].[ReferanceId]
												,[D].[Created]
												,[D].[CreatedBy]
												,[D].[DocumentTypeId]
												,[D].[FileName]
												,[D].[FilePath]
												,[D].[LastModified]
												,[D].[LastModifiedBy]
												FROM [Document].[Document] D
											    
											WHERE [EntityId] = @APQPTemplateId AND [D].[IsDeleted]=0
											GROUP BY [D].[Id]
												,[D].[EntityId]
												,[D].[ReferanceId]
												,[D].[Created]
												,[D].[CreatedBy]
												,[D].[DocumentTypeId]
												,[D].[FileName]
												,[D].[FilePath]
												,[D].[LastModified]
												,[D].[LastModifiedBy]
													ORDER BY
							CASE WHEN @SortBy = 'filename' AND @SortOrder = 'asc'
								THEN [D].[FileName]
								END ASC,
							CASE WHEN @SortBy = 'filename' AND @SortOrder = 'desc'
								THEN [D].[FileName]
								END DESC,
								CASE WHEN @SortBy = 'created' AND @SortOrder = 'asc'
								THEN [D].[Created]
								END ASC,
							CASE WHEN @SortBy = 'created' AND @SortOrder = 'desc'
								THEN [D].[Created]
								END DESC

								OFFSET(@PageNumber - 1) * @PageSize ROWS

						FETCH NEXT @PageSize ROWS ONLY

						SELECT @TotalRecords = Count([D].[Id]) FROM [Document].[Document] D WHERE [EntityId] = @APQPTemplateId AND [D].[IsDeleted]=0
							END";
    }
}