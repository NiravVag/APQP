// <copyright file="GetAllUserManagement.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.UserManagement
{
    /// <summary>
    /// Class GetAllUserManagement.
    /// </summary>
    public class GetAllUserManagement
    {
        /// <summary>
        /// The body
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [Setup].[GetAllUserManagement]
				(
					@CompanyId UNIQUEIDENTIFIER = NULL
				)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.

					SET NOCOUNT ON
	
					SELECT 
						[UR].[Id] 
						,[UR].[UserId]
						,[UR].[RoleId]
						,[R].[Name] [Role]
					FROM [Setup].[Roles] [R]
					JOIN [Role].[UserRole] [UR]
						ON [R].[Id] = [UR].[RoleId]
					WHERE ([R].[CompanyId] IS NULL OR [R].[CompanyId] = @CompanyId) AND [R].[IsDeleted] = 0 AND [UR].[IsDeleted] = 0 

					SELECT 
						[UD].[Id] 
						,[UD].[UserId]
						,[UD].[DesignationId]
						,[D].[Name] [Designation]
					FROM [Setup].[Designation] [D]
					JOIN [Role].[UserDesignations] [UD]
						ON [D].[Id] = [UD].[DesignationId]
						AND [UD].[IsDeleted] = 0
					WHERE ([D].[CompanyId] IS NULL OR [D].[CompanyId] = @CompanyId) AND [D].[IsDeleted] = 0 AND [UD].[IsDeleted] = 0 
				END";
    }
}
