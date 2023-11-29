using Application.Animals.Queries.Cats.GetById;
using Infrastructure.Database;
using SendGrid.Helpers.Errors.Model;

namespace Test.ApplicationTests.CatTests.QueryHandlers
{
    [TestFixture]
    public class GetCatByIdQueryHandlerTests
    {
        private GetCatByIdQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetCatByIdQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_ValidId_THEN_ReturnsCorrectCat()
        {
            // Arrange
            var catId = new Guid("7e910a6d-8621-4f4b-8a0c-5e199f42eaa5");

            var query = new GetCatByIdQuery(catId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(catId));
        }

        [Test]
        public void WHEN_Handle_InvalidId_THEN_ThrowsException()
        {
            // Arrange
            var invalidCatId = Guid.NewGuid();

            var query = new GetCatByIdQuery(invalidCatId);

            // Act & Assert
            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(query, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("Cat not found."));
        }
    }
}