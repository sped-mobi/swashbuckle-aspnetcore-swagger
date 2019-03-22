// <copyright name="SwaggerApplicationBuilderExtensions.cs" organization="Sped Mobi">
//   Copyright © 2019 Brad Marshall. All Rights Reserved.
// </copyright>
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Defines the <see cref="SwaggerApplicationBuilderExtensions" />
    /// </summary>
    public static class SwaggerApplicationBuilderExtensions
    {
        /// <summary>
        /// The ConfigureSwagger
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/></param>
        /// <param name="documentAction">The documentAction<see cref="Action{OpenApiDocument}"/></param>
        /// <param name="documentTitle">The documentTitle<see cref="string"/></param>
        /// <param name="swaggerEndpoint">The swaggerEndpoint<see cref="string"/></param>
        /// <param name="documentDescription">The documentDescription<see cref="string"/></param>
        /// <param name="routePrefix">The routePrefix<see cref="string"/></param>
        /// <param name="routeTemplate">The routeTemplate<see cref="string"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app,
            Action<OpenApiDocument> documentAction = null,
            string documentTitle = "v1",
            string swaggerEndpoint = "/swagger/v1/openapi.json",
            string documentDescription = "API Document",
            string routePrefix = "swagger",
            string routeTemplate = "/swagger/{documentName}/openapi.json"
            )
        {
            return app.ConfigureSwagger(
                c =>
            {
                if (documentAction != null)
                    c.PreSerializeFilters.Add((d, h) =>
                    {
                        documentAction(d);
                    });

                c.RouteTemplate = routeTemplate;

            },
                c =>
            {
                c.RoutePrefix = routePrefix;
                c.DocumentTitle = documentTitle;
                c.SwaggerEndpoint(swaggerEndpoint, documentDescription);
                c.DisplayRequestDuration();
                c.EnableValidator();
                c.DisplayOperationId();
                c.EnableDeepLinking();
                c.ShowExtensions();
                c.DefaultModelExpandDepth(3);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DocExpansion(DocExpansion.None);
                c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Delete, SubmitMethod.Put);

            });
        }

        /// <summary>
        /// The ConfigureSwagger
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/></param>
        /// <param name="swaggerOptionsAction">The swaggerOptionsAction<see cref="Action{SwaggerOptions}"/></param>
        /// <param name="swaggerUIOptionsAction">The swaggerUIOptionsAction<see cref="Action{SwaggerUIOptions}"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app,
            Action<SwaggerOptions> swaggerOptionsAction,
            Action<SwaggerUIOptions> swaggerUIOptionsAction)
        {
            app = app.UseSwagger(swaggerOptionsAction);
            app = app.UseSwaggerUI(swaggerUIOptionsAction);
            return app;
        }
    }
}
