using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RS.FleetAdmin.Shared.Infrastructure;

public static class MasstransitConfig
{
    public static IBusRegistrationConfigurator ConfigureMassTransit<T>(this IServiceCollection services, string queueName, string rabbitmqConnectionString = "rabbitmq:rabbitmq@localhost") where T : DbContext
    {
        var x = ConfigureMassTransit(services, queueName, rabbitmqConnectionString);
        x.AddEntityFrameworkOutbox<T>(o =>
        {
            o.QueryDelay = TimeSpan.FromSeconds(10);
            o.UsePostgres();
            o.UseBusOutbox();
        });
        return x;
    }
    
    public static IBusRegistrationConfigurator ConfigureMassTransit(this IServiceCollection services, string queueName, string rabbitmqConnectionString = "rabbitmq:rabbitmq@localhost")
    {
        IBusRegistrationConfigurator busConfigurator = null;
        services.AddMassTransit(x =>
        {
            busConfigurator = x;
            x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter( queueName, false));
            
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