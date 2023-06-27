// <copyright file="GetPermissionCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.User
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Class GetPermissionCommand.
    /// </summary>
    public class GetPermissionCommand : ICommandResult<IList<PermissionDetail>>
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public IList<PermissionDetail> Result { get; set; }
    }
}
