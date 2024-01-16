using SpaceInvarders.GameObjectFactory;
using SpaceInvarders.GameObjects;
using Xunit;

namespace SpaceInvarders.Tests
{
    public class PlayerShipFactoryTests // Tikrina arsios klases metodas korektiskai sukuria objektus klases 'PlayerShip'  su teisingais parametrais
    {
        [Fact]
        public void GetGameObject_ShouldReturnPlayerShipWithCorrectPlace()
        {
            // Arrange
            var gameSettings = new GameSettings();
            var playerShipFactory = new PlayerShipFactory(gameSettings);

            // Act
            var playerShip = playerShipFactory.GetGameObject();

            // Assert
            Assert.NotNull(playerShip);
            Assert.Equal(gameSettings.PlayerShipStartXCoordinate, playerShip.gameObjectPlace.XCoordinate);
            Assert.Equal(gameSettings.PlayerShipStartYCoordinate, playerShip.gameObjectPlace.YCoordinate);
            Assert.Equal(gameSettings.PlayerShip, playerShip.Figure);
            Assert.Equal(GameObjectType.PlayerShip, playerShip.GameObjectType);
        }

        [Fact]
        public void GetGameObjectWithPlace_ShouldReturnPlayerShipWithSpecifiedPlace()
        {
            // Arrange
            var gameSettings = new GameSettings();
            var playerShipFactory = new PlayerShipFactory(gameSettings);
            var place = new GameObjectPlace { XCoordinate = 5, YCoordinate = 10 };

            // Act
            var playerShip = playerShipFactory.GetGameObject(place);

            // Assert
            Assert.NotNull(playerShip);
            Assert.Equal(place.XCoordinate, playerShip.gameObjectPlace.XCoordinate);
            Assert.Equal(place.YCoordinate, playerShip.gameObjectPlace.YCoordinate);
        }
    }
}
