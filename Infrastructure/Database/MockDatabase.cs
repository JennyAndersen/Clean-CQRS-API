using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        public List<Bird> Birds
        {
            get { return allBirds; }
            set { allBirds = value; }
        }

        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"}
        };

        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Fluffy", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Whiskers", LikesToPlay = false },
            new Cat { Id = Guid.NewGuid(), Name = "Lickers", LikesToPlay = false },
            new Cat { Id = Guid.NewGuid(), Name = "Sickers", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Fluffers", LikesToPlay = false },
        };

        private static List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Robin", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Sparrow", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Birdy", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Herdy", CanFly = false },
            new Bird { Id = Guid.NewGuid(), Name = "Gerdy", CanFly = true }
        };
    }
}

