// <copyright name="IdParameterFilter.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.OpenApi.Models;

using System;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Defines the <see cref="IdParameterFilter" />
    /// </summary>
    public class IdParameterFilter : DefaultParameterFilter
    {
        /// <summary>
        /// The Apply
        /// </summary>
        /// <param name="parameter">The parameter<see cref="OpenApiParameter"/></param>
        /// <param name="context">The context<see cref="ParameterFilterContext"/></param>
        public override void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            Type parameterType = context.ParameterInfo.ParameterType;
            if (parameter.Name.EndsWith("id", StringComparison.CurrentCultureIgnoreCase))
            {
                parameter.In = ParameterLocation.Path;
                parameter.Description = "The integer that identifies the item to be supplied.";
                parameter.Style = ParameterStyle.Simple;
                parameter.AllowEmptyValue = false;
                parameter.Required = true;
                parameter.AllowReserved = false;

                if (parameterType == typeof(int))
                {
                    parameter.Schema = new OpenApiSchema
                    {
                        Type = "integer",
                        Format = "int32"
                    };
                }
                else if (parameterType == typeof(Guid))
                {
                    parameter.Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Format = "uuid"
                    };
                }
                else
                {
                    parameter.Schema = new OpenApiSchema
                    {
                        Type = "string"
                    };
                }
            }
        }
    }
}
