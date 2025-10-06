using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class CollisionComponent : Component
    {
        private PositionComponent _positionComponent;
        private MovementComponent _movementComponent;

        private GameObject _parentGameObject;


        public CollisionComponent (PositionComponent object_position_component, GameObject parent)
        {
            _positionComponent = object_position_component;
            _movementComponent = null;
            _parentGameObject = parent;
        }

        public CollisionComponent (PositionComponent object_position_component, MovementComponent object_movement_component, GameObject parent)
        {
            _positionComponent = object_position_component;
            _movementComponent = object_movement_component;
            _parentGameObject = parent;
        }

        public override void Update(float deltaTime)
        {
            
        }

        public override void FixedUpdate(float fixed_update_time)
        {
            
        }

        public override GameObject GetParentGameObject()
        {
            //Pas une copie (Voir Constucteurs de copies/autres)
            GameObject copy_of_parent = _parentGameObject;
            return copy_of_parent;
        }

        public PositionComponent GetPositionComponent()
        {
            PositionComponent copy_of_position_component = _positionComponent;
            return copy_of_position_component;  
        }

        public MovementComponent GetMovementComponent()
        {
            MovementComponent copy_of_movement_component = _movementComponent;
            return copy_of_movement_component;
        }
    }
}
