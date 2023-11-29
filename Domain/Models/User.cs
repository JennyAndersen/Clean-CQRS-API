using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The username can not be empty")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public string UserPassword { get; set; }
    }
}
