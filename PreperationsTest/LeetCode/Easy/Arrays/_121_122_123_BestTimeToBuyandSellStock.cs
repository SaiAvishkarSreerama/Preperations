/*
 * You are given an array prices where prices[i] is the price of a given stock on the ith day.
 * You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
 * Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
 * 
 * Example 1:
 * Input: prices = [7,1,5,3,6,4]
 * Output: 5
 * Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
 * Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
 * 
 * Example 2:
 * Input: prices = [7,6,4,3,1]
 * Output: 0
 * Explanation: In this case, no transactions are done and the max profit = 0.
 *  */

// Companies: @Meta
namespace PreperationsTest.LeetCode.Easy.Arrays
{
    [TestClass]
    public class _121_BestTimeToBuyandSellStock
    {
        [TestMethod]
        public void Run()
        {
            int[] prices = { 7, 1, 5, 3, 5, 6, 4 };
            int profit = MaxProfit(prices);
        }

        /// <summary>
        /// One Pass
        /// TC - O(n)
        /// SC - O(1)
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int minSoFar = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minSoFar)
                {
                    minSoFar = prices[i];
                }
                else
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - minSoFar);
                }
            }

            return maxProfit;
        }
    }

    [TestClass]
    public class _122_BestTimeToBuyandSellStock_II
    {
        [TestMethod]
        public void Run()
        {
            int[] prices = { 7, 1, 5, 3, 5, 6, 4 };
            int profit = MaxProfit(prices);
        }

        /// <summary>
        /// Peak Valley approach
        /// TC - O(n)
        /// SC - O(1)
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit1(int[] prices)
        {
            int totalProfit = 0;
            int valley = int.MaxValue;
            int peak = valley;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] >= peak)
                { // we see high peak then  set new peak
                    peak = prices[i];
                }
                else
                {
                    totalProfit += peak - valley; // we see a new valley, then sell our old stock at our peak.
                    valley = prices[i]; // and set new valley and peak.
                    peak = valley;
                }
            }

            // as we know, we are selling our stock when we see new valley
            // at last we dont see a valley, so we need to sell our exisitng stock
            totalProfit += peak - valley;

            return totalProfit;
        }

        /// <summary>
        /// One Pass
        /// TC - O(n)
        /// SC - O(1)
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }

            return maxProfit;
        }
    }



    [TestClass]
    public class _123_BestTimeToBuyandSellStock_III
    {
        [TestMethod]
        public void Run()
        {
            int[] prices = { 3, 3, 5, 0, 0, 3, 1, 4 };
            int profit = MaxProfit(prices);
        }

        /// <summary>
        /// BiDirectional Dynamic programming
        /// splitting the prices into two parts from Left: 0 -> i, right: i+1 -> end
        /// TC - O(n)
        /// SC - O(n)
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int length = prices.Length;
            if (length <= 1)
            {
                return 0;
            }

            // Two variables to maintain the min value for buy and max val for sell 
            int leftMin = prices[0];
            int rightMax = prices[length - 1];

            // Two arrays to keep track of two transactions
            // leftProfits - from  day 0 to day i
            // rightProfits - from day i+1 to day n
            int[] leftProfits = new int[length];
            int[] rightProfits = new int[length + 1];

            // Iterate through the prices and find the leftProfits
            for (int l = 1; l < length; l++)
            {
                // Left: we get curr profit by selling at our current price (leftMin is where we bought a stock at low)
                int currProfit = prices[l] - leftMin;
                leftProfits[l] = Math.Max(leftProfits[l - 1], currProfit); // see if the old profit is max or current one?
                leftMin = Math.Min(leftMin, prices[l]); // now we keep the new low in the left min (if)

                int r = (length - 1) - l;
                currProfit = rightMax - prices[r]; //get current profit if we buy at prices[r] and sell at rightMax
                rightProfits[r] = Math.Max(rightProfits[r + 1], currProfit);
                rightMax = Math.Max(rightMax, prices[r]);
            }

            int maxProfit = 0;
            for (int i = 0; i < length; i++)
            {
                maxProfit = Math.Max(maxProfit, leftProfits[i] + rightProfits[i + 1]);
            }

            return maxProfit;
        }

        /*
         * buyOne
        The lowest price you've seen so far to buy the first stock.
        Starts as int.MaxValue and gets updated as you scan through prices.
        2. sellOne
        The maximum profit you can make from the first transaction.
        Calculated as price - buyOne.
        3. buyTwo
        The effective cost of buying the second stock, factoring in the profit from the first transaction.
        
        Think of it as:
        
        "If I already made sellOne profit, how much does this second stock cost me now?"
        
        So it's calculated as:
        buyTwo = Math.Min(buyTwo, price - sellOne)
        
        4. sellTwo
        The maximum total profit you can make from both transactions.
        Calculated as:
        sellTwo = Math.Max(sellTwo, price - buyTwo)
         */
        public int MaxProfit1(int[] prices)
        {
            var n = prices.Length;
            if (n < 2)
                return 0;
            var sellOne = 0;
            var buyOne = int.MaxValue;
            var sellTwo = 0;
            var buyTwo = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                buyOne = Math.Min(prices[i], buyOne);
                sellOne = Math.Max(prices[i] - buyOne, sellOne);
                buyTwo = Math.Min(prices[i] - sellOne, buyTwo);
                sellTwo = Math.Max(prices[i] - buyTwo, sellTwo);
            }
            return sellTwo;
        }
    }
}
