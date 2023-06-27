// <copyright file="GetPartRelations.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Part
{
    /// <summary>
    /// Class GetPartRelations.
    /// </summary>
    public class GetPartRelations
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [APQP].[GetPartRelations]
				(
					@PartId UNIQUEIDENTIFIER,
					@CompanyId UNIQUEIDENTIFIER
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					SET NOCOUNT ON
					;WITH [ParentParts] AS
					(
						SELECT
							[P].[Id]
							,[P].[PartNumber] [Name]
							,[PR].[ParentPartId]
							,1 [Level]
						FROM [APQP].[Part] [P]
						JOIN [APQP].[PartRelation] [PR]
							ON [P].[Id] = [PR].[PartId]
						WHERE [P].Id = @PartId

						UNION ALL

						SELECT [P].[Id]
								,[P].[PartNumber] [Name]
								,[PR].[ParentPartId]
								,[Level] = [PP].[Level] - 1
						FROM [APQP].[Part] [P]
						JOIN [APQP].[PartRelation] [PR]
							ON [P].[Id] = [PR].[PartId]
						JOIN [ParentParts] [PP]
							ON [PR].[PartId] = [PP].[ParentPartId]
					)

					,[ChildParts] AS
					(
						SELECT [P].[Id]
							,[P].[PartNumber] [Name]
							,CAST(NULL AS UNIQUEIDENTIFIER) [ParentPartId]
							,[Level] = ISNULL([PP].[Level], 0)
						FROM [APQP].[Part] [P]
						LEFT JOIN [ParentParts] [PP]
							ON [P].[Id] = [PP].[Id]
						WHERE [P].Id = @PartId

						UNION ALL

						SELECT [PR].[PartId] [Id]
							,(SELECT [P].[PartNumber] FROM [APQP].[Part] [P] WHERE [P].[IsDeleted] = 0 AND [P].[Id] = [PR].[PartId]) [Name]
							,[PR].[ParentPartId]
							,[Level] = [CP].[Level] + 1
						FROM [APQP].[PartRelation] [PR]
						JOIN [ChildParts] [CP]
						ON [PR].[ParentPartId] = [CP].[Id]
					)

					,ParentChildParts AS
					(
						SELECT
							[PP].[Id]
							,[PP].[Name]
							,[PP].[ParentPartId]
							,[PP].[Level]
						FROM [ParentParts] [PP]
						UNION ALL
						SELECT
							[CP].[Id]
							,[CP].[Name]
							,[CP].[ParentPartId]
							,[CP].[Level]
						FROM [ChildParts] [CP]
						WHERE [CP].[ParentPartId] IS NOT NULL
					)

					,MultipleChildParts AS
					(
						SELECT
							[PR].[PartId] [Id]
							,(SELECT [P].[PartNumber] FROM [APQP].[Part] [P] WHERE [P].[IsDeleted] = 0 AND [P].[Id] = [PR].[PartId]) [Name]
							,[PR].[ParentPartId]
							,[Level] = [PCP].[Level] + 1
						FROM [APQP].[PartRelation] [PR]
						JOIN [ParentChildParts] [PCP]
						ON [PR].[ParentPartId] = [PCP].[ParentPartId]
						WHERE [PR].[IsDeleted] = 0
					)

					,PartHieraechy AS (
						SELECT DISTINCT [M].[ParentPartId] [Id]
							  ,(SELECT [P].[PartNumber] FROM [APQP].[Part] [P] WHERE [P].[IsDeleted] = 0 AND [P].[Id] = [M].[ParentPartId]) [Name]
							  ,CAST(NULL AS UNIQUEIDENTIFIER) [ParentPartId]
							  ,[Level] = [M].[Level] - 1
						FROM [MultipleChildParts] [M]
						WHERE [M].[ParentPartId] NOT IN (SELECT [Id] FROM MultipleChildParts)

						UNION ALL

						SELECT [Id]
							,[Name]
							,[ParentPartId]
							,[Level]
						FROM [MultipleChildParts]
					)

					SELECT DISTINCT [Id]
						,[Name]
						,[ParentPartId]
						,[Level]
					FROM [PartHieraechy]
					ORDER BY [Level]
				END";

        /// <summary>
        /// The body19052022.
        /// </summary>
        public const string Body19052022 = @"ALTER PROCEDURE [APQP].[GetPartRelations]
				(
					@PartId UNIQUEIDENTIFIER,
					@CompanyId UNIQUEIDENTIFIER
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					SET NOCOUNT ON
					;WITH [ParentParts] AS
					(
						SELECT
							[P].[Id]
							,[P].[PartNumber] [Name]
							,[PR].[ParentPartId]
							,1 [Level]
						FROM [APQP].[Part] [P]
						JOIN [APQP].[PartRelation] [PR]
							ON [P].[Id] = [PR].[PartId]
						WHERE [P].Id = @PartId

						UNION ALL

						SELECT [P].[Id]
								,[P].[PartNumber] [Name]
								,[PR].[ParentPartId]
								,[Level] = [PP].[Level] - 1
						FROM [APQP].[Part] [P]
						JOIN [APQP].[PartRelation] [PR]
							ON [P].[Id] = [PR].[PartId]
						JOIN [ParentParts] [PP]
							ON [PR].[PartId] = [PP].[ParentPartId]
					)

					,[ChildParts] AS
					(
						SELECT [P].[Id]
							,[P].[PartNumber] [Name]
							,CAST(NULL AS UNIQUEIDENTIFIER) [ParentPartId]
							,[Level] = ISNULL([PP].[Level], 0)
						FROM [APQP].[Part] [P]
						LEFT JOIN [ParentParts] [PP]
							ON [P].[Id] = [PP].[Id]
						WHERE [P].Id = @PartId

						UNION ALL

						SELECT [PR].[PartId] [Id]
							,(SELECT [P].[PartNumber] FROM [APQP].[Part] [P] WHERE [P].[IsDeleted] = 0 AND [P].[Id] = [PR].[PartId]) [Name]
							,[PR].[ParentPartId]
							,[Level] = [CP].[Level] + 1
						FROM [APQP].[PartRelation] [PR]
						JOIN [ChildParts] [CP]
						ON [PR].[ParentPartId] = [CP].[Id]
					)

					,ParentChildParts AS
					(
						SELECT
							[PP].[Id]
							,[PP].[Name]
							,[PP].[ParentPartId]
							,[PP].[Level]
						FROM [ParentParts] [PP]
						UNION ALL
						SELECT
							[CP].[Id]
							,[CP].[Name]
							,[CP].[ParentPartId]
							,[CP].[Level]
						FROM [ChildParts] [CP]
						WHERE [CP].[ParentPartId] IS NOT NULL
					)

					,MultipleChildParts AS
					(
						SELECT
							[PR].[PartId] [Id]
							,(SELECT [P].[PartNumber] FROM [APQP].[Part] [P] WHERE [P].[IsDeleted] = 0 AND [P].[Id] = [PR].[PartId]) [Name]
							,[PR].[ParentPartId]
							,[Level] = [PCP].[Level] + 1
						FROM [APQP].[PartRelation] [PR]
						JOIN [ParentChildParts] [PCP]
						ON [PR].[ParentPartId] = [PCP].[ParentPartId]
						WHERE [PR].[IsDeleted] = 0
					)

					,PartHieraechy AS (
						SELECT DISTINCT [M].[ParentPartId] [Id]
							  ,(SELECT [P].[PartNumber] FROM [APQP].[Part] [P] WHERE [P].[IsDeleted] = 0 AND [P].[Id] = [M].[ParentPartId]) [Name]
							  ,CAST(NULL AS UNIQUEIDENTIFIER) [ParentPartId]
							  ,[Level] = [M].[Level] - 1
						FROM [MultipleChildParts] [M]
						WHERE [M].[ParentPartId] NOT IN (SELECT [Id] FROM MultipleChildParts)

						UNION ALL

						SELECT [Id]
							,[Name]
							,[ParentPartId]
							,[Level]
						FROM [MultipleChildParts]
						WHERE [Name] IS NOT NUll
					)

					SELECT DISTINCT [Id]
						,[Name]
						,[ParentPartId]
						,[Level]
					FROM [PartHieraechy]
					WHERE [Name] IS NOT NUll
					ORDER BY [Level]
				END";

        /// <summary>
        /// The body19052022.
        /// </summary>
        public const string Body06062022 = @"ALTER PROCEDURE [APQP].[GetPartRelations]
				(
					@PartId UNIQUEIDENTIFIER,
					@CompanyId UNIQUEIDENTIFIER
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					SET NOCOUNT ON

					;WITH [ParentParts] AS
					(
						SELECT
							[P].[Id]
							,[P].[PartNumber] [Name]
							,[PR].[ParentPartId]
							,1 [Level]
						FROM [APQP].[Part] [P]
						JOIN [APQP].[PartRelation] [PR]
							ON [P].[Id] = [PR].[PartId]
							AND [PR].IsDeleted = 0
							AND [P].IsDeleted = 0
						WHERE [P].Id = @PartId

						UNION ALL

						SELECT [P].[Id]
								,[P].[PartNumber] [Name]
								,[PR].[ParentPartId]
								,[Level] = [PP].[Level] - 1
						FROM [APQP].[Part] [P]
						JOIN [APQP].[PartRelation] [PR]
							ON [P].[Id] = [PR].[PartId]
							AND [PR].IsDeleted = 0
							AND [P].IsDeleted = 0
						JOIN [ParentParts] [PP]
							ON [PR].[PartId] = [PP].[ParentPartId]
					)

					,[ChildParts] AS
					(
						SELECT [P].[Id]
							,[P].[PartNumber] [Name]
							,CAST(NULL AS UNIQUEIDENTIFIER) [ParentPartId]
							,[Level] = ISNULL([PP].[Level], 0)
						FROM [APQP].[Part] [P]
						LEFT JOIN [ParentParts] [PP]
							ON [P].[Id] = [PP].[Id]
							AND [P].IsDeleted = 0
						WHERE [P].Id = @PartId

						UNION ALL

						SELECT [PR].[PartId] [Id]
							,(SELECT [P].[PartNumber] FROM [APQP].[Part] [P] WHERE [P].[IsDeleted] = 0 AND [P].[Id] = [PR].[PartId]) [Name]
							,[PR].[ParentPartId]
							,[Level] = [CP].[Level] + 1
						FROM [APQP].[PartRelation] [PR]
						JOIN [ChildParts] [CP]
						ON [PR].[ParentPartId] = [CP].[Id]
						AND [PR].IsDeleted = 0
					)

					,ParentChildParts AS
					(
						SELECT
							[PP].[Id]
							,[PP].[Name]
							,[PP].[ParentPartId]
							,[PP].[Level]
						FROM [ParentParts] [PP]
						UNION ALL
						SELECT
							[CP].[Id]
							,[CP].[Name]
							,[CP].[ParentPartId]
							,[CP].[Level]
						FROM [ChildParts] [CP]
						WHERE [CP].[ParentPartId] IS NOT NULL
					)

					,MultipleChildParts AS
					(
						SELECT
							[PR].[PartId] [Id]
							,(SELECT [P].[PartNumber] FROM [APQP].[Part] [P] WHERE [P].[IsDeleted] = 0 AND [P].[Id] = [PR].[PartId]) [Name]
							,[PR].[ParentPartId]
							,[Level] = [PCP].[Level] + 1
						FROM [APQP].[PartRelation] [PR]
						JOIN [ParentChildParts] [PCP]
						ON [PR].[ParentPartId] = [PCP].[ParentPartId]
						AND [PR].IsDeleted = 0
						WHERE [PR].[IsDeleted] = 0
					)

					,PartHieraechy AS (
						SELECT DISTINCT [M].[ParentPartId] [Id]
							  ,(SELECT [P].[PartNumber] FROM [APQP].[Part] [P] WHERE [P].[IsDeleted] = 0 AND [P].[Id] = [M].[ParentPartId]) [Name]
							  ,CAST(NULL AS UNIQUEIDENTIFIER) [ParentPartId]
							  ,[Level] = [M].[Level] - 1
						FROM [MultipleChildParts] [M]
						WHERE [M].[ParentPartId] NOT IN (SELECT [Id] FROM MultipleChildParts)

						UNION ALL

						SELECT [Id]
							,[Name]
							,[ParentPartId]
							,[Level]
						FROM [MultipleChildParts]
						WHERE [Name] IS NOT NUll
					)

					SELECT DISTINCT [Id]
						,[Name]
						,[ParentPartId]
						,[Level]
					FROM [PartHieraechy]
					WHERE [Name] IS NOT NUll
					ORDER BY [Level]
				END";
    }
}