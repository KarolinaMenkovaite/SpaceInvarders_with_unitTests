using SpaceInvarders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvarders.GameObjectFactory
{
    class PlayerShipMissileFactory : GameObjectFactory
    {
        public PlayerShipMissileFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectPlace gameObjectplace)
        {
            GameObjectPlace missilePlace = new GameObjectPlace() { XCoordinate = gameObjectplace.XCoordinate, YCoordinate =  gameObjectplace.YCoordinate - 1 };
            GameObject missile = new PlayerShipMissile() { Figure =  GameSettings.PlayerMissile, gameObjectPlace = missilePlace, GameObjectType  = GameObjectType.PlayerShipMissile };
            return missile;
        }
    }
}
