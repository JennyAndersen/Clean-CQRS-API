using Application.Animals.Queries.Cats.GetAll;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.CatTests.QueryHandlers
{
    [TestFixture]
    public class GetAllDogsTests
    {
        private GetAllCatsQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetAllCatsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_GetAlLCats_THEN_ReturnsCorrect()
        {
            // Arrange
            var query = new GetAllCatsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Cat>>());
            Assert.That(result.Count, Is.GreaterThan(0));
        }

    }
}