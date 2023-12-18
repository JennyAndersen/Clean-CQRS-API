using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class AnimalUserDto
    {
        public Guid UserId { get; set; }

        public Guid AnimalId { get; set; }

        [Range(1, 100, ErrorMessage = "HappyTogetherIndex must be between 1 and 100.")]
        public int HappyTogetherIndex { get; set; }
    }
}
