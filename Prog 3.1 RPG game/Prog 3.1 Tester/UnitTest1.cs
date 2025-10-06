using Prog_3._1_RPG_game;
using Prog_3._1_RPG_game.Components;
using Prog_3._1_RPG_game.Events;

namespace Prog_3._1_Tester
{
    public class Tests
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
        public void TestComponents()
        {
            GameObject testerObject = new GameObject();
            PositionComponent testerPosition = new PositionComponent(1, 1, testerObject);
            MovementComponent testerMovement = new MovementComponent(testerPosition, testerObject, new EventManager());

            testerObject.AddComponent(testerPosition);
            testerObject.AddComponent(testerMovement);

            Assert.IsTrue(testerObject.GetComponent<MovementComponent>() == testerMovement);
            Assert.IsTrue(testerMovement.GetCopyOfParentGameObject().GetComponent<PositionComponent>() == testerPosition);
        }

        public bool tester_game_event_changed;

        [Test]
        public void TestEvents()
        {
            EventManager tester_event_manager = new EventManager();

            tester_event_manager.RegisterToEvent<GameEvent>(TestFunction);

            Assert.IsTrue(tester_event_manager._eventTable[typeof(GameEvent)] != null);

            GameEvent tester_game_event = new GameEvent();
            tester_game_event_changed = false;

            tester_event_manager.TriggerEvent(tester_game_event);

            Assert.IsTrue(tester_game_event_changed);

        }

        public void TestFunction(GameEvent gameEvent)
        {
            tester_game_event_changed = true;
        }
    }
}