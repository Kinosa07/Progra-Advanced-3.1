using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class RenderComponent : Component
    {
        private PositionComponent _positionComponent;
        private string _appearance;

        public RenderComponent(PositionComponent position_component, string wanted_appearance)
        {
            _positionComponent = position_component;
            _appearance = wanted_appearance;
        }

        public override void Update(float time_since_last_update)
        {

        }

        public override void FixedUpdate(float fixed_update_time)
        {
            
        }
    }
}
