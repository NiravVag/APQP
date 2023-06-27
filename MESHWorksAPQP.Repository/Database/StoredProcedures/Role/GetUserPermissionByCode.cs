// <copyright file="GetUserPermissionByCode.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Role
{
    /// <summary>
    /// class GetUserPermissionByCode.
    /// </summary>
    public class GetUserPermissionByCode
    {
        /// <summary>
        /// The body
        /// </summary>
        public const string Body = @"CREATE OR ALTER PROCEDURE [Role].[GetUserPermissionByCode]
			(
				@UserId UNIQUEIDENTIFIER
				,@CompanyId UNIQUEIDENTIFIER = NULL
				,@Code NVARCHAR(100)
			)
			AS
			BEGIN
				DECLARE @RoleId UNIQUEIDENTIFIER;
				SELECT @RoleId = [RoleId] FROM [Role].[UserRole] WHERE [UserId] = @UserId AND [IsDeleted] = 0

				IF (@CompanyId IS NOT NULL)
				BEGIN
					SELECT
						[RP].[Id]
						,[MT].[Id] [ModuleTypeId]
						,[PT].[Name] [ModuleType]
						,[PT].[Id] [PageTypeId]
						,[PT].[Name] [PageType]
						,[RP].[HasRead]
						,[RP].[HasWrite]
						,[RP].[HasNone]
					FROM [Setup].[ModuleType] [MT]
					JOIN [Setup].[PageType] [PT] 
						ON [MT].[Id] = [PT].[ModuleTypeId]
					JOIN [Role].[CompanyModules] [CM] 
						ON [MT].[Id] = [CM].[ModuleTypeId]
					JOIN [Role].[RolePermissions] [RP]
						ON [PT].[Id] = [RP].[PageTypeId]
						AND [CM].[CompanyId] = [RP].[CompanyId]
					JOIN [Setup].[Roles] [R] 
						ON [R].[Id] = [RP].[RoleId] 
						AND [RP].[CompanyId] = [R].[CompanyId]
						AND [R].[IsDeleted] = 0 
					WHERE [CM].[CompanyId] = @CompanyId AND [PT].[Code] = @Code AND [RP].[RoleId] = @RoleId
						AND [MT].[IsDeleted] = 0 AND [PT].[IsDeleted] = 0 AND [CM].[IsDeleted] = 0 AND [RP].[IsDeleted] = 0 
				END
				ELSE IF (@RoleId IS NOT NULL)
				BEGIN
					SELECT 
						[RP].[Id]
						,[MT].[Id] [ModuleTypeId]
						,[PT].[Name] [ModuleType]
						,[PT].[Id] [PageTypeId]
						,[PT].[Name] [PageType]
						,[RP].[HasRead]
						,[RP].[HasWrite]
						,[RP].[HasNone]
					FROM [Setup].[ModuleType] [MT]
						JOIN [Setup].[PageType] [PT] 
							ON [MT].[Id] = [PT].[ModuleTypeId]
						JOIN [Role].[RolePermissions] [RP] 
							ON [PT].[Id] = [RP].[PageTypeId] 
						JOIN [Setup].[Roles] [R] 
							ON [R].[Id] = [RP].[RoleId] 
						WHERE [MT].[ModuleFor] = 3 /*System Users*/ 
						AND [RP].[RoleId] = @RoleId AND [PT].[Code] = @Code
						AND [MT].[IsDeleted] = 0 AND [PT].[IsDeleted] = 0 AND [RP].[IsDeleted] = 0 AND [R].[IsDeleted] = 0
				END
			END";
    }
}
