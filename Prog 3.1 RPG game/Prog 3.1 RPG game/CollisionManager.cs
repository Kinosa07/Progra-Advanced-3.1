using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    public class CollisionManager
    {
        private CollisionComponent[] _collisonComponentsCollection = new CollisionComponent[1];
        private int _tablePositionOfCollider;
        private int _tablePositionOfCollidee;
        private bool _isColliding;
        private int _previousColliderPosX;
        private int _previousColliderPosY;
        private MapComponent _supposedPlayerLocation; //modifier quand StateMachine

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
        public void Update(float delta_time)
        {

            for (int internal_table_index = 0; internal_table_index < _collisonComponentsCollection.Length; internal_table_index++)
            {
                CollisionComponent first_collision_component = _collisonComponentsCollection[internal_table_index];
                if (first_collision_component != null)
                {
                    PositionComponent first_position_component = first_collision_component.GetCopyOfPositionComponent();
                    if (first_collision_component.GetCopyOfMovementComponent() != null)
                    {
                        MovementComponent first_movement_component = first_collision_component.GetCopyOfMovementComponent();
                        int first_element_pos_x = first_position_component.GetPositionX();
                        int first_element_pos_y = first_position_component.GetPositionY();

                        for (int internal_table_index_2 = 0; internal_table_index_2 < _collisonComponentsCollection.Length; internal_table_index_2++)
                        {
                            CollisionComponent second_collision_component = _collisonComponentsCollection[internal_table_index_2];

                            if (second_collision_component != null)
                            {
                                PositionComponent second_position_component = second_collision_component.GetCopyOfPositionComponent();
                                if (second_collision_component.GetCopyOfMovementComponent() != null)
                                {
                                    MovementComponent second_movement_component = second_collision_component.GetCopyOfMovementComponent();
                                    int second_element_pos_x = second_position_component.GetPositionX();
                                    int second_element_pos_y = second_position_component.GetPositionY();

                                    if ((first_element_pos_x == second_element_pos_x) && (first_element_pos_y == second_element_pos_y))
                                    {
                                        _isColliding = true;
                                        if (first_movement_component.GetHasMoved())
                                        {
                                            _tablePositionOfCollider = internal_table_index;
                                            _tablePositionOfCollidee = internal_table_index_2;
                                        }
                                        else if (second_movement_component.GetHasMoved())
                                        {
                                            _tablePositionOfCollider = internal_table_index_2;
                                            _tablePositionOfCollidee = internal_table_index;
                                        }
                                    }
                                }

                                else if (second_collision_component.GetCopyOfMovementComponent() == null)
                                {
                                    _isColliding = true;
                                    _tablePositionOfCollider = internal_table_index;
                                }
                            }
                        }
                    }
                }
            }
            //Si Collision, enregistrer previous position Collider
            if (_isColliding && (_tablePositionOfCollider >= 0))
            {
                _previousColliderPosX = _collisonComponentsCollection[_tablePositionOfCollider].GetCopyOfParentGameObject().GetComponent<PositionComponent>().GetPreviousPositionX();
                _previousColliderPosY = _collisonComponentsCollection[_tablePositionOfCollider].GetCopyOfParentGameObject().GetComponent<PositionComponent>().GetPreviousPositionY();
            }
        }
        public void FixedUpdate(float fixed_time_until_update, float delta_time)
        {
            if (delta_time >= fixed_time_until_update)
            {
                //Repousser les objets au positions de base
                if (_isColliding && (_tablePositionOfCollider >= 0) && (_collisonComponentsCollection[_tablePositionOfCollider].GetCopyOfParentGameObject().GetComponent<MapComponent>() == null))
                {
                    _collisonComponentsCollection[_tablePositionOfCollider].GetCopyOfParentGameObject().GetComponent<MovementComponent>().MoveObject(_previousColliderPosX, _previousColliderPosY);
                }

                else if (_isColliding && (_tablePositionOfCollider >= 0) && (_collisonComponentsCollection[_tablePositionOfCollider].GetCopyOfParentGameObject().GetComponent<MapComponent>() != null))
                {
                    _supposedPlayerLocation = _collisonComponentsCollection[_tablePositionOfCollider].GetCopyOfParentGameObject().GetComponent<MapComponent>();
                }
            }
        }
    }
}
