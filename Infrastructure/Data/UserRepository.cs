using Domain.Models;
using Infrastructure.Interfaces;

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

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public User GetUserByUsernameAndPassword(string username, string hashedPassword)
        {
            return _context.Users
            .FirstOrDefault(u => u.UserName == username && u.UserPasswordHash == hashedPassword);
        }
    }
}
