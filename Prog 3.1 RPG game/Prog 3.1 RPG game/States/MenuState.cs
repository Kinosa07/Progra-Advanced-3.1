using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.States
{
    public class MenuState : IState
    {
        //Que faire dans les Menus:
        //Explorer les options
        //Sortir du menu

        //Objects in State
        private MapComponent _cityMap;
        private GameObject _player;
        private GameManager _gameManager;

        //Variables pour test
        bool _isInState;

        public MenuState()
        {
            
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
