using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.String
{
    public class LongestPalindromicSubStringSolution
    {
        //DYNAMIC PROGRAMMING
        //Time Complexity - O(N^2)  
        //Space Complexity - O(N^2)
        public string LongestPalindrome(string s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n, n];
            string res = "";

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i; j < n; j++)
                {
                    //If both letters are same and if the lenth between them is <3 nothing need todo, else we can get the between length string from the dp[i+1, j-1]
                    dp[i, j] = ((s[i] == s[j]) && (j - i < 3 || dp[i + 1, j - 1]));
                    if (dp[i, j] && (res.Length == 0 || j - i + 1 > res.Length))
                    {
                        res = s.Substring(i, j - i + 1);
                    }
                }
            }
            return res;
        }

        //MANACHERS ALGORITHM
        //TimeComplexity - O(N)
        //Space Complexity - O(N)
        public string LongestPalindrome1(string s)
        {
            string T = preProcess(s);
            int[] P = new int[T.Length];
            int C = 0;
            int R = 0;

            for (int i = 1; i < T.Length - 1; i++)
            {
                int mirror = 2 * C - i;

                P[i] = R > i ? Math.Min(R - i, P[mirror]) : 0;

                while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
                    P[i]++;

                if (i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }

            int maxLength = 0;
            int centerIndex = 0;
            for (int i = 0; i < P.Length; i++)
            {
                if (P[i] > maxLength)
                {
                    maxLength = P[i];
                    centerIndex = i;
                }
            }

            return s.Substring((centerIndex - 1 - maxLength)/2, maxLength);
        }

        public string preProcess(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('^');

            foreach (char c in s)
            {
                sb.Append('#');
                sb.Append(c);
            }

            sb.Append("#$");
            foreach (var c in sb.ToString())
                Console.WriteLine(c);
            return sb.ToString();
        }

        //CaseIII
        //TimeComplexity - O(n^2) or O(n)
        //SpaceComplexity - O(1)
        public string LongestPalindrome2(string s)
        {
            if (s.Length == 0) return "";
            if (s.Length == 1) return s;
            int maxLength = 0;
            int minStart = 0;

            for (int i = 0; i < s.Length - 1;)
            {
                int L = i; //Left
                int R = i; //Right

                while (R < s.Length - 1 && s[R] == s[R + 1])
                    R++;

                i = R + 1;
                while (R < s.Length - 1 && L > 0 && s[R + 1] == s[L - 1])
                {
                    R++;
                    L--;
                }

                int length = R - L + 1;
                if (length > maxLength)
                {
                    maxLength = length;
                    minStart = L;
                }
            }

            return s.Substring(minStart, maxLength);
        }
        public static void Main()
        {
            var obj = new LongestPalindromicSubStringSolution();
            //obj.LongestPalindrome1("babcbabcba");
            Console.WriteLine(obj.LongestPalindrome2("aabaabaa"));
        }
    }
}
