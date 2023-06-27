// <copyright file="EmailManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.Managers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using EmailProvider.Interface.Managers;
    using EmailProvider.Interface.Providers;
    using EmailProvider.Interface.Settings;
    using EmailProvider.ViewModels;
    using EmailProvider.ViewModels.Abstract;
    using MESHWorksAPQP.Model.Models.Email;
    using MESHWorksAPQP.Repository.Interfaces.Email;
    using MESHWorksAPQP.Shared.Enum;
    using MimeKit;
    using StorageManager.Interface;

    /// <summary>
    /// Class EmailManager.
    /// </summary>
    /// <seealso cref="EmailProvider.Interface.Managers.IEmailManager" />
    public class EmailManager : IEmailManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The email placeholder repository.
        /// </summary>
        private readonly IEmailPlaceHolderRepository emailPlaceHolderRepository;

        /// <summary>
        /// The email provider.
        /// </summary>
        private readonly IMailKitProvider smtpProvider;

        /// <summary>
        /// The SMTP setting.
        /// </summary>
        private readonly IEmailTemplateRepository emailTemplateRepository;

        /// <summary>
        /// The email message repository.
        /// </summary>
        private readonly IEmailMessageRepository emailMesssageRepository;

        /// <summary>
        /// The SMTP setting.
        /// </summary>
        private readonly ISmtpSetting smtpSetting;

        /// <summary>
        /// The document storage manager.
        /// </summary>
        private readonly IDocumentStorageManager documentStorageManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailManager" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="smtpProvider">The SMTP provider.</param>
        /// <param name="emailPlaceHolderRepository">The email place holder repository.</param>
        /// <param name="emailTemplateRepository">The email template repository.</param>
        /// <param name="emailMesssageRepository">The email messsage repository.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="smtpSetting">The SMTP setting.</param>
        /// <param name="documentStorageManager">The document storage manager.</param>
        public EmailManager(IMapper mapper, IMailKitProvider smtpProvider, IEmailPlaceHolderRepository emailPlaceHolderRepository, IEmailTemplateRepository emailTemplateRepository, IEmailMessageRepository emailMesssageRepository, ISmtpSetting smtpSetting, IDocumentStorageManager documentStorageManager)
        {
            this.mapper = mapper;
            this.smtpProvider = smtpProvider;
            this.emailPlaceHolderRepository = emailPlaceHolderRepository;
            this.emailTemplateRepository = emailTemplateRepository;
            this.emailMesssageRepository = emailMesssageRepository;
            this.smtpSetting = smtpSetting;
            this.documentStorageManager = documentStorageManager;
        }

        /// <summary>
        /// Customer discussion.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Task.
        /// </returns>
        public async Task Discussion(DiscussionVM model)
        {
            await this.CreateAndSend(model);
        }

        /// <summary>
        /// Contacts the us to mesh.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Task.
        /// </returns>
        public async Task ContactUsToAdmin(ContactUsToAdminVM model)
        {
            await this.CreateAndSend(model);
        }

        /// <summary>
        /// Sends the gate closure email.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Task.
        /// </returns>
        public async Task SendGateClosureEmail(GateClosureEmailVM model)
        {
            await this.CreateAndSend(model);
        }

        /// <summary>
        /// Gates the closure approval email.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Task.
        /// </returns>
        public async Task GateClosureApprovalEmail(GateClosureApprovalEmailVM model)
        {
            await this.CreateAndSend(model);
        }

        /// <summary>
        /// Raises the gate closure approval email.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Task.
        /// </returns>
        public async Task RaiseGateClosureApprovalEmail(RaiseGateClosureApprovalEmailVM model)
        {
            await this.CreateAndSend(model);
        }

        /// <summary>
        /// Processes the email.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task ProcessEmail()
        {
            var messages = this.emailMesssageRepository.GetAll(x => x.Status == EmailStatus.Draft).OrderBy(x => x.Created);
            foreach (var message in messages)
            {
                await this.SendEmail(message);
            }

            await this.emailMesssageRepository.SaveAsync("ProcessEmail");
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="messageEntity">The message entity.</param>
        private async Task SendEmail(EmailMessage messageEntity)
        {
            try
            {
                var message = new MimeMessage();
                message.Subject = messageEntity.Subject;
                var builder = new BodyBuilder { HtmlBody = messageEntity.Body };

                if (messageEntity.HasAttachment && messageEntity.EmailAttachments != null && messageEntity.EmailAttachments.Any())
                {
                    foreach (var attachment in messageEntity.EmailAttachments)
                    {
                        if (await this.documentStorageManager.DocumentExists(attachment.FilePath))
                        {
                            var fileContent = await this.documentStorageManager.GetDocumentBytes(attachment.FilePath);

                            builder.Attachments.Add(attachment.FileName, fileContent);
                        }
                    }
                }

                message.Body = builder.ToMessageBody();

                if (!string.IsNullOrWhiteSpace(messageEntity.EmailFrom))
                {
                    message.From.Add(MailboxAddress.Parse(messageEntity.EmailFrom));
                }

                if (!string.IsNullOrWhiteSpace(messageEntity.To))
                {
                    messageEntity.To.Split(',').ToList().ForEach(a => message.To.Add(MailboxAddress.Parse(a)));
                }

                if (!string.IsNullOrWhiteSpace(messageEntity.CC))
                {
                    messageEntity.CC.Split(',').ToList().ForEach(a => message.Cc.Add(MailboxAddress.Parse(a)));
                }

                if (!string.IsNullOrWhiteSpace(messageEntity.BCC))
                {
                    messageEntity.BCC.Split(',').ToList().ForEach(a => message.Bcc.Add(MailboxAddress.Parse(a)));
                }

                await this.smtpProvider.Send(message, messageEntity.EmailTemplate.EmailConfiguration);

                messageEntity.Status = EmailStatus.Sent;
            }
            catch (Exception ex)
            {
                messageEntity.Status = EmailStatus.Failed;
                messageEntity.ErrorMessage = ex.InnerException.ToString();
            }
        }

        /// <summary>
        /// Creates the and send.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="model">The model.</param>
        private async Task CreateAndSend<T>(T model)
           where T : BaseEmailVM
        {
            var emailTemplate = await this.emailTemplateRepository.FirstOrDefaultAsync(x => x.EmailTemplateType == model.EmailTemplateType && !x.IsDeleted);

            if (emailTemplate.EmailNotificationId.HasValue)
            {
                var users = await this.emailTemplateRepository.GetEmailNotificationUsers(emailTemplate.EmailNotificationId.Value, model.CompanyId, model.UserId);

                if (users != null && users.Any())
                {
                    if (model.To == null)
                    {
                        model.To = new List<string>();
                    }

                    model.To.AddRange(users.Select(x => x.UserName));
                }
            }

            model.Status = EmailStatus.Draft;
            model.From = emailTemplate.EmailConfiguration.Email;
            model.Subject = string.IsNullOrWhiteSpace(model.Subject) ? emailTemplate.Subject : model.Subject;
            model.Body = this.EmailOuterBody(emailTemplate.Body);
            model.CC = emailTemplate.CC;
            model.BCC = emailTemplate.BCC;
            model = this.ReplacePlaceholder(model.EmailTemplateType, model);

            if (!string.IsNullOrWhiteSpace(this.smtpSetting.OverrideEmail))
            {
                model.Subject += $" - {this.smtpSetting.EnvironmentName} To: {string.Join(",", model.To)}";

                if (!string.IsNullOrWhiteSpace(model.CC))
                {
                    model.Subject += $" CC: {model.CC})";
                    model.CC = string.Empty;
                }

                if (!string.IsNullOrWhiteSpace(model.BCC))
                {
                    model.Subject += $" BCC: {model.BCC}";
                    model.BCC = string.Empty;
                }

                model.To.Clear();
                model.To.Add(this.smtpSetting.OverrideEmail);
            }

            await this.Save(model, emailTemplate);
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="emailTemplate">The email template.</param>
        /// <exception cref="ValidationException">User not found.</exception>
        private async Task Save(BaseEmailVM model, EmailTemplate emailTemplate)
        {
            var entity = new EmailMessage();

            entity.Id = Guid.NewGuid();
            entity.CompanyId = model.CompanyId;
            entity.UserId = model.UserId;
            entity.EmailTemplateId = emailTemplate.Id;
            entity.EmailTemplateType = model.EmailTemplateType;
            entity.ReferenceEntityId = model.ReferenceEntityId;
            entity.EmailFrom = model.From;
            entity.To = string.Join(",", model.To);
            entity.CC = model.CC;
            entity.BCC = model.BCC;
            entity.Subject = model.Subject;
            entity.Body = model.Body;
            entity.DateSent = DateTime.UtcNow;
            entity.Status = model.Status;
            entity.RetryCount = model.RetryCount;

            if (model.Attachments != null && model.Attachments.Any())
            {
                entity.HasAttachment = true;
                entity.EmailAttachments = new List<EmailAttachment>();
                foreach (var attachment in model.Attachments)
                {
                    entity.EmailAttachments.Add(new EmailAttachment
                    {
                        FileName = attachment.FileName,
                        FilePath = attachment.FilePath,
                        ContentType = attachment.ContentType
                    });
                }
            }

            this.emailMesssageRepository.Create(entity);
            await this.emailMesssageRepository.SaveAsync(model.UserId.HasValue ? model.UserId.ToString() : model.EmailTemplateType.ToString());
        }

        /// <summary>
        /// Replaces the placeholder.
        /// </summary>
        /// <typeparam name="T">BaseEmailVM.</typeparam>
        /// <param name="emailTemplateType">Type of the email template.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="BaseEmailVM"/>.</returns>
        private T ReplacePlaceholder<T>(EmailTemplateType emailTemplateType, T model) where T : BaseEmailVM
        {
            var emailPlaceHolders = this.emailPlaceHolderRepository.GetAll(x => x.EmailTemplateType == emailTemplateType && !x.IsDeleted);

            StringBuilder sbSubject = new StringBuilder(model.Subject);
            StringBuilder sbBody = new StringBuilder(model.Body);

            var modeType = model.GetType();
            foreach (var emailPlaceHolder in emailPlaceHolders)
            {
                sbSubject.Replace(emailPlaceHolder.Name, modeType.GetProperty(emailPlaceHolder.FieldName).GetValue(model).ToString());
                sbBody.Replace(emailPlaceHolder.Name, modeType.GetProperty(emailPlaceHolder.FieldName).GetValue(model).ToString());
            }

            model.Subject = sbSubject.ToString();
            model.Body = sbBody.ToString();

            return model;
        }

        /// <summary>
        /// Emails the outer body.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <returns>string</returns>
        private string EmailOuterBody(string body)
        {
            string strBody = @"<!doctype html>
            <html lang='en'>
               <head>
                  <meta charset='utf-8'>
                  <meta name='viewport' content='width=device-width, initial-scale=1'>
                  <title>Mesh Global Sourcing</title>
                  <meta name='description' content='Metrics Works'>
                  <link rel='preconnect' href='https://fonts.googleapis.com'>
                  <link rel='preconnect' href='https://fonts.gstatic.com' crossorigin>
                  <link href='https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700;900&display=swap' rel='stylesheet'>
                  <style>
                     body{background:#f1f0f5; margin: 20px 0; font-size:14px; color:rgba(0,0,0,0.8);}
                     table{max-width: 700px; background: #fff; border-radius:10px; width: 100%; font-family: 'Roboto', sans-serif; box-shadow: 0px 0px 11px 0px rgba(0,0,0,0.19);
                     -webkit-box-shadow: 0px 0px 11px 0px rgba(0,0,0,0.19);
                     -moz-box-shadow: 0px 0px 11px 0px rgba(0,0,0,0.19);}
                     table td{padding:10px;}
                  </style>
               </head>
               <body>
                  <table  width='100%' border='0' cellspacing='0' cellpadding='0'  align='center'>
                     <tr align='left' valign='middle'>
                        <td><img src='https://mesh-dev.globalsourcing.com/assets/img/mes-logo.png' width='200px'></td>
                     </tr>
                     <tr>
                        <td colspan='2' style=' padding:10px 20px'>
                           ##content##
                        </td>
                     </tr>
                     <tr>
                        <td colspan='2'  style='border-top:1px solid #f1f0f5; padding:20px 10px; text-align:center'>
                           <p>© copyright 2021 by Mesh Global Sourcing</p>
                        </td>
                     </tr>
                  </table>
               </body>
            </html>";

            return strBody.Replace("##content##", body);
        }

    }
}
