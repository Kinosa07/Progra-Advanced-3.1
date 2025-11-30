using Prog_3._1_RPG_game.Components;
using Prog_3._1_RPG_game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.States
{
    public class InventoryState : IState
    {
        //Que faire dans les Menus:
        //Explorer les options
        //Sortir du menu

        //Objects in State
        private EventManager _eventManager;
        private int _positionInMenu = 0;

        //Variables pour test
        private bool _isInState;

        public InventoryState(EventManager event_manager)
        {
            _eventManager = event_manager;
        }

        public void Enter()
        {
            _isInState = true;
            _eventManager.RegisterToEvent<KeyPressedEvent>(SelectOption);
        }

        public void Exit()
        {
            _isInState = false;
            _eventManager.UnRegisterEvent<KeyPressedEvent>(SelectOption);
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

        public void SelectOption(GameEvent game_event)
        {
            KeyPressedEvent key_pressed_event = game_event as KeyPressedEvent;


        }
    }
}
