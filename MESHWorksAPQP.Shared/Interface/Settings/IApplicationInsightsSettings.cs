// <copyright file="IApplicationInsightsSettings.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Interface.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface IApplicationInsightsSettings.
    /// </summary>
    public interface IApplicationInsightsSettings
    {
        /// <summary>
        /// Gets or sets thte Instrumentation key.
        /// </summary>
        string InstrumentationKey { get; set; }
    }
}
