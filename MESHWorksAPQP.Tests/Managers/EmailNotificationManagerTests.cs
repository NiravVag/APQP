// <copyright file="EmailNotificationManagerTests.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Tests.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using MESHWorksAPQP.Management.Command.Setup.EmailNotification;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.EmailNotification;
    using MESHWorksAPQP.Management.Managers.Setup.EmailNotification;
    using MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Shared.Enum;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// class EmailNotificationManagerTests.
    /// </summary>
    [TestClass]
    public class EmailNotificationManagerTests
    {
        /// <summary>
        /// The EmailNotification identifier.
        /// </summary>
        private Guid Id;

        /// <summary>
        /// The manager.
        /// </summary>
        private IEmailNotificationManager manager;

        /// <summary>
        /// The mapper.
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private Mock<ISetupRepositoty<EmailNotification>> repository;

        /// <summary>
        /// The EmailNotification
        /// </summary>
        private EmailNotification emailnotification;

        /// <summary>
        /// The setup vm.
        /// </summary>
        private EmailNotificationVM emailNotificationVm;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificationManagerTests"/> class.
        /// </summary>
        public EmailNotificationManagerTests()
        {
            this.mapper = new Mock<IMapper>();
            this.repository = new Mock<ISetupRepositoty<EmailNotification>>();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.Id = new Guid("7EE8B8B4-AF09-4F06-AE27-4524C79AB2A8");
            this.manager = new EmailNotificationManager(this.mapper.Object, this.repository.Object);
            this.emailnotification = new EmailNotification()
            {
                Id = this.Id,
                CompanyType = CompanyType.Customer,
                IsOwnerOptionAvailable=true,
                Name = "Order Alert",
                Code = "OA01",
                Description = "New Purchase Order",
                SortOrder = 0
            };

            this.emailNotificationVm = new EmailNotificationVM()
            {
                Id = this.Id,
                CompanyType = CompanyType.Customer,
                IsOwnerOptionAvailable = true,
                Name = "Order Alert",
                Code = "OA01",
                Description = "New Purchase Order",
                SortOrder = 0
            };
        }

        /// <summary>
        /// Tests the get EmailNotification when EmailNotification identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetEmailNotification_WhenEmailNotificationIdIsvalid_ReturnsEmailNotificationVM()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<EmailNotification, bool>>>())).Returns(Task.FromResult(this.emailnotification));
            this.mapper.Setup(m => m.Map<EmailNotificationVM>(It.IsAny<EmailNotification>())).Returns(this.emailNotificationVm);

            var result = await this.manager.Get(new GetEmailNotificationCommand
            {
                Id = this.Id,
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.FirstOrDefaultAsync(It.IsAny<Expression<Func<EmailNotification, bool>>>()), Times.Once());
        }

        /// <summary>
        /// Tests the get EmailNotification when EmailNotification identifier is invalid throws exception.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetEmailNotification_WhenEmailNotificationIdIsInvalid_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var result = await this.manager.Get(new GetEmailNotificationCommand
                {
                    Id = new Guid("097C915A-2D0A-4639-801E-C7BEDE9146BA"),
                });
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
            Assert.AreEqual(expectedExcetpion.Message, "Record not found.");
        }

        /// <summary>
        /// Tests the delete EmailNotification when EmailNotification identifier is valid returns true.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_DeleteEmailNotification_WhenEmailNotificationIdIsValid_ReturnsTrue()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<EmailNotification, bool>>>())).Returns(Task.FromResult(this.emailnotification));

            var result = await this.manager.Delete(this.Id);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the save EmailNotification when EmailNotification identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_SaveEmailNotification_WhenEmailNotificationIdIsValid_ReturnsEmailNotificationVM()
        {
            this.repository.Setup(x => x.Create(this.emailnotification));

            this.mapper.Setup(m => m.Map<EmailNotification>(It.IsAny<EmailNotificationVM>())).Returns(this.emailnotification);

            var result = await this.manager.Save(new SaveEmailNotificationCommand
            {
                Entity = new EmailNotificationVM()
                {
                    Id = Guid.NewGuid(),
                    CompanyType = CompanyType.Customer,
                    IsOwnerOptionAvailable = true,
                    Name = "Purchase Invoice Alert",
                    Code = "OI01",
                    Description = "New Purchase Invoice",
                    SortOrder = 0
                },
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.Create(It.IsAny<EmailNotification>()), Times.Once());
            this.mapper.Verify(m => m.Map<EmailNotification>(It.IsAny<EmailNotificationVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the edit EmailNotification when EmailNotification identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_EditEmailNotification_WhenEmailNotificationIdIsValid_ReturnsEmailNotificationVM()
        {
            this.repository.Setup(x => x.Update(this.emailnotification));

            this.mapper.Setup(m => m.Map<EmailNotification>(It.IsAny<EmailNotificationVM>())).Returns(this.emailnotification);

            var result = await this.manager.Save(new SaveEmailNotificationCommand
            {
                Entity = new EmailNotificationVM()
                {
                    Id = this.Id,
                    CompanyType = CompanyType.Customer,
                    IsOwnerOptionAvailable = true,
                    Name = "Purchase Invoice Alert (PIA)",
                    Code = "OI01",
                    Description = "New Purchase Invoice (PIA)",
                    SortOrder = 0
                },
            });

            Assert.IsNotNull(result);
            this.mapper.Verify(m => m.Map<EmailNotification>(It.IsAny<EmailNotificationVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the search EmailNotification when EmailNotification identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_SearchEmailNotification_WhenEmailNotificationIdIsValid_ReturnsEmailNotificationVM()
        {
            var emailnotifications = new List<EmailNotification>
            {
               this.emailnotification,
            };

            this.repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<EmailNotification, bool>>>())).Returns(emailnotifications.AsQueryable());

            this.mapper.Setup(x => x.ConfigurationProvider)
               .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<EmailNotification, EmailNotificationListVM>(); }));

            this.mapper
           .Setup(c => c.ProjectTo(
               It.Is<IQueryable<EmailNotification>>(x => x.Any()),
               It.IsAny<object>(),
               It.Is<Expression<Func<EmailNotification, object>>[]>(x => x.Length == 0)))
           .Returns(emailnotifications.AsQueryable());

            var result = await this.manager.Search(new SearchEmailNotificationCommand
            {
                Filter = new EmailNotificationFilterVM
                {
                    Code = "OA01",
                    CompanyType = CompanyType.Customer
                },
            });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.TotalSize > 0);
        }
    }
}
