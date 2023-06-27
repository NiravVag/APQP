// <copyright file="ISearchCommand.cs" company="MESHWorksAPQP">
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
    using MESHWorksAPQP.Management.ViewModel;

    /// <summary>
    /// Interface ISearchCommand.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TFilterVM">The type of the filter vm.</typeparam>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ICommandResult{MESHWorksAPQP.Management.ViewModel.Page{TResult}}" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ICommandResult{TResult}" />
    public interface ISearchCommand<TResult, TFilterVM> : ICommandResult<Page<TResult>>
        where TFilterVM : IFilterVM
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        TFilterVM Filter { get; set; }
    }
}
