using SpaceInvarders.GameObjectFactory;
using SpaceInvarders.GameObjects;
using Xunit;

namespace SpaceInvarders.Tests
{
    public class PlayerShipMissileFactoryTests
    {
        [Fact]
        public void GetGameObject_ShouldReturnPlayerShipMissileWithCorrectPlace()
        {
            // Arrange
            var gameSettings = new GameSettings();
            var missileFactory = new PlayerShipMissileFactory(gameSettings);

            // Assuming the player ship is at (X: 5, Y: 10)
            var playerShipPlace = new GameObjectPlace { XCoordinate = 5, YCoordinate = 10 };

            // Act
            var missile = missileFactory.GetGameObject(playerShipPlace);

            // Assert
            Assert.NotNull(missile);
            Assert.Equal(gameSettings.PlayerMissile, missile.Figure); // Check if the figure is correct
            Assert.Equal(GameObjectType.PlayerShipMissile, missile.GameObjectType); // Check if the type is correct

            // Check if the missile is placed one unit above the player ship
            Assert.Equal(playerShipPlace.XCoordinate, missile.gameObjectPlace.XCoordinate);
            Assert.Equal(playerShipPlace.YCoordinate - 1, missile.gameObjectPlace.YCoordinate);
        }
    }
}
