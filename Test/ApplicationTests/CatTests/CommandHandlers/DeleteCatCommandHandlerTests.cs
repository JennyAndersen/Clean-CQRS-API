using Application.Animals.Commands.Cats.DeleteCat;

namespace Test.ApplicationTests.CatTests.CommandHandlers
{
    [TestFixture]
    public class DeleteCatByIdCommandHandlerTests
    {
        private DeleteCatByIdCommandHandler _handler;
        /*
        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_THEN_DeletesCatInDatabase()
        {
            // Arrange
            var initialCat = new Cat { Id = Guid.NewGuid(), Name = "InitialCatName" };
            MockDatabase.Cats.Add(initialCat);

            var command = new DeleteCatByIdCommand(
                deletedCat: new CatDto { Name = "InitialCatName" },
                deletedCatId: initialCat.Id
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }*/
    }
}
