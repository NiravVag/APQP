// <copyright file="ISmtpSetting.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.Interface.Settings
{
    /// <summary>
    /// Interface ISmtpSetting.
    /// </summary>
    public interface ISmtpSetting
    {
        /// <summary>
        /// Gets or sets the override email.
        /// </summary>
        /// <value>
        /// The override email.
        /// </value>
        string OverrideEmail { get; set; }

        /// <summary>
        /// Gets or sets the environment name.
        /// </summary>
        /// <value>
        /// The environment name.
        /// </value>
        string EnvironmentName { get; set; }

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        string Server { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        int Port { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use SSL].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use SSL]; otherwise, <c>false</c>.
        /// </value>
        bool UseSSL { get; set; }

        /// <summary>
        /// Gets or sets the default email from.
        /// </summary>
        /// <value>
        /// The default email from.
        /// </value>
        string DefaultEmailFrom { get; set; }

        /// <summary>
        /// Gets or sets the default name of the email.
        /// </summary>
        /// <value>
        /// The default name of the email.
        /// </value>
        string DefaultEmailName { get; set; }
    }
}
