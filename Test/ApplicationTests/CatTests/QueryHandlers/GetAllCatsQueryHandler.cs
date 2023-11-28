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
        public async Task Handle_GetAlLCats_ReturnsCorrect()
        {
            // Arrange
            var query = new GetAllCatsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Cat>>(result);
            Assert.Greater(result.Count, 0);
        }

    }
}