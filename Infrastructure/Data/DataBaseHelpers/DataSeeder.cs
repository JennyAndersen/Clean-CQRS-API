using Domain.Models.Animal;

namespace Infrastructure.Data.DataBaseHelpers
{
    public static class DataSeeder
    {
        private static readonly List<string> CatNames = new() { "Whiskers", "Fluffy", "Mittens", "Shadow", "Simba", "Luna", "Oliver", "Charlie", "Milo", "Tiger" };
        private static readonly List<string> DogNames = new() { "Buddy", "Max", "Charlie", "Bailey", "Lucy", "Cooper", "Rocky", "Lola", "Daisy", "Teddy" };
        private static readonly List<string> BirdNames = new() { "Tweety", "Polly", "Sunny", "Kiwi", "Blue", "Rio", "Sky", "Pippin", "Oscar", "Coco" };

        private static readonly List<string> DogBreeds = new() { "Labrador Retriever", "German Shepherd", "Golden Retriever", "Bulldog", "Beagle", "Poodle", "Rottweiler", "Dachshund", "Shih Tzu", "Siberian Husky" };
        private static readonly List<string> CatBreeds = new() { "Persian", "Siamese", "Maine Coon", "Ragdoll", "Bengal", "Sphynx", "British Shorthair", "Abyssinian", "Scottish Fold", "Manx" };
        private static readonly List<string> BirdColors = new() { "Red", "Blue", "Green", "Yellow", "Purple", "Orange", "White", "Black", "Brown", "Pink" };

        public static void SeedData(AnimalDbContext dbContext)
        {
            if (!dbContext.Animals.Any())
            {
                var random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    Animal animal;

                    if (i % 3 == 0)
                    {
                        animal = new Cat
                        {
                            Name = CatNames[i % CatNames.Count],
                            LikesToPlay = random.Next(2) == 0,
                            CatBreed = CatBreeds[i % CatBreeds.Count],
                            CatWeight = random.Next(1, 10)
                        };
                    }
                    else if (i % 3 == 1)
                    {
                        animal = new Dog
                        {
                            Name = DogNames[i % DogNames.Count],
                            DogBreed = DogBreeds[i % DogBreeds.Count]
                        };
                    }
                    else
                    {
                        // Add Bird Color
                        animal = new Bird
                        {
                            Name = BirdNames[i % BirdNames.Count],
                            CanFly = random.Next(2) == 0,
                            Color = BirdColors[i % BirdColors.Count]
                        };
                    }

                    dbContext.Animals.Add(animal);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
