using Application.Animals.Queries.Birds.GetAll;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.BirdTests.QueryHandlers
{
    [TestFixture]
    public class GetAllBirdsTests
    {
        private GetAllBirdsQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetAllBirdsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_GetAlLBirds_ReturnsCorrect()
        {
            // Arrange
            var query = new GetAllBirdsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Bird>>(result);
            Assert.Greater(result.Count, 0);
        }

    }
}