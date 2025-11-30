using Prog_3._1_RPG_game.Components;
using Prog_3._1_RPG_game.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Prog_3._1_RPG_game
{
    public class GameEngine
    {
        //élément du GameEngine
        EventManager _eventManager = new EventManager();
        GameManager _gameManager;
        private float _lastUpdateTime = 0;
        private float _lastFixedUpdateTime = 0;
        private bool _shouldQuit = false;
        private Stopwatch _stopWatch = new Stopwatch();

        public void Run()
        {
            _gameManager = new GameManager(_eventManager);
            _stopWatch.Start();

            _eventManager.RegisterToEvent<KeyPressedEvent>(QuitGame);


            while (!_shouldQuit)
            {
                Update(_lastUpdateTime);
                FixedUpdate(1000.0f / 10.0f);
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

        public void FixedUpdate(float fixed_time_until_update)
        {
            _gameManager.FixedUpdate(fixed_time_until_update);
        }

        public void QuitGame(GameEvent game_event)
        {
            KeyPressedEvent key_pressed_event = game_event as KeyPressedEvent;

            if (key_pressed_event != null)
            {
                if (key_pressed_event._keyPressed == ConsoleKey.Escape)
                {
                    _shouldQuit = true;
                }
            }
        }
    }
}
