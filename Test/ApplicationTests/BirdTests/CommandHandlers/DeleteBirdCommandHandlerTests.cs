using Application.Animals.Commands.Birds.DeleteBird;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class DeleteBirdByIdCommandHandlerTests
    {
        private DeleteBirdByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_THEN_DeletesBirdInDatabase()
        {
            // Arrange
            var initialBird = new Bird { Id = Guid.NewGuid(), Name = "InitialBirdName" };
            _mockDatabase.Birds.Add(initialBird);

            var command = new DeleteBirdByIdCommand(
                deletedBird: new BirdDto { Name = "InitialBirdName" },
                deletedBirdId: initialBird.Id
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
