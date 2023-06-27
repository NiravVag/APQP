// <copyright file="ApplicationInsightsSettings.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Settings
{
    using MESHWorksAPQP.Shared.Interface.Settings;

    /// <summary>
    /// Class IApplicationInsightsSettings
    /// </summary>
    public class ApplicationInsightsSettings : IApplicationInsightsSettings
    {
        /// <summary>
        /// Gets or sets thte Instrumentation key.
        /// </summary>
        public string InstrumentationKey { get; set; }
    }
}
