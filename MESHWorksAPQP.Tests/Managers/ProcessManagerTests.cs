// <copyright file="ProcessManagerTests.cs" company="MESHWorksAPQP">
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
    using MESHWorksAPQP.Management.Command.Setup.Process;
    using MESHWorksAPQP.Management.Commands.Part;
    using MESHWorksAPQP.Management.Interface.Managers.Part;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Process;
    using MESHWorksAPQP.Management.Managers.Setup.Process
        ;
    using MESHWorksAPQP.Management.ViewModel.Part;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.Process;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// class ProcessManagerTests.
    /// </summary>
    [TestClass]
    public class ProcessManagerTests
    {
        /// <summary>
        /// The part identifier.
        /// </summary>
        private Guid processId;

        /// <summary>
        /// The manager.
        /// </summary>
        private IProcessManager manager;

        /// <summary>
        /// The mapper.
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private Mock<ISetupRepositoty<Process>> repository;

        /// <summary>
        /// The user identity
        /// </summary>
        private Mock<IUserIdentity> userIdentity;

        /// <summary>
        /// The process
        /// </summary>
        private Process process;

        /// <summary>
        /// The setup vm.
        /// </summary>
        private SetupVM setupVm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessManagerTests"/> class.
        /// </summary>
        public ProcessManagerTests()
        {
            this.mapper = new Mock<IMapper>();
            this.repository = new Mock<ISetupRepositoty<Process>>();
            this.userIdentity = new Mock<IUserIdentity>();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.processId = new Guid("D079B9E8-BEFB-4864-5D68-08D9D9A54648");
            this.manager = new ProcessManager(this.mapper.Object, this.repository.Object, this.userIdentity.Object);
            this.process = new Process()
            {
                Id = this.processId,
                Code = "1234",
                Name = "ABC",
                Description = "Process description",
                SortOrder = 1,
                IsDeleted = false,
            };

            this.setupVm = new SetupVM()
            {
                Id = this.processId,
                Code = "1234",
                Name = "ABC",
                Description = "Process description",
                SortOrder = 1,
                IsDeleted = false,
            };
        }

        /// <summary>
        /// Tests the get process when process identifier is valid returns setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetProcess_WhenProcessIdIsvalid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Process, bool>>>())).Returns(Task.FromResult(this.process));
            this.mapper.Setup(m => m.Map<SetupVM>(It.IsAny<Process>())).Returns(this.setupVm);

            var result = await this.manager.Get(new GetProcessCommand
            {
                Id = this.processId,
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.FirstOrDefaultAsync(It.IsAny<Expression<Func<Process, bool>>>()), Times.Once());
        }

        /// <summary>
        /// Tests the get process when process identifier is invalid throws exception.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetProcess_WhenProcessIdIsInvalid_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var result = await this.manager.Get(new GetProcessCommand
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
        /// Tests the delete process when process identifier is valid returns true.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_DeleteProcess_WhenProcessIdIsValid_ReturnsTrue()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Process, bool>>>())).Returns(Task.FromResult(this.process));

            var result = await this.manager.Delete(this.processId);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the save process when process identifier is valid returns setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_SaveProcess_WhenProcessIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Create(this.process));

            this.mapper.Setup(m => m.Map<Process>(It.IsAny<SetupVM>())).Returns(this.process);

            var result = await this.manager.Save(new SaveProcessCommand
            {
                Entity = new SetupVM()
                {
                    Id = Guid.NewGuid(),
                    Code = "1234",
                    Name = "ABC",
                    Description = "Process description",
                    SortOrder = 1,
                    IsDeleted = false,
                },
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.Create(It.IsAny<Process>()), Times.Once());
            this.mapper.Verify(m => m.Map<Process>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the edit process when process identifier is valid returns setup vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_EditProcess_WhenProcessIdIsValid_ReturnsSetupVM()
        {
            this.repository.Setup(x => x.Update(this.process));
            this.mapper.Setup(m => m.Map<Process>(It.IsAny<SetupVM>())).Returns(this.process);
            var result = await this.manager.Save(new SaveProcessCommand
            {
                Entity = new SetupVM()
                {
                    Id = this.processId,
                    Code = "12345",
                    Name = "ABC",
                    Description = "Process description",
                    SortOrder = 1,
                    IsDeleted = false,
                },
            });

            Assert.IsNotNull(result);
            this.mapper.Verify(m => m.Map<Process>(It.IsAny<SetupVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the search process when process identifier is valid returns setup vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_SearchProcess_WhenProcessIdIsValid_ReturnsSetupVM()
        {
            var processes = new List<Process>
            {
               this.process,
            };

            this.repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Process, bool>>>())).Returns(processes.AsQueryable());

            this.mapper.Setup(x => x.ConfigurationProvider)
               .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<Process, SetupListVM>(); }));

            this.mapper
           .Setup(c => c.ProjectTo(
               It.Is<IQueryable<Process>>(x => x.Any()),
               It.IsAny<object>(),
               It.Is<Expression<Func<Process, object>>[]>(x => x.Length == 0)))
           .Returns(processes.AsQueryable());

            var result = await this.manager.Search(new SearchProcessCommand
            {
                Filter = new ProcessFilterVM
                {
                    ProcessId = this.processId,
                    SearchText = "ABC",
                },
            });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.TotalSize > 0);
        }
    }
}
