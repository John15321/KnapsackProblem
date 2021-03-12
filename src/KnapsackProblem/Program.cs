using System;
using GeneratorCS;

namespace KnapsackProblem
{
    /// <summary>
    /// This class represents an item in the Knapsack problem
    /// it consists of value of a given item, and
    /// of weight of a given object
    /// </summary>
    public class Item
    {
        // Value of the item in $
        private int value;

        // Weight of the item in kg
        private int weight;

        // Value x Weight density
        private int valueDensity;

        // If the item is going to be placed
        // in the bad the value will be true
        // otherwise its going to be false
        private bool inTheBag;

        public Item(int weight, int value)
        {
            this.weight = weight;
            this.value = value;
            this.valueDensity = weight * value;
        }

        public int Value { get => value; set => this.value = value; }
        public int Weight { get => weight; set => weight = value; }
        public bool InTheBag { get => inTheBag; set => inTheBag = value; }
        public int ValueDensity { get => valueDensity; }
    }




    public class Knapsack
    {
        private int CSize;
        private int numberOfItems;
        private Item[] items;

        // The seed for randomness
        private long seed;

        public Knapsack(int numberOfItems, int cSize, long seed)
        {
            this.numberOfItems = numberOfItems;
            this.CSize = cSize;
            this.seed = seed;
        }


        public int C { get => CSize; set => CSize = value; }

        internal void GenerateItems()
        {
            RandomNumberGenerator rng = new RandomNumberGenerator(this.seed);
            this.items = new Item[this.numberOfItems];
            for (int i = 0; i < this.numberOfItems; i++)
            {
                this.items[i] = new Item(rng.nextInt(1, 29), rng.nextInt(1, 29));
            }
        }

        internal void showItems()
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write("{}: {}", i, items[i].Value);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var bagSize = 30;
            var C = 20;
            var seed = 2137;
            Console.WriteLine("Hello World!");
            var x = Console.ReadLine();
            // Console.WriteLine(2*Int32.Parse(x));

            Knapsack ourBag = new Knapsack(bagSize, C, seed);
            // Generate and initialize random items
            ourBag.GenerateItems();
            ourBag.showItems();
            // // Sort the items by value x weight
            // ourBag.SortTheItems();
            // // Fit the items in the bag
            // ourBag.FitTheItemsInTheBag();
            // // Return the list of things
            // ourBag.PrintTheBag();
        }
    }
}
