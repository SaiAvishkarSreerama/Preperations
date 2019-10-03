using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.LeetCodePrep._1.Easy
{
    public class LCP
    {
        /************Comparing S0 to S1,S2,S3,...Sn**************/
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";
            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (string.IsNullOrEmpty(prefix))
                        return "";
                }
            }
            return prefix;
        }
    }
}
