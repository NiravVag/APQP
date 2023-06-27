// <copyright file="CommodityManagerTests.cs" company="MESHWorksAPQP">
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
    using MESHWorksAPQP.Management.Command.Setup.Commodity;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Commodity;
    using MESHWorksAPQP.Management.Managers.Setup.Commodity;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// class CommodityManagerTests.
    /// </summary>
    [TestClass]
    public class CommodityManagerTests
    {
        /// <summary>
        /// The Commodity identifier.
        /// </summary>
        private Guid Id;

        /// <summary>
        /// The manager.
        /// </summary>
        private ICommodityManager manager;

        /// <summary>
        /// The mapper.
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private Mock<ISetupRepositoty<Commodity>> repository;

        /// <summary>
        /// The Commodity
        /// </summary>
        private Commodity commodity;

        /// <summary>
        /// The setup vm.
        /// </summary>
        private SetupVM setupVm;

        /// <summary>
        /// The user identity
        /// </summary>
        private Mock<IUserIdentity> userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommodityManagerTests"/> class.
        /// </summary>
        public CommodityManagerTests()
        {
            this.mapper = new Mock<IMapper>();
            this.repository = new Mock<ISetupRepositoty<Commodity>>();
            this.userIdentity = new Mock<IUserIdentity>();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.Id = new Guid("096C915A-2D0A-4639-801E-C7BEDE9146BA");
            this.manager = new CommodityManager(this.mapper.Object, this.repository.Object, this.userIdentity.Object);
            this.commodity = new Commodity()
            {
                Id = this.Id,
                Name = "Printers",
                Code = "8443",
                Description = "All Types of Printers",
                SortOrder = 0,
                IsDeleted = false
            };

            this.setupVm = new SetupVM()
            {
                Id = this.Id,
                Name = "Printers",
                Code = "8443",
                Description = "All Types of Printers",
                SortOrder = 0,
                IsDeleted = false
            };
        }

        /// <summary>
        /// Tests the get Commodity when Commodity identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetCommodity_WhenCommodityIdIsvalid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Commodity, bool>>>())).Returns(Task.FromResult(this.commodity));
            this.mapper.Setup(m => m.Map<SetupVM>(It.IsAny<Commodity>())).Returns(this.setupVm);

            var result = await this.manager.Get(new GetCommodityCommand
            {
                Id = this.Id,
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.FirstOrDefaultAsync(It.IsAny<Expression<Func<Commodity, bool>>>()), Times.Once());
        }

        /// <summary>
        /// Tests the get Commodity when Commodity identifier is invalid throws exception.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetCommodity_WhenCommodityIdIsInvalid_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var result = await this.manager.Get(new GetCommodityCommand
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
        /// Tests the delete Commodity when Commodity identifier is valid returns true.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_DeleteCommodity_WhenCommodityIdIsValid_ReturnsTrue()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Commodity, bool>>>())).Returns(Task.FromResult(this.commodity));

            var result = await this.manager.Delete(this.Id);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the save Commodity when Commodity identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_SaveCommodity_WhenCommodityIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Create(this.commodity));

            this.mapper.Setup(m => m.Map<Commodity>(It.IsAny<SetupVM>())).Returns(this.commodity);

            var result = await this.manager.Save(new SaveCommodityCommand
            {
                Entity = new SetupVM()
                {
                    Id = Guid.NewGuid(),
                    Name = "Monitors ",
                    Code = "8445",
                    Description = "All Types of Monitors",
                    SortOrder = 0,
                    IsDeleted = false
                },
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.Create(It.IsAny<Commodity>()), Times.Once());
            this.mapper.Verify(m => m.Map<Commodity>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the edit Commodity when Commodity identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_EditCommodity_WhenCommodityIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Update(this.commodity));

            this.mapper.Setup(m => m.Map<Commodity>(It.IsAny<SetupVM>())).Returns(this.commodity);

            var result = await this.manager.Save(new SaveCommodityCommand
            {
                Entity = new SetupVM()
                {
                    Id = this.Id,
                    Name = "Monitors ",
                    Code = "8528",
                    Description = "All Types of Monitors",
                    SortOrder = 0
                },
            });

            Assert.IsNotNull(result);
            this.mapper.Verify(m => m.Map<Commodity>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the search Commodity when Commodity identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_SearchCommodity_WhenCommodityIdIsValid_ReturnsSetupVM()
        {
            var commoditys = new List<Commodity>
            {
               this.commodity,
            };

            this.repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Commodity, bool>>>())).Returns(commoditys.AsQueryable());

            this.mapper.Setup(x => x.ConfigurationProvider)
               .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<Commodity, SetupListVM>(); }));

            this.mapper
           .Setup(c => c.ProjectTo(
               It.Is<IQueryable<Commodity>>(x => x.Any()),
               It.IsAny<object>(),
               It.Is<Expression<Func<Commodity, object>>[]>(x => x.Length == 0)))
           .Returns(commoditys.AsQueryable());

            var result = await this.manager.Search(new SearchCommodityCommand
            {
                Filter = new SetupFilterVM
                {
                    Code = "8443",
                },
            });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.TotalSize > 0);
        }
    }
}
