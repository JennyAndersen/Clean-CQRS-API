using Application.AnimalUsers.Commands.AddAnimalUser;
using Application.Dtos;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.AnimalUserTests.CommandHandlers
{
    [TestFixture]
    public class AddAnimalUserCommandHandlerTests
    {
        private AddAnimalUserCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var mockAnimalUserRepository = new Mock<IAnimalUserRepository>();
            mockAnimalUserRepository.Setup(x => x.AddUserAnimalAsync(It.IsAny<AnimalUser>()))
                .ReturnsAsync(true);
            _handler = new AddAnimalUserCommandHandler(mockAnimalUserRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Adds_AnimalUser([Frozen] AnimalUserDto newAnimalUser)
        {
            // Arrange
            var command = new AddAnimalUserCommand(newAnimalUser);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
