using Application.Authentication.Commands.Users.Register;
using Application.Dtos;
using AutoFixture.NUnit3;
using FluentAssertions;
using Infrastructure.Interfaces;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.AuthenticationTests.CommandHandlers
{
    [TestFixture]
    public class RegisterUserCommandHandlerTests
    {
        private RegisterUserCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            _handler = new RegisterUserCommandHandler(mockUserRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task Handle_ValidRegistration_ReturnsUser([Frozen] UserRegistrationDto newUserDto)
        {
            // Arrange
            var command = new RegisterUserCommand(newUserDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.UserName.Should().Be(command.NewUser.Username);
        }
    }
}
