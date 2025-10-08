using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    public class PositionComponent : Component
    {
        private int _xPos;
        private int _yPos;
        private int _previousXPos;
        private int _previousYPos;
        private GameObject _parentGameObject;

        public PositionComponent(int starting_x_position, int starting_y_position, GameObject parent)
        {
            _xPos = starting_x_position;
            _yPos = starting_y_position;
            _previousXPos = _xPos;
            _previousYPos = _yPos;
            _parentGameObject = parent;
            _parentGameObject.AddComponent(this);
        }

        public PositionComponent(PositionComponent position_component_to_copy)
        {
            _xPos = position_component_to_copy._xPos;
            _yPos = position_component_to_copy._yPos;
            _previousXPos = position_component_to_copy._previousXPos;
            _previousYPos = position_component_to_copy._previousYPos;
            _parentGameObject = position_component_to_copy._parentGameObject;
        }

        //Fonction Update
        public override void Update(float time_since_last_update)
        {

        }

        //Fonction FixedUpdate
        public override void FixedUpdate(float fixed_update_time, float time_since_last_update)
        {
            //Update previousPos
            _previousXPos = _xPos;
            _previousYPos = _yPos;
        }
        public override GameObject GetCopyOfParentGameObject()
        {
            GameObject copy_of_parent = new GameObject(_parentGameObject);
            return copy_of_parent;
        }

        public int GetPositionX()
        {
            return _xPos;
        }

        public int GetPositionY()
        {
            return _yPos;
        }

        public int GetPreviousPositionX()
        {
            return _previousXPos;
        }

        public int GetPreviousPositionY()
        {
            return _previousYPos;
        }

        public void SetPosition(int new_x_position, int new_y_position)
        {
            _xPos = new_x_position;
            _yPos = new_y_position;
        }
    }
}
