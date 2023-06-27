// <copyright file="SmtpSetting.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EmailProvider.Interface.Settings;

    /// <summary>
    /// Class SmtpSetting.
    /// </summary>
    public class SmtpSetting : ISmtpSetting
    {
        /// <summary>
        /// Gets or sets the override email.
        /// </summary>
        /// <value>
        /// The override email.
        /// </value>
        public string OverrideEmail { get; set; }

        /// <summary>
        /// Gets or sets the environment name.
        /// </summary>
        /// <value>
        /// The environment name.
        /// </value>
        public string EnvironmentName { get; set; }

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public string Server { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use SSL].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use SSL]; otherwise, <c>false</c>.
        /// </value>
        public bool UseSSL { get; set; }

        /// <summary>
        /// Gets or sets the default email from.
        /// </summary>
        /// <value>
        /// The default email from.
        /// </value>
        public string DefaultEmailFrom { get; set; }

        /// <summary>
        /// Gets or sets the default name of the email.
        /// </summary>
        /// <value>
        /// The default name of the email.
        /// </value>
        public string DefaultEmailName { get; set; }
    }
}
