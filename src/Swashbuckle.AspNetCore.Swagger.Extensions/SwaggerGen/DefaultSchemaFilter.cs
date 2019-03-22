// <copyright name="DefaultSchemaFilter.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.OpenApi.Models;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Defines the <see cref="DefaultSchemaFilter" />
    /// </summary>
    public class DefaultSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// The Apply
        /// </summary>
        /// <param name="schema">The schema<see cref="OpenApiSchema"/></param>
        /// <param name="context">The context<see cref="SchemaFilterContext"/></param>
        public virtual void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
        }
    }
}
