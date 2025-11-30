using Prog_3._1_RPG_game;
using Prog_3._1_RPG_game.Components;
using Prog_3._1_RPG_game.Events;
using Prog_3._1_RPG_game.States;

namespace Prog_3._1_Tester
{
    public class StateTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SwitchingStates()
        {
            RenderManager tester_render_manager = new RenderManager();
            CollisionManager tester_collision_manager = new CollisionManager();
            EventManager tester_event_manager = new EventManager();
            GameObject tester_world_map = new GameObject("WorldMap");
            MapComponent tester_world_map_component = new MapComponent(tester_render_manager, 10, 10, tester_world_map, tester_collision_manager);
            ExploringState tester_world_state = new ExploringState(tester_world_map_component,tester_render_manager,tester_collision_manager, tester_event_manager);

            GameObject tester_city_map = new GameObject("City");
            MapComponent tester_city_map_component = new MapComponent(tester_render_manager, 10, 5, tester_city_map, tester_collision_manager);
            InventoryState tester_city_state = new MenuState(tester_render_manager, tester_collision_manager, tester_city_map_component, new GameObject("currentlocation"));


            GameObject player = new GameObject("Player");
            StateMachine testerStateMachine = new StateMachine(tester_world_state, player);

            Assert.IsTrue(tester_world_state.GetIsInState());

            testerStateMachine.ChangeState(tester_city_state);

            Assert.IsFalse(tester_world_state.GetIsInState());
        }

        [Test]
        public void StateContentSwitched()
        {
            RenderManager tester_render_manager = new RenderManager();
            CollisionManager tester_collision_manager = new CollisionManager();
            EventManager tester_event_manager = new EventManager();
            GameObject tester_world_map = new GameObject("WorldMap");
            MapComponent tester_world_map_component = new MapComponent(tester_render_manager, 10, 10, tester_world_map, tester_collision_manager);
            GameObject tester_current_location = new GameObject(tester_world_map);

            GameObject tester_city_map = new GameObject("City");
            MapComponent tester_city_map_component = new MapComponent(tester_render_manager, 10, 5, tester_city_map, tester_collision_manager);

            GameObject player = new GameObject("Player");
            StateMachine testerStateMachine = new StateMachine(new ExploringState(tester_world_map_component, tester_render_manager, tester_collision_manager, tester_event_manager), player);

            Assert.IsTrue(tester_current_location.GetComponent<MapComponent>() == tester_world_map_component);

            testerStateMachine.ChangeState(new MenuState(tester_render_manager, tester_collision_manager, tester_city_map_component, tester_current_location));

            Assert.IsTrue(tester_current_location.GetComponent<MapComponent>() != tester_world_map_component);
        }
    }
}