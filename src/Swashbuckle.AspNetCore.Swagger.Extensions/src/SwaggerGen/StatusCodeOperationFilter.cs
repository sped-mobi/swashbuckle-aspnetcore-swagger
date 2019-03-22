// <copyright name="StatusCodeOperationFilter.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Annotations;

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Defines the <see cref="StatusCodeOperationFilter" />
    /// </summary>
    public class StatusCodeOperationFilter : IOperationFilter
    {
        /// <summary>
        /// The ApplyResponse
        /// </summary>
        /// <param name="operation">The operation<see cref="OpenApiOperation"/></param>
        /// <param name="context">The context<see cref="OperationFilterContext"/></param>
        /// <param name="key">The key<see cref="string"/></param>
        /// <param name="description">The description<see cref="string"/></param>
        /// <param name="schemaType">The schemaType<see cref="Type"/></param>
        private static void ApplyResponse(OpenApiOperation operation, OperationFilterContext context, string key, string description, Type schemaType)
        {
            operation.Responses.Add(key, new OpenApiResponse
            {
                Description = description,
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["application/json"] = new OpenApiMediaType
                    {
                        Schema = context.SchemaRegistry.GetOrRegister(schemaType)
                    }
                }
            });
        }

        /// <summary>
        /// The Apply
        /// </summary>
        /// <param name="operation">The operation<see cref="OpenApiOperation"/></param>
        /// <param name="context">The context<see cref="OperationFilterContext"/></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            MethodInfo method = context.MethodInfo;

            if (method.TryGetCustomAttribute<ProducesOKResponseAttribute>(out var attribute))
            {
                ApplyResponse(operation, context, "200", "Success", attribute.Type);
            }
            if (method.TryGetCustomAttribute<ProducesCreatedResponseAttribute>(out var attribute0))
            {
                ApplyResponse(operation, context, "201", "Created", attribute0.Type);
            }
            if (method.TryGetCustomAttribute<ProducesNoContentResponseAttribute>(out var attribute1))
            {
                ApplyResponse(operation, context, "204", "No Content", attribute1.Type);
            }
            if (method.TryGetCustomAttribute<ProducesBadRequestResponseAttribute>(out var attribute2))
            {
                ApplyResponse(operation, context, "400", "Bad Request", attribute2.Type);
            }
            if (method.TryGetCustomAttribute<ProducesNotFoundResponseAttribute>(out var attribute3))
            {
                ApplyResponse(operation, context, "404", "Not Found", attribute3.Type);
            }
            if (method.TryGetCustomAttribute<ProducesInternalServerErrorResponseAttribute>(out var attribute4))
            {
                ApplyResponse(operation, context, "500", "Internal Server Error", attribute4.Type);
            }
        }
    }
}
