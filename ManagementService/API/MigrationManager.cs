using ManagementService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ManagementService.API;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<ManagementContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception)
                {
                    //TODO: handle
                    throw;
                }
            }
        }
        return webApp;
    }
}
