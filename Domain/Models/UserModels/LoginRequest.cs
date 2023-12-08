using System.ComponentModel.DataAnnotations;

namespace Domain.Models.UserModels
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public required string Password { get; set; }
    }
}
