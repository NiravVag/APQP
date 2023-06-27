// <copyright file="GetRolePermissions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Role
{
    /// <summary>
    /// Class GetRolePermissions.
    /// </summary>
    public class GetRolePermissions
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [Role].[GetRolePermissions]
				(
					@RoleId UNIQUEIDENTIFIER = NULL
					,@CompanyId UNIQUEIDENTIFIER = NULL
				)
				AS
				BEGIN
					IF (@CompanyId IS NOT NULL AND @RoleId IS NOT NULL) 
				BEGIN
					   SELECT
						  [RP].[Id]
						  ,[MT].[Id] [ModuleTypeId]
						  ,[MT].[Name] [ModuleType]
						  ,[PT].[Id] [PageTypeId]
						  ,[PT].[Name] [PageType]
						  ,[PT].[ParentId] 
						  ,[RP].[HasRead]
						  ,[RP].[HasWrite]
						  ,[RP].[HasNone]
					   FROM
						  [Setup].[ModuleType] [MT] 
						  JOIN
							 [Setup].[PageType] [PT] 
							 ON [MT].[Id] = [PT].[ModuleTypeId] 
						  JOIN
							 [Role].[CompanyModules] [CM] 
							 ON [MT].[Id] = [CM].[ModuleTypeId] 
						  LEFT JOIN
							 [Role].[RolePermissions] [RP] 
							 ON [PT].[Id] = [RP].[PageTypeId] 
							 AND [CM].[CompanyId] = [RP].[CompanyId]
							 AND [RP].[RoleId] = @RoleId
							 AND [RP].[IsDeleted] = 0 
						 LEFT JOIN
								[Setup].[Roles] [R] 
								ON [R].[Id] = [RP].[RoleId] 
								AND [RP].[CompanyId] = [R].[CompanyId]
								AND [R].[IsDeleted] = 0 
					   WHERE
						  [CM].[CompanyId] = @CompanyId 
						  AND [MT].[IsDeleted] = 0 
						  AND [PT].[IsDeleted] = 0 
						  AND [CM].[IsDeleted] = 0 
					   ORDER BY
						  [PT].[ParentId]
						  ,[PT].[SortOrder]
						  ,[PT].[Name] 
					END
					ELSE IF (@RoleId IS NOT NULL) 
					BEGIN
						SELECT
							[RP].[Id]
							,[MT].[Id] [ModuleTypeId]
							,[MT].[Name] [ModuleType]
							,[PT].[Id] [PageTypeId]
							,[PT].[Name] [PageType]
							,[PT].[ParentId] 
							,[RP].[HasRead]
							,[RP].[HasWrite]
							,[RP].[HasNone]
						FROM
							[Setup].[ModuleType] [MT] 
							JOIN
								[Setup].[PageType] [PT] 
								ON [MT].[Id] = [PT].[ModuleTypeId] 
							LEFT JOIN
								[Role].[RolePermissions] [RP] 
								ON [PT].[Id] = [RP].[PageTypeId] 
								AND [RP].[IsDeleted] = 0 
							LEFT JOIN
								[Setup].[Roles] [R] 
								ON [R].[Id] = [RP].[RoleId] 
								AND [R].[IsDeleted] = 0 
						WHERE
							[MT].[ModuleFor] = 3   /*System Users*/
							AND [MT].[IsDeleted] = 0 
							AND [PT].[IsDeleted] = 0 
						ORDER BY
							[PT].[ParentId]
							,[PT].[SortOrder]
      						,[PT].[Name] 
					END
				END";

        /// <summary>
        /// The body19052022.
        /// </summary>
        public const string Body19052022 = @"CREATE OR ALTER PROCEDURE [Role].[GetRolePermissions]
				(
					@RoleId UNIQUEIDENTIFIER = NULL
					,@CompanyId UNIQUEIDENTIFIER = NULL
				)
				AS
				BEGIN
					IF (@CompanyId IS NOT NULL AND @RoleId IS NOT NULL) 
				BEGIN
					   SELECT
						  [RP].[Id]
						  ,[RP].[CompanyId]
						  ,[MT].[Id] [ModuleTypeId]
						  ,[MT].[Name] [ModuleType]
						  ,[PT].[Id] [PageTypeId]
						  ,[PT].[Name] [PageType]
						  ,[PT].[ParentId] 
						  ,[RP].[HasRead]
						  ,[RP].[HasWrite]
						  ,[RP].[HasNone]
					   FROM
						  [Setup].[ModuleType] [MT] 
						  JOIN
							 [Setup].[PageType] [PT] 
							 ON [MT].[Id] = [PT].[ModuleTypeId] 
						  JOIN
							 [Role].[CompanyModules] [CM] 
							 ON [MT].[Id] = [CM].[ModuleTypeId] 
						  LEFT JOIN
							 [Role].[RolePermissions] [RP] 
							 ON [PT].[Id] = [RP].[PageTypeId] 
							 AND [CM].[CompanyId] = [RP].[CompanyId]
							 AND [RP].[RoleId] = @RoleId
							 AND [RP].[IsDeleted] = 0 
						 LEFT JOIN
								[Setup].[Roles] [R] 
								ON [R].[Id] = [RP].[RoleId] 
								AND [RP].[CompanyId] = [R].[CompanyId]
								AND [R].[IsDeleted] = 0 
					   WHERE
						  [CM].[CompanyId] = @CompanyId 
						  AND [MT].[IsDeleted] = 0 
						  AND [PT].[IsDeleted] = 0 
						  AND [CM].[IsDeleted] = 0 
					   ORDER BY
						  [PT].[ParentId]
						  ,[PT].[SortOrder]
						  ,[PT].[Name] 
					END
					ELSE IF (@RoleId IS NOT NULL) 
					BEGIN
						SELECT
							[RP].[Id]
							,[MT].[Id] [ModuleTypeId]
							,[MT].[Name] [ModuleType]
							,[PT].[Id] [PageTypeId]
							,[PT].[Name] [PageType]
							,[PT].[ParentId] 
							,[RP].[HasRead]
							,[RP].[HasWrite]
							,[RP].[HasNone]
						FROM
							[Setup].[ModuleType] [MT] 
							JOIN
								[Setup].[PageType] [PT] 
								ON [MT].[Id] = [PT].[ModuleTypeId] 
							LEFT JOIN
								[Role].[RolePermissions] [RP] 
								ON [PT].[Id] = [RP].[PageTypeId] 
								AND [RP].[IsDeleted] = 0 
							LEFT JOIN
								[Setup].[Roles] [R] 
								ON [R].[Id] = [RP].[RoleId] 
								AND [R].[IsDeleted] = 0 
						WHERE
							[MT].[ModuleFor] = 3   /*System Users*/
							AND [MT].[IsDeleted] = 0 
							AND [PT].[IsDeleted] = 0 
						ORDER BY
							[PT].[ParentId]
							,[PT].[SortOrder]
      						,[PT].[Name] 
					END
				END";
    }
}
