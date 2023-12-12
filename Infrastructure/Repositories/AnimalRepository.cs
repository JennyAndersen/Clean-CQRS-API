using Domain.Interfaces;
using Domain.Models.Animal;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalDbContext _context;

        public AnimalRepository(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<Animal> GetByIdAsync(Guid Animalid)
        {
            return await _context.Animals.FindAsync(Animalid);
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid animalId)
        {
            var animalToDelete = await _context.Animals.FindAsync(animalId) ?? throw new Exception("User not found");
            _context.Animals.Remove(animalToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Bird>> GetAllBirdsAsync()
        {
            return await _context.Animals.OfType<Bird>().ToListAsync();
        }

        public async Task<List<Cat>> GetAllCatsAsync()
        {
            return await _context.Animals.OfType<Cat>().ToListAsync();
        }

        public async Task<List<Dog>> GetAllDogsAsync()
        {
            return await _context.Animals.OfType<Dog>().ToListAsync();
        }

        public async Task<List<Bird>> GetBirdsByColorAsync(string color)
        {
            return await _context.Birds
        .Where(b => b.Color.ToUpper() == color.ToUpper())
        .OrderByDescending(b => b.Name)
        .ThenByDescending(b => b.AnimalId)
        .ToListAsync();
        }
        //skulle kunna skapa en generisk metod för både cat/dog
        public async Task<List<Dog>> GetDogsByWeightBreedAsync(string? breed, int? weight)
        {
            var query = _context.Animals.OfType<Dog>();

            if (!string.IsNullOrEmpty(breed))
            {
                query = query.Where(dog => dog.DogBreed == breed);
            }

            if (weight.HasValue)
            {
                query = query.Where(dog => dog.DogWeight >= weight.Value);
            }

            var result = await query.OrderByDescending(dog => dog.DogWeight).ToListAsync();
            return result;
        }

        public async Task<List<Cat>> GetCatsByWeightBreedAsync(string? breed, int? weight)
        {
            var query = _context.Animals.OfType<Cat>();

            if (!string.IsNullOrEmpty(breed))
            {
                query = query.Where(cat => cat.CatBreed == breed);
            }

            if (weight.HasValue)
            {
                query = query.Where(cat => cat.CatWeight >= weight.Value);
            }

            var result = await query.OrderByDescending(cat => cat.CatWeight).ToListAsync();
            return result;
        }
    }
}
