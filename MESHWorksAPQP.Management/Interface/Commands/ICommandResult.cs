// <copyright file="ICommandResult.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface ICommandResult.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface ICommandResult<TResult>
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        TResult Result { get; }
    }
}
