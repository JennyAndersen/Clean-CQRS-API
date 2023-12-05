using Domain.Models;
using Domain.Models.Animal;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure.Data
{
    public class DataDbContext : DbContext, IDataDbContext
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
