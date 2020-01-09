using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Trie
{
    //Using Array as TrieNode children
    public class Trie_Array
    {
        public class TrieNode
        {
            public TrieNode[] children = new TrieNode[26];
            public bool isWord = false;

            public TrieNode() { }
        }

        /** Initialize your data structure here. */
        TrieNode root;
        public Trie_Array()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TrieNode cur = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (cur.children[c - 'a'] == null)
                    cur.children[c - 'a'] = new TrieNode();
                cur = cur.children[c - 'a'];
            }
            cur.isWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TrieNode cur = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (cur.children[c - 'a'] == null)
                    return false;
                cur = cur.children[c - 'a'];
            }
            return cur.isWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            TrieNode cur = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                if (cur.children[c - 'a'] == null)
                    return false;
                cur = cur.children[c - 'a'];
            }
            return true;
        }
    }

    //public class MainClass
    //{
    //    public static void Main()
    //    {
    //        string word = "apple";
    //        string prefix = "app";
    //        Trie_Array obj = new Trie_Array();
    //        obj.Insert(word);
    //        Console.WriteLine(obj.Search(word));//return TRUE
    //        Console.WriteLine(obj.Search(prefix));// return FALSE
    //        Console.WriteLine(obj.StartsWith(prefix));// return TRUE
    //        obj.Insert(word);
    //        Console.WriteLine(obj.Search(prefix)); // return TRUE
    //    }
    //}

    public class Trie_Dictionary
    {
        public class TrieNode{
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public bool isWord = false;

            public TrieNode(){}
        }

        public TrieNode root;
        public Trie_Dictionary()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode cur = root;
            for(int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!cur.children.ContainsKey(c))
                    cur.children.Add(c, new TrieNode());
                cur = cur.children[c];
            }
            cur.isWord = true;
        }

        public bool Search(string word)
        {
            TrieNode cur = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!cur.children.ContainsKey(c))
                    return false;
                cur = cur.children[c];
            }
            return cur.isWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode cur = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                if (!cur.children.ContainsKey(c))
                    return false;
                cur = cur.children[c];
            }
            return true;
        }
    }

    //public class MainClass
    //{
    //    public static void Main()
    //    {
    //        string word = "apple";
    //        string prefix = "app";
    //        Trie_Dictionary obj = new Trie_Dictionary();
    //        obj.Insert(word);
    //        Console.WriteLine(obj.Search(word));//return TRUE
    //        Console.WriteLine(obj.Search(prefix));// return FALSE
    //        Console.WriteLine(obj.StartsWith(prefix));// return TRUE
    //        obj.Insert(word);
    //        Console.WriteLine(obj.Search(prefix)); // return TRUE
    //    }
    //}
}
