using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RS.FleetAdmin.Shared.Infrastructure;

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