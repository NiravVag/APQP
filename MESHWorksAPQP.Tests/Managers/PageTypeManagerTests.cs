// <copyright file="PageTypeManagerTests.cs" company="MESHWorksAPQP">
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
    using MESHWorksAPQP.Management.Command.Setup.PageType;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.PageType;
    using MESHWorksAPQP.Management.Managers.Setup.PageType;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.PageType;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// class PageTypeManagerTests.
    /// </summary>
    [TestClass]
    public class PageTypeManagerTests
    {
        /// <summary>
        /// The pagetype identifier.
        /// </summary>
        private Guid pageTypeId;

        /// <summary>
        /// The manager.
        /// </summary>
        private IPageTypeManager manager;

        /// <summary>
        /// The mapper.
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private Mock<ISetupRepositoty<PageType>> repository;

        /// <summary>
        /// The pagetype
        /// </summary>
        private PageType pageType;

        /// <summary>
        /// The setup vm.
        /// </summary>
        private SetupVM setupVm;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageTypeManagerTests"/> class.
        /// </summary>
        public PageTypeManagerTests()
        {
            this.mapper = new Mock<IMapper>();
            this.repository = new Mock<ISetupRepositoty<PageType>>();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.pageTypeId = new Guid("8136b9ff-7fc0-449d-9659-90d2e2b1605d");
            this.manager = new PageTypeManager(this.mapper.Object, this.repository.Object);
            this.pageType = new PageType()
            {
                Id = this.pageTypeId,
                Code = "2345",
                Name = "XYZ",
                Description = "Page Type description",
                SortOrder = 1,
                IsDeleted = false,
            };

            this.setupVm = new SetupVM()
            {
                Id = this.pageTypeId,
                Code = "2345",
                Name = "XYZ",
                Description = "Page Type description",
                SortOrder = 1,
                IsDeleted = false,
            };
        }

        /// <summary>
        /// Tests the get page when page identifier is valid returns setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetPageType_WhenPageTypeIdIsvalid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<PageType, bool>>>())).Returns(Task.FromResult(this.pageType));
            this.mapper.Setup(m => m.Map<SetupVM>(It.IsAny<PageType>())).Returns(this.setupVm);

            var result = await this.manager.Get(new GetPageTypeCommand
            {
                Id = this.pageTypeId,
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.FirstOrDefaultAsync(It.IsAny<Expression<Func<PageType, bool>>>()), Times.Once());
        }

        /// <summary>
        /// Tests the get pagetype when pagetype identifier is invalid throws exception.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetPageType_WhenPageTypeIdIsInvalid_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var result = await this.manager.Get(new GetPageTypeCommand
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
        /// Tests the delete pagetype when pagetype identifier is valid returns true.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_DeletePageType_WhenPageTypeIdIsValid_ReturnsTrue()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<PageType, bool>>>())).Returns(Task.FromResult(this.pageType));

            var result = await this.manager.Delete(this.pageTypeId);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the save pagetype when pagetype identifier is valid returns setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_SavePageType_WhenPageTypeIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Create(this.pageType));

            this.mapper.Setup(m => m.Map<PageType>(It.IsAny<SetupVM>())).Returns(this.pageType);

            var result = await this.manager.Save(new SavePageTypeCommand
            {
                Entity = new PageTypeVM()
                {
                    Id = Guid.NewGuid(),
                    Code = "2345",
                    Name = "XYZ",
                    Description = "Page Type description",
                    SortOrder = 1,
                    IsDeleted = false,
                },
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.Create(It.IsAny<PageType>()), Times.Once());
            this.mapper.Verify(m => m.Map<PageType>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the edit pagetype when pagetype identifier is valid returns setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_EditPageType_WhenPageTypeIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Update(this.pageType));
            this.mapper.Setup(m => m.Map<PageType>(It.IsAny<SetupVM>())).Returns(this.pageType);
            var result = await this.manager.Save(new SavePageTypeCommand
            {
                Entity = new PageTypeVM()
                {
                    Id = this.pageTypeId,
                    Code = "2345",
                    Name = "XYZ",
                    Description = "PageType description",
                    SortOrder = 1,
                    IsDeleted = false,
                },
            });

            Assert.IsNotNull(result);
            this.mapper.Verify(m => m.Map<PageType>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the search pagetype when pagetype identifier is valid returns setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_SearchPageType_WhenPageTypeIdIsValid_ReturnsSetupVM()
        {
            var pagetypes = new List<PageType>
            {
               this.pageType,
            };

            this.repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<PageType, bool>>>())).Returns(pagetypes.AsQueryable());

            this.mapper.Setup(x => x.ConfigurationProvider)
               .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<PageType, SetupListVM>(); }));

            this.mapper
           .Setup(c => c.ProjectTo(
               It.Is<IQueryable<PageType>>(x => x.Any()),
               It.IsAny<object>(),
               It.Is<Expression<Func<PageType, object>>[]>(x => x.Length == 0)))
           .Returns(pagetypes.AsQueryable());

            var result = await this.manager.Search(new SearchPageTypeCommand
            {
                Filter = new PageTypeFilterVM
                {
                    PageTypeId = this.pageTypeId,
                },
            });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.TotalSize > 0);
        }
    }
}
