using Prog_3._1_RPG_game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    public class InputComponent: Component
    {
        private GameObject _parentGameObject;
        private EventManager _eventManager;
        private ConsoleKey _lastKeyPressed;
        private float _ellapsedTime;
        private float _timeSinceLastFixed;


        public InputComponent(GameObject parent_object, EventManager event_manager)
        {
            _parentGameObject = parent_object;
            _parentGameObject.AddComponent(this);
            _eventManager = event_manager;
            _lastKeyPressed = ConsoleKey.RightWindows;
            //Utilisation de RightWindows comme valeur "nulle". Dû à la fréquence d'uilisation de la touche dans un environnement de jeu
        }

        public override void Update (float time_since_last_update)
        {
            _ellapsedTime = time_since_last_update;
        }

        public override void FixedUpdate(float fixed_time_for_new_update)
        {
            if (_ellapsedTime - _timeSinceLastFixed > fixed_time_for_new_update)
            {
                ConsoleKey input = ProcessInput();

                if (input != ConsoleKey.RightWindows)
                {
                    _eventManager.TriggerEvent(new KeyPressedEvent(input));
                }

                _timeSinceLastFixed = _ellapsedTime;
            }
        }

        public override GameObject GetCopyOfParentGameObject()
        {
            GameObject copy_of_parent = new GameObject(_parentGameObject);
            return copy_of_parent;
        }

        public void ReadInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                _lastKeyPressed = key.Key;
            }
        }

        public ConsoleKey ProcessInput()
        {
            ConsoleKey local_copy_of_last_pressed_key = _lastKeyPressed;

            if (_lastKeyPressed != ConsoleKey.RightWindows)
            {
                _lastKeyPressed = ConsoleKey.RightWindows;
            }

            return local_copy_of_last_pressed_key;
        }
    }
}
