using Application.Animals.Commands.Birds.UpdateBird;
using Application.Dtos;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class UpdateBirdByIdCommandHandlerTests
    {
        private UpdateBirdByIdCommandHandler _handler;
        private Mock<IAnimalRepository> _animalRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new UpdateBirdByIdCommandHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_UpdatesBird([Frozen] Bird initialBird, BirdDto updatedBird)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetByIdAsync(initialBird.AnimalId)).ReturnsAsync(initialBird);

            var command = new UpdateBirdByIdCommand(updatedBird, initialBird.AnimalId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Bird>());
        }
    }
}

