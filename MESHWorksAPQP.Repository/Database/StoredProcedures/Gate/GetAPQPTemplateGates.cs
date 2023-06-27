// <copyright file="GetAPQPTemplateGates.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Gate
{
    /// <summary>
    /// Class GetAPQPTemplateGates.
    /// </summary>
    public class GetAPQPTemplateGates
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE PROCEDURE [APQP].[GetAPQPTemplateGates] 
				(
					@APQPTemplateId uniqueidentifier
				)
				AS
				BEGIN
					SELECT
						[G].[Id] [GateId]
						,[G].[APQPTemplateId]
						,[G].[Name]
						,[G].[Code]
						,[G].[Description] [GateDescription]
						,[G].[SortOrder]
						FROM[APQP].[APQPTemplate]
						[AT]
						JOIN[APQP].[Gate]
						[G]
						ON[AT].[Id] = [G].[APQPTemplateId]
						WHERE[AT].[Id] = @APQPTemplateId AND[G].[IsDeleted] = 0
				END";
    }
}
