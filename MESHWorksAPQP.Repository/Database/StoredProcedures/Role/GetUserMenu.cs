// <copyright file="GetUserMenu.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Role
{
    /// <summary>
    /// Class GetUserMenu.
    /// </summary>
    public class GetUserMenu
    {
        /// <summary>
        /// The body
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [Role].[GetUserMenu]
				(
					@UserId UNIQUEIDENTIFIER 
					,@CompanyId UNIQUEIDENTIFIER = NULL
				)
				AS
				BEGIN
					DECLARE @RoleId UNIQUEIDENTIFIER
					SELECT @RoleId = [RoleId] FROM [Role].[UserRole] WHERE [UserId] = @UserId AND [IsDeleted] = 0

					IF (@CompanyId IS NOT NULL AND @RoleId IS NOT NULL)
					BEGIN
						SELECT 
							[PT].[Id]
							,[PT].[Name]
							,[PT].[MenuIcon]
							,[PT].[PageUrl] 
							,[PT].[ParentId]
							,[PT].[SortOrder] 
						FROM [Setup].[ModuleType] [MT]
							JOIN [Setup].[PageType] [PT] 
								ON [MT].[Id] = [PT].[ModuleTypeId]
							JOIN [Role].[CompanyModules] [CM] 
								ON [MT].[Id] = [CM].[ModuleTypeId]
							JOIN [Role].[RolePermissions] [RP] 
								ON [PT].[Id] = [RP].[PageTypeId] 
								AND [CM].[CompanyId] = [RP].[CompanyId]
								AND [RP].[RoleId] = @RoleId
							LEFT JOIN
								[Setup].[Roles] [R] 
								ON [R].[Id] = [RP].[RoleId] 
								AND [RP].[CompanyId] = [R].[CompanyId]
								AND [R].[IsDeleted] = 0 
							LEFT JOIN
								[Role].[UserRole] [UR] 
								ON [UR].[RoleId] = [RP].[RoleId] 
								AND [UR].[UserId] = @UserId 
							WHERE [CM].[CompanyId] = @CompanyId 
								AND [MT].[IsDeleted] = 0 
								AND [PT].[IsDeleted] = 0 
								AND [CM].[IsDeleted] = 0 
								AND [UR].[IsDeleted] = 0 
								AND [RP].[IsDeleted] = 0 
								AND [RP].[HasNone] = 0
								AND [PT].[IsMenuItem] = 1
							ORDER BY 
								[PT].[ParentId]
								,[PT].[SortOrder]
								,[PT].[Name]
					END
					ELSE IF (@RoleId IS NOT NULL)
					BEGIN
						SELECT 
							[PT].[Id]
							,[PT].[Name]
							,[PT].[MenuIcon]
							,[PT].[PageUrl] 
							,[PT].[ParentId]
							,[PT].[SortOrder] 
						FROM [Setup].[ModuleType] [MT]
							JOIN [Setup].[PageType] [PT] 
								ON [MT].[Id] = [PT].[ModuleTypeId]
							JOIN [Role].[RolePermissions] [RP] 
								ON [PT].[Id] = [RP].[PageTypeId] 
							JOIN [Setup].[Roles] [R] 
								ON [R].[Id] = [RP].[RoleId] 
							LEFT JOIN [Role].[UserRole] [UR] 
									ON [UR].[RoleId] = [RP].[RoleId] 
									AND [UR].[RoleId] = @RoleId
									AND [UR].[UserId] = @UserId 
						WHERE [MT].ModuleFor = 3 /*System Users*/ 
							AND [RP].[RoleId] = @RoleId
							AND [MT].[IsDeleted] = 0 
							AND [PT].[IsDeleted] = 0 
							AND [RP].[IsDeleted] = 0 
							AND [R].[IsDeleted] = 0
							AND [UR].[IsDeleted] = 0
							AND [RP].[HasNone] = 0
							AND [PT].[IsMenuItem] = 1
						ORDER BY 
							[PT].[ParentId]
							,[PT].[SortOrder]
							,[PT].[Name]
					END
				END";
    }
}
