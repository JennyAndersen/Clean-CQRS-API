using API.Controllers.UsersController;
using Application.Authentication.Commands.Users.Register;
using Application.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Test.APITests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private WebApplicationFactory<UserController> _factory;
        private HttpClient _client;
        private Mock<IMediator> _mediatorMock;
        private UserController _controller;


        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<UserController>();
            _client = _factory.CreateClient();
            _mediatorMock = new Mock<IMediator>();
            _controller = new UserController(_mediatorMock.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _factory.Dispose();
            _client.Dispose();
        }

        [Test]
        public async Task WHEN_RegisterUser_THEN_Success()
        {
            // Arrange
            var newUser = new UserRegistrationDto
            {
                Username = "testuser1",
                Password = "testpassword1"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    Id = Guid.NewGuid(),
                    UserName = newUser.Username,
                    UserPassword = newUser.Password,
                });

            // Act
            var result = await _controller.Register(newUser);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
        /*
        //HÅLLER PÅ ATT BRYTA NER UTAN SKAPADE EN POC BARA 
        [Test]
        public async Task CanRegisterAndLoginUser()
        {
            // Arrange
            var client = _factory.CreateClient();

            var registrationDto = new UserRegistrationDto
            {
                Username = "testuser",
                Password = "testpassword"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    Id = Guid.NewGuid(),
                    UserName = registrationDto.Username,
                    UserPassword = registrationDto.Password,
                });

            var registrationContent = new StringContent(JsonConvert.SerializeObject(registrationDto), Encoding.UTF8, "application/json");
            var registrationResponse = await client.PostAsync("/api/User/register", registrationContent);
            registrationResponse.EnsureSuccessStatusCode();

            var loginDto = new LoginRequest
            {
                Username = "testuser",
                Password = "testpassword"
            };

            var loginContent = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
            var loginResponse = await client.PostAsync("/api/User/login", loginContent);
            loginResponse.EnsureSuccessStatusCode();

            var token = await loginResponse.Content.ReadAsStringAsync();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Assert 
            Assert.That(loginResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        */
    }
}
