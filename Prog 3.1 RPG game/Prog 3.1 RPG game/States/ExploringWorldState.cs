using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.States
{
    internal class ExploringWorldState : IState
    {
        private MapComponent _worldMap;
        private RenderManager _renderManager;

        public ExploringWorldState(MapComponent world_map, RenderManager render_manager)
        {
            _worldMap = world_map;
            _renderManager = render_manager;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }

        public void Update()
        {

        }

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    //GameEvent: Going Up
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    //GameEvent: Going Down
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    //GameEvent: Going Left
                }

                if (key.Key == ConsoleKey.RightArrow)
                {  
                    //GameEvent: going right
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    //GameEvent: Going to Menu
                }
            }       
        }

        public void Render()
        {
            _renderManager.Render(_worldMap);
        }
    }
}
