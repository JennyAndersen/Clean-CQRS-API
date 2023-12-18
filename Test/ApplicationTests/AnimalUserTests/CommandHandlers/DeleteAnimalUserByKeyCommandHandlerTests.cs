using Application.AnimalUsers.Commands.DeleteAnimalUserByKey;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.AnimalUserTests.CommandHandlers
{
    [TestFixture]
    public class DeleteAnimalUserByKeyCommandHandlerTests
    {
        private Mock<IAnimalUserRepository> _animalUserRepositoryMock;
        private DeleteAnimalUserByKeyCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _animalUserRepositoryMock = new Mock<IAnimalUserRepository>();
            _handler = new DeleteAnimalUserByKeyCommandHandler(_animalUserRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_DeleteBird_return_true([Frozen] AnimalUser animalUser)
        {
            // Arrange
            _animalUserRepositoryMock.Setup(x => x.GetByKeyAsync(animalUser.Key)).ReturnsAsync(animalUser);

            // Act
            var command = new DeleteAnimalUserByKeyCommand(animalUser.Key);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
            _animalUserRepositoryMock.Verify(x => x.DeleteAsync(animalUser.Key), Times.Once);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_with_nonexistent_animalUser_THEN_return_false(Guid key)
        {
            // Arrange
            _animalUserRepositoryMock.Setup(x => x.GetByKeyAsync(key)).ReturnsAsync((AnimalUser)null);

            // Act
            var command = new DeleteAnimalUserByKeyCommand(key);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.False);
            _animalUserRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);
        }
    }
}
