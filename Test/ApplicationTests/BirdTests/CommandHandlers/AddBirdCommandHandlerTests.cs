using Application.Animals.Commands.Birds.AddBird;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Entity;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class AddBirdCommandHandlerTests
    {
        private AddBirdCommandHandler _handler;
        private DataDbContext _dbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _dbContext = new DataDbContext(options);
            _handler = new AddBirdCommandHandler(_dbContext);
        }

        [Test]
        public async Task WHEN_Handle_THEN_AddsBirdToDatabase()
        {
            // Arrange
            var newBird = new BirdDto { Name = "NewBirdName" };
            var command = new AddBirdCommand(newBird);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Bird>());
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.Not.EqualTo(Guid.Empty));
                Assert.That(result.Name, Is.EqualTo("NewBirdName"));
            });
        }
    }
}
