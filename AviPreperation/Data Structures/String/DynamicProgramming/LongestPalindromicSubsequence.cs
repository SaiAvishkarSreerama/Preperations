using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.String.DynamicProgramming
{
    public class LPSSolution
    {
        //TimeComplexity = O(n^2)
        //SpaceComplexity - O(n)
        public int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[,] dp = new int[n, n];

            for (int i = n - 1; i >= 0; i--)
            {
                dp[i, i] = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (s[i] == s[j])
                        dp[i, j] = 2 + dp[i + 1, j - 1];
                    else
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
            return dp[0, n - 1];
        }
    }
}
