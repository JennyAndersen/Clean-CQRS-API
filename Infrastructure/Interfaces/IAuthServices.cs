using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IAuthServices
    {
        User AuthenticateUser(string username, string plainTextPassword);
        string GenerateJwtToken(User user);
    }
}
