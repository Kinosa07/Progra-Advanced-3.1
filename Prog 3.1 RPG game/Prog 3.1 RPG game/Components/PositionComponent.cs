using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class PositionComponent : Component
    {
        private int _xPos;
        private int _yPos;
        private int _previousXPos;
        private int _previousYPos;
        private GameObject _parentGameObject;

        public PositionComponent(int starting_x_position, int starting_y_position, GameObject parent)
        {
            SetPosition(starting_x_position, starting_y_position);
            _parentGameObject = parent;
        }

        //Fonction Update
        public override void Update(float time_since_last_update)
        {

        }

        //Fonction FixedUpdate
        public override void FixedUpdate(float fixed_update_time)
        {
            //Update previousPos
            _previousXPos = _xPos;
            _previousYPos = _yPos;


        }
        public override GameObject GetParentGameObject()
        {
            return _parentGameObject;
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
