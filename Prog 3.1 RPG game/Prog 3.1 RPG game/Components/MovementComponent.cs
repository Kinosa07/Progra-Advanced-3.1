using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class MovementComponent : Component
    {
        private PositionComponent _positionComponent;

        public MovementComponent(PositionComponent position_component)
        {
            _positionComponent = position_component;
        }

        //Fonction Update
        public override void Update(float time_since_last_update)
        {

        }

        //Fonction FixedUpdate
        public override void FixedUpdate(float fixed_update_time)
        {

        }
    }
}
