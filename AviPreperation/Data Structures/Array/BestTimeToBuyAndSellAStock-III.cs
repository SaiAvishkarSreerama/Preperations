using System;
using System.Collections.Generic;
using System.Text;

/*Say you have an array for which the ith element is the price of a given stock on day i.
* 
* Design an algorithm to find the maximum profit. You may complete at most two transactions.
* 
* Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).
* 
* Example 1:
* 
* Input: [3,3,5,0,0,3,1,4]
* Output: 6
* Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
*              Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.
* Example 2:
* 
* Input: [1,2,3,4,5]
* Output: 4
* Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
*              Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
*              engaging multiple transactions at the same time. You must sell before buying again.
* Example 3:
* 
* Input: [7,6,4,3,1]
* Output: 0
* Explanation: In this case, no transaction is done, i.e. max profit = 0.
* 
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
    class BestTimeToBuyAndSellAStock_III
    {
        //USING DYNAMIC PROGRAMMING
        //Time Complexity - O(n*k), where n is length of prices(no of days), k- no of transactions
        //Space Complexity - O(n*k), where n is length of prices(no of days), k- no of transactions
        //https://www.youtube.com/watch?v=oDhu5uGq_ic
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }

            //given two transactions
            int k = 2;
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
