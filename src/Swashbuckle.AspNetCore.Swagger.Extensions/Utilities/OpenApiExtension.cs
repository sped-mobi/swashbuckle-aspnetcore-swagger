// <copyright name="OpenApiExtension.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Writers;

namespace Microsoft.OpenApi.Extensions
{
    /// <summary>
    /// Defines the <see cref="OpenApiExtension" />
    /// </summary>
    public class OpenApiExtension : IOpenApiExtension
    {
        /// <summary>
        /// The Write
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="specVersion">Version of the OpenAPI specification that that will be output.</param>
        public virtual void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
        {
        }
    }
}
