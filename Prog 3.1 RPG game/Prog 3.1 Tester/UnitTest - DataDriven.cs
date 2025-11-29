using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using Prog_3._1_RPG_game;
using Prog_3._1_RPG_game.Components;
using Prog_3._1_RPG_game.Events;

namespace Prog_3._1_Tester
{
    public class DataDrivenTester
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFindTheDataFile()
        {
            ItemDatabase test_database = new ItemDatabase();
            test_database.LoadItemsFromFile("TestData.csv");
            Assert.IsTrue(test_database._hasFoundFile);
        }

        [Test]
        public void TestLoadItemsFromFile()
        {
            ItemDatabase test_database = new ItemDatabase();
            test_database.LoadItemsFromFile("TestData.csv");
            Assert.IsTrue(test_database.GetItemById("TESTVALUE_01") != null);
        }

        [Test]
        public void TestItemSeparation()
        {
            ItemDatabase test_database = new ItemDatabase();
            test_database.LoadItemsFromFile("TestData.csv");
            ItemData tested_item = test_database.GetItemById("TESTVALUE_02");
            Assert.IsTrue(tested_item._name == "Test item 2");
        }
    }
}