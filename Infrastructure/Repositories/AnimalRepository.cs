using Domain.Interfaces;
using Domain.Models.Animal;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalDbContext _context;
        private readonly ILogger _logger;

        public AnimalRepository(AnimalDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<AnimalRepository>();
        }

        public async Task<Animal> GetByIdAsync(Guid Animalid)
        {
            try
            {
                _logger.Information($"Getting animal by ID {Animalid}...");
                var animal = await _context.Animals.FindAsync(Animalid) ?? throw new ArgumentNullException(nameof(Animal), "Cannot find null animal.");
                _logger.Information($"Animal with ID {animal.AnimalId} found.");
                return animal!;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting animal by ID {Animalid}.");
                throw;
            }
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            try
            {
                _logger.Information($"Adding a new entity of type {typeof(T).Name}...");
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                _logger.Information($"Entity of type {typeof(T).Name} added successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error adding entity of type {typeof(T).Name}.");
                throw;
            }
        }

        public async Task UpdateAsync(Animal animal)
        {
            try
            {
                _logger.Information($"Updating animal with ID {animal?.AnimalId}...");
                _context.Animals.Update(animal ?? throw new ArgumentNullException(nameof(animal), "Cannot update null animal."));
                await _context.SaveChangesAsync();
                _logger.Information($"Animal with ID {animal.AnimalId} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while updating animal with ID {animal?.AnimalId}.");
                throw;
            }
        }

        public async Task DeleteAsync(Guid animalId)
        {
            try
            {
                var animalToDelete = await _context.Animals.FindAsync(animalId) ?? throw new ArgumentNullException(nameof(animalId), "Cannot delete null animal.");
                _logger.Information($"Deleting animal with ID {animalToDelete?.AnimalId}...");
                _context.Animals.Remove(animalToDelete);
                await _context.SaveChangesAsync();
                _logger.Information($"Animal with ID {animalToDelete.AnimalId} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while deleting animal with ID {animalId}.");
            }
        }

        public async Task<List<Bird>> GetAllBirdsAsync()
        {
            try
            {
                _logger.Information("Getting all birds...");
                var birds = await _context.Animals.OfType<Bird>().ToListAsync();
                _logger.Information($"Found {birds.Count} birds.");
                return birds;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all birds.");
                throw;
            }
        }

        public async Task<List<Cat>> GetAllCatsAsync()
        {
            try
            {
                _logger.Information("Getting all cats...");
                var cats = await _context.Animals.OfType<Cat>().ToListAsync();
                _logger.Information($"Found {cats.Count} cats.");
                return cats;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all cats.");
                throw;
            }
        }

        public async Task<List<Dog>> GetAllDogsAsync()
        {
            try
            {
                _logger.Information("Getting all dogs...");
                var dogs = await _context.Animals.OfType<Dog>().ToListAsync();
                _logger.Information($"Found {dogs.Count} dogs.");
                return dogs;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all dogs.");
                throw;
            }
        }

        public async Task<List<Bird>> GetBirdsByColorAsync(string color)
        {
            try
            {
                _logger.Information($"Getting birds by color: {color}...");
                var birds = await _context.Birds
                    .Where(b => b.Color.ToUpper() == color.ToUpper())
                    .OrderByDescending(b => b.Name)
                    .ThenByDescending(b => b.AnimalId)
                    .ToListAsync();

                _logger.Information($"Found {birds.Count} birds with color {color}.");
                return birds;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting birds by color {color}.");
                throw;
            }
        }

        public async Task<List<Dog>> GetDogsByWeightBreedAsync(string? breed, int? weight)
        {
            try
            {
                _logger.Information($"Getting dogs by weight and breed...");
                var query = _context.Animals.OfType<Dog>();

                if (!string.IsNullOrEmpty(breed))
                {
                    query = query.Where(dog => dog.DogBreed == breed);
                }

                if (weight.HasValue)
                {
                    query = query.Where(dog => dog.DogWeight >= weight.Value);
                }

                var dogs = await query.OrderByDescending(dog => dog.DogWeight).ToListAsync();
                _logger.Information($"Found {dogs.Count} dogs by weight and breed.");
                return dogs;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting dogs by weight and breed.");
                throw;
            }
        }

        public async Task<List<Cat>> GetCatsByWeightBreedAsync(string? breed, int? weight)
        {
            try
            {
                _logger.Information($"Getting cats by weight and breed...");
                var query = _context.Animals.OfType<Cat>();

                if (!string.IsNullOrEmpty(breed))
                {
                    query = query.Where(cat => cat.CatBreed == breed);
                }
                if (weight.HasValue)
                {
                    query = query.Where(cat => cat.CatWeight >= weight.Value);
                }

                var cats = await query.OrderByDescending(cat => cat.CatWeight).ToListAsync();
                _logger.Information($"Found {cats.Count} cats by weight and breed.");
                return cats;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting cats by weight and breed.");
                throw;
            }
        }

    }
}
