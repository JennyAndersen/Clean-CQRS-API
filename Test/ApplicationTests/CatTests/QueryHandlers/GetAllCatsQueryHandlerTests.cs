using Application.Animals.Queries.Cats.GetAll;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.CatTests.QueryHandlers
{
    [TestFixture]
    public class GetAllDogsTests
    {
        private GetAllCatsQueryHandler _handler;
        private Mock<IAnimalRepository> _animalRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new GetAllCatsQueryHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_GetAlLCats_ReturnsCorrect([Frozen] List<Cat> cats)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetAllCatsAsync()).ReturnsAsync(cats);

            var query = new GetAllCatsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Cat>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}