// <copyright name="ProducesOKResponseAttribute.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using System;

namespace Swashbuckle.AspNetCore.Annotations
{
    /// <summary>
    /// Defines the <see cref="ProducesOKResponseAttribute" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ProducesOKResponseAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProducesOKResponseAttribute"/> class.
        /// </summary>
        /// <param name="type">The type<see cref="Type"/></param>
        public ProducesOKResponseAttribute(Type type)
        {
            Type = type;
        }

        /// <summary>
        /// Gets the Type
        /// </summary>
        public Type Type { get; }
    }
}
