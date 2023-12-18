using Application.Authentication.Commands.DeleteUser;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.UsersTests.CommandHandlers
{
    [TestFixture]
    public class DeleteUserByIdCommandHandlerTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private DeleteUserByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new DeleteUserByIdCommandHandler(_userRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_DeleteUser_return_true([Frozen] User initialUser)
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetByIdAsync(initialUser.UserId)).ReturnsAsync(initialUser);
            var command = new DeleteUserByIdCommand(initialUser.UserId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
