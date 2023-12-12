using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AnimalDbContext _context;
        public UserRepository(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User newUser)
        {
            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid userId)
        {
            var userToDelete = await _context.Users.FindAsync(userId) ?? throw new Exception("User not found");
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public User GetUserByUsernameAndPassword(string username, string hashedPassword)
        {
            return _context.Users
            .FirstOrDefault(u => u.UserName == username && u.UserPasswordHash == hashedPassword);
        }

        public async Task UpdateAsync(User userToUpdate)
        {
            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
