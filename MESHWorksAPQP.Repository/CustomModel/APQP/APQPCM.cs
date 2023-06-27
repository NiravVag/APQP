// <copyright file="APQPCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;

    /// <summary>
    /// class APQPCM.
    /// </summary>
    public class APQPCM
    {
        /// <summary>
        /// Gets or sets the part apqp.
        /// </summary>
        /// <value>
        /// The part apqp.
        /// </value>
        public APQPProjectCM APQPProject { get; set; }

        /// <summary>
        /// Gets or sets the apqp template identifier.
        /// </summary>
        /// <value>
        /// The apqp template identifier.
        /// </value>
        public APQPTemplateCM APQPTemplate { get; set; }

        /// <summary>
        /// Gets or sets the part.
        /// </summary>
        /// <value>
        /// The part.
        /// </value>
        public PartCM Part { get; set; }
    }
}
