// <copyright name="DefaultParameterFilter.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.OpenApi.Models;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Defines the <see cref="DefaultParameterFilter" />
    /// </summary>
    public class DefaultParameterFilter : IParameterFilter
    {
        /// <summary>
        /// The Apply
        /// </summary>
        /// <param name="parameter">The parameter<see cref="OpenApiParameter"/></param>
        /// <param name="context">The context<see cref="ParameterFilterContext"/></param>
        public virtual void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
        }
    }
}
