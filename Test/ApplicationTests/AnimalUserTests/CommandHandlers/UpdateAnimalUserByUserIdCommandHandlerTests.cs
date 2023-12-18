using Application.AnimalUsers.Commands.UpdateAnimalUserByUserID;
using Application.Dtos;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.AnimalUserTests.CommandHandlers
{
    [TestFixture]
    public class UpdateAnimalUserByUserIdCommandHandlerTests
    {

        private UpdateAnimalUserByUserIdCommandHandler _handler;
        private Mock<IAnimalUserRepository> _animalUserRepositoryMock;

        [SetUp]
        public void Setup()
        {
            // Set up the mock repository
            _animalUserRepositoryMock = new Mock<IAnimalUserRepository>();

            // Set up the handler with the mock repository
            _handler = new UpdateAnimalUserByUserIdCommandHandler(_animalUserRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_UpdatesAnimalUser(
            [Frozen] AnimalUser initialAnimalUser,
            AnimalUserDto updatedAnimalUserDto)
        {
            // Arrange
            _animalUserRepositoryMock.Setup(x => x.GetAnimalUserByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid userId) => new AnimalUser { UserId = userId });

            var command = new UpdateAnimalUserByUserIdCommand(updatedAnimalUserDto.UserId, initialAnimalUser.UserId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
            _animalUserRepositoryMock.Verify(x => x.UpdateAnimalUserAsync(It.Is<AnimalUser>(user =>
            user.UserId == initialAnimalUser.UserId)), Times.Once);
        }
    }
}
