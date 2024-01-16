using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvarders.GameObjectFactory;
using SpaceInvarders.GameObjects;
using System.Collections.Generic;

namespace SpaceInvarders.Tests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void CalculateMovePlayerShipLeft_ShouldDecrementXCoordinate()
        {
            // Arrange
            GameSettings gameSettings = new GameSettings(); // You might need to set appropriate values here
            GameEngine gameEngine = GameEngine.GetGameEngine(gameSettings);

            // Act
            gameEngine.CalculateMovePlayerShipLeft();

            // Assert
            Assert.AreEqual(gameEngine.GetScene().PlayerShip.GameObjectPlace.XCoordinate - 1, gameEngine.GetScene().PlayerShip.GameObjectPlace.XCoordinate);
        }

        [TestMethod]
        public void CalculateMovePlayerShipRight_ShouldIncrementXCoordinate()
        {
            // Arrange
            GameSettings gameSettings = new GameSettings(); // You might need to set appropriate values here
            GameEngine gameEngine = GameEngine.GetGameEngine(gameSettings);

            // Act
            gameEngine.CalculateMovePlayerShipRight();

            // Assert
            Assert.AreEqual(gameEngine.GetScene().PlayerShip.GameObjectPlace.XCoordinate + 1, gameEngine.GetScene().PlayerShip.GameObjectPlace.XCoordinate);
        }

        [TestMethod]
        public void CalculateSwarmMove_ShouldEndGameIfAlienShipReachesPlayerShip()
        {
            // Arrange
            GameSettings gameSettings = new GameSettings(); // You might need to set appropriate values here
            GameEngine gameEngine = GameEngine.GetGameEngine(gameSettings);
            gameEngine.GetScene().PlayerShip.GameObjectPlace.YCoordinate = 5; // Set a Y-coordinate where collision occurs

            // Act
            gameEngine.CalculateSwarmMove();

            // Assert
            Assert.IsFalse(gameEngine.GetIsNotOver());
        }

        // Add more tests for other methods as needed
    }
}
