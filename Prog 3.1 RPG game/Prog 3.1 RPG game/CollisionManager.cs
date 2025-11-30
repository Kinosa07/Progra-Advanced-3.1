using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    public class CollisionManager
    {
        private GameManager _gameManager;
        private CollisionComponent[] _collisonComponentsTable = new CollisionComponent[1];
        private int _tablePositionOfCollider;
        private int _tablePositionOfCollidee;
        private bool _isColliding = false;
        private int _previousColliderPosX;
        private int _previousColliderPosY;
        private MapComponent _supposedPlayerLocation; //modifier quand StateMachine
        private float _ellapsedTime;
        private float _timeSinceLastFixed;

        public CollisionManager(GameManager neighbooring_manager)
        {
            _gameManager = neighbooring_manager;
        }

        public void AddCollisionComponent(CollisionComponent collision_component_to_add)
        {
            //Is table Full
            bool is_table_full = true;
            for (int collection_index = 0; collection_index < _collisonComponentsTable.Length; collection_index++)
            {
                if (_collisonComponentsTable[collection_index] == null)
                {
                    is_table_full = false;
                    break;
                }
            }

            if (is_table_full == true)
            {
                //magic to expand Table
                CollisionComponent[] temporary_table = new CollisionComponent[_collisonComponentsTable.Length + 3];
                for (int collection_index = 0; collection_index < _collisonComponentsTable.Length; collection_index++)
                {
                    temporary_table[collection_index] = _collisonComponentsTable[collection_index];
                }
                _collisonComponentsTable = temporary_table;
                is_table_full = false;
            }

            if (is_table_full == false)
            {
                for (int collection_index = 0; collection_index < _collisonComponentsTable.Length; collection_index++)
                {
                    if (_collisonComponentsTable[collection_index] == null)
                    {
                        _collisonComponentsTable[collection_index] = collision_component_to_add;
                        break;
                    }
                }
            }
        }

        //Analyser si Collisions
        public void Update(float delta_time)
        {
            for (int internal_table_index = 0; internal_table_index < _collisonComponentsTable.Length; internal_table_index++)
            {
                CollisionComponent first_collision_component = _collisonComponentsTable[internal_table_index];
                if (first_collision_component != null)
                {
                    PositionComponent first_position_component = first_collision_component.GetCopyOfPositionComponent();
                    if (first_collision_component.GetCopyOfMovementComponent() != null)
                    {
                        MovementComponent first_movement_component = first_collision_component.GetCopyOfMovementComponent();
                        int first_element_pos_x = first_position_component.GetPositionX();
                        int first_element_pos_y = first_position_component.GetPositionY();

                        for (int internal_table_index_2 = 0; internal_table_index_2 < _collisonComponentsTable.Length; internal_table_index_2++)
                        {
                            if (internal_table_index != internal_table_index_2)
                            {
                                CollisionComponent second_collision_component = _collisonComponentsTable[internal_table_index_2];

                                if (second_collision_component != null)
                                {
                                    PositionComponent second_position_component = second_collision_component.GetCopyOfPositionComponent();
                                    int second_element_pos_x = second_position_component.GetPositionX();
                                    int second_element_pos_y = second_position_component.GetPositionY();

                                    if (second_collision_component.GetCopyOfMovementComponent() != null)
                                    {
                                        MovementComponent second_movement_component = second_collision_component.GetCopyOfMovementComponent();

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
                                        if ((first_element_pos_x == second_element_pos_x) && (first_element_pos_y == second_element_pos_y))
                                        {
                                            _isColliding = true;
                                            _tablePositionOfCollider = internal_table_index;
                                            _tablePositionOfCollidee = internal_table_index_2;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else if (first_collision_component.GetCopyOfMovementComponent() == null)
                    {
                        int first_element_pos_x = first_position_component.GetPositionX();
                        int first_element_pos_y = first_position_component.GetPositionY();

                        for (int internal_table_index_2 = internal_table_index + 1; internal_table_index_2 < _collisonComponentsTable.Length; internal_table_index_2++)
                        {
                            CollisionComponent second_collision_component = _collisonComponentsTable[internal_table_index_2];

                            if (second_collision_component != null)
                            {
                                PositionComponent second_position_component = second_collision_component.GetCopyOfPositionComponent();
                                int second_element_pos_x = second_position_component.GetPositionX();
                                int second_element_pos_y = second_position_component.GetPositionY();

                                if (second_collision_component.GetCopyOfMovementComponent() == null)
                                {
                                    if ((first_element_pos_x == second_element_pos_x) && (first_element_pos_y == second_element_pos_y))
                                    {
                                        //This line of code is to identify in Visual Studio who are the two colliding components (That shouldn't)
                                        first_collision_component = first_collision_component;
                                        second_collision_component = second_collision_component;

                                        //if you reach this, it means two objects without Movement Component are colliding
                                        _isColliding = true;
                                        _tablePositionOfCollider = internal_table_index;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //Si Collision, enregistrer previous position Collider
            if (_isColliding && (_tablePositionOfCollider >= 0))
            {
                _previousColliderPosX = _collisonComponentsTable[_tablePositionOfCollider].GetCopyOfParentGameObject().GetComponent<PositionComponent>().GetPreviousPositionX();
                _previousColliderPosY = _collisonComponentsTable[_tablePositionOfCollider].GetCopyOfParentGameObject().GetComponent<PositionComponent>().GetPreviousPositionY();
            }
            _ellapsedTime = delta_time;
        }
        public void FixedUpdate(float fixed_time_until_update)
        {
            if (_ellapsedTime - _timeSinceLastFixed >= fixed_time_until_update)
            {
                //Repousser les objets au positions de base
                if (_isColliding && (_tablePositionOfCollider >= 0) && (_collisonComponentsTable[_tablePositionOfCollidee].GetCopyOfParentGameObject().GetComponent<MapComponent>() == null))
                {
                    _collisonComponentsTable[_tablePositionOfCollider].GetCopyOfParentGameObject().GetComponent<MovementComponent>().MoveObject(_previousColliderPosX, _previousColliderPosY);
                    _isColliding = false;
                }

                else if (_isColliding && (_tablePositionOfCollider >= 0) && (_collisonComponentsTable[_tablePositionOfCollidee].GetCopyOfParentGameObject().GetComponent<MapComponent>() != null))
                {
                    _gameManager.ChangeLocation(_collisonComponentsTable[_tablePositionOfCollidee].GetCopyOfParentGameObject());
                    _isColliding = false;
                }
                _timeSinceLastFixed = _ellapsedTime;
            }
        }

        public void RecalculateContents(GameObject[] active_elements)
        {
            _collisonComponentsTable = new CollisionComponent[0];

            for (int active_elements_index = 0; active_elements_index < active_elements.Length; active_elements_index++)
            {
                if (active_elements[active_elements_index] != null)
                {
                    if (active_elements[active_elements_index].GetComponent<CollisionComponent>() != null)
                    {
                        AddCollisionComponent(active_elements[active_elements_index].GetComponent<CollisionComponent>());
                    }

                    else if (active_elements[active_elements_index].GetComponent<MapComponent>() != null)
                    {
                        MapComponent current_map_component = active_elements[active_elements_index].GetComponent<MapComponent>();
                        GameObject[] map_contents = current_map_component.GetAllObjectsInside();
                        GameObject[] map_borders = current_map_component.GetMapBordersTable();

                        for (int map_contents_index = 0; map_contents_index < map_contents.Length; map_contents_index++)
                        {
                            if (map_contents[map_contents_index] != null)
                            {
                                if (map_contents[map_contents_index].GetComponent<CollisionComponent>() != null)
                                {
                                    AddCollisionComponent(map_contents[map_contents_index].GetComponent<CollisionComponent>());
                                }
                            }
                        }

                        for (int map_borders_index = 0; map_borders_index < map_borders.Length; map_borders_index++)
                        {
                            if (map_borders[map_borders_index] != null)
                            {
                                if (map_borders[map_borders_index].GetComponent<CollisionComponent>() != null)
                                {
                                    AddCollisionComponent(map_borders[map_borders_index].GetComponent<CollisionComponent>());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
