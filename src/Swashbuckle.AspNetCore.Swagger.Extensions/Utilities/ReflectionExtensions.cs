// <copyright name="ReflectionExtensions.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using System.Collections.Generic;
using System.Linq;

namespace System.Reflection
{
    /// <summary>
    /// Defines the <see cref="ReflectionExtensions" />
    /// </summary>
    internal static class ReflectionExtensions
    {
        /// <summary>
        /// The GetCustomAttribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type">The type<see cref="MethodInfo"/></param>
        /// <returns>The <see cref="TAttribute"/></returns>
        public static TAttribute GetCustomAttribute<TAttribute>(this MethodInfo type) where TAttribute : Attribute
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var attribute = type.GetCustomAttributes<TAttribute>().FirstOrDefault();
            return attribute;
        }

        /// <summary>
        /// The HasCustomAttribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type">The type<see cref="MethodInfo"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool HasCustomAttribute<TAttribute>(this MethodInfo type) where TAttribute : Attribute
        {
            IEnumerable<TAttribute> ofType = type.GetCustomAttributes()
                .OfType<TAttribute>();
            return ofType.Any();
        }

        /// <summary>
        /// The TryGetCustomAttribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type">The type<see cref="MethodInfo"/></param>
        /// <param name="attribute">The attribute<see cref="TAttribute"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool TryGetCustomAttribute<TAttribute>(this MethodInfo type, out TAttribute attribute) where TAttribute : Attribute
        {
            bool result = false;
            attribute = null;
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (type.HasCustomAttribute<TAttribute>())
            {
                result = true;
                attribute = type.GetCustomAttribute<TAttribute>();
            }
            return result;
        }
    }
}
