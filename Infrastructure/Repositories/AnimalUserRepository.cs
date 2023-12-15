using Domain.Dtos;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Repositories
{
    public class AnimalUserRepository : IAnimalUserRepository
    {
        private readonly AnimalDbContext _context;
        private readonly ILogger _logger;

        public AnimalUserRepository(AnimalDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<AnimalRepository>();
        }

        // Read
        public async Task<List<GetAnimalUsersDto>> GetAllAnimalUsersAsync()
        {
            try
            {
                _logger.Information("Getting all animal users...");

                var animalUsers = await _context.AnimalUser
                    .Select(au => new GetAnimalUsersDto
                    {
                        UserName = au.User.UserName,
                        AnimalName = au.Animal.Name,
                        HappyTogetherIndex = au.HappyTogetherIndex
                    })
                    .ToListAsync();

                _logger.Information($"Found {animalUsers.Count} animal users.");
                return animalUsers;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all animal users.");
                throw;
            }
        }

        public async Task<bool> AddUserAnimalAsync(AnimalUser animalUser)
        {
            try
            {
                _logger.Information("Adding user animal...");
                await _context.AnimalUser.AddAsync(animalUser);
                await _context.SaveChangesAsync();
                _logger.Information("User animal added successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while adding user animal.");
                throw;
            }
        }

        public async Task<AnimalUser> GetAnimalUserByIdAsync(Guid animalUserId)
        {
            try
            {
                _logger.Information($"Getting animal user by ID: {animalUserId}...");
                var animalUser = await _context.AnimalUser.FindAsync(animalUserId);
                _logger.Information($"Found animal user with ID: {animalUserId}.");
                return animalUser;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting animal user by ID: {animalUserId}.");
                throw;
            }
        }

        public async Task UpdateAnimalUserAsync(AnimalUser animalUser)
        {
            try
            {
                _logger.Information($"Updating animal user with ID: {animalUser?.Key}...");
                _context.AnimalUser.Update(animalUser);
                await _context.SaveChangesAsync();
                _logger.Information($"Animal user with ID: {animalUser?.Key} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while updating animal user with ID: {animalUser?.Key}.");
                throw;
            }
        }

        public async Task<AnimalUser> GetByKeyAsync(Guid key)
        {
            try
            {
                _logger.Information($"Getting animal user by key: {key}...");
                var animalUser = await _context.AnimalUser.FindAsync(key);
                _logger.Information($"Found animal user with key: {key}.");
                return animalUser;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting animal user by key: {key}.");
                throw;
            }
        }

        public async Task DeleteAsync(Guid key)
        {
            try
            {
                _logger.Information($"Deleting animal user with key: {key}...");
                var animalUserToDelete = await _context.AnimalUser.FindAsync(key) ?? throw new Exception("User not found");
                _context.AnimalUser.Remove(animalUserToDelete);
                await _context.SaveChangesAsync();
                _logger.Information($"Animal user with key: {key} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while deleting animal user with key: {key}.");
                throw;
            }
        }
    }
}
