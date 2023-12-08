using Application.Animals.Commands.Dogs.AddDog;

namespace Test.ApplicationTests.DogTests.CommandHandlers
{
    [TestFixture]
    public class AddDogCommandHandlerTests
    {
        private AddDogCommandHandler _handler;
        /*
        [SetUp]
        public void Setup()
        {
            _handler = new AddDogCommandHandler(new MockDatabase());
        }

        [Test]
        public async Task WHEN_Handle_THEN_AddsDogToDatabase()
        {
            // Arrange
            var newDog = new DogDto { Name = "NewDogName" };
            var command = new AddDogCommand(newDog);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Dog>());
            Assert.Multiple(() =>
            {
                Assert.That(result.AnimalId, Is.Not.EqualTo(Guid.Empty));
                Assert.That(result.Name, Is.EqualTo("NewDogName"));
            });
        }*/
    }
}
