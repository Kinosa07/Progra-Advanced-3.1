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
        InputComponent _playerInput;

        //Données test
        private bool _isInState;

        //Stuff that you're meant to do
        //Walk around (Except through walls)
        //See the map (See Render Function)
        //Enter Cities

        public ExploringState(InputComponent player_input, EventManager event_manager)
        {
            _playerInput = player_input;
            _eventManager = event_manager;
        }

        public void Enter()
        {
            _isInState = true;
        }

        public void Exit()
        {
            _isInState = false;
        }

        public void Update(float delta_time)
        {
            ConsoleKey player_input = _playerInput.ProcessInput();

            if (player_input != ConsoleKey.RightWindows)
            {
                _eventManager.TriggerEvent(new KeyPressedEvent(player_input));
            }
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
    }
}
