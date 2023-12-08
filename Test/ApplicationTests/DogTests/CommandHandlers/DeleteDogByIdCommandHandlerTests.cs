using Application.Animals.Commands.Dogs.DeleteDog;

namespace Test.ApplicationTests.DogTests.CommandHandlers
{
    [TestFixture]
    public class DeleteDogByIdCommandHandlerTests
    {
        private DeleteDogByIdCommandHandler _handler;
        /*
        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_THEN_DeletesDogInDatabase()
        {
            // Arrange
            var initialDog = new Dog { Id = Guid.NewGuid(), Name = "InitialDogName" };
            MockDatabase.Dogs.Add(initialDog);

            var command = new DeleteDogByIdCommand(
                deletedDog: new DogDto { Name = "InitialDogName" },
                deletedDogId: initialDog.Id
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }*/
    }
}
