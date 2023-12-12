using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.DataBaseHelpers;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AnimalDbContext>();
                DataSeeder.SeedData(dbContext);
            }

            return services;
        }
    }
}
