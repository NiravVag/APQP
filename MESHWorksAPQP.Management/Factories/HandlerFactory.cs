// <copyright file="HandlerFactory.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Interface.Factories;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using SimpleInjector;

    /// <summary>
    /// Class HandlerFactory.
    /// </summary>
    public class HandlerFactory : IHandlerFactory
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly Container container;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandlerFactory"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public HandlerFactory(Container container)
        {
            this.container = container;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute<TCommand>(TCommand command)
        {
            await this.GetHandler<TCommand>().Execute(command);
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>Task TResponse.</returns>
        public async Task<TResponse> Execute<TCommand, TResponse>(TCommand command)
        {
            return await this.GetHandler<TCommand, TResponse>().Execute(command);
        }

        /// <summary>
        /// Gets the handler.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <returns>ICommandHandler TCommand.</returns>
        private ICommandHandler<TCommand> GetHandler<TCommand>()
        {
            return (ICommandHandler<TCommand>)this.container.GetInstance(typeof(ICommandHandler<TCommand>));
        }

        /// <summary>
        /// Gets the handler.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <returns>ICommandResponseHandler TResponse.</returns>
        private ICommandResponseHandler<TCommand, TResponse> GetHandler<TCommand, TResponse>()
        {
            return (ICommandResponseHandler<TCommand, TResponse>)this.container.GetInstance(typeof(ICommandResponseHandler<TCommand, TResponse>));
        }
    }
}
