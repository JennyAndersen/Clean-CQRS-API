using Application.Animals.Queries.Dogs.GetAll;

namespace Test.ApplicationTests.DogTests.QueryHandlers
{
    [TestFixture]
    public class GetAllDogsTests
    {
        private GetAllDogsQueryHandler _handler;
        /*
        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetAllDogsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task WHEN_Handle_GetAlLDogs_THEN_ReturnsCorrect()
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
        */
    }
}
