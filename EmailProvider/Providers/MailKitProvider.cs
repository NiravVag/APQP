// <copyright file="MailKitProvider.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.Providers
{
    using System.Threading.Tasks;
    using EmailProvider.Interface.Providers;
    using MailKit.Net.Smtp;
    using MESHWorksAPQP.Model.Models.Email;
    using MimeKit;

    /// <summary>
    /// Class MailKitProvider.
    /// </summary>
    /// <seealso cref="MESHWorks.Management.Interface.Provider.IMailKitProvider" />
    public class MailKitProvider : IMailKitProvider
    {
        /// <summary>
        /// Sends the specified from.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="emailConfiguration">The emailConfiguration.</param>
        /// <returns>Task.</returns>
        public async Task Send(MimeMessage message, EmailConfiguration emailConfiguration)
        {
            if (message.From.Count == 0)
            {
                // message.From.Add(MailboxAddress.Parse(this.smtpSetting.DefaultEmailFrom));
                message.From.Add(new MailboxAddress(emailConfiguration.Name, emailConfiguration.Email));
            }

            using (var emailClient = new SmtpClient())
            {
                if (emailConfiguration.UseSSL)
                {
                    emailClient.Connect(emailConfiguration.Server, emailConfiguration.Port, false);
                }
                else
                {
                    emailClient.Connect(emailConfiguration.Server, emailConfiguration.Port, MailKit.Security.SecureSocketOptions.StartTls);
                }

                emailClient.Capabilities &= ~(SmtpCapabilities.Chunking | SmtpCapabilities.BinaryMime | SmtpCapabilities.Size);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(emailConfiguration.Email, emailConfiguration.Password);
                await emailClient.SendAsync(message);

                emailClient.Disconnect(true);
            }
        }
    }
}
