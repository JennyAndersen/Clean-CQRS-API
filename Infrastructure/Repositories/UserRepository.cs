using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AnimalDbContext _context;
        private readonly ILogger _logger;
        public UserRepository(AnimalDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<UserRepository>();
        }

        public async Task AddUserAsync(User newUser)
        {
            try
            {
                _logger.Information("Adding new user...");
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                _logger.Information("User added successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while adding new user.");
                throw;
            }
        }

        public async Task DeleteAsync(Guid userId)
        {
            try
            {
                _logger.Information($"Deleting user with ID: {userId}...");
                var userToDelete = await _context.Users.FindAsync(userId) ?? throw new Exception("User not found");
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                _logger.Information($"User with ID: {userId} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while deleting user with ID: {userId}.");
                throw;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                _logger.Information("Getting all users...");
                var users = await _context.Users.ToListAsync();
                _logger.Information($"Found {users.Count} users.");
                return users;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all users.");
                throw;
            }
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            try
            {
                _logger.Information($"Getting user by ID: {userId}...");
                var user = await _context.Users.FindAsync(userId);
                _logger.Information($"Found user with ID: {userId}.");
                return user;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting user by ID: {userId}.");
                throw;
            }
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                _logger.Information($"Getting user by username: {username}...");
                var user = _context.Users.FirstOrDefault(u => u.UserName == username);
                _logger.Information($"Found user with username: {username}.");
                return user;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting user by username: {username}.");
                throw;
            }
        }

        public User GetUserByUsernameAndPassword(string username, string hashedPassword)
        {
            try
            {
                _logger.Information($"Getting user by username and password...");
                var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.UserPasswordHash == hashedPassword);
                _logger.Information($"Found user with username: {username} and provided password.");
                return user;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting user by username and password.");
                throw;
            }
        }

        public async Task UpdateAsync(User userToUpdate)
        {
            try
            {
                _logger.Information($"Updating user with ID: {userToUpdate?.UserId}...");
                _context.Users.Update(userToUpdate);
                await _context.SaveChangesAsync();
                _logger.Information($"User with ID: {userToUpdate?.UserId} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while updating user with ID: {userToUpdate?.UserId}.");
                throw;
            }
        }
    }
}
