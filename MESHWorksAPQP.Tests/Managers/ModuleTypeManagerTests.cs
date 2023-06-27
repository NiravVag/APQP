// <copyright file="ModuleTypeManagerTests.cs" company="MESHWorksAPQP">
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
    using MESHWorksAPQP.Management.Command.Setup.ModuleType;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.ModuleType;
    using MESHWorksAPQP.Management.Managers.Setup.ModuleType;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// class ModuleTypeManagerTests.
    /// </summary>
    [TestClass]
    public class ModuleTypeManagerTests
    {
        /// <summary>
        /// The ModuleType identifier.
        /// </summary>
        private Guid id;

        /// <summary>
        /// The manager.
        /// </summary>
        private IModuleTypeManager manager;

        /// <summary>
        /// The mapper.
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private Mock<ISetupRepositoty<ModuleType>> repository;

        /// <summary>
        /// The ModuleType
        /// </summary>
        private ModuleType moduletype;

        /// <summary>
        /// The setup vm.
        /// </summary>
        private SetupVM setupVm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleTypeManagerTests"/> class.
        /// </summary>
        public ModuleTypeManagerTests()
        {
            this.mapper = new Mock<IMapper>();
            this.repository = new Mock<ISetupRepositoty<ModuleType>>();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.id = new Guid("559E63E5-C47B-49EC-8447-44E8FE1998C3");
            this.manager = new ModuleTypeManager(this.mapper.Object, this.repository.Object);
            this.moduletype = new ModuleType()
            {
                Id = this.id,
                Name = "Sales Module",
                Code = "SM01",
                Description = "Sales Department",
                SortOrder = 0
            };

            this.setupVm = new SetupVM()
            {
                Id = this.id,
                Name = "Sales Module",
                Code = "SM01",
                Description = "Sales Department",
                SortOrder = 0
            };
        }

        /// <summary>
        /// Tests the get ModuleType when ModuleType identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetModuleType_WhenModuleTypeIdIsvalid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<ModuleType, bool>>>())).Returns(Task.FromResult(this.moduletype));
            this.mapper.Setup(m => m.Map<SetupVM>(It.IsAny<ModuleType>())).Returns(this.setupVm);

            var result = await this.manager.Get(new GetModuleTypeCommand
            {
                Id = this.id,
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.FirstOrDefaultAsync(It.IsAny<Expression<Func<ModuleType, bool>>>()), Times.Once());
        }

        /// <summary>
        /// Tests the get ModuleType when ModuleType identifier is invalid throws exception.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetModuleType_WhenModuleTypeIdIsInvalid_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var result = await this.manager.Get(new GetModuleTypeCommand
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
        /// Tests the delete ModuleType when ModuleType identifier is valid returns true.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_DeleteModuleType_WhenModuleTypeIdIsValid_ReturnsTrue()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<ModuleType, bool>>>())).Returns(Task.FromResult(this.moduletype));

            var result = await this.manager.Delete(this.id);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the save ModuleType when ModuleType identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_SaveModuleType_WhenModuleTypeIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Create(this.moduletype));

            this.mapper.Setup(m => m.Map<ModuleType>(It.IsAny<SetupVM>())).Returns(this.moduletype);

            var result = await this.manager.Save(new SaveModuleTypeCommand
            {
                Entity = new SetupVM()
                {
                    Id = Guid.NewGuid(),
                    Name = "Production Module",
                    Code = "PR01",
                    Description = "Production Department",
                    SortOrder = 0
                },
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.Create(It.IsAny<ModuleType>()), Times.Once());
            this.mapper.Verify(m => m.Map<ModuleType>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the edit ModuleType when ModuleType identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_EditModuleType_WhenModuleTypeIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Update(this.moduletype));

            this.mapper.Setup(m => m.Map<ModuleType>(It.IsAny<SetupVM>())).Returns(this.moduletype);

            var result = await this.manager.Save(new SaveModuleTypeCommand
            {
                Entity = new SetupVM()
                {
                    Id = this.id,
                    Name = "Production Module (PM)",
                    Code = "PR01",
                    Description = "Production Department (PM)",
                    SortOrder = 0
                },
            });

            Assert.IsNotNull(result);
            this.mapper.Verify(m => m.Map<ModuleType>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the search ModuleType when ModuleType identifier is valid returns Setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_SearchModuleType_WhenModuleTypeIdIsValid_ReturnsSetupVM()
        {
            var moduletypes = new List<ModuleType>
            {
               this.moduletype,
            };

            this.repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<ModuleType, bool>>>())).Returns(moduletypes.AsQueryable());

            this.mapper.Setup(x => x.ConfigurationProvider)
               .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<ModuleType, SetupListVM>(); }));

            this.mapper
           .Setup(c => c.ProjectTo(
               It.Is<IQueryable<ModuleType>>(x => x.Any()),
               It.IsAny<object>(),
               It.Is<Expression<Func<ModuleType, object>>[]>(x => x.Length == 0)))
           .Returns(moduletypes.AsQueryable());

            var result = await this.manager.Search(new SearchModuleTypeCommand
            {
                Filter = new SetupFilterVM
                {
                    Code = "PR01",
                },
            });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.TotalSize > 0);
        }
    }
}
