// <copyright file="GetCustomFields.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.CustomField
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class GetCustomFields.
    /// </summary>
    public class GetCustomFields
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [CustomField].[GetCustomFields]
                (
                    @CompanyId UNIQUEIDENTIFIER,
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


                    SET @SortBy = LOWER(ISNULL(@SortBy, ''))

                    SET @SortOrder = LOWER(ISNULL(@SortOrder, ''))


                    SELECT
                        [CF].[Id]

                        , [CF].[Name]

                        , [CF].[FieldType]

                        , [CF].[IsRequired]

                        , [CF].[IsPredefindField]

                        , [CF].[IsActive]
                    FROM [CustomField].[CustomField] [CF]
                    WHERE [CF].[CompanyId] = @CompanyId AND[CF].[IsDeleted] = @IsDeleted

                    AND (@SearchText IS NULL OR[CF].[Name] LIKE + '%' + @SearchText + '%')
                    ORDER BY
                    CASE WHEN @SortBy = 'name' AND @SortOrder = 'asc'
                    THEN[CF].[Name]
                        END ASC,
                   CASE WHEN @SortBy = 'name' AND @SortOrder = 'desc'
                    THEN[CF].[Name]
                        END DESC,
                   CASE WHEN @SortBy = 'isActive' AND @SortOrder = 'asc'
                    THEN[CF].[IsActive]
                        END ASC,
                   CASE WHEN @SortBy = 'isActive' AND @SortOrder = 'desc'
                    THEN[CF].[IsActive]
                        END DESC,
                   CASE WHEN @SortBy = 'isRequired' AND @SortOrder = 'asc'
                    THEN[CF].[IsRequired]
                        END ASC,
                   CASE WHEN @SortBy = 'isRequired' AND @SortOrder = 'desc'
                    THEN[CF].[IsRequired]
                        END DESC,
                   CASE WHEN @SortBy = 'fieldType' AND @SortOrder = 'asc'
                    THEN[CF].[FieldType]
                        END ASC,
                   CASE WHEN @SortBy = 'fieldType' AND @SortOrder = 'desc'
                    THEN[CF].[FieldType]
                        END DESC,
                   CASE WHEN @SortBy IS NULL AND @SortOrder IS NULL
                    THEN[CF].[Name]
                        END

                   OFFSET(@PageNumber - 1) * @PageSize ROWS

                    FETCH NEXT @PageSize ROWS ONLY

                    SELECT @TotalRecords = Count([CF].[Id]) FROM[CustomField].[CustomField] [CF]
                    WHERE[CF].[CompanyId] = @CompanyId AND[CF].[IsDeleted] = @IsDeleted
                        AND(@SearchText IS NULL OR [CF].[Name] LIKE + '%' + @SearchText + '%')
                END";
    }
}
