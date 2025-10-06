using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.States
{
    internal class ExploringCityState : IState
    {
        //Que faire dans le City:
        //marcher dans la ville
        //Voir la ville
        //Sortir de la ville
        //Entrer dans les Bâtiments

        //Logic Components
        private RenderManager _renderManager;
        private CollisionManager _collisionManager;

        //Objects in State
        private MapComponent _cityMap;
        private GameObject _player;

        //Variables pour test


        public ExploringCityState(RenderManager render_manager, CollisionManager collision_manager, MapComponent city_map, GameObject player)
        {
            _renderManager = render_manager;
            _collisionManager = collision_manager;
            _cityMap = city_map;
            _player = player;
        }

        public void Enter(GameObject player)
        {
            _player = player;
        }

        public GameObject Exit()
        {
            return _player;
        }

        public void Update(float delta_time)
        {
            _renderManager.Update(delta_time);
            _collisionManager.Update(delta_time);
            _player.Update(delta_time);
        }
    }
}
