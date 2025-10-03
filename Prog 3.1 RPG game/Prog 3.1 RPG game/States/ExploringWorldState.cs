using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.States
{
    internal class ExploringWorldState : IState
    {
        //Logic "Components"
        private MapComponent _worldMap;
        private RenderManager _renderManager;
        private CollisionManager _collisionManager;
        private EventManager _eventManager;

        //Objects present in State
        private GameObject _player;

        //Stuff that you're meant to do
        //Walk around (Except through walls)
        //See the map (See Render Function)
        //Enter Cities

        public ExploringWorldState(MapComponent world_map, RenderManager render_manager, CollisionManager collision_manager, EventManager event_manager)
        {
            _worldMap = world_map;
            _renderManager = render_manager;
            _collisionManager = collision_manager;
            _eventManager = event_manager;
        }

        public void Enter(GameObject player_object)
        {
            _player = player_object;
        }

        public void Exit()
        {

        }

        public void Update(float delta_time)
        {
            _renderManager.Update(delta_time);
            _collisionManager.Update(delta_time);
        }

        public void FixedUpdate(float fixed_time_until_update, float delta_time)
        {
            _renderManager.FixedUpdate(fixed_time_until_update, delta_time);
            _collisionManager.FixedUpdate(fixed_time_until_update, delta_time);
        }

        public void Render()
        {
            _renderManager.Render(_worldMap);
        }
    }
}
