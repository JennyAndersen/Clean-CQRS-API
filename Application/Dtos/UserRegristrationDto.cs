using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class UserRegistrationDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The username can not be empty")]
        public required string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The password can not be empty")]
        public required string Password { get; set; }
    }
}
