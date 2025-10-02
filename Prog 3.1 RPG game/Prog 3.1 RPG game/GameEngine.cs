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
        //(Potentiellement migrable vers GameManager)
        CollisionManager _collisionManager = new CollisionManager();

        //élément du GameEngine
        GameManager _gameManager = new GameManager();
        private float _lastUpdateTime = 0;
        private bool _shouldQuit = false;
        private string _playerInput = "null";
        private Stopwatch _stopWatch = new Stopwatch();

        public void Run()
        {

            while (!_shouldQuit)
            {
                
                Update(_lastUpdateTime);
                FixedUpdate(1.0f);
                Render();
                Thread.Sleep(1000 / 10);
            }
        }

        public void Render()
        {
            _gameManager.Render();
        }

        public void Update(float time_since_last_update)
        {
            _lastUpdateTime = _stopWatch.ElapsedMilliseconds;
            _gameManager.Update(time_since_last_update);
            _collisionManager.Update();
        }

        public void FixedUpdate(float fixed_time_until_update)
        {
            if (fixed_time_until_update <= _lastUpdateTime)
            {
                //Work your magic
                _collisionManager.Update();
            }
        }

        private void ReadInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    _playerInput = "up";
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    _playerInput = "down";
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    _playerInput = "left";
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    _playerInput = "right";
                }

                if (key.Key == ConsoleKey.Escape)
                {

                    _playerInput = "Escape";
                }
            }
        }
    }
}
