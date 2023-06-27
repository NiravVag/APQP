// <copyright file="CommandResponseHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.Interface.Handlers;

    /// <summary>
    /// Class CommandResponseHandler.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="MESHWorks.Management.Interface.Handlers.ICommandResponseHandler{TCommand, TResponse}" />
    public class CommandResponseHandler<TCommand, TResponse, TResult> : ICommandResponseHandler<TCommand, TResponse>
        where TCommand : ICommandResult<TResult>
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly ICommandHandler<TCommand> handler;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResponseHandler{TCommand, TResponse, TResult}"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <param name="mapper">The mapper.</param>
        public CommandResponseHandler(ICommandHandler<TCommand> handler, IMapper mapper)
        {
            this.handler = handler;
            this.mapper = mapper;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// TResponse.
        /// </returns>
        public async Task<TResponse> Execute(TCommand command)
        {
            await this.handler.Execute(command);

            TResponse result = this.mapper.Map<TResult, TResponse>(command.Result);

            return result;
        }
    }
}
