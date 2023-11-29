using Application.Animals.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.DogTests.QueryHandlers
{
    [TestFixture]
    public class GetAllDogsTests
    {
        private GetAllDogsQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetAllDogsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_GetAlLDogs_ReturnsCorrect()
        {
            // Arrange
            var query = new GetAllDogsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Dog>>());
            Assert.That(result.Count, Is.GreaterThan(0));
        }

    }
}
