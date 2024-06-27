using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RS.FleetAdmin.Shared.Tools;

public static class DbHelpers
{
    public static void ApplyPendingMigrations<T>(IServiceProvider serviceProvider) where T : DbContext
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<T>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}