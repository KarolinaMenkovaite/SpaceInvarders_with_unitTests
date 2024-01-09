using SpaceInvarders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvarders.GameObjectFactory
{
    abstract class GameObjectFactory
    {
        public GameSettings GameSettings { get; set; }
        public abstract GameObject GetGameObject(GameObjectPlace gameObject);

        public GameObjectFactory(GameSettings gameSettingset)
        {
            GameSettings = gameSettingset;

        }
    }
}
