//// <copyright file="GetUserByUserNameHandler.cs" company="MESHWorksAPQP">
//// Copyright (c) MESHWorksAPQP. All rights reserved.
//// </copyright>

//namespace MESHWorksAPQP.Management.Handlers.User
//{
//    using System.Threading.Tasks;
//    using MESHWorksAPQP.Management.Commands.User;
//    using MESHWorksAPQP.Management.Interface.Handlers;
//    using MESHWorksAPQP.Management.Interface.Managers.User;

//    /// <summary>
//    /// Class GetUserByUserNameHandler.
//    /// </summary>
//    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.User.GetUserByUserNameCommand}" />
//    public class GetUserByUserNameHandler : ICommandHandler<GetUserByUserNameCommand>
//    {
//        /// <summary>
//        /// The manager.
//        /// </summary>
//        private readonly IUserManager manager;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="GetUserByUserNameHandler"/> class.
//        /// </summary>
//        /// <param name="manager">The manager.</param>
//        public GetUserByUserNameHandler(IUserManager manager)
//        {
//            this.manager = manager;
//        }

//        /// <summary>
//        /// Executes the specified command.
//        /// </summary>
//        /// <param name="command">The command.</param>
//        /// <returns>Task.</returns>
//        public async Task Execute(GetUserByUserNameCommand command)
//        {
//            command.Result = await this.manager.GetUser(command);
//        }
//    }
//}
