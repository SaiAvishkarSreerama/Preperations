using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class WordBreakIISolution
    {
        //RECURSION WITH MEMOIZATION
        //Time complecity - O(n^3)
        //Space Complexity - O(n^3)
        HashSet<string> h;
        Dictionary<int, List<string>> memo;
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            h = new HashSet<string>(wordDict);
            memo = new Dictionary<int, List<string>>();
            return helper(s, 0);
        }

        public List<string> helper(string s, int start)
        {
            if (memo.ContainsKey(start))
                return memo[start];

            List<string> res = new List<string>();
            if (start == s.Length)
                res.Add("");

            for (int end = start + 1; end <= s.Length; end++)
            {
                if (h.Contains(s.Substring(start, end - start)))
                {
                    List<string> list = helper(s, end);
                    foreach (string l in list)
                    {
                        res.Add(s.Substring(start, end - start) + (l == "" ? "" : " ") + l);
                    }
                }
            }

            memo.Add(start, res);
            return res;
        }
    }
}
