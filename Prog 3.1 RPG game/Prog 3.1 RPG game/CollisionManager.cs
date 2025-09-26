using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    internal class CollisionManager
    {
        private CollisionComponent[] _collisonComponentsCollection = new CollisionComponent[1];
        public CollisionManager()
        {

        }

        public void AddCollisionComponent(CollisionComponent collision_component_to_add)
        {
            //Is table Full
            bool is_table_full = true;
            for (int collection_index = 0; collection_index < _collisonComponentsCollection.Length; collection_index++)
            {
                if (_collisonComponentsCollection[collection_index] == null)
                {
                    is_table_full = false;
                    break;
                }
            }

            if (is_table_full == true)
            {
                //magic to expand Table
                CollisionComponent[] temporary_table = new CollisionComponent[_collisonComponentsCollection.Length + 3];
                for (int collection_index = 0; collection_index < _collisonComponentsCollection.Length; collection_index++)
                {
                    temporary_table[collection_index] = _collisonComponentsCollection[collection_index];
                }
                _collisonComponentsCollection = temporary_table;
                is_table_full = false;
            }

            if (is_table_full == false)
            {
                for (int collection_index = 0; collection_index < _collisonComponentsCollection.Length; collection_index++)
                {
                    if (_collisonComponentsCollection[collection_index] == null)
                    {
                        _collisonComponentsCollection[collection_index] = collision_component_to_add;
                    }
                }
            }
        }
        /*
        //Analyser si Collisions
            Update()
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
            FixedUpdate()
            //Repousser les objets au positions de base
            if (_isColliding && (_tablePositionOfCollider >= 0))
            {
                _mapComponent.GetAllObjectsInside()[_tablePositionOfCollider].GetComponent<MovementComponent>().MoveObject(_previousColliderPosX, _previousColliderPosY);
            }
        */
    }
}
