using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Common;

public static class MapperExtensions
{
    /// <summary>
    /// Add the required dependency for configure mapster to service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static void AddCustomMapster(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        TypeAdapterConfig.GlobalSettings.Scan(assemblies);
    }
}