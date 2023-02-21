using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Framework.Common.SwaggerExtensions;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    /// <summary>
    /// Configure each API discovered for Swagger Documentation
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerGenOptions options)
    {
        var projectName = Assembly.GetEntryAssembly()!.GetName().Name!;
        var title = $"{projectName} API";

        // add swagger document for every API version discovered
        foreach (var description in _provider.ApiVersionDescriptions.DistinctBy(x => x.GroupName))
        {
            options.SwaggerDoc(description.GroupName, new OpenApiInfo
            {
                Title = title,
                Version = description.GroupName,
                Description = description.IsDeprecated
                    ? "This API version has been deprecated. Please use new versions."
                    : string.Empty
            });
        }
        var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
            .ToList();
        xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
    }

    /// <summary>
    /// Configure Swagger Options. Inherited from the Interface
    /// </summary>
    /// <param name="name"></param>
    /// <param name="options"></param>
    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }
}