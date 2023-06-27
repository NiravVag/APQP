// <copyright file="NewCompanySetup.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Setup
{
    /// <summary>
    /// Class NewCompanySetup.
    /// </summary>
    public class NewCompanySetup
    {
        /// <summary>
        /// The body
        /// </summary>
        public const string Body18052022 = @"CREATE OR ALTER PROCEDURE [Setup].[NewCompanySetup]
				(
					@CompanyId UNIQUEIDENTIFIER
					,@UserId UNIQUEIDENTIFIER
				)
				AS 
				BEGIN 
					DECLARE @ModuleType INT = 2; /*For default module type - Customer*/

					-- Commodity
					INSERT INTO [Setup].[Commodity] ([Id], [CompanyId], [Name], [Code], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [C].[Name], [C].[Code], GETUTCDATE(), 'RegisterCompany', 0
					FROM [Setup].[Commodity] [C] 
					WHERE [C].[CompanyId] IS NULL AND [C].[IsDeleted] = 0

					-- Process
					INSERT INTO [Setup].[Process] ([Id], [CompanyId], [Name], [Code], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [P].[Name], [P].[Code], GETUTCDATE(), 'RegisterCompany', 0
					FROM [Setup].[Process] [P] 
					WHERE [P].[CompanyId] IS NULL AND [P].[IsDeleted] = 0
	
					-- Material
					INSERT INTO [Setup].[Material] ([Id], [CommodityId], [CompanyId], [Name], [Code], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), [NC].[Id], @CompanyId, [M].[Name], [M].[Code], GETUTCDATE(), 'RegisterCompany', 0
					FROM [Setup].[Commodity] [C]
					JOIN [Setup].[Commodity] [NC]
						ON [C].[Code] = [NC].[Code]
						AND [C].[IsDeleted] = 0 AND [C].[CompanyId] IS NULL
					JOIN [Setup].[Material] [M]
						ON [C].[Id] = [M].[CommodityId]
						AND [M].[IsDeleted] = 0 AND [M].[CompanyId] IS NULL
						AND [NC].[CompanyId] = @CompanyId AND [NC].[IsDeleted] = 0

					-- Document Type
					INSERT INTO [Setup].[DocumentType] ([Id], [CompanyId], [Name], [Code], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [D].[Name], [D].[Code], GETUTCDATE(), 'RegisterCompany', 0
					FROM [Setup].[DocumentType] [D] 
					WHERE [D].[CompanyId] IS NULL AND [D].[IsDeleted] = 0

					-- APQP Template
					DECLARE @APQPTemplateId UNIQUEIDENTIFIER = NEWID();

					INSERT INTO [APQP].[APQPTemplate] ([Id], [CompanyId], [Name], [Description], [IsActive], [IsSystemDefault], [Created], [CreatedBy], [IsDeleted])
					SELECT @APQPTemplateId, @CompanyId, [AT].[Name], [AT].[Description], [AT].[IsActive], 1, GETUTCDATE(), 'RegisterCompany', 0
					FROM [APQP].[APQPTemplate] [AT]
					WHERE [AT].[IsDeleted] = 0 AND [AT].[IsActive] = 1 AND [AT].[IsSystemDefault] = 1 AND [AT].[CompanyId] IS NULL

					-- APQP Template Gates
					INSERT INTO [APQP].[Gate] ([Id], [APQPTemplateId], [Name], [Code], [Description], [SortOrder], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @APQPTemplateId, [G].[Name], [G].[Code], [G].[Description], [G].[SortOrder], GETUTCDATE(), 'RegisterCompany', 0
					FROM [APQP].[APQPTemplate] [AT]
					JOIN [APQP].[Gate] [G]
						ON [AT].[Id] = [G].[APQPTemplateId]
					WHERE [AT].[IsDeleted] = 0 AND [AT].[IsActive] = 1 AND [AT].[IsSystemDefault] = 1 AND [AT].[CompanyId] IS NULL AND [G].[IsDeleted] = 0

					-- Company module
					INSERT INTO [Role].[CompanyModules] ([Id], [CompanyId], [ModuleTypeId], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [MT].[Id], GETUTCDATE(), 'RegisterCompany', 0 
					FROM [Setup].[ModuleType] [MT] WHERE [MT].[ModuleFor] = @ModuleType AND [MT].[IsDeleted] = 0

					-- For Admin role
					DECLARE @AdminRoleId UNIQUEIDENTIFIER = NEWID();

					INSERT INTO [Setup].[Roles] ([Id], [CompanyId], [IsSystemRole], [Name], [Code], [Created], [CreatedBy], [IsDeleted]) 
						VALUES (@AdminRoleId, @CompanyId, 0, 'Admin', 'Admin', GETUTCDATE(), 'RegisterCompany', 0 )

					-- Admin Permissions
					INSERT INTO [Role].[RolePermissions] ([Id], [CompanyId], [PageTypeId], [RoleId], [HasRead], [HasWrite], [HasNone], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [PT].[Id], @AdminRoleId, 0, 1, 0,  GETUTCDATE(), 'RegisterCompany', 0 
					FROM [Setup].[ModuleType] [MT]
					JOIN [Setup].[PageType] [PT] 
						ON [MT].[Id] = [PT].[ModuleTypeId]
					JOIN [Role].[CompanyModules] [CM] 
						ON [MT].[Id] = [CM].[ModuleTypeId]
					WHERE [CM].[CompanyId] = @CompanyId AND [MT].[IsDeleted] = 0 AND [PT].[IsDeleted] = 0 AND [CM].[IsDeleted] = 0

					-- For Non-Admin role
					DECLARE @NonAdminRoleId UNIQUEIDENTIFIER = NEWID();

					INSERT INTO [Setup].[Roles] ([Id], [CompanyId],  [IsSystemRole], [Name], [Code], [Created], [CreatedBy], [IsDeleted]) 
						VALUES (@NonAdminRoleId, @CompanyId, 0, 'Non-Admin', 'NonAdmin', GETUTCDATE(), 'RegisterCompany', 0 )

					-- Non-Admin Permissions
					INSERT INTO [Role].[RolePermissions] ([Id], [CompanyId], [PageTypeId], [RoleId], [HasRead], [HasWrite], [HasNone], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [PT].[Id], @NonAdminRoleId, 1, 0, 0,  GETUTCDATE(), 'RegisterCompany', 0 
					FROM [Setup].[ModuleType] [MT]
					JOIN [Setup].[PageType] [PT] 
						ON [MT].[Id] = [PT].[ModuleTypeId]
					JOIN [Role].[CompanyModules] [CM] 
						ON [MT].[Id] = [CM].[ModuleTypeId]
					WHERE [CM].[CompanyId] = @CompanyId AND [MT].[IsDeleted] = 0 AND [PT].[IsDeleted] = 0 AND [CM].[IsDeleted] = 0

					-- Admin User 
					INSERT INTO [Role].[UserRole] ([Id], [UserId], [RoleId], [Created], [CreatedBy], [IsDeleted])
					VALUES (NEWID(), @UserId, @AdminRoleId, GETUTCDATE(), 'RegisterCompany', 0)
				END";

        /// <summary>
        /// The body23052022
        /// </summary>
        public const string Body23052022 = @"CREATE OR ALTER PROCEDURE [Setup].[NewCompanySetup]
				(
					@CompanyId UNIQUEIDENTIFIER
					,@UserId UNIQUEIDENTIFIER
				)
				AS 
				BEGIN 
					DECLARE @ModuleType INT = 2; /*For default module type - Customer*/

					-- Commodity
					INSERT INTO [Setup].[Commodity] ([Id], [CompanyId], [Name], [Code], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [C].[Name], [C].[Code], GETUTCDATE(), 'RegisterCompany', 0
					FROM [Setup].[Commodity] [C] 
					WHERE [C].[CompanyId] IS NULL AND [C].[IsDeleted] = 0

					-- Process
					INSERT INTO [Setup].[Process] ([Id], [CompanyId], [Name], [Code], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [P].[Name], [P].[Code], GETUTCDATE(), 'RegisterCompany', 0
					FROM [Setup].[Process] [P] 
					WHERE [P].[CompanyId] IS NULL AND [P].[IsDeleted] = 0
	
					-- Material
					INSERT INTO [Setup].[Material] ([Id], [CommodityId], [CompanyId], [Name], [Code], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), [NC].[Id], @CompanyId, [M].[Name], [M].[Code], GETUTCDATE(), 'RegisterCompany', 0
					FROM [Setup].[Commodity] [C]
					JOIN [Setup].[Commodity] [NC]
						ON [C].[Code] = [NC].[Code]
						AND [C].[IsDeleted] = 0 AND [C].[CompanyId] IS NULL
					JOIN [Setup].[Material] [M]
						ON [C].[Id] = [M].[CommodityId]
						AND [M].[IsDeleted] = 0 AND [M].[CompanyId] IS NULL
						AND [NC].[CompanyId] = @CompanyId AND [NC].[IsDeleted] = 0

					-- Document Type
					INSERT INTO [Setup].[DocumentType] ([Id], [CompanyId], [Name], [Code], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [D].[Name], [D].[Code], GETUTCDATE(), 'RegisterCompany', 0
					FROM [Setup].[DocumentType] [D] 
					WHERE [D].[CompanyId] IS NULL AND [D].[Code] <> 'Discussion' AND [D].[IsDeleted] = 0

					-- APQP Template
					DECLARE @APQPTemplateId UNIQUEIDENTIFIER = NEWID();

					INSERT INTO [APQP].[APQPTemplate] ([Id], [CompanyId], [Name], [Description], [IsActive], [IsSystemDefault], [Created], [CreatedBy], [IsDeleted])
					SELECT @APQPTemplateId, @CompanyId, [AT].[Name], [AT].[Description], [AT].[IsActive], 1, GETUTCDATE(), 'RegisterCompany', 0
					FROM [APQP].[APQPTemplate] [AT]
					WHERE [AT].[IsDeleted] = 0 AND [AT].[IsSystemDefault] = 1 AND [AT].[CompanyId] IS NULL

					-- APQP Template Gates
					INSERT INTO [APQP].[Gate] ([Id], [APQPTemplateId], [Name], [Code], [Description], [SortOrder], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @APQPTemplateId, [G].[Name], [G].[Code], [G].[Description], [G].[SortOrder], GETUTCDATE(), 'RegisterCompany', 0
					FROM [APQP].[APQPTemplate] [AT]
					JOIN [APQP].[Gate] [G]
						ON [AT].[Id] = [G].[APQPTemplateId]
					WHERE [AT].[IsDeleted] = 0 AND [AT].[IsSystemDefault] = 1 AND [AT].[CompanyId] IS NULL AND [G].[IsDeleted] = 0

					-- Company module
					INSERT INTO [Role].[CompanyModules] ([Id], [CompanyId], [ModuleTypeId], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [MT].[Id], GETUTCDATE(), 'RegisterCompany', 0 
					FROM [Setup].[ModuleType] [MT] WHERE [MT].[ModuleFor] = @ModuleType AND [MT].[IsDeleted] = 0

					-- For Admin role
					DECLARE @AdminRoleId UNIQUEIDENTIFIER = NEWID();

					INSERT INTO [Setup].[Roles] ([Id], [CompanyId], [IsSystemRole], [Name], [Code], [Created], [CreatedBy], [IsDeleted]) 
						VALUES (@AdminRoleId, @CompanyId, 0, 'Admin', 'Admin', GETUTCDATE(), 'RegisterCompany', 0 )

					-- Admin Permissions
					INSERT INTO [Role].[RolePermissions] ([Id], [CompanyId], [PageTypeId], [RoleId], [HasRead], [HasWrite], [HasNone], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [PT].[Id], @AdminRoleId, 0, 1, 0,  GETUTCDATE(), 'RegisterCompany', 0 
					FROM [Setup].[ModuleType] [MT]
					JOIN [Setup].[PageType] [PT] 
						ON [MT].[Id] = [PT].[ModuleTypeId]
					JOIN [Role].[CompanyModules] [CM] 
						ON [MT].[Id] = [CM].[ModuleTypeId]
					WHERE [CM].[CompanyId] = @CompanyId AND [MT].[IsDeleted] = 0 AND [PT].[IsDeleted] = 0 AND [CM].[IsDeleted] = 0

					-- For Non-Admin role
					DECLARE @NonAdminRoleId UNIQUEIDENTIFIER = NEWID();

					INSERT INTO [Setup].[Roles] ([Id], [CompanyId],  [IsSystemRole], [Name], [Code], [Created], [CreatedBy], [IsDeleted]) 
						VALUES (@NonAdminRoleId, @CompanyId, 0, 'Non-Admin', 'NonAdmin', GETUTCDATE(), 'RegisterCompany', 0 )

					-- Non-Admin Permissions
					INSERT INTO [Role].[RolePermissions] ([Id], [CompanyId], [PageTypeId], [RoleId], [HasRead], [HasWrite], [HasNone], [Created], [CreatedBy], [IsDeleted])
					SELECT NEWID(), @CompanyId, [PT].[Id], @NonAdminRoleId, 1, 0, 0,  GETUTCDATE(), 'RegisterCompany', 0 
					FROM [Setup].[ModuleType] [MT]
					JOIN [Setup].[PageType] [PT] 
						ON [MT].[Id] = [PT].[ModuleTypeId]
					JOIN [Role].[CompanyModules] [CM] 
						ON [MT].[Id] = [CM].[ModuleTypeId]
					WHERE [CM].[CompanyId] = @CompanyId AND [MT].[IsDeleted] = 0 AND [PT].[IsDeleted] = 0 AND [CM].[IsDeleted] = 0

					-- Admin User 
					INSERT INTO [Role].[UserRole] ([Id], [UserId], [RoleId], [Created], [CreatedBy], [IsDeleted])
					VALUES (NEWID(), @UserId, @AdminRoleId, GETUTCDATE(), 'RegisterCompany', 0)
				END";
    }
}
