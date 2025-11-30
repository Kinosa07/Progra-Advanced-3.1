using Prog_3._1_RPG_game.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    public class StateMachine
    {
        private IState _currentState;

        public StateMachine(IState initial_state)
        {
            _currentState = initial_state;

            _currentState.Enter();
        }

        public void Update(float delta_time)
        {
            _currentState.Update(delta_time);
        }

        public void FixedUpdate(float fixed_time_until_update)
        {
            _currentState.FixedUpdate(fixed_time_until_update);
        }

        public void Render()
        {
            _currentState.Render();
        }

        public void ChangeState(IState new_state)
        {
            _currentState.Exit();
            _currentState = new_state;
            _currentState.Enter();
        }
    }
}
