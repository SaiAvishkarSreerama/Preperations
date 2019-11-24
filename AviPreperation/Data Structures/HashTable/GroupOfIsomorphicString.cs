using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    class GroupOfIsomorphicStringSol
    {
        //TimeComplexity = O(n * m) n-no of strings, m-no of characters of each string
        //Space Complexity = O(1)
        public static List<List<string>> GroupOfIsomorphicString(string[] s)
        {
            //creating a return object 
            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            List<List<string>> result = new List<List<string>>();

            //let create a hash function to find the groups for each string in the array
            for (int i = 0; i < s.Length; i++)
                {
                    string key = IsomorphicHash(s[i]);//Hash key return a number that matches to similar pattern
                    if (!d.ContainsKey(key))
                    {
                        List<string> ls = new List<string>();
                        ls.Add(s[i]);
                        d.Add(key, ls);
                    }
                    else
                    {
                        List<string> ls = d[key];
                        ls.Add(s[i]);
                        d[key] = ls;
                    }
                }

            foreach(var val in d)
            {
                result.Add(val.Value);
            }
            return result;
        }

        public static string IsomorphicHash( string s)
        {
            Dictionary<char, int> ds = new Dictionary<char, int>();
            StringBuilder sb = new StringBuilder();
            
            for(int i = 0; i < s.Length; i++)
            {
                if (ds.ContainsKey(s[i]))
                    sb.Append(ds[s[i]]);
                else
                    ds.Add(s[i], i);
                    sb.Append(i);
            }

            return sb.ToString();
        }

        //public static void Main()
        //{
        //    string[] s = new string[] { "aab", "xxy", "xyz", "abc", "def", "xyx" };
        //    GroupOfIsomorphicString(s);
        //}
    }
}
