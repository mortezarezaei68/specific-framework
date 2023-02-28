using System.Reflection;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Framework.Commands.MassTransitDefaultConfig;

public static class ServiceExtension
{
    public static void AddMasstransitConsumerProducerExtension<TContext>(this IServiceCollection services,
        IConfiguration configuration, string projectsName) where TContext : DbContext
    {
        services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

        services.AddMassTransit(x =>
        {
            x.AddEntityFrameworkOutbox<TContext>(o =>
            {
                o.UseSqlServer();
                o.UseBusOutbox();
            });
            x.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
                cfg.ConnectConsumerConfigurationObserver(new UnitOfWorkConsumerConfigurationObserver());

            });
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName != null && assembly.FullName.Contains(projectsName)).ToArray();
            x.AddConsumers(assemblies);
            x.AddSagaStateMachines(assemblies);
            x.SetEntityFrameworkSagaRepositoryProvider(repositoryConfigurator =>
            {
                repositoryConfigurator.AddDbContext<DbContext, TContext>((provider, builder) =>
                {
                    builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), m =>
                    {
                        m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                        m.MigrationsHistoryTable($"__{nameof(TContext)}");
                    });
                });
            });

            x.AddRider(rider =>
            {
                rider.AddProducers(assemblies);
                rider.AddConsumers(assemblies);
                rider.AddSagaStateMachines(assemblies);
                rider.SetEntityFrameworkSagaRepositoryProvider(repositoryConfigurator =>
                {
                    repositoryConfigurator.ConcurrencyMode = ConcurrencyMode.Optimistic;
                    repositoryConfigurator.AddDbContext<DbContext, TContext>((provider, builder) =>
                    {
                        builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), m =>
                        {
                            m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                            m.MigrationsHistoryTable($"__{nameof(TContext)}");
                        });
                    });
                });
            
                rider.UsingKafka((context, k) =>
                {
                    k.Host(new List<string> {"localhost:9092"});
                    k.AddTopicEndPoints(context, assemblies);
                });
            });
        });
        services.AddHostedService<MassTransitConsoleHostedService>();

    }
}

public class KafkaConfiguration
{
    public string HostName { get; set; } //Added set property
}