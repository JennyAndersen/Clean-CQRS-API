using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class AnimalUser
    {
        [Key]
        public Guid Key { get; set; }
        // public required int HappyTogetherIndex { get; set; }
        public Guid AnimalId { get; set; }
        public Animal.Animal Animal { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
