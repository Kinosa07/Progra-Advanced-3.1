using Prog_3._1_RPG_game.Components;
using Prog_3._1_RPG_game.States;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    public class GameManager
    {
        //Composants du jeu
        GameObject[] _gameObjectTable = new GameObject[10];
        GameObject _player = new GameObject("");
        GameObject _worldMap = new GameObject("");
        GameObject _townMap = new GameObject("");
        GameObject _shop = new GameObject("");
        GameObject _currentLocation = new GameObject("");
        GameObject _inputManager = new GameObject("");
        //Composants logique du jeu
        RenderManager _renderManager = new RenderManager();
        CollisionManager _collisionManager = new CollisionManager();
        EventManager _eventManager = new EventManager();
        StateMachine _stateMachine;


        public GameManager()
        {
            _player = CreatePlayer(1, 1, _collisionManager);
            _worldMap = CreateWorld(20, 15, _collisionManager);

            InputComponent player_input = new InputComponent(_inputManager, _eventManager);

            _currentLocation = new(_worldMap);
            _stateMachine = new StateMachine(new ExploringState(_inputManager.GetComponent<InputComponent>(), _eventManager));

            AddToObjectCollection(_player);
            AddToObjectCollection(_currentLocation);
        }

        public void Render()
        {
            _renderManager.Render(_currentLocation.GetComponent<MapComponent>());
        }

        public void Update(float time_since_last_update)
        {
            _inputManager.GetComponent<InputComponent>().ReadInput();
            for (int game_objects_index = 0; game_objects_index < _gameObjectTable.Length; game_objects_index++)
            {
                if (_gameObjectTable[game_objects_index] != null)
                {
                    _gameObjectTable[game_objects_index].Update(time_since_last_update);
                }
            }
            _stateMachine.Update(time_since_last_update);
            _collisionManager.Update(time_since_last_update);
            _renderManager.Update(time_since_last_update);
        }

        public void FixedUpdate(float fixed_time_until_new_update)
        {
            _inputManager.FixedUpdate(fixed_time_until_new_update);
            for (int game_objects_index = 0; game_objects_index < _gameObjectTable.Length; game_objects_index++)
            {
                if (_gameObjectTable[game_objects_index] != null)
                {
                    _gameObjectTable[game_objects_index].FixedUpdate(fixed_time_until_new_update);
                }
            }
            _collisionManager.FixedUpdate(fixed_time_until_new_update);
            _renderManager.FixedUpdate(fixed_time_until_new_update);
        }

        public void AddToObjectCollection(GameObject object_to_add)
        {
            //Check if empty spot
            bool is_table_full = true;
            int free_table_slot = -1;
            for (int game_objects_table_index = 0; game_objects_table_index < _gameObjectTable.Length; game_objects_table_index++)
            {
                if (_gameObjectTable[game_objects_table_index] == null)
                {
                    is_table_full = false;
                    free_table_slot = game_objects_table_index;
                    break;
                }
            }
            //Ajouter taille si plus d'empty slots
            if (is_table_full)
            {
                GameObject[] temporary_table = new GameObject[_gameObjectTable.Length + 5];
                for (int temporary_table_index = 0; temporary_table_index < _gameObjectTable.Length; temporary_table_index++)
                {
                    temporary_table[temporary_table_index] = _gameObjectTable[temporary_table_index];
                }
                _gameObjectTable = temporary_table;
                is_table_full = false;
                free_table_slot = _gameObjectTable.Length - 5;
            }
            //Ajouter object au tableau
            if (!is_table_full)
            {
                _gameObjectTable[free_table_slot] = object_to_add;
            }
        }

        public void RemoveObjectFromCollection(GameObject object_to_remove)
        {
            //Check si l'objet existe
            bool exists_in_table = false;
            int object_position_in_table = -1;
            int empty_slots = 0;
            for (int game_objects_table_index = 0; game_objects_table_index < _gameObjectTable.Length; game_objects_table_index++)
            {
                if (_gameObjectTable[game_objects_table_index] == object_to_remove)
                {
                    exists_in_table = true;
                    object_position_in_table = game_objects_table_index;
                    break;
                }
            }
            //retirer object du tableau
            if (exists_in_table)
            {
                _gameObjectTable[object_position_in_table] = null;

                for (int temporary_table_index = 0; temporary_table_index < _gameObjectTable.Length; temporary_table_index++)
                {
                    if (temporary_table_index + 1 < _gameObjectTable.Length)
                    {
                        if ((_gameObjectTable[temporary_table_index] == null) && (_gameObjectTable[temporary_table_index + 1] != null))
                        {
                            _gameObjectTable[temporary_table_index] = _gameObjectTable[temporary_table_index + 1];
                        }
                        else if ((_gameObjectTable[temporary_table_index] == null) && (_gameObjectTable[temporary_table_index + 1] == null))
                        {
                            empty_slots += 1;
                        }
                    }
                }
            }
            else if (!exists_in_table)
            {

            }

            if (empty_slots >= 10)
            {
                //Réduire taille si plus d'empty slots
                GameObject[] temporary_table = new GameObject[_gameObjectTable.Length - 9];
                for (int temporary_table_index = 0; temporary_table_index < temporary_table.Length; temporary_table_index++)
                {
                    temporary_table[temporary_table_index] = _gameObjectTable[temporary_table_index];
                }

                _gameObjectTable = temporary_table;
                empty_slots = 0;
            }
        }

        private GameObject CreatePlayer(int starting_x_pos, int starting_y_pos, CollisionManager collision_manager)
        {
            GameObject player = new GameObject("player");
            PositionComponent player_pos_comp = new PositionComponent(starting_x_pos, starting_y_pos, player);
            MovementComponent player_move_comp = new MovementComponent(player_pos_comp, player, _eventManager);
            RenderComponent player_render = new RenderComponent(_renderManager, player_pos_comp, "^", "v", "<", ">", player);
            CollisionComponent player_collision = new CollisionComponent(player_pos_comp, player_move_comp, player, collision_manager);

            return player;
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
