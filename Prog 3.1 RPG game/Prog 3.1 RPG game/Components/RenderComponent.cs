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
        private GameObject _parentGameObject;

        public RenderComponent(RenderManager game_render_manager, PositionComponent position_component, string immobile_image, GameObject parent)
        {
            _positionComponent = position_component;
            _appearanceTable.Add("base", immobile_image);
            _currentLookingDirection = "base";
            _parentGameObject = parent;

            game_render_manager.AddRenderComponent(this);
        }
        public RenderComponent(RenderManager game_render_manager, PositionComponent position_component, string looking_up, string looking_down, string looking_left, string looking_right, GameObject parent)
        {
            _positionComponent = position_component;
            _appearanceTable.Add("up", looking_up);
            _appearanceTable.Add("down", looking_down);
            _appearanceTable.Add("left", looking_left);
            _appearanceTable.Add("right", looking_right);
            _currentLookingDirection = "up";
            _parentGameObject = parent;

            game_render_manager.AddRenderComponent(this);
        }

        public override void Update(float time_since_last_update)
        {

        }

        public override void FixedUpdate(float fixed_update_time)
        {

        }
        public override GameObject GetParentGameObject()
        {
            //Pas une copie (Voir Constucteurs de copies/autres)
            return _parentGameObject;
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
