/*
 * Problem: Maximum number of profit can we get by filling the knapsack with the objects
 * Constraint: Total weight the knapsack can carry is x-kg/lbs only
 * Time Complexity: O(N logN)
 *      Sorting takes N logN time
 *      Iterating through all objects takes N time
 * Space Complexity: O(N)
 *      No new space is used here, but used all constants which takes O(1)
 *      Input object takes O(N), combining both it will be O(N)
 */

using System.Collections;

namespace PreperationsTest.Algorithms.GreedyMethods
{
    [TestClass]
    public class KnapsackProblem
    {
        [TestMethod]
        public void Run()
        {
            // Input type 1: { profit, weight}
            Item[] obj = { new Item( 10, 2 ),
                            new Item( 5, 3 ),
                            new Item( 15, 5 ),
                            new Item( 7, 7 ),
                            new Item( 6, 1 ),
                            new Item( 18, 4 ),
                            new Item( 3, 1 )
                        };
            int maxWeight = 15;

            // Input type 2:
            // If weights[] and profits[] provided in a separate array
            // Create a tuple/list with weightPerObject, weight, profit, like below
            // List<(double, int, int)> = new List<(double, int, int)>{{profits[i]/weights[i], weight[i], profits[i]}}
            // Sorting: items.Sort((a, b) => b.weightPerObject.CompareTo(a.weightPerObject));

            double result = Knapsack_solution(obj, maxWeight);
        }

        public double Knapsack_solution(Item[] objects, int maxWeight)
        {
            if(maxWeight == 0)
            {
                return 0;
            }

            CprCompare cmpr = new CprCompare();
            Array.Sort(objects, cmpr); // Sort the items based on single object weight
            double totalProfit = 0;

            foreach (Item item in objects)
            {
                if (maxWeight == 0)
                {
                    break;
                }
                else if (maxWeight > 0 && item.weight <= maxWeight) // currentWeight must be less than maxWeight
                {
                    totalProfit += item.profit; // Add profit
                    maxWeight -= item.weight; // remove weight
                }
                else if (maxWeight != 0) // if current weight is higher
                {
                    double fractionOfWeight = (double)maxWeight / item.weight; // we can take some weight from current weight only, fractionOfWeight = max / current (ex: 2/3)
                    totalProfit += fractionOfWeight * (item.profit); // same profice also for that fractionOfWeight, 
                    maxWeight -= (int)(fractionOfWeight * item.weight); // removing the fractionOfWeight from maxweight which becoes zero.
                }
            }

            return totalProfit;
        }
    }

    public class CprCompare : IComparer
    {
        public int Compare(Object x, Object y)
        {
            Item Item1 = (Item)x;
            Item Item2 = (Item)y;

            double Item1_pwRatio = Item1.profit / Item1.weight;
            double Item2_pwRatio = Item2.profit / Item2.weight;

            if (Item1_pwRatio == Item2_pwRatio)
                return 0;
            return Item1_pwRatio > Item2_pwRatio ? -1 : 1;
        }
    }

    public class Item
    {
        public int profit;
        public int weight;

        public Item(int profit, int weight)
        {
            this.profit = profit;
            this.weight = weight;
        }
    }
}
