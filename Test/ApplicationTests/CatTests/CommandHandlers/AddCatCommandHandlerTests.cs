using Application.Animals.Commands.Cats.AddCat;
using Application.Dtos;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using FluentAssertions;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.CatTests.CommandHandlers
{
    [TestFixture]
    public class AddCatCommandHandlerTests
    {
        private AddCatCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var mockAnimalRepository = new Mock<IAnimalRepository>();
            _handler = new AddCatCommandHandler(mockAnimalRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_AddsCatToDatabase([Frozen] CatDto newCatDto)
        {
            // Arrange
            var command = new AddCatCommand(newCatDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.InstanceOf<Cat>());
                Assert.That(result.AnimalId, Is.Not.EqualTo(Guid.Empty));
            });
            result.Name.Should().Be(command.NewCat.Name);
        }
    }
}
