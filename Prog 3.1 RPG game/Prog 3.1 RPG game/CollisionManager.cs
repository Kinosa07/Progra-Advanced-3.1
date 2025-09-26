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
        private int _tablePositionOfCollider;
        private int _tablePositionOfCollidee;
        private bool _isColliding;
        private int _previousColliderPosX;
        private int _previousColliderPosY;

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
        
        //Analyser si Collisions
        private void Update()
        {

            for (int internal_table_index = 0; internal_table_index < _collisonComponentsCollection.Length; internal_table_index++)
            {
                for (int internal_table_index_2 = 0; internal_table_index_2 < _collisonComponentsCollection.Length; internal_table_index_2++)
                {
                    _tablePositionOfCollider = internal_table_index;
                    if (_collisonComponentsCollection[internal_table_index].GetPositionComponent().GetPositionX() == _collisonComponentsCollection[internal_table_index].GetPositionComponent().GetPositionX())
                    {
                        _isColliding = true;
                        if (_collisonComponentsCollection[internal_table_index].GetParentGameObject().GetComponent<MovementComponent>().GetHasMoved())
                        {
                            _tablePositionOfCollider = internal_table_index;
                            _tablePositionOfCollidee = internal_table_index_2;
                        }
                        else if (_collisonComponentsCollection[internal_table_index_2].GetParentGameObject().GetComponent<MovementComponent>().GetHasMoved())
                        {
                            _tablePositionOfCollider = internal_table_index_2;
                            _tablePositionOfCollidee = internal_table_index;
                        }
                    }

                    if (_collisonComponentsCollection[internal_table_index].GetPositionComponent().GetPositionY() == _collisonComponentsCollection[internal_table_index].GetPositionComponent().GetPositionY())
                    {
                        _isColliding = true;
                    }
                }
            }
            //Si Collision, enregistrer previous position Collider
            if (_isColliding && (_tablePositionOfCollider >= 0))
            {
                _previousColliderPosX = _collisonComponentsCollection[_tablePositionOfCollider].GetParentGameObject().GetComponent<PositionComponent>().GetPreviousPositionX();
                _previousColliderPosY = _collisonComponentsCollection[_tablePositionOfCollider].GetParentGameObject().GetComponent<PositionComponent>().GetPreviousPositionY();
            }
        }
        private void FixedUpdate()
        { 
            //Repousser les objets au positions de base
            if (_isColliding && (_tablePositionOfCollider >= 0) && (_collisonComponentsCollection[_tablePositionOfCollider].GetParentGameObject().GetComponent<MapComponent>() == null))
            {
                _collisonComponentsCollection[_tablePositionOfCollider].GetParentGameObject().GetComponent<MovementComponent>().MoveObject(_previousColliderPosX, _previousColliderPosY);
            }

            else if (_isColliding && (_tablePositionOfCollider >= 0) && (_collisonComponentsCollection[_tablePositionOfCollider].GetParentGameObject().GetComponent<MapComponent>() != null))
            {
                //Enter new map
            }
        }
    }
}
