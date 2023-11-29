using Application.Animals.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.DogTests.CommandHandlers
{
    [TestFixture]
    public class UpdateDogByIdCommandHandlerTests
    {
        private UpdateDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_THEN_UpdatesDogInDatabase()
        {
            // Arrange
            var initialDog = new Dog { Id = Guid.NewGuid(), Name = "InitialDogName" };
            _mockDatabase.Dogs.Add(initialDog);

            var command = new UpdateDogByIdCommand(
                updatedDog: new DogDto { Name = "UpdatedDogName" },
                id: initialDog.Id
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Dog>());
            Assert.That(result.Name, Is.EqualTo("UpdatedDogName"));
        }
    }
}

