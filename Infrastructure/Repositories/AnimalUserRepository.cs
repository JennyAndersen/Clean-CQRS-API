using Domain.Dtos;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AnimalUserRepository : IAnimalUserRepository
    {
        private readonly AnimalDbContext _context;
        public AnimalUserRepository(AnimalDbContext context)
        {
            _context = context;
        }
        //Read
        public async Task<List<GetAnimalUsersDto>> GetAllAnimalUsersAsync()
        {
            return await _context.AnimalUser
                .Select(au => new GetAnimalUsersDto
                {
                    UserName = au.User.UserName,
                    AnimalName = au.Animal.Name,
                    HappyTogetherIndex = au.HappyTogetherIndex
                })
                .ToListAsync();
        }

        //Create
        public async Task<bool> AddUserAnimalAsync(AnimalUser animalUser)
        {
            await _context.AnimalUser.AddAsync(animalUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AnimalUser> GetAnimalUserByIdAsync(Guid animalUserId)
        {
            return await _context.AnimalUser.FindAsync(animalUserId);
        }

        public async Task UpdateAnimalUserAsync(AnimalUser animalUser)
        {
            _context.AnimalUser.Update(animalUser);
            await _context.SaveChangesAsync();
        }

        public async Task<AnimalUser> GetByKeyAsync(Guid key)
        {
            return await _context.AnimalUser.FindAsync(key);
        }

        public async Task DeleteAsync(Guid key)
        {
            var animalUserToDelete = await _context.AnimalUser.FindAsync(key) ?? throw new Exception("User not found");
            _context.AnimalUser.Remove(animalUserToDelete);
            await _context.SaveChangesAsync();
        }

    }
}
