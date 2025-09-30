using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Prog_3._1_RPG_game
{
    internal class GameEngine
    {
        //élément du GameEngine
        RenderManager _renderManager = new RenderManager();
        CollisionManager _collisionManager = new CollisionManager();
        private float _lastUpdateTime = 0;
        private bool _shouldQuit = false;
        private string _playerInput = "null";
        //Elements du Jeu
        private Stopwatch _stopWatch = new Stopwatch();
        GameObject _player = new GameObject();
        GameObject _worldMap = new GameObject();
        GameObject _townMap = new GameObject();
        GameObject _shop = new GameObject();
        GameObject _currentLocation = new GameObject();
        public void Run()
        {
            _player = CreatePlayer(1, 1);
            _worldMap = CreateWorld(20, 15);
            _townMap = CreateCity(10, 7, 1, 2, _worldMap.GetComponent<MapComponent>());
            _shop = CreateShop(5, 5, 3, 5, _townMap.GetComponent<MapComponent>());

            while (!_shouldQuit)
            {
                ReadInput();
                Update(_lastUpdateTime);
                FixedUpdate(1.0f);
                Render();
                Thread.Sleep(1000 / 10);
            }
        }

        public void Render()
        {
            _renderManager.Render(_currentLocation.GetComponent<MapComponent>());
        }

        public void Update(float time_since_last_update)
        {
            _lastUpdateTime = _stopWatch.ElapsedMilliseconds;
            _player.Update(time_since_last_update);
            _collisionManager.Update();
        }

        public void FixedUpdate(float fixed_time_until_update)
        {
            if (fixed_time_until_update <= _lastUpdateTime)
            {
                //Work your magic
                ProcessInput();
                _player.FixedUpdate(_lastUpdateTime);
                _collisionManager.Update();
            }
        }

        private void ReadInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    _playerInput = "up";
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    _playerInput = "down";
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    _playerInput = "left";
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    _playerInput = "right";
                }

                if (key.Key == ConsoleKey.Escape)
                {

                    _playerInput = "Escape";
                }
            }
        }

        public void ProcessInput()
        {
            if (_playerInput == "up")
            {
                //Move Up
                _player.GetComponent<MovementComponent>().MoveObject(_player.GetComponent<PositionComponent>().GetPositionX(), _player.GetComponent<PositionComponent>().GetPositionY() - 1);
            }

            if (_playerInput == "down")
            {
                //Move Down
                _player.GetComponent<MovementComponent>().MoveObject(_player.GetComponent<PositionComponent>().GetPositionX(), _player.GetComponent<PositionComponent>().GetPositionY() + 1);
            }

            if (_playerInput == "left")
            {
                //Move Left
                _player.GetComponent<MovementComponent>().MoveObject(_player.GetComponent<PositionComponent>().GetPositionX() - 1, _player.GetComponent<PositionComponent>().GetPositionY());
            }

            if (_playerInput == "right")
            {
                //Move Right
                _player.GetComponent<MovementComponent>().MoveObject(_player.GetComponent<PositionComponent>().GetPositionX() + 1, _player.GetComponent<PositionComponent>().GetPositionY());
            }

            if (_playerInput == "escape")
            {
                //Quitting
                _shouldQuit = true;
            }
        }

        private GameObject CreatePlayer(int starting_x_pos, int starting_y_pos)
        {
            GameObject player = new GameObject();
            PositionComponent player_pos_comp = new PositionComponent(starting_x_pos, starting_y_pos, player);
            MovementComponent player_move_comp = new MovementComponent(player_pos_comp, player);
            RenderComponent player_render = new RenderComponent(_renderManager, player_pos_comp, "^", "v", "<", ">", player);
            CollisionComponent player_collision = new CollisionComponent(player_pos_comp, player);

            player.AddComponent(player_pos_comp);
            player.AddComponent(player_move_comp);
            player.AddComponent(player_render);
            player.AddComponent(player_collision);

            return player;
        }

        private GameObject CreateWorld(int x_size, int y_size)
        {
            GameObject location = new GameObject();
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location);

            location.AddComponent(location_map_component);

            return location;
        }
        private GameObject CreateCity(int x_size, int y_size, int x_exit_position, int y_exit_position, MapComponent exit_map)
        {
            GameObject location = new GameObject();
            GameObject location_exit = new GameObject();
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location);
            PositionComponent location_exit_position = new PositionComponent(x_exit_position, y_exit_position, location_exit);
            CollisionComponent location_exit_collision = new CollisionComponent(location_exit_position, location_exit);
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
        private GameObject CreateShop(int x_size, int y_size, int x_exit_position, int y_exit_position, MapComponent exit_map)
        {
            GameObject location = new GameObject();
            GameObject location_exit = new GameObject();
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location);
            InventoryComponent shop_inventory = new InventoryComponent(300, 4, location);
            PositionComponent location_exit_position = new PositionComponent(x_exit_position, y_exit_position, location_exit);
            CollisionComponent location_exit_collision = new CollisionComponent(location_exit_position, location_exit);
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
