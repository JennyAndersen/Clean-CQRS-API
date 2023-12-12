using Domain.Models;
using Domain.Models.Animal;

namespace Infrastructure.Interfaces
{
    public interface IAnimalUserRepository
    {
        Task AddUserAnimalAsync(AnimalUser animalUser);
        Task<List<Animal>> GetAnimalsByUserIdAsync(Guid userId);
        Task<List<User>> GetUsersByAnimalIdAsync(Guid animalId);
    }
}
