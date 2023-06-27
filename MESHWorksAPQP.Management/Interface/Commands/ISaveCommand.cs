// <copyright file="ISaveCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Interface.ViewModel;

    /// <summary>
    /// Interface ISaveCommand.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ICommandResult{TResult}" />
    public interface ISaveCommand<TResult> : ICommandResult<TResult>
        where TResult : ISaveResult
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        TResult Entity { get; set; }
    }
}
