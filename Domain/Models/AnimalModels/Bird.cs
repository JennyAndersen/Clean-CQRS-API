namespace Domain.Models.Animal
{
    public class Bird : Animal
    {
        public bool CanFly { get; set; }
        public required string Color { get; set; }
    }
}