using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Application.Commands.Dogs.UpdateDog;
using Domain.Models;
using Infrastructure.Database;
using Application.Dtos;

namespace Application.Tests.Commands.Dogs
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
        public async Task Handle_UpdatesDogInDatabase()
        {
            // Arrange
            var initialDog = new Dog { Id = Guid.NewGuid(), Name = "InitialDogName" };
            _mockDatabase.Dogs.Add(initialDog);

            // Create an instance of UpdateDogByIdCommand
            var command = new UpdateDogByIdCommand(
                updatedDog: new DogDto { Name = "UpdatedDogName" },
                id: initialDog.Id
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Dog>(result);

            // Check that the dog has the correct updated name
            Assert.AreEqual("UpdatedDogName", result.Name);

            // Check that the dog has been updated in MockDatabase
            var updatedDogInDatabase = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == command.Id);
            Assert.NotNull(updatedDogInDatabase);
            Assert.AreEqual("UpdatedDogName", updatedDogInDatabase.Name);
        }
    }
}

