using Domain.Dtos;
using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IAnimalUserRepository
    {
        Task<List<GetAnimalUsersDto>> GetAllAnimalUsersAsync();

        Task<bool> AddUserAnimalAsync(AnimalUser animalUser);
        Task<AnimalUser> GetAnimalUserByIdAsync(Guid animalUserId);
        Task UpdateAnimalUserAsync(AnimalUser animalUser);
        Task<AnimalUser> GetByKeyAsync(Guid key);
        Task DeleteAsync(Guid key);
    }
}
