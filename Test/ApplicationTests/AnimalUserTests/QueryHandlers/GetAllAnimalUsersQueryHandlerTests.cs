using Application.AnimalUsers.Queries.GetAllAnimalUsers;
using AutoFixture.NUnit3;
using Domain.Dtos;
using Infrastructure.Interfaces;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.AnimalUserTests.QueryHandlers
{
    [TestFixture]
    public class GetAllAnimalUsersQueryHandlerTests
    {
        private Mock<IAnimalUserRepository> _animalUserRepositoryMock;
        private GetAllAnimalUsersQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _animalUserRepositoryMock = new Mock<IAnimalUserRepository>();
            _handler = new GetAllAnimalUsersQueryHandler(_animalUserRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_GetAllAnimalUsers_ReturnsCorrect([Frozen] List<GetAnimalUsersDto> animalUsers)
        {
            // Arrange
            _animalUserRepositoryMock.Setup(x => x.GetAllAnimalUsersAsync()).ReturnsAsync(animalUsers);

            var query = new GetAllAnimalUsersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<GetAnimalUsersDto>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}
