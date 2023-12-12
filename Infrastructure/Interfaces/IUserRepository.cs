using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User newUser);
        User GetUserByUsernameAndPassword(string username, string hashedPassword);
        User GetUserByUsername(string username);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetByIdAsync(Guid deletedUserId);
        Task DeleteAsync(Guid deletedUserId);
        Task UpdateAsync(User userToUpdate);
    }
}
