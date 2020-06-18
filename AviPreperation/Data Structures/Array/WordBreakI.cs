using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class WordBreakISolution
    {
        //**********************Code doesnot check for alternate strings************
        // public bool WordBreak(string s, IList<string> wordDict) {
        //     HashSet<string> wordSet = new HashSet<string>();
        //     foreach(string k in wordDict)
        //         wordSet.Add(k);                

        //     int i=0;
        //     StringBuilder sub = new StringBuilder();
        //     while(i < s.Length){
        //         sub.Append(s[i++]);                    
        //         if(wordSet.Contains(sub.ToString()))
        //             sub = new StringBuilder();
        //     }

        //     return sub.Length == 0;            
        // }

        //USING RECURSION WITH MEMOIZATION
        //TIME LIMIT EXCEEDS FOR ONE TEST CASE
        //TC - O(n^2)
        //SC - O(n)
        public bool WordBreak1_1(string s, IList<string> wordDict)
        {
            return helper(s, new HashSet<string>(wordDict), 0, new bool[s.Length]);
        }

        public bool helper(string s, HashSet<string> wordDict, int start, bool[] memo)
        {
            if (start == s.Length)
                return true;
            if (memo[start])
                return memo[start];
            for (int end = start + 1; end <= s.Length; end++)
            {
                Console.WriteLine(s.Substring(start, end - start) + ":- start-" + start + ", end- " + end);
                if (wordDict.Contains(s.Substring(start, end - start)) &&
                    helper(s, wordDict, end, memo))
                    return memo[start] = true;
            }

            return memo[start] = false;
        }

        //DYNAMIC PROGRAMMING
        //TC - O(n^2)
        //SC - O(n)
        public bool WordBreak1_2(string s, IList<string> wordDict)
        {
            HashSet<string> h = new HashSet<string>(wordDict);
            bool[] memo = new bool[s.Length + 1];
            memo[0] = true;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (memo[j] && h.Contains(s.Substring(j, i - j)))
                    {
                        memo[i] = true;
                        break;
                    }
                }
            }
            return memo[s.Length];
        }
    }
}
