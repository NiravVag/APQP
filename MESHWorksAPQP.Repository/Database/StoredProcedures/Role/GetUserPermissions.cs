// <copyright file="GetUserPermissions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Role
{
    /// <summary>
    /// class GetUserPermissions.
    /// </summary>
    public class GetUserPermissions
    {
        /// <summary>
        /// The body
        /// </summary>
        public const string Body = @"CREATE OR ALTER PROCEDURE [Role].[GetUserPermissions]
				(
					@UserId UNIQUEIDENTIFIER
					,@CompanyId UNIQUEIDENTIFIER = NULL
				)
				AS
				BEGIN
					DECLARE @RoleId UNIQUEIDENTIFIER
					SELECT @RoleId = RoleId FROM [Role].[UserRole] WHERE [UserId] = @UserId AND [IsDeleted] = 0

					IF (@CompanyId IS NOT NULL AND @RoleId IS NOT NULL)
					BEGIN
						SELECT
							[RP].[Id]
							,[MT].[Id] [ModuleTypeId]
							,[MT].[Name] [ModuleType]
							,[PT].[Id] [PageTypeId]
							,[PT].[Name] [PageType]
							,[PT].[Code]
							,[PT].[PageUrl] 
							,[CM].[CompanyId]
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
					END
					ELSE IF (@RoleId IS NOT NULL)
					BEGIN
						SELECT
							[RP].[Id]
							,[MT].[Id] [ModuleTypeId]
							,[MT].[Name] [ModuleType]
							,[PT].[Id] [PageTypeId]
							,[PT].[Name] [PageType]
							,[PT].[Code]
							,[PT].[PageUrl] 
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
					END
				END";
    }
}
