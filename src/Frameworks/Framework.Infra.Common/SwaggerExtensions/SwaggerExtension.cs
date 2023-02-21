using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;
using Unchase.Swashbuckle.AspNetCore.Extensions.Options;

namespace Framework.Infra.Common.SwaggerExtensions
{
    public static class SwaggerExtension
    {
    /// <summary>
    /// customize swagger include: versioning by url, jwt config
    /// </summary>
    /// <param name="services"></param>
    public static void AddCustomSwagger(this IServiceCollection services)
    {
        services.AddApiVersioning(o =>
        {
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.DefaultApiVersion = new ApiVersion(1, 0);
            o.ReportApiVersions = true;
            o.ApiVersionReader = new UrlSegmentApiVersionReader();
        });
        services.AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        
        services.AddSwaggerGen(c =>
        {
            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            c.AddSecurityDefinition("Bearer", securitySchema);
            c.OperationFilter<SecurityRequirementsOperationFilter>();
            c.AddEnumsWithValuesFixFilters(o =>
            {
                // add descriptions from DescriptionAttribute or xml-comments to fix enums (add 'x-enumDescriptions' or its alias from XEnumDescriptionsAlias for schema extensions) for applied filters
                o.IncludeDescriptions = true;

                // get descriptions from DescriptionAttribute then from xml-comments
                o.DescriptionSource = DescriptionSources.DescriptionAttributesThenXmlComments;
                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
                    .ToList();
                // get descriptions from xml-file comments on the specified path
                xmlFiles.ForEach(xmlFile => o.IncludeXmlCommentsFrom(xmlFile));
            });

        });
        services.AddEndpointsApiExplorer();
        services.ConfigureOptions<ConfigureSwaggerOptions>();

    }

    /// <summary>
    /// application middleware for swagger
    /// </summary>
    /// <param name="app"></param>
    public static void UseCustomSwagger(this IApplicationBuilder app)
    {
        var services = app.ApplicationServices;
        using var scope = services.CreateScope();
        var provider = scope.ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var projectName = Assembly.GetEntryAssembly()!.GetName().Name!;
            options.DocumentTitle = $"Test- {projectName} API document";
            options.DocExpansion(DocExpansion.None);
            options.DisplayRequestDuration();
            options.EnableDeepLinking();
            options.EnableFilter();
            options.ShowExtensions();
            options.EnableValidator();
            
            // make group name list for swagger ui
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    $"{projectName}_{description.GroupName.ToUpperInvariant()}");
            }
        });
    }
    }
}