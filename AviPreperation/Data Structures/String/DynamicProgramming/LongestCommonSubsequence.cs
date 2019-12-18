using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.String.DynamicProgramming
{
    class LongestCommonSubsequenceSol
    {
        //RECURSION
        //Time limit exceeds NotRecommended
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int s1 = text1.Length;
            int s2 = text2.Length;

            if (s1 == 0 || s2 == 0)
                return 0;

            string text1WithoutLastChar = text1.Substring(0, s1 - 1);
            string text2WithoutLastChar = text2.Substring(0, s2 - 1);

            char text1LastChar = text1[s1 - 1];
            char text2LastChar = text2[s2 - 1];

            if (text1LastChar == text2LastChar)
            {
                return 1 + LongestCommonSubsequence(text1WithoutLastChar, text2WithoutLastChar);
            }
            else
            {
                return Math.Max(
                    LongestCommonSubsequence(text1, text2WithoutLastChar),
                    LongestCommonSubsequence(text1WithoutLastChar, text2));
            }

        }

        //Dynamic Programming using int[]******************
        //TimeComplexity-O(n^2)
        //SpaceComplexity - O(n)
        public int LongestCommonSubsequence1(string text1, string text2)
        {
            int[] dp = new int[text2.Length + 1];

            for (int i = 1; i <= text1.Length; i++)
            {
                int prev = 0;
                for (int j = 1; j <= text2.Length; j++)
                {
                    int temp = dp[j];
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[j] = prev + 1;
                    }
                    else
                    {
                        dp[j] = Math.Max(dp[j - 1], dp[j]);
                    }
                    prev = temp;
                }
            }
            return dp[text2.Length];
        }

        //Dynamic Programming using int[][]
        //TimeComplexity - O(n^2)
        //SpaceComplexity - O(n^2)
        public int LongestCommonSubsequence2(string text1, string text2)
        {
            int[,] dp = new int[text2.Length + 1, text1.Length + 1];
            for (int i = 1; i <= text2.Length; i++) // for no of row times it will iterate
            {
                for (int j = 1; j <= text1.Length; j++) //for number of column times it will iterate
                {
                    if (text1[j - 1] == text2[i - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];  // this will add 1+ diagnol element value in dp
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]); // this iwll just take the max of cross elements.
                    }
                }

            }
            return dp[text2.Length, text1.Length];
        }
    }
}
