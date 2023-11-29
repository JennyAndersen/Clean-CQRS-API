﻿using Application.Animals.Commands.Birds.AddBird;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class AddBirdCommandHandlerTests
    {
        private AddBirdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _handler = new AddBirdCommandHandler(new MockDatabase());
        }

        [Test]
        public async Task Handle_AddsBirdToDatabase()
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
