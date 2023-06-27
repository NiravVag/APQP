// <copyright file="GetAPQPDocuments.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.APQP
{
    /// <summary>
    /// Class GetPartAPQPDocuments.
    /// </summary>
    public class GetAPQPDocuments
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"ALTER  PROCEDURE [APQP].[GetAPQPDocuments]
									(
										@APQPTemplateId UNIQUEIDENTIFIER,
										@SearchText NVARCHAR(25) = NULL,
										@PageNumber INT,
										@PageSize INT,
										@SortBy NVARCHAR(25) = NULL,
										@SortOrder NVARCHAR(4) = NULL,
										@TotalRecords INT OUTPUT
									)
									AS
									BEGIN
	
										SET NOCOUNT ON

										DECLARE @APQPDocument TABLE(
												[Id] UNIQUEIDENTIFIER
												,[GateId] UNIQUEIDENTIFIER
												,[GateName]  NVARCHAR(50)
												,[EntityId] UNIQUEIDENTIFIER
												,[ReferanceId] UNIQUEIDENTIFIER
												,[Created] DATETIME2
												,[CreatedBy] NVARCHAR(50)
												,[DocumentTypeId] UNIQUEIDENTIFIER
												,[FileName] NVARCHAR(200)
												,[FilePath] NVARCHAR(300)
												,[LastModified] DATETIME2
												,[LastModifiedBy] NVARCHAR(50)
												,[DocumentType] NVARCHAR(50)
												)

												
							INSERT INTO @APQPDocument 
							(
												[Id] 
												,[GateName] 
												,[GateId]
												,[EntityId] 
												,[ReferanceId] 
												,[Created] 
												,[CreatedBy] 
												,[DocumentTypeId] 
												,[FileName] 
												,[FilePath] 
												,[LastModified] 
												,[LastModifiedBy] 
												,[DocumentType] 
												)

												SELECT [D].[Id]
												,[A].[Name] AS GateName
												,[A].[Id] AS GateId
												,[D].[EntityId]
												,[D].[ReferanceId]
												,[D].[Created]
												,[D].[CreatedBy]
												,[D].[DocumentTypeId]
												,[D].[FileName]
												,[D].[FilePath]
												,[D].[LastModified]
												,[D].[LastModifiedBy]
												,[DT].[Name] AS DocumentType
												FROM [Document].[Document] D
											LEFT OUTER JOIN [APQP].[Gate] A ON [D].[ReferanceId] = [A].[Id]
											JOIN [Setup].[DocumentType] DT ON [D].[DocumentTypeId] = [DT].[Id]
											WHERE [EntityId] = @APQPTemplateId AND [D].[IsDeleted]=0
											AND (@SearchText IS NULL OR [A].[Name] LIKE + '%' + @SearchText + '%' OR [D].[FileName] LIKE + '%' + @SearchText + '%' OR [DT].[Name] LIKE + '%' + @SearchText + '%')
											
											SELECT [Document].[Id]
												,[Document].[GateName]
												,[Document].[GateId]
												,[Document].[EntityId]
												,[Document].[ReferanceId]
												,[Document].[Created]
												,[Document].[CreatedBy]
												,[Document].[DocumentTypeId]
												,[Document].[FileName]
												,[Document].[FilePath]
												,[Document].[LastModified]
												,[Document].[LastModifiedBy]
												,[Document].[DocumentType] 
												FROM @APQPDocument [Document]
											GROUP BY [Document].[Id]
												,[Document].[GateName] 
												,[Document].[GateId]
												,[Document].[EntityId]
												,[Document].[ReferanceId]
												,[Document].[Created]
												,[Document].[CreatedBy]
												,[Document].[DocumentTypeId]
												,[Document].[FileName]
												,[Document].[FilePath]
												,[Document].[LastModified]
												,[Document].[LastModifiedBy]
												,[Document].[DocumentType] 
												ORDER BY
							CASE WHEN @SortBy = 'fileName' AND @SortOrder = 'asc'
								THEN [Document].[FileName]
								END ASC,
							CASE WHEN @SortBy = 'fileName' AND @SortOrder = 'desc'
								THEN [Document].[FileName]
								END DESC,
							CASE WHEN @SortBy = 'gateName' AND @SortOrder = 'asc'
								THEN [Document].[GateName]
								END ASC,
							CASE WHEN @SortBy = 'gatename' AND @SortOrder = 'desc'
								THEN [Document].[GateName]
								END DESC,
							CASE WHEN @SortBy = 'documenttype' AND @SortOrder = 'asc'
								THEN [Document].[DocumentType]
								END ASC,
							CASE WHEN @SortBy = 'documenttype' AND @SortOrder = 'desc'
								THEN [Document].[DocumentType]
								END DESC,
								CASE WHEN @SortBy = 'created' AND @SortOrder = 'asc'
								THEN [Document].[Created]
								END ASC,
							CASE WHEN @SortBy = 'created' AND @SortOrder = 'desc'
								THEN [Document].[Created]
								END DESC

								OFFSET(@PageNumber - 1) * @PageSize ROWS

						FETCH NEXT @PageSize ROWS ONLY

						SELECT @TotalRecords = Count([Document].[Id]) FROM @APQPDocument [Document]
						
											END";

		public const string Body15062022 = @"ALTER  PROCEDURE [APQP].[GetAPQPDocuments]
									(
										@APQPTemplateId UNIQUEIDENTIFIER,
										@SearchText NVARCHAR(25) = NULL,
										@PageNumber INT,
										@PageSize INT,
										@SortBy NVARCHAR(25) = NULL,
										@SortOrder NVARCHAR(4) = NULL,
										@TotalRecords INT OUTPUT
									)
									AS
									BEGIN
	
										SET NOCOUNT ON

										DECLARE @APQPDocument TABLE(
												[Id] UNIQUEIDENTIFIER
												,[GateId] UNIQUEIDENTIFIER
												,[GateName]  NVARCHAR(50)
												,[EntityId] UNIQUEIDENTIFIER
												,[ReferanceId] UNIQUEIDENTIFIER
												,[Created] DATETIME2
												,[CreatedBy] NVARCHAR(50)
												,[DocumentTypeId] UNIQUEIDENTIFIER
												,[FileName] NVARCHAR(200)
												,[FilePath] NVARCHAR(300)
												,[LastModified] DATETIME2
												,[LastModifiedBy] NVARCHAR(50)
												,[DocumentType] NVARCHAR(200)
												)

												
							INSERT INTO @APQPDocument 
							(
												[Id] 
												,[GateName] 
												,[GateId]
												,[EntityId] 
												,[ReferanceId] 
												,[Created] 
												,[CreatedBy] 
												,[DocumentTypeId] 
												,[FileName] 
												,[FilePath] 
												,[LastModified] 
												,[LastModifiedBy] 
												,[DocumentType] 
												)

												SELECT [D].[Id]
												,[A].[Name] AS GateName
												,[A].[Id] AS GateId
												,[D].[EntityId]
												,[D].[ReferanceId]
												,[D].[Created]
												,[D].[CreatedBy]
												,[D].[DocumentTypeId]
												,[D].[FileName]
												,[D].[FilePath]
												,[D].[LastModified]
												,[D].[LastModifiedBy]
												,[DT].[Name] AS DocumentType
												FROM [Document].[Document] D
											LEFT OUTER JOIN [APQP].[Gate] A ON [D].[ReferanceId] = [A].[Id]
											JOIN [Setup].[DocumentType] DT ON [D].[DocumentTypeId] = [DT].[Id]
											WHERE [EntityId] = @APQPTemplateId AND [D].[IsDeleted]=0
											AND (@SearchText IS NULL OR [A].[Name] LIKE + '%' + @SearchText + '%' OR [D].[FileName] LIKE + '%' + @SearchText + '%' OR [DT].[Name] LIKE + '%' + @SearchText + '%')
											
											SELECT [Document].[Id]
												,[Document].[GateName]
												,[Document].[GateId]
												,[Document].[EntityId]
												,[Document].[ReferanceId]
												,[Document].[Created]
												,[Document].[CreatedBy]
												,[Document].[DocumentTypeId]
												,[Document].[FileName]
												,[Document].[FilePath]
												,[Document].[LastModified]
												,[Document].[LastModifiedBy]
												,[Document].[DocumentType] 
												FROM @APQPDocument [Document]
											GROUP BY [Document].[Id]
												,[Document].[GateName] 
												,[Document].[GateId]
												,[Document].[EntityId]
												,[Document].[ReferanceId]
												,[Document].[Created]
												,[Document].[CreatedBy]
												,[Document].[DocumentTypeId]
												,[Document].[FileName]
												,[Document].[FilePath]
												,[Document].[LastModified]
												,[Document].[LastModifiedBy]
												,[Document].[DocumentType] 
												ORDER BY
							CASE WHEN @SortBy = 'fileName' AND @SortOrder = 'asc'
								THEN [Document].[FileName]
								END ASC,
							CASE WHEN @SortBy = 'fileName' AND @SortOrder = 'desc'
								THEN [Document].[FileName]
								END DESC,
							CASE WHEN @SortBy = 'gateName' AND @SortOrder = 'asc'
								THEN [Document].[GateName]
								END ASC,
							CASE WHEN @SortBy = 'gatename' AND @SortOrder = 'desc'
								THEN [Document].[GateName]
								END DESC,
							CASE WHEN @SortBy = 'documenttype' AND @SortOrder = 'asc'
								THEN [Document].[DocumentType]
								END ASC,
							CASE WHEN @SortBy = 'documenttype' AND @SortOrder = 'desc'
								THEN [Document].[DocumentType]
								END DESC,
								CASE WHEN @SortBy = 'created' AND @SortOrder = 'asc'
								THEN [Document].[Created]
								END ASC,
							CASE WHEN @SortBy = 'created' AND @SortOrder = 'desc'
								THEN [Document].[Created]
								END DESC

								OFFSET(@PageNumber - 1) * @PageSize ROWS

						FETCH NEXT @PageSize ROWS ONLY

						SELECT @TotalRecords = Count([Document].[Id]) FROM @APQPDocument [Document]
						
											END";
	}
}
