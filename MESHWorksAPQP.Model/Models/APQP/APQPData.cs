// <copyright file="APQPData.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class APQPData.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity" />
    [Table("APQPData", Schema = "APQP")]
    public class APQPData : BaseEntity
    {
        /// <summary>
        /// Gets or sets the apqp identifier.
        /// </summary>
        /// <value>
        /// The apqp identifier.
        /// </value>
        public Guid APQPId { get; set; }

        /// <summary>
        /// Gets or sets the apqp.
        /// </summary>
        /// <value>
        /// The apqp.
        /// </value>
        public virtual APQP APQP { get; set; }

        /// <summary>
        /// Gets or sets the apqp engineer.
        /// </summary>
        /// <value>
        /// The apqp engineer.
        /// </value>
        public Guid? APQPEngineerId { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>
        /// The manufacturer.
        /// </value>
        public Guid? ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets the initial piece cost.
        /// </summary>
        /// <value>
        /// The initial piece cost.
        /// </value>
        public decimal? InitialPieceCost { get; set; }

        /// <summary>
        /// Gets or sets the SCC.
        /// </summary>
        /// <value>
        /// The SCC.
        /// </value>
        public Guid? SCCId { get; set; }

        /// <summary>
        /// Gets or sets the tooling supplier identifier.
        /// </summary>
        /// <value>
        /// The tooling supplier identifier.
        /// </value>
        public Guid? ToolingSupplierId { get; set; }

        /// <summary>
        /// Gets or sets the initial piece price.
        /// </summary>
        /// <value>
        /// The initial piece price.
        /// </value>
        public decimal? InitialPiecePrice { get; set; }

        /// <summary>
        /// Gets or sets the planner.
        /// </summary>
        /// <value>
        /// The planner.
        /// </value>
        public Guid? PlannerId { get; set; }

        /// <summary>
        /// Gets or sets the minimum order qty.
        /// </summary>
        /// <value>
        /// The minimum order qty.
        /// </value>
        public int? MinOrderQTY { get; set; }

        /// <summary>
        /// Gets or sets the initial tooling cost.
        /// </summary>
        /// <value>
        /// The initial tooling cost.
        /// </value>
        public decimal? InitialToolingCost { get; set; }

        /// <summary>
        /// Gets or sets the customer engineer.
        /// </summary>
        /// <value>
        /// The customer engineer.
        /// </value>
        [MaxLength(100)]
        public string CustomerEngineer { get; set; }

        /// <summary>
        /// Gets or sets the tooling cavity.
        /// </summary>
        /// <value>
        /// The tooling cavity.
        /// </value>
        public int? ToolingCavity { get; set; }

        /// <summary>
        /// Gets or sets the initial tooling price.
        /// </summary>
        /// <value>
        /// The initial tooling price.
        /// </value>
        public decimal? InitialToolingPrice { get; set; }

        /// <summary>
        /// Gets or sets the ce email.
        /// </summary>
        /// <value>
        /// The ce email.
        /// </value>
        [MaxLength(100)]
        public string CEEmail { get; set; }

        /// <summary>
        /// Gets or sets the tooling lead time.
        /// </summary>
        /// <value>
        /// The tooling lead time.
        /// </value>
        public int? ToolingLeadTime { get; set; }

        /// <summary>
        /// Gets or sets the type of the tooling.
        /// </summary>
        /// <value>
        /// The type of the tooling.
        /// </value>
        public Guid? ToolingTypeId { get; set; }

        /// <summary>
        /// Gets or sets the ce phone number.
        /// </summary>
        /// <value>
        /// The ce phone number.
        /// </value>
        [MaxLength(50)]
        public string CEPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the production leadtime.
        /// </summary>
        /// <value>
        /// The production leadtime.
        /// </value>
        public int? ProductionLeadtime { get; set; }

        /// <summary>
        /// Gets or sets the start of production.
        /// </summary>
        /// <value>
        /// The start of production.
        /// </value>
        public DateTime? StartOfProduction { get; set; }

        /// <summary>
        /// Gets or sets the tooling p oreceived.
        /// </summary>
        /// <value>
        /// The tooling p oreceived.
        /// </value>
        public DateTime? ToolingPOreceived { get; set; }

        /// <summary>
        /// Gets or sets the ppap submission.
        /// </summary>
        /// <value>
        /// The ppap submission.
        /// </value>
        public Guid? PPAPSubmissionId { get; set; }

        /// <summary>
        /// Gets or sets the update ppap submission.
        /// </summary>
        /// <value>
        /// The update ppap submission.
        /// </value>
        public DateTime? UpdatePPAPSubmission { get; set; }

        /// <summary>
        /// Gets or sets the customer tooling po number.
        /// </summary>
        /// <value>
        /// The customer tooling po number.
        /// </value>
        [MaxLength(100)]
        public string CustToolingPONumber { get; set; }

        /// <summary>
        /// Gets or sets the number of samples.
        /// </summary>
        /// <value>
        /// The number of samples.
        /// </value>
        public int? NumOfSamples { get; set; }

        /// <summary>
        /// Gets or sets the project notes.
        /// </summary>
        /// <value>
        /// The project notes.
        /// </value>
        [MaxLength(300)]
        public string ProjectNotes { get; set; }

        /// <summary>
        /// Gets or sets the custmfg location.
        /// </summary>
        /// <value>
        /// The custmfg location.
        /// </value>
        [MaxLength(100)]
        public string CustmfgLocation { get; set; }

        /// <summary>
        /// Gets or sets the raw material input.
        /// </summary>
        /// <value>
        /// The raw material input.
        /// </value>
        public decimal? RawMaterialInput { get; set; }

        /// <summary>
        /// Gets or sets the mes warehouse.
        /// </summary>
        /// <value>
        /// The mes warehouse.
        /// </value>
        public Guid? MESWarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the raw material cost.
        /// </summary>
        /// <value>
        /// The raw material cost.
        /// </value>
        public decimal? RawMaterialCost { get; set; }

        /// <summary>
        /// Gets or sets the gate2 rev level.
        /// </summary>
        /// <value>
        /// The gate2 rev level.
        /// </value>
        [MaxLength(50)]
        public string Gate2RevLevel { get; set; }

        /// <summary>
        /// Gets or sets the supplier quality.
        /// </summary>
        /// <value>
        /// The supplier quality.
        /// </value>
        public Guid? SupplierQualityId { get; set; }

        /// <summary>
        /// Gets or sets the gate2 revision date.
        /// </summary>
        /// <value>
        /// The gate2 revision date.
        /// </value>
        public DateTime? Gate2RevisionDate { get; set; }

        /// <summary>
        /// Gets or sets the supplier quality lead.
        /// </summary>
        /// <value>
        /// The supplier quality lead.
        /// </value>
        public Guid? SupplierQualityLeadId { get; set; }

        /// <summary>
        /// Gets or sets the gate2 drawing number.
        /// </summary>
        /// <value>
        /// The gate2 drawing number.
        /// </value>
        [MaxLength(50)]
        public string Gate2DrawingNumber { get; set; }

        /// <summary>
        /// Gets or sets the supplier country manager.
        /// </summary>
        /// <value>
        /// The supplier country manager.
        /// </value>
        public Guid? SupplierCountryManagerId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Guid? StatusId { get; set; }

        /// <summary>
        /// Gets or sets the tooling engineer.
        /// </summary>
        /// <value>
        /// The tooling engineer.
        /// </value>
        public Guid? ToolingEngineerId { get; set; }

        /// <summary>
        /// Gets or sets the tooling kick of date.
        /// </summary>
        /// <value>
        /// The tooling kick of date.
        /// </value>
        public DateTime? ToolingKickOfDate { get; set; }

        /// <summary>
        /// Gets or sets new productdeveloperid.
        /// </summary>
        /// <value>
        /// The new product developer identifier.
        /// </value>
        public Guid? NewProductDeveloperId { get; set; }

        /// <summary>
        /// Gets or sets the plan tooling completion.
        /// </summary>
        /// <value>
        /// The plan tooling completion.
        /// </value>
        public DateTime? PlanToolingCompletion { get; set; }

        /// <summary>
        /// Gets or sets the design review notes.
        /// </summary>
        /// <value>
        /// The design review notes.
        /// </value>
        [MaxLength(300)]
        public string DesignReviewNotes { get; set; }

        /// <summary>
        /// Gets or sets the plan ppap submission.
        /// </summary>
        /// <value>
        /// The plan ppap submission.
        /// </value>
        [MaxLength(50)]
        public string PlanPPAPSubmission { get; set; }

        /// <summary>
        /// Gets or sets the gate3 rev level.
        /// </summary>
        /// <value>
        /// The gate3 rev level.
        /// </value>
        [MaxLength(50)]
        public string Gate3RevLevel { get; set; }

        /// <summary>
        /// Gets or sets the tool build status.
        /// </summary>
        /// <value>
        /// The tool build status.
        /// </value>
        public Guid ToolBuildStatusId { get; set; }

        /// <summary>
        /// Gets or sets the gate3 revision date.
        /// </summary>
        /// <value>
        /// The gate3 revision date.
        /// </value>
        public DateTime Gate3RevisionDate { get; set; }

        /// <summary>
        /// Gets or sets the ppap submission date update notes.
        /// </summary>
        /// <value>
        /// The ppap submission date update notes.
        /// </value>
        [MaxLength(300)]
        public string PPAPSubmissionDateUpdateNotes { get; set; }

        /// <summary>
        /// Gets or sets the tool completion date update notes.
        /// </summary>
        /// <value>
        /// The tool completion date update notes.
        /// </value>
        [MaxLength(300)]
        public string ToolCompletionDateUpdateNotes { get; set; }

        /// <summary>
        /// Gets or sets the actual tool completion.
        /// </summary>
        /// <value>
        /// The actual tool completion.
        /// </value>
        public DateTime ActualToolCompletion { get; set; }

        /// <summary>
        /// Gets or sets the approval notes.
        /// </summary>
        /// <value>
        /// The approval notes.
        /// </value>
        [MaxLength(300)]
        public string ApprovalNotes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        public bool IsApproved { get; set; }
    }
}