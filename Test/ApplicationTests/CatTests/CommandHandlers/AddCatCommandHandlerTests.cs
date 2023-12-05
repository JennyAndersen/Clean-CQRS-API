using Application.Animals.Commands.Cats.AddCat;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.CatTests.CommandHandlers
{
    [TestFixture]
    public class AddCatCommandHandlerTests
    {
        private AddCatCommandHandler _handler;
        /*
        [SetUp]
        public void Setup()
        {
            _handler = new AddCatCommandHandler(new MockDatabase());
        }

        [Test]
        public async Task WHEN_Handle_THEN_AddsCatToDatabase()
        {
            // Arrange
            var newCat = new CatDto { Name = "NewCatName" };
            var command = new AddCatCommand(newCat);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Cat>());
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.Not.EqualTo(Guid.Empty));
                Assert.That(result.Name, Is.EqualTo("NewCatName"));
            });
        }
        */
    }
}
