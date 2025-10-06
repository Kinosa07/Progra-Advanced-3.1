using Prog_3._1_RPG_game;
using Prog_3._1_RPG_game.Components;

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

        [Test]
        public void TestEvents()
        {

        }
    }
}