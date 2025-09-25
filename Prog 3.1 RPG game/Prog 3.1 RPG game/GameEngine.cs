using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    internal class GameEngine
    {
        private bool _shouldQuit = false;
        private Stopwatch _stopWatch = new Stopwatch();
        private float _lastUpdateTime = 0;
        public void Run()
        {
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
    }
}
