using Prog_3._1_RPG_game.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    internal class StateMachine
    {
        private IState _currentState;

        public StateMachine(IState initial_state)
        {
            _currentState = initial_state;
        }

        public void Update()
        {

        }

        public void ChangeState(IState new_state)
        {
            _currentState.Exit();
            _currentState = new_state;
            _currentState.Enter();
        }
    }
}
