using SpaceInvarders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvarders.GameObjectFactory
{
    class AlienShipFactory : GameObjectFactory //grazina musu laivus oksmnautu
    {

        public AlienShipFactory(GameSettings gameSettings)
            : base(gameSettings)//persiunciam
        {

        }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject alianShip = new AlienShip() { Figure = GameSettings.AlienShip, gameObjectPlace = objectPlace, GameObjectType = GameObjectType.AlienShip };
            return alianShip;
        }



        public List<GameObject> GetSwarm()
        {
            List<GameObject> swarm = new List<GameObject>();
            int startX = GameSettings.SwarmStartXCoordinate;
            int startY = GameSettings.SwarmStartYCoordinate;

            for (int y = 0; y<GameSettings.NumberOfSwarmRows; y++)
            {
                for (int x = 0; x<GameSettings.NumberOfSwarmColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCoordinate = startX+ x, YCoordinate= startY + y };
                    GameObject alienShip = GetGameObject(objectPlace);
                    swarm.Add(alienShip);
                }
            }
            return swarm;
        }
    }
}
