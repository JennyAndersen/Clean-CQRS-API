using Application.Animals.Commands.Cats.DeleteCat;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.CatTests.CommandHandlers
{
    [TestFixture]
    public class DeleteCatByIdCommandHandlerTests
    {
        private Mock<IAnimalRepository> _animalRepositoryMock;
        private DeleteCatByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new DeleteCatByIdCommandHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_DeleteCat_return_true([Frozen] Cat initialCat)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetByIdAsync(initialCat.AnimalId)).ReturnsAsync(initialCat);
            var command = new DeleteCatByIdCommand(initialCat.AnimalId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}


