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
        private Dictionary<string, string> _appearanceTable = new Dictionary<string, string>();
        private string _currentLookingDirection;

        public RenderComponent(RenderManager game_render_manager ,PositionComponent position_component, string immobile_image)
        {
            _positionComponent = position_component;
            _appearanceTable.Add("base", immobile_image);
            _currentLookingDirection = "base";
        }
        public RenderComponent(RenderManager game_render_manager, PositionComponent position_component, string looking_up, string looking_down, string looking_left, string looking_right)
        {
            _positionComponent = position_component;
            _appearanceTable.Add("up", looking_up);
            _appearanceTable.Add("down", looking_down);
            _appearanceTable.Add("left", looking_left);
            _appearanceTable.Add("right", looking_right);
            _currentLookingDirection = "up";
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

        public string GetAppearance()
        {
            return _appearanceTable[_currentLookingDirection];
        }

        public void ModifyLookDirection(string key)
        { 
            _currentLookingDirection = key;
        }

    }
}
