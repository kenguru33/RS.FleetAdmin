using System.Reflection;
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
    public static IBusRegistrationConfigurator ConfigureMassTransit<T>(this IServiceCollection services, string queueName, string rabbitmqConnectionString = "rabbitmq:rabbitmq@localhost") where T : DbContext
    {
        IBusRegistrationConfigurator busConfigurator = null;
        services.AddMassTransit(x =>
        {
            busConfigurator = x;
            x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter( queueName, false));
            x.AddEntityFrameworkOutbox<T>(o =>
            {
                o.QueryDelay = TimeSpan.FromSeconds(10);
                o.UsePostgres();
                o.UseBusOutbox();
            });
            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://" + rabbitmqConnectionString);
                cfg.ConfigureEndpoints(context);
            });
        });

        return busConfigurator;

    }
    
    public static void ConfigureApplicationDbContext<T>(this IServiceCollection services, string connectionString)
        where T : DbContext
    {
        services.AddDbContext<T>(options =>
            options.UseNpgsql(connectionString));
    }
}