using Domain.Models.Animal;

namespace Domain.Interfaces
{
    public interface IAnimalRepository
    {
        Task<Animal> GetByIdAsync(Guid animalId);
        Task AddAsync<T>(T entity) where T : class;
        Task UpdateAsync(Animal animal);
        Task DeleteAsync(Guid animalId);
        Task<List<Bird>> GetAllBirdsAsync();
        Task<List<Cat>> GetAllCatsAsync();
        Task<List<Dog>> GetAllDogsAsync();
        Task<List<Bird>> GetBirdsByColorAsync(string color);
        Task<List<Dog>> GetDogsByWeightBreedAsync(string? breed, int? weight);
        Task<List<Cat>> GetCatsByWeightBreedAsync(string? breed, int? weight);
    }
}
