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
        private GameObject _parentGameObject;
        private bool _hasMovedlast;

        public MovementComponent(PositionComponent position_component, GameObject parent)
        {
            _positionComponent = position_component;
            _parentGameObject = parent;
            _hasMovedlast = false;
        }

        //Fonction Update
        public override void Update(float time_since_last_update)
        {

        }

        //Fonction FixedUpdate
        public override void FixedUpdate(float fixed_update_time)
        {
            _hasMovedlast = false;
        }
        public override GameObject GetParentGameObject()
        {
            return _parentGameObject;
        }

        public void MoveObject(int new_x_position, int new_y_position)
        {
            //Bouger l'objet selon de nouvelles positions
            _positionComponent.SetPosition(new_x_position, new_y_position);
            _hasMovedlast = true;
        }

        public bool GetHasMoved()
        { 
            return _hasMovedlast; 
        }
    }
}
