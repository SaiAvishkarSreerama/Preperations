using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Trie
{
   public class MapSum
    {
        //Using Trie DataStructure
        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public int score;
        }

        Dictionary<string, int> d;
        TrieNode root;
        /** Initialize your data structure here. */
        public MapSum()
        {
            d = new Dictionary<string, int>();
            root = new TrieNode();
        }

        public void Insert(string key, int val)
        {
            int diff = val;
            if (!d.ContainsKey(key))
            {
                d.Add(key, val);
            }
            else
            {
                diff = val - d[key];
                d[key] = val;
            }

            TrieNode cur = root;
            cur.score += diff;

            foreach (char c in key)
            {
                if (!cur.children.ContainsKey(c))
                    cur.children.Add(c, new TrieNode());
                cur = cur.children[c];
                cur.score += diff;
            }
        }

        public int Sum(string prefix)
        {
            TrieNode cur = root;
            foreach (char c in prefix)
            {
                if (cur.children[c] == null)
                    return 0;
                cur = cur.children[c];
            }
            return cur.score;
        }
    }

    //public class MainClass
    //{
    //    public static void Main()
    //    {
    //        var obj = new MapSum();
    //        obj.Insert("apple", 3);
    //        Console.WriteLine(obj.Sum("app"));//return TRUE
    //        obj.Insert("app", 2);
    //        Console.WriteLine(obj.Sum("ap"));// return TRUE
    //    }
    //}
    /**
     * Your MapSum object will be instantiated and called as such:
     * MapSum obj = new MapSum();
     * obj.Insert(key,val);
     * int param_2 = obj.Sum(prefix);
     */
}
