using Domain.Models;
using Domain.Models.Animal;

namespace Infrastructure.Data
{
    public static class DataSeeder
    {
        private static readonly List<string> CatNames = new() { "Whiskers", "Fluffy", "Mittens", "Shadow", "Simba", "Luna", "Oliver", "Charlie", "Milo", "Tiger" };
        private static readonly List<string> DogNames = new() { "Buddy", "Max", "Charlie", "Bailey", "Lucy", "Cooper", "Rocky", "Lola", "Daisy", "Teddy" };
        private static readonly List<string> BirdNames = new() { "Tweety", "Polly", "Sunny", "Kiwi", "Blue", "Rio", "Sky", "Pippin", "Oscar", "Coco" };

        public static void SeedData(DataDbContext dbContext)
        {
            if (!dbContext.Animals.Any())
            {
                var random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    AnimalModel animal;

                    if (i % 3 == 0)
                    {
                        animal = new Cat
                        {
                            Name = CatNames[i % CatNames.Count],
                            LikesToPlay = random.Next(2) == 0
                        };
                    }
                    else if (i % 3 == 1)
                    {
                        animal = new Dog
                        {
                            Name = DogNames[i % DogNames.Count],
                        };
                    }
                    else
                    {
                        animal = new Bird
                        {
                            Name = BirdNames[i % BirdNames.Count],
                            CanFly = random.Next(2) == 0
                        };
                    }

                    dbContext.Animals.Add(animal);
                }
                dbContext.SaveChanges();
            }
        }
    }
}