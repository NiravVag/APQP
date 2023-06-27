// <copyright file="RoleManagerTests.cs" company="MESHWorksAPQP">
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
    using MESHWorksAPQP.Management.Command.Setup.Role;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Role;
    using MESHWorksAPQP.Management.Managers.Setup.Role;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.Role;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// class RoleManagerTests.
    /// </summary>
    [TestClass]
    public class RoleManagerTests
    {
        /// <summary>
        /// The role identifier.
        /// </summary>
        private Guid roleId;

        /// <summary>
        /// The manager.
        /// </summary>
        private IRoleManager manager;

        /// <summary>
        /// The mapper.
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private Mock<ISetupRepositoty<Roles>> repository;

        /// <summary>
        /// The role
        /// </summary>
        private Roles role;

        /// <summary>
        /// The setup vm.
        /// </summary>
        private SetupVM setupVm;

        /// <summary>
        /// The user identity
        /// </summary>
        private Mock<IUserIdentity> userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleManagerTests"/> class.
        /// </summary>
        public RoleManagerTests()
        {
            this.mapper = new Mock<IMapper>();
            this.repository = new Mock<ISetupRepositoty<Roles>>();
            this.userIdentity = new Mock<IUserIdentity>();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.roleId = new Guid("f2a938ea-61aa-4486-bfd4-e45eca3ab615");
            this.manager = new RoleManager(this.mapper.Object, this.repository.Object, this.userIdentity.Object);
            this.role = new Roles()
            {
                Id = this.roleId,
                Code = "2345",
                Name = "XYZ",
                Description = "Role description",
                SortOrder = 1,
                IsDeleted = false,
            };

            this.setupVm = new SetupVM()
            {
                Id = this.roleId,
                Code = "2345",
                Name = "XYZ",
                Description = "Role description",
                SortOrder = 1,
                IsDeleted = false,
            };
        }

        /// <summary>
        /// Tests the get user when user identifier is valid returns setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetRole_WhenRoleIdIsvalid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Roles, bool>>>())).Returns(Task.FromResult(this.role));
            this.mapper.Setup(m => m.Map<SetupVM>(It.IsAny<Roles>())).Returns(this.setupVm);

            var result = await this.manager.Get(new GetRoleCommand
            {
                Id = this.roleId,
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.FirstOrDefaultAsync(It.IsAny<Expression<Func<Roles, bool>>>()), Times.Once());
        }

        /// <summary>
        /// Tests the get role when role identifier is invalid throws exception.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetRole_WhenRoleIdIsInvalid_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var result = await this.manager.Get(new GetRoleCommand
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
        /// Tests the delete role when role identifier is valid returns true.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_DeleteRole_WhenRoleIdIsValid_ReturnsTrue()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Roles, bool>>>())).Returns(Task.FromResult(this.role));

            var result = await this.manager.Delete(this.roleId);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the save role when role identifier is valid returns setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_SaveRole_WhenRoleIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Create(this.role));

            this.mapper.Setup(m => m.Map<Roles>(It.IsAny<SetupVM>())).Returns(this.role);

            var result = await this.manager.Save(new SaveRoleCommand
            {
                Entity = new SetupVM()
                {
                    Id = Guid.NewGuid(),
                    Code = "2345",
                    Name = "XYZ",
                    Description = "Role description",
                    SortOrder = 1,
                    IsDeleted = false,
                },
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.Create(It.IsAny<Roles>()), Times.Once());
            this.mapper.Verify(m => m.Map<Roles>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the edit role when role identifier is valid returns setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_EditRole_WhenRoleIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Update(this.role));
            this.mapper.Setup(m => m.Map<Roles>(It.IsAny<SetupVM>())).Returns(this.role);
            var result = await this.manager.Save(new SaveRoleCommand
            {
                Entity = new SetupVM()
                {
                    Id = this.roleId,
                    Code = "2345",
                    Name = "XYZ",
                    Description = "Role description",
                    SortOrder = 1,
                    IsDeleted = false,
                },
            });

            Assert.IsNotNull(result);
            this.mapper.Verify(m => m.Map<Roles>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the search role when role identifier is valid returns setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_SearchRole_WhenRoleIdIsValid_ReturnsSetupVM()
        {
            var roles = new List<Roles>
            {
               this.role,
            };

            this.repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Roles, bool>>>())).Returns(roles.AsQueryable());

            this.mapper.Setup(x => x.ConfigurationProvider)
               .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<Roles, SetupListVM>(); }));

            this.mapper
           .Setup(c => c.ProjectTo(
               It.Is<IQueryable<Roles>>(x => x.Any()),
               It.IsAny<object>(),
               It.Is<Expression<Func<Roles, object>>[]>(x => x.Length == 0)))
           .Returns(roles.AsQueryable());

            var result = await this.manager.Search(new SearchRoleCommand
            {
                Filter = new RoleFilterVM
                {
                    Id = this.roleId,
                },
            });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.TotalSize > 0);
        }
    }
}
