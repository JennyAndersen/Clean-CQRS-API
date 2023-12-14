using Application.Animals.Queries.Birds.GetById;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using SendGrid.Helpers.Errors.Model;
using Test.TestHelpers;

namespace Test.ApplicationTests.BirdTests.QueryHandlers
{
    [TestFixture]
    public class GetBirdByIdQueryHandlerTests
    {
        private GetBirdByIdQueryHandler _handler;
        private Mock<IAnimalRepository> _animalRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new GetBirdByIdQueryHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_ValidId_ReturnsCorrectBird([Frozen] Bird bird)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetByIdAsync(bird.AnimalId)).ReturnsAsync(bird);

            var query = new GetBirdByIdQuery(bird.AnimalId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AnimalId, Is.EqualTo(bird.AnimalId));
        }

        [Test]
        public void Handle_InvalidId_Throws_Exception()
        {
            // Arrange
            var invalidBirdId = Guid.NewGuid();
            var query = new GetBirdByIdQuery(invalidBirdId);

            // Act & Assert
            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(query, CancellationToken.None));
            // Assert.That(exception.Message, Is.EqualTo("Bird not found."));
        }
    }
}