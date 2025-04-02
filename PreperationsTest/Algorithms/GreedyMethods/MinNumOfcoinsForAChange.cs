/*
 * Problem: Minumin Nuber of Coins for a change of X
 * Time Complexity: O (n logn)
 *      Sorting the array takes O(n logn)
 * Space Complexity: O(n) 
 *      - No extra space is used
 *      - input array takes - O(n)
 */

using System.Collections.Immutable;

namespace PreperationsTest.Algorithms.GreedyMethods
{
    [TestClass]
    public class MinNumOfcoinsForAChange
    {
        [TestMethod]
        public void Run()
        {
            int[] denominations = { 5, 2, 10,  };
            int amount = 34;

            int minCoins = MinCoins(denominations, amount);
        }

        /// <summary>
        /// 1. We have denominations of coins, amount that need change
        /// 2. First we need to sort the coins to start with the highest denomination
        /// 3. check max multiple of the selected denomination coins could cover the change, add them to list and check the remaining balance with diff denominations
        /// 4. Return the result
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int MinCoins(int[] denominations, int amount)
        {
            int minCoins = 0;
            Array.Sort(denominations);

            // decrementing the denominations array to get the max denomination as it is sorted
            for( int i = denominations.Length - 1; i >= 0; i--)
            {
                if (amount == 0)
                    break;

                int noOfCoins = amount / denominations[i];
                if (noOfCoins > 0)
                {
                    minCoins = minCoins + noOfCoins;
                    amount = amount - (noOfCoins * denominations[i]);
                }
            }
            return minCoins;
        }
    }
}
