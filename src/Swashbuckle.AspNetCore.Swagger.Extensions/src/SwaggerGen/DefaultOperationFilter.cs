// <copyright name="DefaultOperationFilter.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.OpenApi.Models;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Defines the <see cref="DefaultOperationFilter" />
    /// </summary>
    public class DefaultOperationFilter : IOperationFilter
    {
        /// <summary>
        /// The Apply
        /// </summary>
        /// <param name="operation">The operation<see cref="OpenApiOperation"/></param>
        /// <param name="context">The context<see cref="OperationFilterContext"/></param>
        public virtual void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
        }
    }
}
