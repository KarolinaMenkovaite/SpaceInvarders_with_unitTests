using SpaceInvarders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space//saugo tam tikrus objektus
{
    class Program
    {
        static GameEngine gameEngine;

        static GameSettings gameSettings;

        static UIController uiController;

        static void Main(string[] args)
        {

            Initialize();

            gameEngine.Run();


        }

        public static void Initialize()
        {

            gameSettings = new GameSettings();

            gameEngine = GameEngine.GetGameEngine(gameSettings);

            uiController = new UIController();

            uiController.OnAPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            uiController.OnDPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();
            uiController.OnSpacePressed += (obj, arg) => gameEngine.Shot();

            Thread uIthread = new Thread(uiController.StartListening); //sozdoem potok
            
            uIthread.Start();



        }
    }
}
