using Application.Animals.Commands.Birds.DeleteBird;
using Infrastructure.Data;
using Moq;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class DeleteBirdByIdCommandHandlerTests
    {
        private DeleteBirdByIdCommandHandler _handler;
        private Mock<AnimalDbContext> _dataDbContextMock;
        /*
        [SetUp]
        public void Setup()
        {
            _dataDbContextMock = new Mock<AnimalDbContext>();
            _handler = new DeleteBirdByIdCommandHandler(_dataDbContextMock.Object);
        }

        [Fact]
        public void WHEN_Handle_THEN_DeletesBirdInDatabase()
        {
            // Arrange
            var initialBird = new Bird { Id = Guid.NewGuid(), Name = "InitialBirdName" };
            _dataDbContextMock.Setup(x => x.Birds.FindAsync(initialBird.Id)).ReturnsAsync(initialBird);

            var command = new DeleteBirdByIdCommand(
                deletedBirdId: initialBird.Id
            );

            // Act
            var result = _handler.Handle(command, CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            Assert.That(result, Is.True);
            _dataDbContextMock.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Once);
        }*/
    }
}
