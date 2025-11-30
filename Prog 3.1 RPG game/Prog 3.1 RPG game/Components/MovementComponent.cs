using Prog_3._1_RPG_game.Events;
using System.Threading.Tasks.Sources;

namespace Prog_3._1_RPG_game.Components
{
    public class MovementComponent : Component
    {
        private PositionComponent _positionComponent;
        private GameObject _parentGameObject;
        private bool _hasMovedlast;
        private EventManager _eventManager;
        private float _ellapsedTime;
        private float _timeSinceLastFixed;

        public MovementComponent(PositionComponent position_component, GameObject parent, EventManager event_manager)
        {
            _positionComponent = position_component;
            _parentGameObject = parent;
            _hasMovedlast = false;
            _eventManager = event_manager;

            _parentGameObject.AddComponent(this);
        }

        public MovementComponent(MovementComponent movement_component_to_copy)
        {
            if (movement_component_to_copy != null)
            {
                _positionComponent = movement_component_to_copy._positionComponent;
                _parentGameObject = movement_component_to_copy._parentGameObject;
                _hasMovedlast = movement_component_to_copy._hasMovedlast;
                _eventManager = movement_component_to_copy._eventManager;
            }
        }

        //Fonction Update
        public override void Update(float time_since_last_update)
        {
            _ellapsedTime = time_since_last_update;
        }

        //Fonction FixedUpdate
        public override void FixedUpdate(float fixed_update_time)
        {
            if (_ellapsedTime - _timeSinceLastFixed >= fixed_update_time)
            {
                _hasMovedlast = false;
                _timeSinceLastFixed = _ellapsedTime;
            }
        }
        public override GameObject GetCopyOfParentGameObject()
        {
            GameObject copy_of_parent = new GameObject(_parentGameObject);
            return copy_of_parent;
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
