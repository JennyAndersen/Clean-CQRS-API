using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class AnimalUserDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid AnimalId { get; set; }

        // [Required]
        // public int HappyTogetherIndex { get; set; }
    }
}
