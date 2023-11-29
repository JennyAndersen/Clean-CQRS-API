using Application.Animals.Queries.Dogs.GetById;
using Infrastructure.Database;
using SendGrid.Helpers.Errors.Model;

namespace Test.ApplicationTests.DogTests.QueryHandlers
{
    [TestFixture]
    public class GetDogByIdQueryHandlerTests
    {
        private GetDogByIdQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetDogByIdQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_ValidId_THEN_ReturnsCorrectDog()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");

            var query = new GetDogByIdQuery(dogId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(dogId));
        }

        [Test]
        public void WHEN_Handle_InvalidId_THEN_THrowsException()
        {
            // Arrange
            var invalidDogId = Guid.NewGuid();

            var query = new GetDogByIdQuery(invalidDogId);

            //Act & Arrange
            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(query, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("Dog not found."));
        }
    }
}
