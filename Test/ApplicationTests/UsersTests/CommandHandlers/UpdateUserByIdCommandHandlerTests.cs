using Application.Authentication.Commands.UpdateUser;
using Application.Dtos;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.UsersTests.CommandHandlers
{
    [TestFixture]
    public class UpdateUserByIdCommandHandlerTests
    {
        private UpdateUserByIdCommandHandler _handler;
        private Mock<IUserRepository> _userRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new UpdateUserByIdCommandHandler(_userRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_UpdatesUser([Frozen] User initialUser, UserRegistrationDto updatedUser)
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetByIdAsync(initialUser.UserId)).ReturnsAsync(initialUser);

            var command = new UpdateUserByIdCommand(updatedUser, initialUser.UserId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<User>());
        }
    }
}
