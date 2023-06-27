// <copyright file="PartManagerTests.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using MESHWorksAPQP.Management.Commands.Part;
    using MESHWorksAPQP.Management.Interface.Managers.Part;
    using MESHWorksAPQP.Management.Managers.Part;
    using MESHWorksAPQP.Management.ViewModel.Part;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Part;
    using MESHWorksAPQP.Shared.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// class PartManagerTests.
    /// </summary>
    [TestClass]
    public class PartManagerTests
    {
        /// <summary>
        /// The company identifier.
        /// </summary>
        private Guid companyId;

        /// <summary>
        /// The part identifier.
        /// </summary>
        private Guid partId;

        /// <summary>
        /// The manager.
        /// </summary>
        private IPartManager manager;

        /// <summary>
        /// The mapper.
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private Mock<IPartRepository> repository;

        /// <summary>
        /// The part relationrepository
        /// </summary>
        private Mock<IGenericRepository<PartRelation>> partRelationrepository;

        /// <summary>
        /// The apqp repository.
        /// </summary>
        private Mock<IGenericRepository<APQP>> apqpRepository;

        /// <summary>
        /// The user identity
        /// </summary>
        private Mock<IUserIdentity> userIdentity;

        /// <summary>
        /// The part
        /// </summary>
        private Part part;

        /// <summary>
        /// The part vm.
        /// </summary>
        private PartVM partVm;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartManagerTests"/> class.
        /// </summary>
        public PartManagerTests()
        {
            this.mapper = new Mock<IMapper>();
            this.repository = new Mock<IPartRepository>();
            this.partRelationrepository = new Mock<IGenericRepository<PartRelation>>();
            this.apqpRepository = new Mock<IGenericRepository<APQP>>();
            this.userIdentity = new Mock<IUserIdentity>();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.companyId = new Guid("a5241fce-21b3-406a-ab5a-bacb91625144");
            this.partId = new Guid("D079B9E8-BEFB-4864-5D68-08D9D9A54648");
            this.manager = new PartManager(this.mapper.Object, this.repository.Object, this.partRelationrepository.Object, this.apqpRepository.Object, this.userIdentity.Object);
            this.part = new Part()
            {
                Id = this.partId,
                PartNumber = "1234",
                CompanyId = this.companyId,
                CustomerName = "ABC",
                CustomerEmail = "abc@xyz.com",
                CustomerPhone = "123456789",
                Description = "Part description",
                CommodityId = new Guid("08F0CD79-5D16-4A40-9D2F-21FDF6038B2B"),
                ProcessId = new Guid("A0F076F8-D551-444B-8317-D775BCE24123"),
                MaterialTypeId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AF12"),
                EAU = "10",
                EstimatedWeight = 0.123M,
                InitialRevLevel = "1",
                SAM = "sam",
                Commodity = new Commodity
                {
                    Id = new Guid("08F0CD79-5D16-4A40-9D2F-21FDF6038B2B"),
                    Name = "commodity 1",
                    Code = "Commodity1"
                },
                Process = new Process
                {
                    Id = new Guid("A0F076F8-D551-444B-8317-D775BCE24123"),
                    Name = "Process 1",
                    Code = "Process1"
                },
                MaterialType = new MaterialType
                {
                    Id = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AF12"),
                    Name = "MaterialType 1",
                    Code = "MaterialType1"
                },
            };

            this.partVm = new PartVM()
            {
                Id = this.partId,
                PartNumber = "1234",
                CompanyId = this.companyId,
                CommodityId = Guid.NewGuid(),
                CustomerName = "ABC",
                CustomerEmail = "abc@xyz.com",
                CustomerPhone = "123456789",
                Description = "Part description",
            };
        }

        /// <summary>
        /// Tests the get part when part identifier is valid returns part vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetPart_WhenPartIdIsvalid_ReturnsPartVM()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Part, bool>>>())).Returns(Task.FromResult(this.part));
            this.mapper.Setup(m => m.Map<PartVM>(It.IsAny<Part>())).Returns(this.partVm);

            var result = await this.manager.Get(new GetPartCommand
            {
                Id = this.partId,
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.FirstOrDefaultAsync(It.IsAny<Expression<Func<Part, bool>>>()), Times.Once());
        }

        /// <summary>
        /// Tests the get part when part identifier is invalid throws exception.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_GetPart_WhenPartIdIsInvalid_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var result = await this.manager.Get(new GetPartCommand
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
        /// Tests the delete part when part identifier is valid returns true.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_DeletePart_WhenPartIdIsValid_ReturnsTrue()
        {
            this.repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Part, bool>>>())).Returns(Task.FromResult(this.part));

            var result = await this.manager.Delete(new DeletePartCommand
            {
                Id = this.partId,
            });

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the save part when part identifier is valid returns part vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_SavePart_WhenPartIdIsValid_ReturnsPartVM()
        {
            this.repository.Setup(x => x.Create(this.part));

            this.mapper.Setup(m => m.Map<Part>(It.IsAny<PartVM>())).Returns(this.part);

            var result = await this.manager.Save(new SavePartCommand
            {
                Entity = new PartVM()
                {
                    PartNumber = "1234",
                    CompanyId = this.companyId,
                    CommodityId = Guid.NewGuid(),
                    CustomerName = "ABC",
                    CustomerEmail = "abc@xyz.com",
                    CustomerPhone = "123456789",
                    Description = "Part description",
                },
            });

            Assert.IsNotNull(result);
            this.repository.Verify(mock => mock.Create(It.IsAny<Part>()), Times.Once());
            this.mapper.Verify(m => m.Map<Part>(It.IsAny<PartVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the edit part when part identifier is valid returns part vm.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        [TestMethod]
        public async Task Test_EditPart_WhenPartIdIsValid_ReturnsPartVM()
        {
            this.repository.Setup(x => x.Update(this.part));

            this.mapper.Setup(m => m.Map<Part>(It.IsAny<PartVM>())).Returns(this.part);

            var result = await this.manager.Save(new SavePartCommand
            {
                Entity = new PartVM()
                {
                    Id = this.partId,
                    PartNumber = "1234",
                    CompanyId = this.companyId,
                    CommodityId = Guid.NewGuid(),
                    CustomerName = "xyz",
                    CustomerEmail = "xyz@abc.com",
                    CustomerPhone = "123456789",
                    Description = "Part description",
                },
            });

            Assert.IsNotNull(result);
            this.mapper.Verify(m => m.Map<Part>(It.IsAny<PartVM>()), Times.Once());
        }

        /// <summary>
        /// Tests the search part when part identifier is valid returns part vm.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task Test_SearchPart_WhenPartIdIsValid_ReturnsPartVM()
        {
            var parts = new List<Part>
            {
               this.part,
            };

            this.repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Part, bool>>>())).Returns(parts.AsQueryable());

            this.mapper.Setup(x => x.ConfigurationProvider)
               .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<Part, PartListVM>(); }));

            this.mapper
           .Setup(c => c.ProjectTo(
               It.Is<IQueryable<Part>>(x => x.Any()),
               It.IsAny<object>(),
               It.Is<Expression<Func<Part, object>>[]>(x => x.Length == 0)))
           .Returns(parts.AsQueryable());

            var result = await this.manager.Search(new SearchPartCommand
            {
                Filter = new PartFilterVM
                {
                    PartNumber = "1234",
                    CompanyId = this.companyId,
                },
            });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.TotalSize > 0);
        }
    }
}
