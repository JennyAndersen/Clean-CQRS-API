using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The username can not be empty")]
        public required string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public required string UserPasswordHash { get; set; }
        public ICollection<AnimalUser>? AnimalUsers { get; set; }
    }
}
