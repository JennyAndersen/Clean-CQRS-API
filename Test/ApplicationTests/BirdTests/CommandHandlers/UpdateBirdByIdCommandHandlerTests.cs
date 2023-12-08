using Application.Animals.Commands.Birds.UpdateBird;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class UpdateBirdByIdCommandHandlerTests
    {
        private UpdateBirdByIdCommandHandler _handler;

        /*
        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_THEN_UpdatesBirdInDatabase()
        {
            // Arrange
            var initialBird = new Bird { AnimalId = Guid.NewGuid(), Name = "InitialBirdName", CanFly = true };
            _mockDatabase.Birds.Add(initialBird);

            var command = new UpdateBirdByIdCommand(
                updatedBird: new BirdDto { Name = "UpdatedBirdName", CanFly = false },
                id: initialBird.AnimalId
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Bird>());
            Assert.That(result.Name, Is.EqualTo("UpdatedBirdName"));
        }
        */
    }
}

