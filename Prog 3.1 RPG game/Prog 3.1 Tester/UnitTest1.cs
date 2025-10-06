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

            Assert.IsTrue(tester_event_manager.GetCopyEventTable()[typeof(GameEvent)] != null);

            GameEvent tester_game_event = new GameEvent();
            tester_game_event_changed = false;

            tester_event_manager.TriggerEvent(tester_game_event);

            Assert.IsTrue(tester_game_event_changed);

        }

        public void TestFunction(GameEvent gameEvent)
        {
            tester_game_event_changed = true;
        }

        [Test]
        public void InputMovementTest()
        {
            EventManager tester_event_manager = new EventManager();

            GameObject tester_object = new GameObject();
            PositionComponent tester_position = new PositionComponent(1, 1, tester_object);
            MovementComponent tester_movement = new MovementComponent(tester_position, tester_object, tester_event_manager);

            //Assert.IsTrue(tester_event_manager._eventTable.ContainsKey(typeof(KeyPressedEvent)));

            tester_event_manager.TriggerEvent(new KeyPressedEvent(ConsoleKey.DownArrow));

            Assert.IsTrue(tester_movement.GetHasMoved());
            Assert.IsTrue(tester_position.GetPositionY() == 2);
        }

        [Test]
        public void CollisionTest()
        {
            CollisionManager tester_collision_manager = new CollisionManager();

            GameObject tester_object_one = new GameObject();
            PositionComponent object_one_position = new PositionComponent(1,1, tester_object_one);
            MovementComponent object_one_movement = new MovementComponent(object_one_position, tester_object_one, new EventManager());
            CollisionComponent object_one_collision = new CollisionComponent(object_one_position, tester_object_one, tester_collision_manager);

            GameObject tester_object_two = new GameObject();
            PositionComponent object_two_position = new PositionComponent(1,2, tester_object_two);
            MovementComponent object_two_movement = new MovementComponent(object_two_position, tester_object_two, new EventManager());
            CollisionComponent object_two_collision = new CollisionComponent(object_two_position, tester_object_two, tester_collision_manager);

            object_one_movement.MoveObject(object_one_position.GetPositionX(), object_one_position.GetPositionY() + 1);
            tester_collision_manager.Update(1.0f);

            Assert.IsTrue(object_one_position.GetPositionY() == object_two_position.GetPositionY());
        }
    }
}