using Application.Animals.Commands.Cats.DeleteCat;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.CatTests.CommandHandlers
{
    [TestFixture]
    public class DeleteCatByIdCommandHandlerTests
    {
        private DeleteCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_DeletesCatInDatabase()
        {
            // Arrange
            var initialCat = new Cat { Id = Guid.NewGuid(), Name = "InitialCatName" };
            _mockDatabase.Cats.Add(initialCat);

            var command = new DeleteCatByIdCommand(
                deletedCat: new CatDto { Name = "InitialCatName" },
                deletedCatId: initialCat.Id
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);

            var deletedCatInDatabase = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == command.DeletedCatId);
            Assert.That(deletedCatInDatabase, Is.Null);
        }
    }
}
