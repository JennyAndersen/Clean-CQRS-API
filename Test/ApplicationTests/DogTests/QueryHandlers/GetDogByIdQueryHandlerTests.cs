using Application.Animals.Queries.Dogs.GetById;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using SendGrid.Helpers.Errors.Model;
using Test.TestHelpers;

namespace Test.ApplicationTests.DogTests.QueryHandlers
{
    [TestFixture]
    public class GetDogByIdQueryHandlerTests
    {

        private GetDogByIdQueryHandler _handler;
        private Mock<IAnimalRepository> _animalRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new GetDogByIdQueryHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_ValidId_ReturnsCorrectDog([Frozen] Dog dog)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetByIdAsync(dog.AnimalId)).ReturnsAsync(dog);

            var query = new GetDogByIdQuery(dog.AnimalId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AnimalId, Is.EqualTo(dog.AnimalId));
        }

        [Test]
        public void Handle_InvalidId_Throws_Exception()
        {
            // Arrange
            var invalidDogId = Guid.NewGuid();
            var query = new GetDogByIdQuery(invalidDogId);

            // Act & Assert
            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(query, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("Dog not found."));
        }
    }
}
