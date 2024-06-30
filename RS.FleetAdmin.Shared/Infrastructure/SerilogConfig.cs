using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace RS.FleetAdmin.Shared.Infrastructure;

public static class SerilogConfig
{
    public static void ConfigureSerilog(this IServiceCollection services)
    {
        services.AddSerilog(options =>
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                options.MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug,
                        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}");
            }
            else
            {
                options.MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information,
                        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}");
            }
        });

    }
}