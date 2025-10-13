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
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void SwitchingStates()
        {
            RenderManager tester_render_manager = new RenderManager();
            CollisionManager tester_collision_manager = new CollisionManager();
            EventManager tester_event_manager = new EventManager();
            GameObject tester_world_map = new GameObject("WorldMap");
            MapComponent tester_world_map_component = new MapComponent(tester_render_manager, 10, 10, tester_world_map, tester_collision_manager);
            ExploringWorldState tester_world_state = new ExploringWorldState(tester_world_map_component,tester_render_manager,tester_collision_manager, tester_event_manager);

            GameObject tester_city_map = new GameObject("City");
            MapComponent tester_city_map_component = new MapComponent(tester_render_manager, 10, 5, tester_city_map, tester_collision_manager);
            ExploringCityState tester_city_state = new ExploringCityState(tester_render_manager, tester_collision_manager, tester_city_map_component, new GameObject("plauyer"));


            GameObject player = new GameObject("Player");
            StateMachine testerStateMachine = new StateMachine(tester_world_state, player);

            Assert.IsTrue(tester_world_state.GetIsInState());

            testerStateMachine.ChangeState(tester_city_state);

            Assert.IsFalse(tester_world_state.GetIsInState());
        }
    }
}