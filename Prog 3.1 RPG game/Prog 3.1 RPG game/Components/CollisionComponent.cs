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
        private PositionComponent _positionComponent = new PositionComponent(1, 1, new GameObject());
        private MovementComponent _movementComponent = null;

        private int _previousColliderPosX;
        private int _previousColliderPosY;
        private int _tablePositionOfCollider = -1;
        private GameObject _parentGameObject;

        private bool _isColliding;

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

        //Ce que CollCompo doit faire: Repousser les objets vers leurs positions initiales : Get Previous X & Y et utiliser Movement Component
        //Comment trouver si un objet collisione: Utiliser MapComponent et parcourir TOUT les objets présents

        public override void Update(float deltaTime)
        {
            
        }

        public override void FixedUpdate(float fixed_update_time)
        {
            
        }

        public override GameObject GetParentGameObject()
        {
            return _parentGameObject;
        }

        public PositionComponent GetPositionComponent()
        {
            return _positionComponent;  
        }
    }
}
