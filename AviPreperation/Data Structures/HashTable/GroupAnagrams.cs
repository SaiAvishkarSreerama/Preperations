using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
/*Given an array of strings, group anagrams together.

Example:
Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
Output:
[
  ["ate","eat","tea"],
  ["nat","tan"],
  ["bat"]
]

Note:
All inputs will be in lowercase.
The order of your output does not matter.*/

    public class GroupAnagramsSolution
    {
        //TimeComplexity - O(n * k), n-no of string, k- max length of each string
        //SpaceComplexity - O(n * k), total information stored in answer
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            List<IList<string>> res = new List<IList<string>>();

            //iterate each string from the string[] strs
            foreach (string s in strs)
            {
                //prepare an array with ASCII values, instead take 26 
                //NOTE*************Instead we can simply sort each string by converting into char[] and use it as key, but T-O(n klogk), S-(nk) is same
                int[] arr = new int[26];
                foreach (char c in s)
                {
                    arr[c - 'a']++; //starts from 0 instead of 96
                }

                //with the ASCII array, from a key to store in Map
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < arr.Length; i++)
                {
                    sb.Append('#');
                    sb.Append(arr[i]);
                }
                string key = sb.ToString();

                //If key exists, add the s else create and add s in d
                if (!d.ContainsKey(key))
                    d.Add(key, new List<string>());
                d[key].Add(s);
            }

            //Converting the hastable to list of list
            foreach (var list in d)
                res.Add(list.Value);

            return res;
        }
    }
}
