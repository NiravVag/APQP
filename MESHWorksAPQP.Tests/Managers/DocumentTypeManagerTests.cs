// <copyright file="DocumentTypeManagerTests.cs" company="MESHWorksAPQP">
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
    using MESHWorksAPQP.Management.Command.Setup.DocumentType;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.DocumentType;
    using MESHWorksAPQP.Management.Managers.Setup.DocumentType;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Shared.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// class DocumentTypeManagerTests.
    /// </summary>
    [TestClass]
    public class DocumentTypeManagerTests
    {
        /// <summary>
        /// The company identifier.
        /// </summary>
        private Guid companyId;

        /// <summary>
        /// The DocumentType identifier.
        /// </summary>
        private Guid id;

        /// <summary>
        /// The manager.
        /// </summary>
        private IDocumentTypeManager manager;

        /// <summary>
        /// The mapper.
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private Mock<ISetupRepositoty<DocumentType>> repository;

        /// <summary>
        /// The DocumentType
        /// </summary>
        private DocumentType documenttype;

        /// <summary>
        /// The DocumentType vm.
        /// </summary>
        private SetupVM setupVM;

        /// <summary>
        /// The user identity.
        /// </summary>
        private Mock<IUserIdentity> userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTypeManagerTests"/> class.
        /// </summary>
        public DocumentTypeManagerTests()
        {
            this.mapper = new Mock<IMapper>();
            this.repository = new Mock<ISetupRepositoty<DocumentType>>();
            this.userIdentity = new Mock<IUserIdentity>();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.companyId = new Guid("DD5BA0B4-FBA3-4DD1-BB6C-D783C41CEE4B");
            this.id = new Guid("2F4896A7-E22B-4AC7-93D7-AC8B0A89B3E2");
            this.manager = new DocumentTypeManager(this.mapper.Object, this.repository.Object, this.userIdentity.Object);
            this.documenttype = new DocumentType()
            {
                Id = this.id,
                CompanyID = this.companyId,
                Name = "Test Doc New",
                Code = "TDN123",
                Description = "Test Doc New Desc",
                SortOrder = 0
            };

            this.setupVM = new SetupVM()
            {
                Id = this.id,
                CompanyId = this.companyId,
                Name = "Test Doc New",
                Code = "TDN123",
                Description = "Test Doc New Desc",
                SortOrder = 0
            };
        }

        /// <summary>
        /// Tests the get DocumentType when DocumentType identifier invalid returns DocumentType vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetDocumentType_WhenDocumentTypeIdInvalid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<DocumentType, bool>>>())).Returns(Task.FromResult(this.documenttype));
            this.mapper.Setup(m => m.Map<SetupVM>(It.IsAny<DocumentType>())).Returns(this.setupVM);

            var result = await this.manager.Get(new GetDocumentTypeCommand
            {
                Id = this.id,
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.FirstOrDefaultAsync(It.IsAny<Expression<Func<DocumentType, bool>>>()), Times.Once());
        }

        /// <summary>
        /// Tests the get DocumentType when DocumentType identifier is invalid throws exception.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetDocumentType_WhenDocumentTypeIdIsInvalid_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var result = await this.manager.Get(new GetDocumentTypeCommand
                {
                    Id = new Guid("0079B9E8-BEFB-4864-5D68-08D9D9A54648"),
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
        /// Tests the delete DocumentType when DocumentType identifier is valid returns true.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_DeleteDocumentType_WhenDocumentTypeIdIsValid_ReturnsTrue()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<DocumentType, bool>>>())).Returns(Task.FromResult(this.documenttype));

            var result = await this.manager.Delete(this.id);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the save DocumentType when DocumentType identifier is valid returns DocumentType vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_SaveDocumentType_WhenDocumentTypeIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Create(this.documenttype));

            this.mapper.Setup(m => m.Map<DocumentType>(It.IsAny<SetupVM>())).Returns(this.documenttype);

            var result = await this.manager.Save(new SaveDocumentTypeCommand
            {
                Entity = new SetupVM()
                {
                    CompanyId = this.companyId,
                    Name = "Test Doc Type New",
                    Code = "TDN124",
                    Description = "Test Doc Type New Desc",
                    SortOrder = 0
                },
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.Create(It.IsAny<DocumentType>()), Times.Once());
            this.mapper.Verify(m => m.Map<DocumentType>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the edit DocumentType when DocumentType identifier is valid returns DocumentType vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_EditDocumentType_WhenDocumentTypeIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Update(this.documenttype));

            this.mapper.Setup(m => m.Map<DocumentType>(It.IsAny<SetupVM>())).Returns(this.documenttype);

            var result = await this.manager.Save(new SaveDocumentTypeCommand
            {
                Entity = new SetupVM()
                {
                    Id = this.id,
                    CompanyId = this.companyId,
                    Name = "Test Doc Type New Up",
                    Code = "TDN124",
                    Description = "Test Doc Type New Desc",
                    SortOrder = 0
                },
            });

            Assert.IsNotNull(result);
            this.mapper.Verify(m => m.Map<DocumentType>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the search DocumentType when DocumentType identifier is valid returns DocumentType vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_SearchDocumentType_WhenDocumentTypeIdIsValid_ReturnsSetupVM()
        {
            var documenttypes = new List<DocumentType>
            {
               this.documenttype,
            };

            this.repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<DocumentType, bool>>>())).Returns(documenttypes.AsQueryable());

            this.mapper.Setup(x => x.ConfigurationProvider)
               .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<DocumentType, SetupListVM>(); }));

            this.mapper
           .Setup(c => c.ProjectTo(
               It.Is<IQueryable<DocumentType>>(x => x.Any()),
               It.IsAny<object>(),
               It.Is<Expression<Func<DocumentType, object>>[]>(x => x.Length == 0)))
           .Returns(documenttypes.AsQueryable());

            var result = await this.manager.Search(new SearchDocumentTypeCommand
            {
                Filter = new SetupFilterVM
                {
                    Code = "TDN124",
                },
            });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.TotalSize > 0);
        }
    }
}
