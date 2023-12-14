using Domain.Interfaces;
using Infrastructure.Authentication;
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
            services.AddTransient<IAnimalUserRepository, AnimalUserRepository>();
            services.AddTransient<IAuthServices, AuthServices>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AnimalDbContext>();
                DataSeeder.SeedData(dbContext);
            }

            return services;
        }
    }
}
