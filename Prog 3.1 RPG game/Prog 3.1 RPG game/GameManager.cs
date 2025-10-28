using Prog_3._1_RPG_game.Components;
using Prog_3._1_RPG_game.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    public class GameManager
    {
        //Composants du jeu
        GameObject _player = new GameObject("");
        GameObject _worldMap = new GameObject("");
        GameObject _townMap = new GameObject("");
        GameObject _shop = new GameObject("");
        GameObject _currentLocation = new GameObject("");
        //Composants logique du jeu
        RenderManager _renderManager = new RenderManager();
        CollisionManager _collisionManager = new CollisionManager();
        EventManager _eventManager = new EventManager();
        StateMachine _stateMachine;


        public GameManager()
        {
            _player = CreatePlayer(1, 1, _collisionManager);
            _worldMap = CreateWorld(20, 15, _collisionManager);

            _currentLocation = _worldMap;
            _stateMachine = new StateMachine(new ExploringWorldState(_worldMap.GetComponent<MapComponent>(),_renderManager,_collisionManager, _eventManager), _player);
        }

        private GameObject CreatePlayer(int starting_x_pos, int starting_y_pos, CollisionManager collision_manager)
        {
            GameObject player = new GameObject("player");
            PositionComponent player_pos_comp = new PositionComponent(starting_x_pos, starting_y_pos, player);
            MovementComponent player_move_comp = new MovementComponent(player_pos_comp, player, _eventManager);
            RenderComponent player_render = new RenderComponent(_renderManager, player_pos_comp, "^", "v", "<", ">", player);
            CollisionComponent player_collision = new CollisionComponent(player_pos_comp, player_move_comp, player, collision_manager);
            InputComponent player_input = new InputComponent(player, _eventManager);

            return player;
        }

        public void Render()
        {
            _stateMachine.Render();
        }

        public void Update(float time_since_last_update)
        {
            _stateMachine.Update(time_since_last_update);
        }

        public void FixedUpdate(float fixed_time_until_new_update, float time_since_last_update)
        {
            _stateMachine.FixedUpdate(fixed_time_until_new_update, time_since_last_update);
        }

        private GameObject CreateWorld(int x_size, int y_size, CollisionManager collision_manager)
        {
            GameObject location = new GameObject("world");
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location, collision_manager);

            return location;
        }
        private GameObject CreateCity(int x_size, int y_size, int x_exit_position, int y_exit_position, MapComponent exit_map, CollisionManager collision_manager)
        {
            GameObject location = new GameObject("City");
            GameObject location_exit = new GameObject("Exit");
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location, collision_manager);
            PositionComponent location_exit_position = new PositionComponent(x_exit_position, y_exit_position, location_exit);
            CollisionComponent location_exit_collision = new CollisionComponent(location_exit_position, location_exit, collision_manager);
            RenderComponent location_exit_render = new RenderComponent(_renderManager, location_exit_position, "O", location_exit);
            MapComponent location_exit_new_map = exit_map;

            location.GetComponent<MapComponent>().AddMapElement(location_exit);

            return location;
        }
        private GameObject CreateShop(int x_size, int y_size, int x_exit_position, int y_exit_position, MapComponent exit_map, CollisionManager collision_manager)
        {
            GameObject location = new GameObject("Shop");
            GameObject location_exit = new GameObject("Exit");
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location, collision_manager);
            InventoryComponent shop_inventory = new InventoryComponent(300, 4, location);
            PositionComponent location_exit_position = new PositionComponent(x_exit_position, y_exit_position, location_exit);
            CollisionComponent location_exit_collision = new CollisionComponent(location_exit_position, location_exit, collision_manager);
            RenderComponent location_exit_render = new RenderComponent(_renderManager, location_exit_position, "O", location_exit);
            MapComponent location_exit_new_map = exit_map;

            location.GetComponent<MapComponent>().AddMapElement(location_exit);

            return location;
        }
    }
}
