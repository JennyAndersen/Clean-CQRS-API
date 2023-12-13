using Application.Animals.Queries.Dogs.GetAll;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.DogTests.QueryHandlers
{
    [TestFixture]
    public class GetAllDogsTests
    {
        private Mock<IAnimalRepository> _animalRepositoryMock;
        private GetAllDogsQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new GetAllDogsQueryHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_GetAlLDogs_ReturnsCorrect([Frozen] List<Dog> dogs)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetAllDogsAsync()).ReturnsAsync(dogs);

            var query = new GetAllDogsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Dog>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}
