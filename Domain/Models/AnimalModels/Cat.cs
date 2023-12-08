namespace Domain.Models.Animal
{
    public class Cat : Animal
    {
        public required bool LikesToPlay { get; set; }

        public string? CatBreed { get; set; }
        public int? CatWeight { get; set; }
    }
}