using SpaceInvarders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvarders.GameObjectFactory
{
     class GroundFactory : GameObjectFactory
    {
        public GroundFactory(GameSettings gameSettings)
            : base(gameSettings)//persiunciam
        {

        }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject groundObject = new GroundObject() { Figure = GameSettings.Ground, gameObjectPlace = objectPlace, GameObjectType = GameObjectType.GroundObject };
            return groundObject;
        }



        public List<GameObject> GetGround()
        {
            List<GameObject> ground = new List<GameObject>();
            int startX = GameSettings.GroundStartXCoordinate;
            int startY = GameSettings.GroundStartYCoordinate;

            for (int y = 0; y<GameSettings.NumberOfGroundRows; y++)
            {
                for (int x = 0; x<GameSettings.NumberOfGroundColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCoordinate = startX+ x, YCoordinate= startY + y };
                    GameObject groundObj = GetGameObject(objectPlace);
                    ground.Add(groundObj);
                }
            }
            return ground;
        }
    }
}
