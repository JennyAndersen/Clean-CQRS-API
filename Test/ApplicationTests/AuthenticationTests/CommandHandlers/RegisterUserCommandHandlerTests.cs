using Application.Authentication.Commands.Users.Register;
using Application.Dtos;
using AutoFixture.NUnit3;
using FluentAssertions;
using Infrastructure.Database;
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
            var mockDatabase = new Mock<MockDatabase>();
            _handler = new RegisterUserCommandHandler(mockDatabase.Object);
        }

        [Theory]
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
