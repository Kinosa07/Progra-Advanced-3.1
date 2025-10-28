using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.States
{
    public class ExploringCityState : IState
    {
        //Que faire dans le City:
        //marcher dans la ville
        //Voir la ville
        //Sortir de la ville
        //Entrer dans les Bâtiments

        //Objects in State
        private MapComponent _cityMap;
        private GameObject _player;

        //Variables pour test
        bool _isInState;

        public ExploringCityState(RenderManager render_manager, CollisionManager collision_manager, MapComponent city_map)
        {
            render_manager = new RenderManager();
            collision_manager = new CollisionManager();
            MapComponent copy_of_world_map = new MapComponent(city_map, collision_manager, render_manager);
            city_map = copy_of_world_map;
        }

        public void Enter()
        {
            _isInState = true;
        }

        public void Exit()
        {
            _isInState = false;
        }

        public void Update(float delta_time)
        {
            
        }

        public void FixedUpdate(float fixed_time_until_update)
        {
            
        }

        public void Render()
        {
            
        }

        //fonction pour test Unitaires
        public bool GetIsInState()
        {
            return _isInState;
        }
    }
}
