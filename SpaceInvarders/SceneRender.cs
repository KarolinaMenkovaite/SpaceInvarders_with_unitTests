using SpaceInvarders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvarders
{
    class SceneRender
    {
        int _screenWhidth;
        int _screenHeight;

        char[,] _screenMatrix;

        public SceneRender(GameSettings gameSettings)
        {
            _screenWhidth = gameSettings.ConsoleWidth;//savybes
            _screenHeight = gameSettings.ConsoleHight;
            _screenMatrix = new char[gameSettings.ConsoleHight, gameSettings.ConsoleWidth];

            Console.WindowHeight = gameSettings.ConsoleHight;
            Console.WindowWidth = gameSettings.ConsoleWidth;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {
            //Console.Clear();
            ClearScreen();
            Console.SetCursorPosition(0, 0);

            AddListForRendering(scene.swarm);//kosminiailaivai
            AddListForRendering(scene.ground);
            AddListForRendering(scene.playerShipMissile);

            AddGameObjectForRendering(scene.playerShip);


            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x<_screenWhidth; x++)
                {
                    stringBuilder.Append(_screenMatrix[y, x]);

                }

                stringBuilder.Append(Environment.NewLine);

            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public void AddGameObjectForRendering(GameObject gameObject)
        {

            if (gameObject.gameObjectPlace.YCoordinate < _screenMatrix.GetLength(0)
                && gameObject.gameObjectPlace.XCoordinate < _screenMatrix.GetLength(1))
            {
                _screenMatrix[gameObject.gameObjectPlace.YCoordinate, gameObject.gameObjectPlace.XCoordinate] = gameObject.Figure;
            }
            else
            {
               // _screenMatrix[gameObject.gameObjectPlace.YCoordinate, gameObject.gameObjectPlace.XCoordinate] = ' ';
            }
        }


        public void AddListForRendering(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                AddGameObjectForRendering(gameObject);

            }
        }

        public void ClearScreen()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x<_screenWhidth; x++)
                {
                    _screenMatrix[y, x]=' ';//panaikinam pasikartojancius praeitoies rodomus vaidus

                }

            }
            Console.SetCursorPosition(0, 0);
           // Console.WriteLine(stringBuilder.ToString());
            
        }

        public void RenderGameOver()
        {
            StringBuilder stringBuilder= new StringBuilder();stringBuilder.Append("!!! Game  Over !!!");
            Console.WriteLine(stringBuilder.ToString());
        }

    }
}
