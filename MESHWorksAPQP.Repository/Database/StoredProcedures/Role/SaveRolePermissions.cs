// <copyright file="SaveRolePermissions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Role
{
    /// <summary>
    /// Class SaveRolePermissions.
    /// </summary>
    public class SaveRolePermissions
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [Role].[SaveRolePermissions]
				(
					@UserId UNIQUEIDENTIFIER
					,@RoleId UNIQUEIDENTIFIER = NULL
					,@CompanyId UNIQUEIDENTIFIER = NULL
					,@json NVARCHAR(MAX)
				)
				AS
				BEGIN
					IF (@CompanyId IS NOT NULL AND @RoleId IS NOT NULL)
					BEGIN
						DELETE 
							FROM [RP]
							FROM [Role].[RolePermissions] [RP] 
							JOIN
								[Setup].[Roles] [R] 
								ON [R].[Id] = [RP].[RoleId] 
								AND [RP].[CompanyId] = [R].[CompanyId]
								AND [R].[IsDeleted] = 0 
							JOIN 
								[Setup].[PageType] [PT] 
								ON [RP].[PageTypeId] = [PT].[Id]
							JOIN 
								[Role].[CompanyModules] [CM]
								ON [PT].[ModuleTypeId] = [CM].[ModuleTypeId]
								AND [RP].[CompanyId] = [CM].[CompanyId]
							WHERE 
								[RP].[CompanyId] = @CompanyId 
								AND [RP].[RoleId] = @RoleId
			 
						INSERT INTO [Role].[RolePermissions] 
						(	
							[Id]
							,[CompanyId]
							,[PageTypeId]
							,[RoleId]
							,[HasRead]
							,[HasWrite]
							,[HasNone]
							,[Created]
							,[CreatedBy]
							,[IsDeleted]
						)
						SELECT 
							NEWID()
							,@CompanyId
							,[RP].[PageTypeId]
							,@RoleId
							,[RP].[HasRead]
							,[RP].[HasWrite]
							,[RP].[HasNone]
							,GETUTCDATE()
							,@UserId
							,0
						FROM [Setup].[ModuleType] [MT]
							JOIN [Setup].[PageType] [PT] 
								ON [MT].[Id] = [PT].[ModuleTypeId]
							JOIN [Role].[CompanyModules] [CM]
								ON [MT].[Id] = [CM].[ModuleTypeId] 
							JOIN OPENJSON(@json) WITH 
							(
								Id UNIQUEIDENTIFIER 
								,PageTypeId UNIQUEIDENTIFIER 
								,HasRead BIT 
								,HasWrite BIT 
								,HasNone BIT 
							) [RP] ON [PT].[Id] = [RP].[PageTypeId] 
						WHERE 
							[CM].[CompanyId] = @CompanyId 
							AND [MT].[IsDeleted] = 0 
							AND [PT].[IsDeleted] = 0 
							AND [CM].[IsDeleted] = 0
					END
					ELSE IF (@RoleId IS NOT NULL)
					BEGIN
						DELETE
						FROM 
							[RP]
						FROM 
							[Role].[RolePermissions] [RP]
						JOIN
							[Setup].[Roles] [UR] 
							ON [UR].[Id] = [RP].[RoleId] 
							AND [UR].[IsDeleted] = 0 
						JOIN 
							[Setup].[PageType] [PT] 
							ON [RP].[PageTypeId] = [PT].[Id]
						WHERE [RP].[RoleId] = @RoleId
			 
						INSERT INTO [Role].[RolePermissions] 
						( 
							[Id]
							,[PageTypeId]
							,[RoleId]
							,[HasRead]
							,[HasWrite]
							,[HasNone]
							,[Created]
							,[CreatedBy]
							,[IsDeleted]
						)
						SELECT 
							NEWID()
							,[RP].[PageTypeId]
							,@RoleId
							,[RP].[HasRead]
							,[RP].[HasWrite]
							,[RP].[HasNone]
							,GETUTCDATE()
							,@UserId
							,0
						FROM [Setup].[ModuleType] [MT] 
							JOIN 
								[Setup].[PageType] [PT] 
								ON [MT].[Id] = [PT].[ModuleTypeId] 
							JOIN OPENJSON(@json) WITH 
							(
								Id UNIQUEIDENTIFIER 
								,PageTypeId UNIQUEIDENTIFIER 
								,HasRead BIT 
								,HasWrite BIT 
								,HasNone BIT 
							) [RP] 
							ON [PT].[Id] = [RP].[PageTypeId] 
						WHERE 
							[MT].[ModuleFor] = 3 /*System Users*/
							AND [MT].[IsDeleted] = 0 
							AND [PT].[IsDeleted] = 0
					END

					EXEC [Role].[GetRolePermissions] @RoleId, @CompanyId
				END";
    }
}
