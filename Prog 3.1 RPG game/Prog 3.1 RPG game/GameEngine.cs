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
        //élément du GameEngine
        GameManager _gameManager = new GameManager();
        private float _lastUpdateTime = 0;
        private float _lastFixedUpdateTime = 0;
        private bool _shouldQuit = false;
        private Stopwatch _stopWatch = new Stopwatch();

        public void Run()
        {
            _stopWatch.Start();

            while (!_shouldQuit)
            {
                Update(_lastUpdateTime);
                FixedUpdate(1000.0f/10.0f, _lastUpdateTime);
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
        }

        public void FixedUpdate(float fixed_time_until_update, float time_since_last_update)
        {
            if (fixed_time_until_update <= time_since_last_update - _lastFixedUpdateTime)
            {
                //Work your magic
                _gameManager.FixedUpdate(fixed_time_until_update, time_since_last_update);
                _lastFixedUpdateTime = time_since_last_update;
            }
        }
    }
}
