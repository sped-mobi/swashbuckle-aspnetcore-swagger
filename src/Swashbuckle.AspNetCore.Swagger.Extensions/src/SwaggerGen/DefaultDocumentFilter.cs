// <copyright name="DefaultDocumentFilter.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.OpenApi.Models;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Defines the <see cref="DefaultDocumentFilter" />
    /// </summary>
    public class DefaultDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// The Apply
        /// </summary>
        /// <param name="swaggerDoc">The swaggerDoc<see cref="OpenApiDocument"/></param>
        /// <param name="context">The context<see cref="DocumentFilterContext"/></param>
        public virtual void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
        }
    }
}
