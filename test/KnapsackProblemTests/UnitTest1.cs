using NUnit.Framework;
using GeneratorCS;
using KnapsackProblem;

namespace KnapsackProblemTests
{
    public class Tests
    {
        private Item t1;
        private Item[] lt = { new Item(1, 10), new Item(10, 1) };

        [SetUp]
        public void Setup()
        {
            t1 = new Item(10, 10);
        }

        [Test]
        public void Test_ValueDensity_Calculation()
        {
            Assert.AreEqual(t1.ValueDensity, 1);
        }

        [Test]
        public void Test_RandomNumberGenerator1()
        {
            RandomNumberGenerator rng = new RandomNumberGenerator(1);
            int x = rng.nextInt(1, 29);
            Assert.IsTrue(x >= 1);
        }

        [Test]
        public void Test_RandomNumberGenerator2()
        {
            RandomNumberGenerator rng = new RandomNumberGenerator(1);
            int x = rng.nextInt(1, 29);
            Assert.IsTrue(x <= 29);
        }

        [Test]
        public void Test_ValueSum1()
        {
            var bagSize = 30;
            var C = 20;
            var seed = 2137;
            var testBag = new Knapsack(bagSize, C, seed);
            testBag.GenerateItems();
            testBag.SortTheItems();
            testBag.FitTheItemsInTheBag();
            testBag.PrintTheBag();
            Assert.AreEqual(testBag.ValueSum, 61);
        }

        [Test]
        public void Test_ValueSum2()
        {
            var bagSize = 10;
            var C = 15;
            var seed = 420;
            var testBag = new Knapsack(bagSize, C, seed);
            testBag.GenerateItems();
            testBag.SortTheItems();
            testBag.FitTheItemsInTheBag();
            testBag.PrintTheBag();
            Assert.AreEqual(testBag.ValueSum, 41);
        }

        [Test]
        public void Test_ValueSum3()
        {
            var bagSize = 5;
            var C = 10;
            var seed = 609;
            var testBag = new Knapsack(bagSize, C, seed);
            testBag.GenerateItems();
            testBag.SortTheItems();
            testBag.FitTheItemsInTheBag();
            testBag.PrintTheBag();
            Assert.AreEqual(testBag.ValueSum, 14);
        }

        [Test]
        public void Item_generate()
        {
            var bagSize = 5;
            var C = 10;
            var seed = 609;
            var testBag = new Knapsack(bagSize, C, seed);
            testBag.GenerateItems();
            Assert.AreEqual(testBag.ItemSize, 5);
        }
    }
}