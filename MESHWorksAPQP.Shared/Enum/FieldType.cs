// <copyright file="FieldType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Enum
{
    using System.ComponentModel;

    /// <summary>
    /// enum FieldType.
    /// </summary>
    public enum FieldType
    {
        /// <summary>
        /// The text box
        /// </summary>
        [Description("Text Box")]
        TextBox = 1,

        /// <summary>
        /// The text area
        /// </summary>
        [Description("Text Area")]
        TextArea = 2,

        /// <summary>
        /// The dropdown
        /// </summary>
        [Description("Dropdown")]
        DropDown = 3,

        /// <summary>
        /// The checkbox
        /// </summary>
        [Description("Checkbox")]
        CheckBox = 4,

        /// <summary>
        /// The radio button
        /// </summary>
        [Description("Radio Button")]
        RadioButton = 5,

        /// <summary>
        /// The date picker
        /// </summary>
        [Description("Date Picker")]
        DatePicker = 6,

        /// <summary>
        /// The numeric text box
        /// </summary>
        [Description("Numeric Text Box")]
        NumericTextBox = 7,
    }
}
