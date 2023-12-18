using API.Controllers.UsersController;
using Application.Authentication.Commands.Register;
using Application.Dtos;
using AutoFixture.NUnit3;
using Domain.Models;
using Domain.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Test.TestHelpers;

namespace Test.APITests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private UserController _controller;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = CreateControllerInstance();
        }

        private UserController CreateControllerInstance()
        {
            return new UserController(_mediatorMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_RegisterUser_THEN_Success([Frozen] UserRegistrationDto newUser)
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = newUser.Username,
                    UserPasswordHash = newUser.Password,
                });

            // Act
            var result = await _controller.Register(newUser);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        [CustomAutoData]
        public async Task CanRegisterAndLoginUser([Frozen] UserRegistrationDto registrationDto, [Frozen] LoginRequest loginRequest)
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = registrationDto.Username,
                    UserPasswordHash = registrationDto.Password,
                });

            // Act
            var registrationResult = await _controller.Register(registrationDto);
            var loginResult = await _controller.Login(loginRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(registrationResult, Is.InstanceOf<OkObjectResult>());
                Assert.That(loginResult, Is.InstanceOf<OkObjectResult>());
            });
        }
    }
}
