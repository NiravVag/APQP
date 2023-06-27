// <copyright file="GetAPQPTemplates.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.APQPTemplate
{
    /// <summary>
    /// Class GetAPQPTemplates.
    /// </summary>
    public class GetAPQPTemplates
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [APQP].[GetAPQPTemplates]
				(
					@CompanyId UNIQUEIDENTIFIER = NULL,
					@SearchText NVARCHAR(25) = NULL,
					@IsDeleted BIT,
					@PageNumber INT,
					@PageSize INT,
					@SortBy NVARCHAR(25) = NULL,
					@SortOrder NVARCHAR(4) = NULL,
					@TotalRecords INT OUTPUT
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON

					DECLARE @APQPTemplate TABLE(
						[Id] UNIQUEIDENTIFIER
						,[Name] NVARCHAR(50)
						,[Description] NVARCHAR(300) NULL
						,[CompanyId] UNIQUEIDENTIFIER NULL
						,[Created] DATETIME2
						,[IsActive] BIT
						,[IsSystemDefault] BIT
					)

					IF(@CompanyId IS NULL)
					BEGIN
						INSERT INTO @APQPTemplate 
						(
							[Id]
							,[Name]
							,[Description]
							,[CompanyId]
							,[Created]
							,[IsActive]
							,[IsSystemDefault]
						)
						SELECT 
							[AT].[Id]
							,[AT].[Name]
							,[AT].[Description]
							,[AT].[CompanyId]
							,[AT].[Created]
							,[AT].[IsActive]
							,[AT].[IsSystemDefault]
						FROM [APQP].[APQPTemplate] [AT]
						WHERE [AT].[IsDeleted] = @IsDeleted AND [AT].[CompanyId] IS NULL
							AND (@SearchText IS NULL OR [AT].[Name] LIKE + '%' + @SearchText + '%')
					END
					ELSE
					BEGIN
						INSERT INTO @APQPTemplate 
						(
							[Id]
							,[Name]
							,[Description]
							,[CompanyId]
							,[Created]
							,[IsActive]
							,[IsSystemDefault]
						)
						SELECT [AT].[Id]
							,[AT].[Name]
							,[AT].[Description]
							,[AT].[CompanyId]
							,[AT].[Created]
							,[AT].[IsActive]
							,[AT].[IsSystemDefault]
						FROM [APQP].[APQPTemplate] [AT]
						WHERE [AT].[IsDeleted] = @IsDeleted AND [AT].[CompanyId] = @CompanyId
							AND (@SearchText IS NULL OR [AT].[Name] LIKE + '%' + @SearchText + '%')
					END

					SELECT	
						[Template].[Id]
						,[Template].[Name]
						,[Template].[Description]
						,[Template].[CompanyId]
						,[Template].[Created]
						,[Template].[IsActive]
						,[Template].[IsSystemDefault]
						,COUNT(DISTINCT [A].[PartId]) [AssociatedParts]
						,COUNT(DISTINCT [G].[Id]) [TotalGates]
					FROM @APQPTemplate [Template]
					LEFT JOIN [APQP].[APQP] [A]
						ON [Template].[Id] = [A].[APQPTemplateId]
						AND [Template].[CompanyId] = [A].[CompanyId]
						AND [A].[IsDeleted] = 0 
					LEFT JOIN [APQP].[Gate] [G]
						ON [Template].[Id] = [G].[APQPTemplateId]
						AND [G].[IsDeleted] = 0
					GROUP BY [Template].[Id]
						,[Template].[Name]
						,[Template].[Description]
						,[Template].[CompanyId]
						,[Template].[Created]
						,[Template].[IsActive]
						,[Template].[IsSystemDefault]
					ORDER BY
						CASE WHEN @SortBy = 'name' AND @SortOrder = 'asc'
							THEN [Template].[Name]
							END ASC,
						CASE WHEN @SortBy = 'name' AND @SortOrder = 'desc'
							THEN [Template].[Name]
							END DESC,
						CASE WHEN @SortBy = 'created' AND @SortOrder = 'asc'
							THEN [Template].[Created]
							END ASC,
						CASE WHEN @SortBy = 'created' AND @SortOrder = 'desc'
							THEN [Template].[Created]
							END DESC,
						CASE WHEN @SortBy = 'isSystemDefault' AND @SortOrder = 'asc'
							THEN [Template].[IsSystemDefault]
							END ASC,
						CASE WHEN @SortBy = 'isSystemDefault' AND @SortOrder = 'desc'
							THEN [Template].[IsSystemDefault]
							END DESC,
						CASE WHEN @SortBy IS NULL AND @SortOrder IS NULL
							THEN [Template].[IsSystemDefault]
							END DESC
		
					OFFSET(@PageNumber - 1) * @PageSize ROWS

					FETCH NEXT @PageSize ROWS ONLY

					SELECT @TotalRecords = Count([Template].[Id]) FROM @APQPTemplate [Template]
				END";

        /// <summary>
        /// The body02062022
        /// </summary>
        public const string Body02062022 = @"CREATE OR ALTER PROCEDURE [APQP].[GetAPQPTemplates]
					(
						@CompanyId UNIQUEIDENTIFIER = NULL,
						@SearchText NVARCHAR(25) = NULL,
						@IsDeleted BIT,
						@PageNumber INT,
						@PageSize INT,
						@SortBy NVARCHAR(25) = NULL,
						@SortOrder NVARCHAR(4) = NULL,
						@TotalRecords INT OUTPUT
					)
					AS
					BEGIN
						-- SET NOCOUNT ON added to prevent extra result sets from
						-- interfering with SELECT statements.
						SET NOCOUNT ON

						DECLARE @APQPTemplate TABLE(
							[Id] UNIQUEIDENTIFIER
							,[Name] NVARCHAR(50)
							,[Description] NVARCHAR(300) NULL
							,[CompanyId] UNIQUEIDENTIFIER NULL
							,[Created] DATETIME2
							,[IsActive] BIT
							,[IsSystemDefault] BIT
						)

						IF(@CompanyId IS NULL)
						BEGIN
							INSERT INTO @APQPTemplate 
							(
								[Id]
								,[Name]
								,[Description]
								,[CompanyId]
								,[Created]
								,[IsActive]
								,[IsSystemDefault]
							)
							SELECT 
								[AT].[Id]
								,[AT].[Name]
								,[AT].[Description]
								,[AT].[CompanyId]
								,[AT].[Created]
								,[AT].[IsActive]
								,[AT].[IsSystemDefault]
							FROM [APQP].[APQPTemplate] [AT]
							WHERE [AT].[IsDeleted] = @IsDeleted AND [AT].[CompanyId] IS NULL
								AND (@SearchText IS NULL OR [AT].[Name] LIKE + '%' + @SearchText + '%')
						END
						ELSE
						BEGIN
							INSERT INTO @APQPTemplate 
							(
								[Id]
								,[Name]
								,[Description]
								,[CompanyId]
								,[Created]
								,[IsActive]
								,[IsSystemDefault]
							)
							SELECT [AT].[Id]
								,[AT].[Name]
								,[AT].[Description]
								,[AT].[CompanyId]
								,[AT].[Created]
								,[AT].[IsActive]
								,[AT].[IsSystemDefault]
							FROM [APQP].[APQPTemplate] [AT]
							WHERE [AT].[IsDeleted] = @IsDeleted AND [AT].[CompanyId] = @CompanyId
								AND (@SearchText IS NULL OR [AT].[Name] LIKE + '%' + @SearchText + '%')
						END

						SELECT	
							[Template].[Id]
							,[Template].[Name]
							,[Template].[Description]
							,[Template].[CompanyId]
							,[Template].[Created]
							,[Template].[IsActive]
							,[Template].[IsSystemDefault]
							,COUNT(DISTINCT [P].[Id]) [AssociatedParts]
							,COUNT(DISTINCT [G].[Id]) [TotalGates]
						FROM @APQPTemplate [Template]
						LEFT JOIN [APQP].[APQP] [A]
							ON [Template].[Id] = [A].[APQPTemplateId]
							AND [Template].[CompanyId] = [A].[CompanyId]
							AND [A].[IsDeleted] = 0 
						LEFT JOIN [APQP].[Gate] [G]
							ON [Template].[Id] = [G].[APQPTemplateId]
							AND [G].[IsDeleted] = 0
						LEFT JOIN [APQP].[Part] [P]
							ON [A].[PartId]=[P].[Id] 
							AND [P].[IsDeleted]=0
						GROUP BY [Template].[Id]
							,[Template].[Name]
							,[Template].[Description]
							,[Template].[CompanyId]
							,[Template].[Created]
							,[Template].[IsActive]
							,[Template].[IsSystemDefault]
						ORDER BY
							CASE WHEN @SortBy = 'name' AND @SortOrder = 'asc'
								THEN [Template].[Name]
								END ASC,
							CASE WHEN @SortBy = 'name' AND @SortOrder = 'desc'
								THEN [Template].[Name]
								END DESC,
							CASE WHEN @SortBy = 'created' AND @SortOrder = 'asc'
								THEN [Template].[Created]
								END ASC,
							CASE WHEN @SortBy = 'created' AND @SortOrder = 'desc'
								THEN [Template].[Created]
								END DESC,
							CASE WHEN @SortBy = 'isSystemDefault' AND @SortOrder = 'asc'
								THEN [Template].[IsSystemDefault]
								END ASC,
							CASE WHEN @SortBy = 'isSystemDefault' AND @SortOrder = 'desc'
								THEN [Template].[IsSystemDefault]
								END DESC,
							CASE WHEN @SortBy IS NULL AND @SortOrder IS NULL
								THEN [Template].[IsSystemDefault]
								END DESC
		
						OFFSET(@PageNumber - 1) * @PageSize ROWS

						FETCH NEXT @PageSize ROWS ONLY

						SELECT @TotalRecords = Count([Template].[Id]) FROM @APQPTemplate [Template]
					END";
    }
}
