using Application.Animals.Commands.Dogs.AddDog;
using Application.Dtos;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using FluentAssertions;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.DogTests.CommandHandlers
{
    [TestFixture]
    public class AddDogCommandHandlerTests
    {
        private AddDogCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            _handler = new AddDogCommandHandler(mockAnimalRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_AddsDogToDatabase([Frozen] DogDto newDogDto)
        {
            // Arrange
            var command = new AddDogCommand(newDogDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.InstanceOf<Dog>());
                Assert.That(result.AnimalId, Is.Not.EqualTo(Guid.Empty));
            });
            result.Name.Should().Be(command.NewDog.Name);
        }
    }
}
