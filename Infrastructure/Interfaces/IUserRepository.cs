using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User newUser);
        User GetUserByUsernameAndPassword(string username, string hashedPassword);
        User GetUserByUsername(string username);
    }
}
