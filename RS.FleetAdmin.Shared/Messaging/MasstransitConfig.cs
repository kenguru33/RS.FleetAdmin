using MassTransit;
using MassTransit.Configuration;
using MassTransit.MultiBus;
using MassTransit.RabbitMqTransport.Configuration;
using MassTransit.Topology;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RS.FleetAdmin.Shared.Messaging.Messages;

namespace RS.FleetAdmin.Shared.Messaging;

public static class MasstransitConfig
{
    public static void ConfigureMassTransit<T>(this IServiceCollection services, string queueNamePrefix, string url,
        string username, string password, params Type[] consumers) where T : DbContext
    {
        services.AddMassTransit(x =>
        {
            foreach (var consumer in consumers)
            {
                x.AddConsumer(consumer);
            }
            
            x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(queueNamePrefix + "Endpoint-", false));
            x.AddEntityFrameworkOutbox<T>(o =>
            {
                o.QueryDelay = TimeSpan.FromSeconds(10);
                o.UsePostgres();
                o.UseBusOutbox();
            });
            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(url, h =>
                {
                    h.Username(username);
                    h.Password(password);
                });
                
                cfg.ConfigureEndpoints(context);
            });
            
        });
    }
    
    public static void ConfigureApplicationDbContext<T>(this IServiceCollection services, string connectionString)
        where T : DbContext
    {
        services.AddDbContext<T>(options =>
            options.UseNpgsql(connectionString));
    }

    // public static void AddMassTransitWithRabbitMq(this IServiceCollection services, IConfiguration configuration, DbContext dbContext)
    // {
    //     services.AddMassTransit(busConfigurator =>
    //     {
    //         busConfigurator.AddEntityFrameworkOutbox<typeof(DbContext)>(outboxConfig =>
    //         {
    //             outboxConfig.QueryDelay = TimeSpan.FromSeconds(10);
    //             outboxConfig.UsePostgres();
    //             outboxConfig.UseBusOutbox();
    //         });
    //         // busConfigurator.AddConsumer<StationCreatedHandler>();
    //         // busConfigurator.AddConsumersFromNamespaceContaining<StationCreatedConsumer>();
    //         busConfigurator.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("station", false));
    //         busConfigurator.UsingRabbitMq((context, config) =>
    //         {
    //             config.Host("localhost", rabbitConfig =>
    //             {
    //                 rabbitConfig.Username("rabbitmq");
    //                 rabbitConfig.Password("rabbitmq");
    //             });
    //             config.ReceiveEndpoint("Station", e =>
    //             {
    //                 // e.ConfigureConsumer<StationCreatedConsumer>(context);
    //             });
    //             config.ConfigureEndpoints(context);
    //         });
    //     
    // }
}