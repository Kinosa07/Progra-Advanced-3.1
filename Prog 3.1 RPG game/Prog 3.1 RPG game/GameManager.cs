using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    internal class GameManager
    {
        //Composants du jeu
        GameObject _player = new GameObject();
        GameObject _worldMap = new GameObject();
        GameObject _townMap = new GameObject();
        GameObject _shop = new GameObject();
        GameObject _currentLocation = new GameObject();
        //Composants logique du jeu
        RenderManager _renderManager = new RenderManager();
        CollisionManager _collisionManager = new CollisionManager();
        EventManager _eventManager = new EventManager();


        public void Placeholder()
        { 
            _player = CreatePlayer(1, 1);
            _worldMap = CreateWorld(20, 15);
            _townMap = CreateCity(10, 7, 1, 2, _worldMap.GetComponent<MapComponent>());
            _shop = CreateShop(5, 5, 3, 5, _townMap.GetComponent<MapComponent>());
        }

        private GameObject CreatePlayer(int starting_x_pos, int starting_y_pos, CollisionManager collision_manager)
        {
            GameObject player = new GameObject();
            PositionComponent player_pos_comp = new PositionComponent(starting_x_pos, starting_y_pos, player);
            MovementComponent player_move_comp = new MovementComponent(player_pos_comp, player, _eventManager);
            RenderComponent player_render = new RenderComponent(_renderManager, player_pos_comp, "^", "v", "<", ">", player);
            CollisionComponent player_collision = new CollisionComponent(player_pos_comp, player, collision_manager);
            InputComponent player_input = new InputComponent(player, _eventManager);

            player.AddComponent(player_pos_comp);
            player.AddComponent(player_move_comp);
            player.AddComponent(player_render);
            player.AddComponent(player_collision);
            player.AddComponent(player_input);

            return player;
        }

        public void Render()
        {
            _renderManager.Render(_currentLocation.GetComponent<MapComponent>());
        }

        public void Update(float time_since_last_update)
        {
            _player.Update(time_since_last_update);
            _collisionManager.Update(time_since_last_update);
        }

        public void FixedUpdate(float fixed_time_until_new_update, float time_since_last_update)
        {
            _renderManager.FixedUpdate(fixed_time_until_new_update, time_since_last_update);
            _collisionManager.FixedUpdate(fixed_time_until_new_update, time_since_last_update);
            _player.FixedUpdate(time_since_last_update, time_since_last_update); 
        }

        private GameObject CreateWorld(int x_size, int y_size, CollisionManager collision_manager)
        {
            GameObject location = new GameObject();
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location, collision_manager);

            location.AddComponent(location_map_component);

            return location;
        }
        private GameObject CreateCity(int x_size, int y_size, int x_exit_position, int y_exit_position, MapComponent exit_map, CollisionManager collision_manager)
        {
            GameObject location = new GameObject();
            GameObject location_exit = new GameObject();
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location, collision_manager);
            PositionComponent location_exit_position = new PositionComponent(x_exit_position, y_exit_position, location_exit);
            CollisionComponent location_exit_collision = new CollisionComponent(location_exit_position, location_exit, collision_manager);
            RenderComponent location_exit_render = new RenderComponent(_renderManager, location_exit_position, "O", location_exit);
            MapComponent location_exit_new_map = exit_map;

            location.AddComponent(location_map_component);
            location_exit.AddComponent(location_exit_position);
            location_exit.AddComponent(location_exit_collision);
            location_exit.AddComponent(location_exit_new_map);
            location_exit.AddComponent(location_exit_render);

            location.GetComponent<MapComponent>().AddMapElement(location_exit);

            return location;
        }
        private GameObject CreateShop(int x_size, int y_size, int x_exit_position, int y_exit_position, MapComponent exit_map, CollisionManager collision_manager)
        {
            GameObject location = new GameObject();
            GameObject location_exit = new GameObject();
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location, collision_manager);
            InventoryComponent shop_inventory = new InventoryComponent(300, 4, location);
            PositionComponent location_exit_position = new PositionComponent(x_exit_position, y_exit_position, location_exit);
            CollisionComponent location_exit_collision = new CollisionComponent(location_exit_position, location_exit, collision_manager);
            RenderComponent location_exit_render = new RenderComponent(_renderManager, location_exit_position, "O", location_exit);
            MapComponent location_exit_new_map = exit_map;

            location.AddComponent(location_map_component);
            location.AddComponent(shop_inventory);
            location_exit.AddComponent(location_exit_position);
            location_exit.AddComponent(location_exit_collision);
            location_exit.AddComponent(location_exit_new_map);
            location_exit.AddComponent(location_exit_render);

            location.GetComponent<MapComponent>().AddMapElement(location_exit);

            return location;
        }
    }
}
