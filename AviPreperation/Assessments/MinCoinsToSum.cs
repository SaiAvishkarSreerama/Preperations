using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Assessments
{
    class FindMinCoins
    {
        public static int findMinCoins(int[] coins, int sum)
        {
            int[] sol = new int[sum + 1];
            for (int i = 0; i <= sum; i++)
            {
                sol[i] = int.MaxValue;
            }
            sol[0] = 0;/*sum 0 , can be made with 0 coins*/
            for (int i = 1; i <= sum; i++)
            {
                foreach (int coin in coins)
                {
                    if (i >= coin && i - coin >= 0 && sol[i - coin] + 1 < sol[i])
                    {
                        sol[i] = sol[i - coin] + 1;
                    }
                }
            }
            return sol[sum];
        }

        //public static void Main()
        //{
        //    findMinCoins(new int[] { 1, 3, 5 }, 11);
        //}


        //DYNAMIC PROGRAMMING
        //TC- O(S * n): where s is amount, n is no of denominations given
        //SC - O(s)
        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;

            for (int i = 1; i <= amount; i++)
            {
                foreach (int coin in coins)
                {
                    if (coin <= i)
                        dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
            // return dp[amount] > amount ? -1 : dp[amount];
            return dp[4];
        }
    }

}
