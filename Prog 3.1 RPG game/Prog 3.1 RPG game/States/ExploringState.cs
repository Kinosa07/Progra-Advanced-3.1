using Prog_3._1_RPG_game.Components;
using Prog_3._1_RPG_game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.States
{
    public class ExploringState : IState
    {
        //Objects present in State
        private GameManager gameManager;
        private EventManager _eventManager;
        private InputComponent _playerInput;
        private MovementComponent _playerMovement;

        //Données test
        private bool _isInState;

        //Stuff that you're meant to do
        //Walk around (Except through walls)
        //See the map (See Render Function)
        //Enter Cities

        public ExploringState(InputComponent player_input, MovementComponent player_movement, EventManager event_manager)
        {
            _playerInput = player_input;
            _playerMovement = player_movement;
            _eventManager = event_manager;
        }

        public void Enter()
        {
            _isInState = true;
            _eventManager.RegisterToEvent<KeyPressedEvent>(MoveWhenTriggered);
        }

        public void Exit()
        {
            _isInState = false;
            _eventManager.UnRegisterEvent<KeyPressedEvent>(MoveWhenTriggered);
        }

        public void Update(float delta_time)
        {

        }

        public void FixedUpdate(float fixed_time_until_update)
        {

        }

        public void Render()
        {

        }

        //fonction pour test Unitaires
        public bool GetIsInState()
        {
            return _isInState;
        }

        public void MoveWhenTriggered(GameEvent game_event)
        {
            KeyPressedEvent key_pressed_event = game_event as KeyPressedEvent;

            if (key_pressed_event != null)
            {
                switch (key_pressed_event._keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        {
                            _playerMovement.MoveObject(0, -1);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            _playerMovement.MoveObject(0, +1);
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            _playerMovement.MoveObject(-1, 0);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            _playerMovement.MoveObject(+1, 0);
                            break;
                        }
                }
            }
        }
    }
}
