using Application.Animals.Queries.Cats.GetById;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using SendGrid.Helpers.Errors.Model;
using Test.TestHelpers;

namespace Test.ApplicationTests.CatTests.QueryHandlers
{
    [TestFixture]
    public class GetCatByIdQueryHandlerTests
    {
        private GetCatByIdQueryHandler _handler;
        private Mock<IAnimalRepository> _animalRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new GetCatByIdQueryHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_ValidId_ReturnsCorrectCat([Frozen] Cat cat)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetByIdAsync(cat.AnimalId)).ReturnsAsync(cat);

            var query = new GetCatByIdQuery(cat.AnimalId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AnimalId, Is.EqualTo(cat.AnimalId));
        }

        [Test]
        public void Handle_InvalidId_Throws_Exception()
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