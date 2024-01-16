using System.Collections.Generic;
using Xunit;
using SpaceInvarders;
using SpaceInvarders.GameObjectFactory;
using SpaceInvarders.GameObjects;


namespace SpaceInvarders.Tests
{
    public class GroundFactoryTest
    {
        [Fact]
        public void GetGround_ShouldReturnListOfGroundObjects()
        {
            // Arrange (pasiruosišimas, objekto sukurimas)
            var gameSettings = new GameSettings
            {
                GroundStartXCoordinate = 1,
                GroundStartYCoordinate = 2,
                NumberOfGroundRows = 3,
                NumberOfGroundColls = 4,
                Ground = 'U'
            };

            var groundFactory = new GroundFactory(gameSettings);

            // Act (veiksmas)
            List<GameObject> ground = groundFactory.GetGround();

            // Assert (patikrinimas)
            Assert.NotNull(ground);
            Assert.Equal(3 * 4, ground.Count); // Tikrina ar atitinka reikiamakieki,  nurodyta "NumberOfGrounRows" ir "NumberOfGroundColls"

            // Tikrinamas kiekvienas zemes objektas pagal koordinaciu atitikima ir 'Figure'. Taipariamama  pradinems koordinatems 'GroundStartXCoordinate' ir 'GroundStartYCoordinate' is klases 'gameSettings' 
            int expectedX = gameSettings.GroundStartXCoordinate;
            int expectedY = gameSettings.GroundStartYCoordinate;

            foreach (var groundObj in ground)
            {
                Assert.Equal(expectedX, groundObj.gameObjectPlace.XCoordinate);
                Assert.Equal(expectedY, groundObj.gameObjectPlace.YCoordinate);
                Assert.Equal(gameSettings.Ground, groundObj.Figure);

                expectedX++;
                if (expectedX >= gameSettings.GroundStartXCoordinate + gameSettings.NumberOfGroundColls)
                {
                    expectedX = gameSettings.GroundStartXCoordinate;
                    expectedY++;
                }
            }
        }
    }
}
