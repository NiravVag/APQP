// <copyright file="EnumHelper.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Helpers
{
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>
    /// Class EnumHelper.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Descriptions the attribute.
        /// </summary>
        /// <typeparam name="T">
        /// The enum type
        /// </typeparam>
        /// <param name="source">
        /// The  enum source.
        /// </param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string DescriptionAttribute<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return source.ToString();
            }
        }
    }
}
