using System;
using System.Collections.Generic;
using System.Text;

/*Say you have an array for which the i-th element is the price of a given stock on day i.
* 
* Design an algorithm to find the maximum profit. You may complete at most k transactions.
* 
* Note:
* You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
* 
* Example 1:
* Input: [2,4,1], k = 2
* Output: 2
* Explanation: Buy on day 1 (price = 2) and sell on day 2 (price = 4), profit = 4-2 = 2.
* 
* Example 2:
* Input: [3,2,6,5,0,3], k = 2
* Output: 7
* Explanation: Buy on day 2 (price = 2) and sell on day 3 (price = 6), profit = 6-2 = 4.
* Then buy on day 5 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
*
* Consider Example - [1,4,2,6,5,0,3] k = 3
* 
*         1   4   2   6   5   0   3
* k = 0   0   0   0   0   0   0   0
* k = 1   0   3   3   5   5   5   5
* k = 2   0   3   3   7   7   7   8
* k = 3   0   3   3   7   7   7   10
*/

namespace AviPreperation.Data_Structures.Array
{
    class BestTimeToBuyAndSellAStock_IIII
    {
        //Time complexity - O(k * n), where n is price.Length(whcih is days))
        //Space complexity - O(k * n) where n is price.Length(whcih is days))

        public int MaxProfit(int k, int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            //By doing this method we can do maximum no of transactions
            //This case was used in method II(as many as trasactions)
            if (k >= prices.Length / 2)
            {
                int profit = 0;
                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] > prices[i - 1])
                        profit += prices[i] - prices[i - 1];
                }
                return profit;
            }

            //This case fails when the prices lenght is very huge and exceeds the limit of array
            int[,] dp = new int[k + 1, prices.Length];

            for (int i = 1; i <= k; i++)
            {
                int maxDiff = -prices[0];
                for (int j = 1; j < prices.Length; j++)
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], prices[j] + maxDiff);
                    maxDiff = Math.Max(maxDiff, dp[i - 1, j] - prices[j]);
                }
            }

            return dp[k, prices.Length - 1];
        }
    }
}
