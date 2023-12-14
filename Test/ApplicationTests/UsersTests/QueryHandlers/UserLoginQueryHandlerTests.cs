using Application.Authentication.Queries.Login;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.AuthenticationTests.QueryHandlers
{
    [TestFixture]
    public class UserLoginQueryandlerTests
    {
        private UserLoginQueryHandler _handler;
        private Mock<IAuthServices> _mockAuthServices;

        [SetUp]
        public void SetUp()
        {
            _mockAuthServices = new Mock<IAuthServices>();
            _handler = new UserLoginQueryHandler(_mockAuthServices.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Login([Frozen] User user)
        {
            // Arrange
            _mockAuthServices.Setup(x => x.AuthenticateUser(user.UserName, user.UserPasswordHash)).Returns(user);
            _mockAuthServices.Setup(x => x.GenerateJwtToken(user)).Returns("MockedJwtToken");

            var query = new UserLoginQuery
            {
                Username = user.UserName,
                Password = user.UserPasswordHash
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo("MockedJwtToken"));
        }
    }
}
