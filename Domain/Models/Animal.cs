namespace Domain.Models.Animal
{
    public class Animal
    {
        public Guid AnimalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<AnimalUser> AnimalUsers { get; set; }
    }
}
