using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Given a string, we can "shift" each of its letter to its successive letter, for example: "abc" -> "bcd". We can keep "shifting" which forms the sequence:

//"abc" -> "bcd" -> ... -> "xyz"
//Given a list of strings which contains only lowercase alphabets, group all strings that belong to the same shifting sequence.

//Example:

//Input: ["abc", "bcd", "acef", "xyz", "az", "ba", "a", "z"],
//Output: 
//[
//  ["abc","bcd","xyz"],
//  ["az","ba"],
//  ["acef"],
//  ["a","z"]
//]
namespace AviPreperation.Data_Structures.HashTable
{
    public class GroupStringsSolution
    {
        //TimeComplexity - O(N*M), N-no of string, M-length of each string
        //Space Complexity - O(N*M); total information stored in dictionary
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();

            foreach (string s in strings)
            {
                string key = Gen_Key(s);
                if (d.ContainsKey(key))
                {
                    d[key].Add(s);
                }
                else
                    d.Add(key, new List<string> { s });
            }

            return new List<IList<string>>(d.Select(a => a.Value));
        }

        public string Gen_Key(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < s.Length; i++)
            {
                // for the case az and ba, az gives 25 but ba gives -1 so we add 26(length of alphabets) and doing % gives a value between 1-26
                int val = (s[i] - s[i - 1] + 26) % 26;
                sb.Append(val + "#");
            }

            return sb.ToString();
        }
    }
}
