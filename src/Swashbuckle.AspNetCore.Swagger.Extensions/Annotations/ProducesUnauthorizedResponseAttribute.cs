// <copyright name="ProducesUnauthorizedResponseAttribute.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.AspNetCore.Mvc;

using System;

namespace Swashbuckle.AspNetCore.Annotations
{
    /// <summary>
    /// Defines the <see cref="ProducesUnauthorizedResponseAttribute" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ProducesUnauthorizedResponseAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProducesUnauthorizedResponseAttribute"/> class.
        /// </summary>
        public ProducesUnauthorizedResponseAttribute()
        {
            Type = typeof(UnauthorizedResult);
        }

        /// <summary>
        /// Gets the Type
        /// </summary>
        public Type Type { get; }
    }
}
