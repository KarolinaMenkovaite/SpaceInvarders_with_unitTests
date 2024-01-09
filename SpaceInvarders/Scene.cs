using SpaceInvarders.GameObjectFactory;
using SpaceInvarders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvarders
{
    class Scene
    {
        GameSettings _gameSettings;
        public List<GameObject> swarm; //laukas
        public List<GameObject> ground; // grindys
        public GameObject playerShip;
        public List<GameObject> playerShipMissile;


        private static Scene _scene;

        private Scene()
        {

        }

        private Scene(GameSettings gameSettings)//inicializacija
        {
            _gameSettings = gameSettings;
            swarm = new AlienShipFactory(_gameSettings).GetSwarm();
            ground = new GroundFactory(_gameSettings).GetGround();//kolekcijos
            playerShip = new PlayerShipFactory(_gameSettings).GetGameObject();
            playerShipMissile = new List<GameObject>();
        }
        public static Scene GetScene(GameSettings gameSettings)
        {
            if (_scene == null)
            {
                _scene = new Scene(gameSettings);
            }
            return _scene;
        }
      


        
    }
}
