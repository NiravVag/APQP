INSERT [Email].[EmailConfiguration] ([Id], [Code], [Name], [Server], [Email], [Password], [Port], [UseSSL], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'fa2f7196-36b7-41ee-a77d-70613b514b4d', N'Globalsourcing', N'Globalsourcing', N'smtp.office365.com', N'support@globalsourcing.com', N'HomeForceStart88#', 587, 0, CAST(N'2022-03-24T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailTemplate] ([Id], [EmailConfigurationId], [EmailTemplateType], [Code], [Name], [Subject], [Body], [CC], [BCC], [EmailNotificationId], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'06b8033c-6f1e-447d-b960-1237439dcffe', N'fa2f7196-36b7-41ee-a77d-70613b514b4d', 4, N'GateClosureApprovalEmail', N'Gate Closure Approva Email', N'Gate Closure Approval Email', N'Hi 
 <br />  
 <br />  
 ##Message##  
 <br /> 
 <br />   
 Status : ##ApprovalStatus##
 <br /> 
 <br />  
 Click on the link to Review  
 <br />
 <a href=''##ApqpProjectLink##''>View APQP Project</a>  
 <br />  
 <br />  
Thank you,  
<br />
Mesh Global Sourcing Team', NULL, NULL, NULL, CAST(N'2022-04-15T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailTemplate] ([Id], [EmailConfigurationId], [EmailTemplateType], [Code], [Name], [Subject], [Body], [CC], [BCC], [EmailNotificationId], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'cf6dd3f9-1f4b-4b37-b182-53163e4cc695', N'fa2f7196-36b7-41ee-a77d-70613b514b4d', 3, N'GateClosureEmail', N'Gate Closure Email', N'Gate Closure', N'Dear ##ClosureEmailRecipient##,  <br />  <br />  ##Message##  <br />  <br />   <br /> <br /> Click on the link to Review  <br /><a href=''##ApqpProjectLink##''>View APQP Project</a>  <br />  <br />  Thank you,  <br />  ##ClosureEmailSender##', NULL, NULL, NULL, CAST(N'2022-03-24T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailTemplate] ([Id], [EmailConfigurationId], [EmailTemplateType], [Code], [Name], [Subject], [Body], [CC], [BCC], [EmailNotificationId], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'912b3ad4-1b4e-4638-b15d-e49be1539b96', N'fa2f7196-36b7-41ee-a77d-70613b514b4d', 5, N'RaiseGateClosureApprovalEmai', N'Raise Gate Closure Approval Emai', N'Approval request', N'Hi 
 <br />  
 <br />  
 ##Message##  
 <br /> 
 <br />   

 Click on the link to Review  
 <br />
 <a href=''##ApqpProjectLink##''>View APQP Project</a>  
 <br />  
 <br />  
Thank you,  
<br />
Mesh Global Sourcing Team', NULL, NULL, NULL, CAST(N'2022-04-15T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailPlaceHolder] ([Id], [EmailTemplateType], [FieldName], [Name], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'c6e95954-089e-46e3-8d31-032b28076f66', 5, N'Message', N'##Message##', CAST(N'2022-04-15T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailPlaceHolder] ([Id], [EmailTemplateType], [FieldName], [Name], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'd3e95f38-e5a2-4abf-9e31-14bbff408a19', 3, N'ApqpProjectLink', N'##ApqpProjectLink##', CAST(N'2022-03-24T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailPlaceHolder] ([Id], [EmailTemplateType], [FieldName], [Name], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'd772c736-5ea4-4bc3-b4f2-15434b87c325', 4, N'Message', N'##Message##', CAST(N'2022-04-15T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailPlaceHolder] ([Id], [EmailTemplateType], [FieldName], [Name], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'db90f8ae-c4b3-4502-b7c9-177ab9da0ea7', 5, N'ApqpProjectLink', N'##ApqpProjectLink##', CAST(N'2022-04-15T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailPlaceHolder] ([Id], [EmailTemplateType], [FieldName], [Name], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'7111110c-fe62-480f-9f11-1e0aacecc61e', 3, N'ClosureEmailRecipient', N'##ClosureEmailRecipient##', CAST(N'2022-03-24T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailPlaceHolder] ([Id], [EmailTemplateType], [FieldName], [Name], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'c2985394-9fe3-47dc-a323-80f94a123b39', 4, N'ApqpProjectLink', N'##ApqpProjectLink##', CAST(N'2022-04-15T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailPlaceHolder] ([Id], [EmailTemplateType], [FieldName], [Name], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'b084128e-6886-4e5b-b388-ab2762601366', 3, N'ClosureEmailSender', N'##ClosureEmailSender##', CAST(N'2022-03-24T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailPlaceHolder] ([Id], [EmailTemplateType], [FieldName], [Name], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'de791a21-bf73-431b-bcca-b4f522ff3153', 4, N'ApprovalStatus', N'##ApprovalStatus##', CAST(N'2022-04-15T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
INSERT [Email].[EmailPlaceHolder] ([Id], [EmailTemplateType], [FieldName], [Name], [Created], [CreatedBy], [LastModified], [LastModifiedBy], [IsDeleted]) VALUES (N'c644baa9-ebff-4930-aeb4-fb6e06c445af', 3, N'Message', N'##Message##', CAST(N'2022-03-24T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL, 0)
GO
