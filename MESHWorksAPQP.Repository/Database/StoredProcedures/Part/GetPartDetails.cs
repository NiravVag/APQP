// <copyright file="GetPartDetails.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Database.StoredProcedures.Part
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class GetPartDetails.
    /// </summary>
    public class GetPartDetails
    {
        /// <summary>
        /// The body.
        /// </summary>
        public const string Body = @"CREATE OR ALTER PROCEDURE [APQP].[GetPartDetails]
									(
									   @id uniqueidentifier
									)
									AS
									BEGIN
										SET NOCOUNT ON
											SELECT [Id]
												  ,[CompanyId]
												  ,[PartNumber]
												  ,[Description]
												  ,[DrawingNumber]
												  ,[CommodityId]
												  ,[ProcessId]
												  ,[MaterialTypeId]
												  ,[SAM]
												  ,[InitialRevLevel]
												  ,[InitialRevDate]
												  ,[EstimatedWeight]
												  ,[EAU]
												  ,[CustomerName]
												  ,[CustomerEmail]
												  ,[CustomerPhone]
												  ,[IsDeleted]
												  ,[Customer]
												  ,[OtherMaterialTypeName]
												  ,[OtherProcessName]
											  FROM [APQP].[Part]
											  WHERE Id= @id
									END";
    }
}
