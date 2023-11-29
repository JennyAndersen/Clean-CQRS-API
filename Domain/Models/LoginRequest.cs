using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Password { get; set; }
    }
}
