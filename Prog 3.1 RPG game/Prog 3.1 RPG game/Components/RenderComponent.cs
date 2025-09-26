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
        private Dictionary<string, string> _appearanceTable;


        public RenderComponent(PositionComponent position_component, string immobile_image)
        {
            _positionComponent = position_component;
            _appearanceTable.Add("base", immobile_image);
        }
        public RenderComponent(PositionComponent position_component, string looking_up, string looking_down, string looking_left, string looking_right)
        {
            _positionComponent = position_component;
            _appearanceTable.Add("Up", looking_up);
            _appearanceTable.Add("Down", looking_down);
            _appearanceTable.Add("Left", looking_left);
            _appearanceTable.Add("Right", looking_right);
        }

        public override void Update(float time_since_last_update)
        {

        }

        public override void FixedUpdate(float fixed_update_time)
        {

        }

        public PositionComponent GetPositionComponent()
        {
            return _positionComponent;
        }
    }
}
