using Application.Animals.Queries.Birds.GetAll;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.BirdTests.QueryHandlers
{
    [TestFixture]
    public class GetAllBirdsTests
    {
        private Mock<IAnimalRepository> _animalRepositoryMock;
        private GetAllBirdsQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new GetAllBirdsQueryHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_GetAlLBirds_ReturnsCorrect([Frozen] List<Bird> birds)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetAllBirdsAsync()).ReturnsAsync(birds);

            var query = new GetAllBirdsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Bird>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}
