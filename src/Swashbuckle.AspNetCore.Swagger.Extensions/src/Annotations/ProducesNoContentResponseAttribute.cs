// <copyright name="ProducesNoContentResponseAttribute.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.AspNetCore.Mvc;

using System;

namespace Swashbuckle.AspNetCore.Annotations
{
    /// <summary>
    /// Defines the <see cref="ProducesNoContentResponseAttribute" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ProducesNoContentResponseAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProducesNoContentResponseAttribute"/> class.
        /// </summary>
        public ProducesNoContentResponseAttribute()
        {
            Type = typeof(NoContentResult);
        }

        /// <summary>
        /// Gets the Type
        /// </summary>
        public Type Type { get; }
    }
}
