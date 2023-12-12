using Domain.Models;
using Domain.Models.Animal;
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
        public async Task<List<Animal>> GetAnimalsByUserIdAsync(Guid userId)
        {
            return await _context.AnimalUsers
        .Where(ua => ua.UserId == userId)
        .Select(ua => ua.Animal)
        .ToListAsync();
        }

        public async Task<List<User>> GetUsersByAnimalIdAsync(Guid animalId)
        {
            return await _context.AnimalUsers
        .Where(ua => ua.AnimalId == animalId)
        .Select(ua => ua.User)
        .ToListAsync();
        }
        //Create
        public async Task AddUserAnimalAsync(AnimalUser animalUser)
        {
            await _context.AnimalUsers.AddAsync(animalUser);
            await _context.SaveChangesAsync();
        }
        //Update 
        //Delete

    }
}
