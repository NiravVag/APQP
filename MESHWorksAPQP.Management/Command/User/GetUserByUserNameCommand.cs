// <copyright file="GetUserByUserNameCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.User
{
    using MESHWorksAPQP.Management.ViewModel.User;

    /// <summary>
    /// Class GetUserByUserNameCommand.
    /// </summary>
    public class GetUserByUserNameCommand
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public UserVM Result { get; set; }
    }
}
