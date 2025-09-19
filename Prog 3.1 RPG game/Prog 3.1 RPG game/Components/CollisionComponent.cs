using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class CollisionComponent : Component
    {
        private PositionComponent _positionComponent = new PositionComponent(-1, -1);
        private MapComponent _mapComponent = new MapComponent();

        private int _previousColliderPosX;
        private int _previousColliderPosY;
        int _tablePositionOfCollider = -1;

        private bool _isColliding;

        public CollisionComponent (PositionComponent object_position_component, MapComponent location_map_component)
        {
            _positionComponent = object_position_component;
            _mapComponent = location_map_component;
        }

        //Ce que CollCompo doit faire: Repousser les objets vers leurs positions initiales : Get Previous X & Y et utiliser Movement Component
        //Comment trouver si un objet collisione: Utiliser MapComponent et parcourir TOUT les objets présents

        public override void Update(float deltaTime)
        {
            //Analyser si Collisions
            for (int map_object_index = 0; map_object_index < _mapComponent.GetAllObjectsInside().Length; map_object_index++)
            {
                _tablePositionOfCollider = map_object_index;
                if (_positionComponent.GetPositionX() == _mapComponent.GetAllObjectsInside()[map_object_index].GetComponent<PositionComponent>().GetPositionX())
                {
                    _isColliding = true;
                    _tablePositionOfCollider = map_object_index;
                }

                if (_positionComponent.GetPositionY() == _mapComponent.GetAllObjectsInside()[map_object_index].GetComponent<PositionComponent>().GetPositionY())
                {
                    _isColliding = true;
                    _tablePositionOfCollider = map_object_index;
                }
            }
            //Si Collision, enregistrer previous position Collider
            if (_isColliding && (_tablePositionOfCollider >= 0))
            {
                _previousColliderPosX = _mapComponent.GetAllObjectsInside()[_tablePositionOfCollider].GetComponent<PositionComponent>().GetPreviousPositionX();
                _previousColliderPosY = _mapComponent.GetAllObjectsInside()[_tablePositionOfCollider].GetComponent<PositionComponent>().GetPreviousPositionY();
            }
        }

        public override void FixedUpdate(float fixed_update_time)
        {
            //Repousser les objets au positions de base
        }
    }
}
