using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.States
{
    public class ExploringWorldState : IState
    {
        //Objects present in State
        private GameObject _player;

        //Données test
        private bool _isInState;

        //Stuff that you're meant to do
        //Walk around (Except through walls)
        //See the map (See Render Function)
        //Enter Cities

        public ExploringWorldState(MapComponent world_map, RenderManager render_manager, CollisionManager collision_manager, EventManager event_manager)
        {
            render_manager = new RenderManager();
            collision_manager = new CollisionManager();
            event_manager = new EventManager();
            MapComponent copy_of_world_map = new MapComponent(world_map, collision_manager, render_manager);
            world_map = copy_of_world_map;
        }

        public void Enter(GameObject player_object)
        {
            _player = player_object;
            _isInState = true;
        }

        public GameObject Exit()
        {
            _isInState = false;
            return _player;
        }

        public void Update(float delta_time)
        {
            
        }

        public void FixedUpdate(float fixed_time_until_update, float delta_time)
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
