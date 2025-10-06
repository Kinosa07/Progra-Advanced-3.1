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
        private GameObject _playerToTransfer;

        public StateMachine(IState initial_state, GameObject player_object)
        {
            _currentState = initial_state;
            _playerToTransfer = player_object;
        }

        public void Update(float delta_time)
        {
            _currentState.Update(delta_time);
        }

        public void FixedUpdate(float fixed_time_until_update, float delta_time)
        {
            _currentState.FixedUpdate(fixed_time_until_update, delta_time);
        }
        }

        public void ChangeState(IState new_state)
        {
            _currentState.Exit();
            _currentState = new_state;
            _currentState.Enter(_playerToTransfer);
        }
    }
}
