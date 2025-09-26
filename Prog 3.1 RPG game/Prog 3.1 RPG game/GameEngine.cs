using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Prog_3._1_RPG_game
{
    internal class GameEngine
    {
        private bool _shouldQuit = false;
        private Stopwatch _stopWatch = new Stopwatch();
        private float _lastUpdateTime = 0;
        public void Run()
        {
            GameObject _player = CreatePlayer(1,1);

            while (!_shouldQuit)
            {
                ProcessInput();
                Update(_lastUpdateTime);
                FixedUpdate(1.0f);
                Render();
                Thread.Sleep(1000 / 10);
            }
        }

        public void Render()
        {

        }

        public void Update(float time_since_last_update)
        {
            _lastUpdateTime = _stopWatch.ElapsedMilliseconds;
        }

        public void FixedUpdate(float fixed_time_until_update)
        {
            if (fixed_time_until_update <= _lastUpdateTime)
            {
                //Work your magic
            }
        }

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    //Move Up
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    //Move Down
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    //Move Left
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    //Move Right
                }
            }
        }

        private GameObject CreatePlayer(int starting_x_pos, int starting_y_pos)
        {
            GameObject player = new GameObject();
            PositionComponent player_pos_comp = new PositionComponent(starting_x_pos, starting_y_pos);
            MovementComponent player_move_comp = new MovementComponent(player_pos_comp);
            RenderComponent player_render = new RenderComponent(player_pos_comp, "^", "v", "<", ">");
            CollisionComponent player_collision = new CollisionComponent(player_pos_comp);

            player.AddComponent(player_pos_comp);
            player.AddComponent(player_move_comp);
            player.AddComponent(player_render);
            player.AddComponent(player_collision);

            return player;
        }
    }
}
