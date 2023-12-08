using Application.Animals.Commands.Cats.UpdateCat;

namespace Test.ApplicationTests.CatTests.CommandHandlers
{
    [TestFixture]
    public class UpdateCatByIdCommandHandlerTests
    {
        private UpdateCatByIdCommandHandler _handler;
        /*
        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_THEN_UpdatesCatInDatabase()
        {
            // Arrange
            var initialCat = new Cat { AnimalId = Guid.NewGuid(), Name = "InitialCatName", LikesToPlay = true };
            MockDatabase.Cats.Add(initialCat);

            var command = new UpdateCatByIdCommand(
                updatedCat: new CatDto { Name = "UpdatedCatName", LikesToPlay = false },
                id: initialCat.AnimalId
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Cat>());
            Assert.That(result.Name, Is.EqualTo("UpdatedCatName"));
        }*/
    }
}

