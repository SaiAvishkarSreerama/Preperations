using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion
{
    public class ClimbStairsSolution
    {
        // TimeComplexty - O(n)
        // SpaceComplexity - O(n)
        //Using Dynamic Programming
        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;
            int[] dp = new int[n + 1];

            dp[1] = 1;
            dp[2] = 2;


            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
    }
}
