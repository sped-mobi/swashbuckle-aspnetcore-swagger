// <copyright name="ProducesBadRequestResponseAttribute.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.AspNetCore.Mvc;

using System;

namespace Swashbuckle.AspNetCore.Annotations
{
    /// <summary>
    /// Defines the <see cref="ProducesBadRequestResponseAttribute" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ProducesBadRequestResponseAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProducesBadRequestResponseAttribute"/> class.
        /// </summary>
        public ProducesBadRequestResponseAttribute()
        {
            Type = typeof(BadRequestResult);
        }

        /// <summary>
        /// Gets the Type
        /// </summary>
        public Type Type { get; }
    }
}
