using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class MapComponent : Component
    {
        GameObject[] _mapContentsTable = new GameObject[4];
        private GameObject[] _mapBordersTable = new GameObject[1];
        //créer des bordures de map
        private int _mapSizeX;
        private int _mapSizeY;

        public MapComponent(int map_size_x, int map_size_y)
        {
            _mapSizeX = map_size_x;
            _mapSizeY = map_size_y;
            _mapBordersTable = new GameObject[(2 * _mapSizeX) + (2 * _mapSizeY) - 4];

            for (int border_table_index = 0; border_table_index < _mapBordersTable.Length; border_table_index++)
            {
                _mapBordersTable[border_table_index] = new GameObject();
            }

            for (int horizontal_map_size_index = 0; horizontal_map_size_index < _mapSizeX; horizontal_map_size_index++)
            {
                PositionComponent game_object_position_component = new PositionComponent(horizontal_map_size_index, 0);
                CollisionComponent game_object_collision_component = new CollisionComponent(game_object_position_component, this);
                RenderComponent game_object_render_component = new RenderComponent(game_object_position_component, "=");

                _mapBordersTable[horizontal_map_size_index].AddComponent(game_object_position_component);
                _mapBordersTable[horizontal_map_size_index].AddComponent(game_object_collision_component);
                _mapBordersTable[horizontal_map_size_index].AddComponent(game_object_render_component);
            }

            for (int horizontal_map_size_index = 0; horizontal_map_size_index < _mapSizeX; horizontal_map_size_index++)
            {
                PositionComponent game_object_position_component = new PositionComponent(horizontal_map_size_index, _mapSizeY);
                CollisionComponent game_object_collision_component = new CollisionComponent(game_object_position_component, this);
                RenderComponent game_object_render_component = new RenderComponent(game_object_position_component, "=");

                _mapBordersTable[horizontal_map_size_index + _mapSizeX].AddComponent(game_object_position_component);
                _mapBordersTable[horizontal_map_size_index + _mapSizeX].AddComponent(game_object_collision_component);
                _mapBordersTable[horizontal_map_size_index + _mapSizeX].AddComponent(game_object_render_component);
            }


        }

        public override void Update(float time_since_last_update)
        {

        }

        public override void FixedUpdate(float fixed_update_time)
        {

        }

        public GameObject[] GetAllObjectsInside()
        {
            return _mapContentsTable;
        }
    }
}
