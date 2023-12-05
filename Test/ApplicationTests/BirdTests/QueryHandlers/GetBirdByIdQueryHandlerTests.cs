using Application.Animals.Queries.Birds.GetById;
using Infrastructure.Database;
using SendGrid.Helpers.Errors.Model;

namespace Test.ApplicationTests.BirdTests.QueryHandlers
{
    [TestFixture]
    public class GetBirdByIdQueryHandlerTests
    {
        private GetBirdByIdQueryHandler _handler;
        private MockDatabase _mockDatabase;
        /*
        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetBirdByIdQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_THEN_ValidId_ReturnsCorrectBird()
        {
            // Arrange
            var birdId = new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a");

            var query = new GetBirdByIdQuery(birdId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(birdId));
        }

        [Test]
        public void Handle_InvalidId_Throws_Exception()
        {
            // Arrange
            var invalidBirdId = Guid.NewGuid();
            var query = new GetBirdByIdQuery(invalidBirdId);

            // Act & Assert
            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(query, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("Bird not found."));
        }
        */
    }
}