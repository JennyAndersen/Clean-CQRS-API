using Application.Animals.Commands.Birds.AddBird;
using Application.Dtos;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using FluentAssertions;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class AddBirdCommandHandlerTests
    {
        private AddBirdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            _handler = new AddBirdCommandHandler(mockAnimalRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_AddsBirdToDatabase([Frozen] BirdDto newBird)
        {
            // Arrange
            var command = new AddBirdCommand(newBird);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Bird>());
            Assert.That(result.AnimalId, Is.Not.EqualTo(Guid.Empty));
            result.Name.Should().Be(command.NewBird.Name);
        }
    }
}
