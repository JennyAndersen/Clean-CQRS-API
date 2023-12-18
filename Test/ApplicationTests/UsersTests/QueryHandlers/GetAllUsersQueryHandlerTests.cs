using Application.Authentication.Queries.GetAll;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.UsersTests.QueryHandlers
{
    [TestFixture]
    public class GetAllUsersQueryHandlerTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private GetAllUsersQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetAllUsersQueryHandler(_userRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_GetAlLDogs_ReturnsCorrect([Frozen] List<User> users)
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(users);

            var query = new GetAllUsersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<User>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}
