using Infrastructure.Data;
using Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DataDbContext>();
            services.AddSingleton<MockDatabase>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataDbContext>();
                DataSeeder.SeedData(dbContext);
            }

            return services;
        }
    }
}
