﻿using Application.Animals.Commands.Dogs.UpdateDog;
using Application.Dtos;
using AutoFixture.NUnit3;
using Domain.Interfaces;
using Domain.Models.Animal;
using Moq;
using Test.TestHelpers;

namespace Test.ApplicationTests.DogTests.CommandHandlers
{
    [TestFixture]
    public class UpdateDogByIdCommandHandlerTests
    {
        private UpdateDogByIdCommandHandler _handler;
        private Mock<IAnimalRepository> _animalRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _handler = new UpdateDogByIdCommandHandler(_animalRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_UpdatesDog([Frozen] Dog initialDog, DogDto updatedDog)
        {
            // Arrange
            _animalRepositoryMock.Setup(x => x.GetByIdAsync(initialDog.AnimalId)).ReturnsAsync(initialDog);

            var command = new UpdateDogByIdCommand(updatedDog, initialDog.AnimalId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Dog>());
        }
    }
}

