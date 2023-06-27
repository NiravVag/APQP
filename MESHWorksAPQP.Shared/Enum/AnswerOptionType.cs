// <copyright file="AnswerOptionType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Enum
{
    using System.ComponentModel;

    /// <summary>
    ///  enum AnswerOptionType.
    /// </summary>
    public enum AnswerOptionType
    {
        /// <summary>
        /// The system defined answer
        /// </summary>
        [Description("System Defined Answer")]
        SystemDefinedAnswer = 1,

        /// <summary>
        /// The user defined answer
        /// </summary>
        [Description("User Defined Answer")]
        UserDefinedAnswer = 2
    }
}
