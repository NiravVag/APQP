// <copyright file="MaterialTypeManagerTests.cs" company="MESHWorksAPQP">
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
    using MESHWorksAPQP.Management.Command.Setup.MaterialType;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.MaterialType;
    using MESHWorksAPQP.Management.Managers.Setup.MaterialType;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// class PartManagerTests.
    /// </summary>
    [TestClass]
    public class MaterialTypeManagerTests
    {
        /// <summary>
        /// The materialtype identifier.
        /// </summary>
        private Guid materialTypeId;

        /// <summary>
        /// The manager.
        /// </summary>
        private IMaterialTypeManager manager;

        /// <summary>
        /// The mapper.
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private Mock<ISetupRepositoty<MaterialType>> repository;

        /// <summary>
        /// The materialType
        /// </summary>
        private MaterialType materialType;

        /// <summary>
        /// The material vm.
        /// </summary>
        private MaterialVM materialVm;

        /// <summary>
        /// The user identity
        /// </summary>
        private Mock<IUserIdentity> userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialTypeManagerTests"/> class.
        /// </summary>
        public MaterialTypeManagerTests()
        {
            this.mapper = new Mock<IMapper>();
            this.repository = new Mock<ISetupRepositoty<MaterialType>>();
            this.userIdentity = new Mock<IUserIdentity>();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.materialTypeId = new Guid("D079B9E8-BEFB-4864-5D68-08D9D9A54648");
            this.manager = new MaterialTypeManager(this.mapper.Object, this.repository.Object, this.userIdentity.Object);
            this.materialType = new MaterialType()
            {
                Id = this.materialTypeId,
                Code = "2345",
                Name = "XYZ",
                Description = "Process description",
                SortOrder = 1,
                IsDeleted = false,
            };

            this.materialVm = new MaterialVM()
            {
                Id = this.materialTypeId,
                Code = "2345",
                Name = "XYZ",
                Description = "Material Type description",
                SortOrder = 1,
                IsDeleted = false,
            };
        }

        /// <summary>
        /// Tests the get material when material identifier is valid returns setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetMaterialType_WhenMaterialTypeIdIsvalid_ReturnsMaterialVM()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<MaterialType, bool>>>())).Returns(Task.FromResult(this.materialType));
            this.mapper.Setup(m => m.Map<MaterialVM>(It.IsAny<MaterialType>())).Returns(this.materialVm);

            var result = await this.manager.Get(new GetMaterialTypeCommand
            {
                Id = this.materialTypeId,
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.FirstOrDefaultAsync(It.IsAny<Expression<Func<MaterialType, bool>>>()), Times.Once());
        }

        /// <summary>
        /// Tests the get material when material identifier is invalid throws exception.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetMaterial_WhenMaterialIdIsInvalid_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var result = await this.manager.Get(new GetMaterialTypeCommand
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
        /// Tests the delete materialtype when materialtype identifier is valid returns true.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_DeleteMaterialType_WhenMaterialTypeIdIsValid_ReturnsTrue()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<MaterialType, bool>>>())).Returns(Task.FromResult(this.materialType));

            var result = await this.manager.Delete(this.materialTypeId);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the save materialtype when materialtype identifier is valid returns material vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_SaveMaterialType_WhenMaterialTypeIdIsValid_ReturnsMaterialVM()
        {
            this.repository.Setup(x => x.Create(this.materialType));

            this.mapper.Setup(m => m.Map<MaterialType>(It.IsAny<MaterialVM>())).Returns(this.materialType);

            var result = await this.manager.Save(new SaveMaterialTypeCommand
            {
                Entity = new MaterialVM()
                {
                    Id = Guid.NewGuid(),
                    Code = "2345",
                    Name = "XYZ",
                    Description = "MaterialType description",
                    SortOrder = 1,
                    IsDeleted = false,
                },
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.Create(It.IsAny<MaterialType>()), Times.Once());
            this.mapper.Verify(m => m.Map<MaterialType>(It.IsAny<MaterialVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the edit materialtype when materialtype identifier is valid returns setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_EditMaterialType_WhenMaterialTypeIdIsValid_ReturnsMaterialVM()
        {
            this.repository.Setup(x => x.Update(this.materialType));
            this.mapper.Setup(m => m.Map<MaterialType>(It.IsAny<MaterialVM>())).Returns(this.materialType);
            var result = await this.manager.Save(new SaveMaterialTypeCommand
            {
                Entity = new MaterialVM()
                {
                    Id = this.materialTypeId,
                    Code = "2345",
                    Name = "XYZ",
                    Description = "MaterialType description",
                    SortOrder = 1,
                    IsDeleted = false,
                },
            });

            Assert.IsNotNull(result);
            this.mapper.Verify(m => m.Map<MaterialType>(It.IsAny<MaterialVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the search materialtype when materialtype identifier is valid returns setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_SearchMaterialType_WhenMaterialTypeIdIsValid_ReturnsSetupVM()
        {
            var materialtypes = new List<MaterialType>
            {
               this.materialType,
            };

            this.repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<MaterialType, bool>>>())).Returns(materialtypes.AsQueryable());

            this.mapper.Setup(x => x.ConfigurationProvider)
               .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<MaterialType, SetupListVM>(); }));

            this.mapper
           .Setup(c => c.ProjectTo(
               It.Is<IQueryable<MaterialType>>(x => x.Any()),
               It.IsAny<object>(),
               It.Is<Expression<Func<MaterialType, object>>[]>(x => x.Length == 0)))
           .Returns(materialtypes.AsQueryable());

            var result = await this.manager.Search(new SearchMaterialTypeCommand
            {
                Filter = new MaterialFilterVM
                {
                    Id = this.materialTypeId,
                },
            });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.TotalSize > 0);
        }
    }
}
