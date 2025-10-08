using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class MapComponent : Component
    {
        private GameObject[] _mapContentsTable;
        private GameObject[] _mapBordersTable;
        //créer des bordures de map
        private int _mapSizeX;
        private int _mapSizeY;
        private GameObject _parentGameObject;

        public MapComponent(RenderManager game_render_manager, int map_size_x, int map_size_y, GameObject parent, CollisionManager collision_manager)
        {

            _mapContentsTable = new GameObject[4];
            _mapSizeX = map_size_x;
            _mapSizeY = map_size_y;
            _mapBordersTable = new GameObject[(2 * _mapSizeX) + (2 * _mapSizeY - 2)];
            _parentGameObject = parent;
            _parentGameObject.AddComponent(this);

            for (int border_table_index = 0; border_table_index < _mapBordersTable.Length; border_table_index++)
            {
                _mapBordersTable[border_table_index] = new GameObject();
            }

            for (int horizontal_map_size_index = 0; horizontal_map_size_index < _mapSizeX; horizontal_map_size_index++)
            {
                PositionComponent game_object_position_component = new PositionComponent(horizontal_map_size_index, 0, _mapBordersTable[horizontal_map_size_index]);
                CollisionComponent game_object_collision_component = new CollisionComponent(game_object_position_component, _mapBordersTable[horizontal_map_size_index], collision_manager);
                RenderComponent game_object_render_component = new RenderComponent(game_render_manager, game_object_position_component, "=", _mapBordersTable[horizontal_map_size_index]);

                _mapBordersTable[horizontal_map_size_index].AddComponent(game_object_position_component);
                _mapBordersTable[horizontal_map_size_index].AddComponent(game_object_collision_component);
                _mapBordersTable[horizontal_map_size_index].AddComponent(game_object_render_component);
            }

            for (int horizontal_map_size_index = 0; horizontal_map_size_index < _mapSizeX; horizontal_map_size_index++)
            {
                PositionComponent game_object_position_component = new PositionComponent(horizontal_map_size_index, _mapSizeY - 1, _mapBordersTable[horizontal_map_size_index + _mapSizeX]);
                CollisionComponent game_object_collision_component = new CollisionComponent(game_object_position_component, _mapBordersTable[horizontal_map_size_index + _mapSizeX], collision_manager);
                RenderComponent game_object_render_component = new RenderComponent(game_render_manager, game_object_position_component, "=", _mapBordersTable[horizontal_map_size_index + _mapSizeX]);

                _mapBordersTable[horizontal_map_size_index + _mapSizeX].AddComponent(game_object_position_component);
                _mapBordersTable[horizontal_map_size_index + _mapSizeX].AddComponent(game_object_collision_component);
                _mapBordersTable[horizontal_map_size_index + _mapSizeX].AddComponent(game_object_render_component);
            }

            for (int vertical_map_size_index = 0; vertical_map_size_index < _mapSizeY - 2; vertical_map_size_index++)
            {
                PositionComponent game_object_position_component = new PositionComponent(0, vertical_map_size_index + 1, _mapBordersTable[vertical_map_size_index + (2 * _mapSizeX)]);
                CollisionComponent game_object_collision_component = new CollisionComponent(game_object_position_component, _mapBordersTable[vertical_map_size_index + (2 * _mapSizeX)], collision_manager);
                RenderComponent game_object_render_component = new RenderComponent(game_render_manager, game_object_position_component, "|", _mapBordersTable[vertical_map_size_index + (2 * _mapSizeX)]);

                _mapBordersTable[vertical_map_size_index + (2 * _mapSizeX)].AddComponent(game_object_position_component);
                _mapBordersTable[vertical_map_size_index + (2 * _mapSizeX)].AddComponent(game_object_collision_component);
                _mapBordersTable[vertical_map_size_index + (2 * _mapSizeX)].AddComponent(game_object_render_component);
            }

            for (int vertical_map_size_index = 0; vertical_map_size_index < _mapSizeY - 2; vertical_map_size_index++)
            {
                PositionComponent game_object_position_component = new PositionComponent(_mapSizeX - 1, vertical_map_size_index + 1, _mapBordersTable[vertical_map_size_index + ((2 * _mapSizeX) + _mapSizeY)]);
                CollisionComponent game_object_collision_component = new CollisionComponent(game_object_position_component, _mapBordersTable[vertical_map_size_index + ((2 * _mapSizeX) + _mapSizeY)], collision_manager);
                RenderComponent game_object_render_component = new RenderComponent(game_render_manager, game_object_position_component, "|", _mapBordersTable[vertical_map_size_index + ((2 * _mapSizeX) + _mapSizeY)]);

                _mapBordersTable[vertical_map_size_index + ((2 * _mapSizeX) + _mapSizeY) - 2].AddComponent(game_object_position_component);
                _mapBordersTable[vertical_map_size_index + ((2 * _mapSizeX) + _mapSizeY) - 2].AddComponent(game_object_collision_component);
                _mapBordersTable[vertical_map_size_index + ((2 * _mapSizeX) + _mapSizeY) - 2].AddComponent(game_object_render_component);
            }
        }

        public override void Update(float time_since_last_update)
        {

        }

        public override void FixedUpdate(float fixed_update_time, float time_since_last_update)
        {

        }
        public override GameObject GetCopyOfParentGameObject()
        {
            GameObject copy_of_parent = new GameObject(_parentGameObject);
            return copy_of_parent;
        }

        public GameObject[] GetAllObjectsInside()
        {
            GameObject[] copy_of_map_contents = _mapContentsTable; 
            return copy_of_map_contents;
        }

        public int GetSizeX()
        {
            return _mapSizeX;
        }

        public int GetSizeY()
        {
            return _mapSizeY;
        }

        public void AddMapElement(GameObject element_to_add)
        {
            //Is table Full
            bool is_table_full = true;
            for (int collection_index = 0; collection_index < _mapContentsTable.Length; collection_index++)
            {
                if (_mapContentsTable[collection_index] == null)
                {
                    is_table_full = false;
                    break;
                }
            }

            if (is_table_full == true)
            {
                //magic to expand Table
                GameObject[] temporary_table = new GameObject[_mapContentsTable.Length + 3];
                for (int collection_index = 0; collection_index < _mapContentsTable.Length; collection_index++)
                {
                    temporary_table[collection_index] = _mapContentsTable[collection_index];
                }
                _mapContentsTable = temporary_table;
                is_table_full = false;
            }

            if (is_table_full == false)
            {
                for (int collection_index = 0; collection_index < _mapContentsTable.Length; collection_index++)
                {
                    if (_mapContentsTable[collection_index] == null)
                    {
                        _mapContentsTable[collection_index] = element_to_add;
                    }
                }
            }
        }
    }
}
