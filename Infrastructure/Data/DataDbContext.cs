using Domain.Models;
using Domain.Models.Animal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        public DbSet<AnimalModel> Animals { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
    }
}
