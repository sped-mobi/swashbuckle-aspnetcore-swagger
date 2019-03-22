// <copyright name="EnumSchemaFilter.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

using System;
using System.Reflection;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Defines the <see cref="EnumSchemaFilter" />
    /// </summary>
    public class EnumSchemaFilter : DefaultSchemaFilter
    {
        /// <summary>
        /// The Apply
        /// </summary>
        /// <param name="schema">The schema<see cref="OpenApiSchema"/></param>
        /// <param name="context">The context<see cref="SchemaFilterContext"/></param>
        public override void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var typeInfo = context.SystemType.GetTypeInfo();

            if (typeInfo.IsEnum)
            {
                schema.Extensions.Add(
                    "x-ms-enum",
                    new EnumExtension(typeInfo.Name, true)
                );
            }
        }

        /// <summary>
        /// Defines the <see cref="EnumExtension" />
        /// </summary>
        private class EnumExtension : OpenApiExtension
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="EnumExtension"/> class.
            /// </summary>
            /// <param name="name">The name<see cref="string"/></param>
            /// <param name="modelAsString">The modelAsString<see cref="bool"/></param>
            public EnumExtension(string name, bool modelAsString)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
                ModelAsString = modelAsString;
            }

            /// <summary>
            /// Gets a value indicating whether ModelAsString
            /// </summary>
            public bool ModelAsString { get; }

            /// <summary>
            /// Gets the Name
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// The Write
            /// </summary>
            /// <param name="writer"></param>
            /// <param name="specVersion">Version of the OpenAPI specification that that will be output.</param>
            public override void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("name");
                writer.WriteValue(Name);
                writer.WritePropertyName("modelAsString");
                writer.WriteValue(ModelAsString);
                writer.WriteEndObject();
            }
        }
    }
}
