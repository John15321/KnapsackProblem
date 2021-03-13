using System;
using System.Collections.Generic;
using GeneratorCS;

namespace KnapsackProblem
{
    /// <summary>
    /// This class represents an item in the Knapsack problem.
    /// It consists of value that a given item has,
    /// and of its weight
    /// </summary>
    public class Item : IComparable<Item>
    {
        public Item(int weight, int value)
        {
            Weight = weight;
            Value = value;
            ValueDensity = (double) value / weight;
        }

        // Value of the item
        public int Value { get; }

        // Weight of the item
        public int Weight { get; }

        // Value x Weight density
        public bool InTheBag { get; set; }

        // If the item is going to be placed
        // in the bag, the value will be true
        // otherwise its going to be false
        public double ValueDensity { get; }

        public int CompareTo(Item other)
        {
            return ValueDensity.CompareTo(other.ValueDensity);
        }
    }

    public class SortByValueDensityDescending : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return y.ValueDensity.CompareTo(x.ValueDensity);
        }
    }


    /// <summary>
    /// The Knapsack class contains all the Items, and
    /// Items that will be stored in the bag
    /// </summary>
    public class Knapsack
    {
        private int _cSize;
        private readonly int _numberOfItems;
        private Item[] _items;

        // The seed for randomness
        private readonly long _seed;


        public Knapsack(int numberOfItems, int cSize, long seed)
        {
            _numberOfItems = numberOfItems;
            _seed = seed;
            _cSize = cSize;
        }


        public int C
        {
            get => _cSize;
            set => _cSize = value;
        }

        internal void GenerateItems()
        {
            RandomNumberGenerator rng = new RandomNumberGenerator(_seed);
            _items = new Item[_numberOfItems];
            for (var i = 0; i < _numberOfItems; i++)
            {
                _items[i] = new Item(rng.nextInt(1, 29), rng.nextInt(1, 29));
            }
        }

        internal void ShowItems()
        {
            for (var i = 0; i < _items.Length; i++)
            {
                Console.WriteLine(
                    $"Item {i + 1:00}| Density: {_items[i].ValueDensity:00.00}| Weight: {_items[i].Weight:00}| Value: {_items[i].Value:00}| InTheBag: {_items[i].InTheBag}");
            }
        }

        internal void SortTheItems()
        {
            SortByValueDensityDescending sortByValueDensityDescending = new SortByValueDensityDescending();
            Array.Sort(_items, sortByValueDensityDescending);
        }

        internal void FitTheItemsInTheBag()
        {
            var sum = 0;
            var i = 0;
            while (sum < _cSize)
            {
                _items[i].InTheBag = true;
                sum += _items[i].Weight;
                i++;
            }
        }

        public void PrintTheBag()
        {
            var value_sum = 0;
            foreach (var item in _items)
            {
                if (item.InTheBag)
                {
                    value_sum += item.Value;
                }
            }

            Console.WriteLine($"Total value in the Knapsack: {value_sum:000}");
        }
    }

    class Program
    {
        static void Main()
        {
            var bagSize = 30;
            var C = 20;
            var seed = 2137;

            var ourBag = new Knapsack(bagSize, C, seed);
            // Generate and initialize random items
            ourBag.GenerateItems();
            ourBag.ShowItems();
            // Sort the items by value x weight
            ourBag.SortTheItems();
            Console.WriteLine("Sorted");
            ourBag.ShowItems();
            Console.WriteLine("---------------------------");
            // Fit the items in the bag
            ourBag.FitTheItemsInTheBag();
            Console.WriteLine("---------------------------");
            Console.WriteLine("In the bag");
            ourBag.ShowItems();
            // Return the list of things
            ourBag.PrintTheBag();
        }
    }
}