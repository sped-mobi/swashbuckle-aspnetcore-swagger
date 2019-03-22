// <copyright name="SwaggerServiceCollectionExtensions.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static void AssignOperationIdsByHttpMethodAndControllerName(this SwaggerGenOptions source)
        {
            source.CustomOperationIds(x =>
            {
                var builder = new StringBuilder();
                var method = ConvertHttpMethodName(x.HttpMethod);
                var metadata = x.ActionDescriptor.EndpointMetadata;
                var id = x.ActionDescriptor.Id;

                builder.Append(method);

                if (x.ActionDescriptor is ControllerActionDescriptor descriptor)
                {
                    var controllerName = descriptor.ControllerName;
                    builder.Append(controllerName);
                }

                return builder.ToString();
            });
        }

        public static void AssignSchemaIdsByTypeName(this SwaggerGenOptions source)
        {
            source.CustomSchemaIds(t => t.Name);
        }

        public static IServiceCollection ConfigureOpenApiSwagger(
            this IServiceCollection source,
            string documentName,
            OpenApiInfo info)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (documentName == null) throw new ArgumentNullException(nameof(documentName));
            if (info == null) throw new ArgumentNullException(nameof(info));
            source.ConfigureSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc(documentName, info);
                c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
                c.DescribeStringEnumsInCamelCase();
                c.UseReferencedDefinitionsForEnums();
                c.TagActionsByControllerName();
                c.AssignSchemaIdsByTypeName();
                c.AssignOperationIdsByHttpMethodAndControllerName();
                c.OperationFilter<StatusCodeOperationFilter>();
                c.ParameterFilter<IdParameterFilter>();
                c.SchemaFilter<EnumSchemaFilter>();
            });

            return source;
        }

        public static IServiceCollection ConfigureOpenApiSwaggerGen(
            this IServiceCollection source,
            string documentName,
            string version,
            string title,
            string contactName = null,
            string contactEmail = null,
            Uri contactUrl = null,
            string licenseName = null,
            Uri licenseUrl = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (string.IsNullOrEmpty(documentName)) throw new ArgumentException("Value cannot be null or empty.", nameof(documentName));
            if (string.IsNullOrEmpty(version)) throw new ArgumentException("Value cannot be null or empty.", nameof(version));
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("Value cannot be null or empty.", nameof(title));

            //Uri url0 = !string.IsNullOrEmpty(contactUrl) ? new Uri(contactUrl) : default(Uri);
            //Uri url1 = !string.IsNullOrEmpty(licenseUrl) ? new Uri(licenseUrl) : default(Uri);

            var license = !string.IsNullOrEmpty(licenseName) ? new OpenApiLicense
            {
                Name = licenseName,
                Url = licenseUrl
            } : new OpenApiLicense();

            var contact = !string.IsNullOrEmpty(contactName) ? new OpenApiContact
            {
                Name = contactName,
                Url = contactUrl,
                Email = contactEmail
            } : new OpenApiContact();

            var info = new OpenApiInfo
            {
                Version = version,
                Title = title,
                Description = title,
                Contact = contact,
                License = license
            };
            return source.ConfigureOpenApiSwagger(documentName, info);
        }

        public static void TagActionsByControllerName(this SwaggerGenOptions source)
        {
            source.TagActionsBy(x =>
            {
                var list = new List<string>();
                if (x.ActionDescriptor is ControllerActionDescriptor descriptor)
                {
                    var controllerName = descriptor.ControllerName;

                    list.Add($"{controllerName}Controller");
                }
                return list;
            });
        }

        private static string ConvertHttpMethodName(string httpMethodName)
        {
            if (string.IsNullOrEmpty(httpMethodName)) throw new ArgumentException("Value cannot be null or empty.", nameof(httpMethodName));

            switch (httpMethodName.ToLower(CultureInfo.CurrentCulture))
            {
                case "get": return "Get";
                case "post": return "Create";
                case "put": return "Update";
                case "patch": return "Edit";
                case "delete": return "Remove";
                default: return "";
            }
        }
    }
}
