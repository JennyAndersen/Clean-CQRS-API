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
        public List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
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
            new Cat { Id = new Guid("7e910a6d-8621-4f4b-8a0c-5e199f42eaa5"), Name = "TestCatForUnitTests"}
        };

        private static List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Robin", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Sparrow", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Birdy", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Herdy", CanFly = false },
            new Bird { Id = Guid.NewGuid(), Name = "Gerdy", CanFly = true },
            new Bird { Id = new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a"), Name = "TestBirdForUnitTests"}
        };

        private static List<User> allUsers = new()
        {
            new User { Id = Guid.NewGuid(), UserName = "JohnDoe" },
            new User { Id = Guid.NewGuid(), UserName = "JaneDoe" },

        };
    }
}

