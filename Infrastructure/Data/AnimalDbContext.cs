using Domain.Models;
using Domain.Models.Animal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AnimalDbContext : DbContext
    {

        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
