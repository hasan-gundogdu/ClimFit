using ClimFit.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClimFit.Infrastructure
{
    public static class DatabaseInitializer
    {
        public static void MigrateDataBase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ClimFitDBContext>();

            try
            {
                // Migration işlemini uygula
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veritabanı başlatma sırasında hata: {ex.Message}");
                throw;
            }
        }
    }
}
