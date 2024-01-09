using SpaceInvarders.GameObjectFactory;
using SpaceInvarders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvarders
{
    class GameEngine
    {


        private bool _isNotOwer;
        private static GameEngine _gameEngine;
        private SceneRender _sceneRender;
        private GameSettings _gamesettings;
        private Scene _scene;

        private GameEngine()
        {

        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine == null)
            {
                _gameEngine = new GameEngine(gameSettings);
            }
            return _gameEngine;
        }
        private GameEngine(GameSettings gameSettings)
        {
            _gamesettings = gameSettings;
            _isNotOwer = true;
            _scene = Scene.GetScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);
        }

        public void Run()
        {
            int swarmMoveCounter = 0;
            int playerMissileCounter = 0;
            do
            {
                
                _sceneRender.Render(_scene);
                Thread.Sleep(_gamesettings.GameSpeed);
                _sceneRender.ClearScreen();
                
                if (swarmMoveCounter == _gamesettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }
                swarmMoveCounter++;

                if(playerMissileCounter ==  _gamesettings.PlayerMissileSpeed)
                {
                    CalculateMissileMove();
                    playerMissileCounter = 0;
                }
                playerMissileCounter++;

            } while (_isNotOwer);

            Console.ForegroundColor = ConsoleColor.Red;
            _sceneRender.RenderGameOver();
        }


        public void CalculateMovePlayerShipLeft()
        {
            if (_scene.playerShip.gameObjectPlace.XCoordinate > 1)
            {
                _scene.playerShip.gameObjectPlace.XCoordinate--;
            }
        }
        public void CalculateMovePlayerShipRight()
        {
            if (_scene.playerShip.gameObjectPlace.XCoordinate < _gamesettings.ConsoleWidth)
            {
                _scene.playerShip.gameObjectPlace.XCoordinate++;
            }
        }

        public void CalculateSwarmMove()
        {

            for (int i = 0; i < _scene.swarm.Count; i++)
            {
                GameObject alienShip = _scene.swarm[i];
                alienShip.gameObjectPlace.YCoordinate++;
                if (alienShip.gameObjectPlace.YCoordinate == _scene.playerShip.gameObjectPlace.YCoordinate)
                {
                    _isNotOwer = false;
                    
                    //Console.WriteLine("Game over");
                    break;
                }
                

            }

        }

        public void Shot()
        {

            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(_gamesettings);
            GameObject missile = missileFactory.GetGameObject(_scene.playerShip.gameObjectPlace);

            _scene.playerShipMissile.Add(missile);

            Console.Beep(1000, 200);


        }

        public void CalculateMissileMove()
        {
            if(_scene.playerShipMissile.Count == 0)
            {
                return;
            }

            for(int x = 0; x < _scene.playerShipMissile.Count; x++)
            {
                GameObject missile = _scene.playerShipMissile[x];

                if(missile.gameObjectPlace.YCoordinate == 1)
                {
                    _scene.playerShipMissile.RemoveAt(x);
                }
                
                missile.gameObjectPlace.YCoordinate--;

                for(int i=0; i<  _scene.swarm.Count; i++)
                {
                    GameObject alienShip = _scene.swarm[i];
                    if(missile.gameObjectPlace.Equals(alienShip.gameObjectPlace))
                    {
                        _scene.swarm.RemoveAt(i);
                        _scene.playerShipMissile.RemoveAt(x);
                        break;
                    }
                }
            }
        }
    }
}
