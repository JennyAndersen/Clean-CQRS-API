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
            _mockDatabase = new MockDatabase();
            _handler = new GetAllBirdsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_THEN_GetAlLBirds_ReturnsCorrect()
        {
            // Arrange
            var query = new GetAllBirdsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Bird>>());
            Assert.That(result.Count, Is.GreaterThan(0));
        }

    }
}