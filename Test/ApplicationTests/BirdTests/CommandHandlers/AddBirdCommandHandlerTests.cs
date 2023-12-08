using Application.Animals.Commands.Birds.AddBird;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class AddBirdCommandHandlerTests
    {
        private AddBirdCommandHandler _handler;
        /*
        [SetUp]
        public void Setup()
        {
            _handler = new AddBirdCommandHandler(new MockDatabase());
        }
        
        [Test]
        public async Task WHEN_Handle_THEN_AddsBirdToDatabase()
        {
            // Arrange
            var newBird = new BirdDto { Name = "NewBirdName" };
            var command = new AddBirdCommand(newBird);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Bird>());
            Assert.Multiple(() =>
            {
                Assert.That(result.AnimalId, Is.Not.EqualTo(Guid.Empty));
                Assert.That(result.Name, Is.EqualTo("NewBirdName"));
            });
        }*/
    }
}
