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
        private bool _shouldQuit = false;
        private Stopwatch _stopWatch = new Stopwatch();
        private float _lastUpdateTime = 0;
        GameObject _player = new GameObject();
        GameObject _worldMap = new GameObject();
        GameObject _townMap = new GameObject();
        GameObject _shop = new GameObject();
        GameObject _currentLocation = new GameObject();
        RenderManager _renderManager = new RenderManager();
        public void Run()
        {
            _player = CreatePlayer(1, 1);
            _worldMap = CreateWorld(10, 7);

            while (!_shouldQuit)
            {
                ProcessInput();
                Update(_lastUpdateTime);
                FixedUpdate(1.0f);
                Render();
                Thread.Sleep(1000 / 10);
            }
        }

        public void Render()
        {
            _renderManager.Render(_worldMap.GetComponent<MapComponent>());
        }

        public void Update(float time_since_last_update)
        {
            _lastUpdateTime = _stopWatch.ElapsedMilliseconds;
            _player.Update(time_since_last_update);
        }

        public void FixedUpdate(float fixed_time_until_update)
        {
            if (fixed_time_until_update <= _lastUpdateTime)
            {
                //Work your magic
                _player.FixedUpdate(_lastUpdateTime);
            }
        }

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    //Move Up
                    _player.GetComponent<MovementComponent>().MoveObject(_player.GetComponent<PositionComponent>().GetPositionX(), _player.GetComponent<PositionComponent>().GetPositionY() - 1);
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    //Move Down
                    _player.GetComponent<MovementComponent>().MoveObject(_player.GetComponent<PositionComponent>().GetPositionX(), _player.GetComponent<PositionComponent>().GetPositionY() + 1);
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    //Move Left
                    _player.GetComponent<MovementComponent>().MoveObject(_player.GetComponent<PositionComponent>().GetPositionX() - 1, _player.GetComponent<PositionComponent>().GetPositionY());
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    //Move Right
                    _player.GetComponent<MovementComponent>().MoveObject(_player.GetComponent<PositionComponent>().GetPositionX() + 1, _player.GetComponent<PositionComponent>().GetPositionY());
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    _shouldQuit = true;
                }
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
        private GameObject CreateCity(int x_size, int y_size, int x_exit_position, int y_exit_position)
        {
            GameObject location = new GameObject();
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location);

            location.AddComponent(location_map_component);

            return location;
        }
        private GameObject CreateShop(int x_size, int y_size)
        {
            GameObject location = new GameObject();
            MapComponent location_map_component = new MapComponent(_renderManager, x_size, y_size, location);

            location.AddComponent(location_map_component);

            return location;
        }
    }
}
