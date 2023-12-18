using Application.Animals.Commands.Birds.DeleteBird;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class DeleteBirdByIdCommandHandlerTests
    {
        private Mock<IAnimalRepository> _animalRepositoryMock;
        private DeleteBirdByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new DeleteBirdByIdCommandHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_DeleteBird_return_true([Frozen] Bird initialBird)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetByIdAsync(initialBird.AnimalId)).ReturnsAsync(initialBird);

            // Act
            var command = new DeleteBirdByIdCommand(initialBird.AnimalId);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.IsSuccess, Is.True);
        }
    }
}
