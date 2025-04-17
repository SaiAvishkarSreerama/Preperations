using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreperationsTest.LeetCode.Easy.Strings
{
    [TestClass]
    public class _14_LongestCommonPrefix
    {
        [TestMethod]
        public void Run()
        {
            string[] strs = { "flower", "flow", "flight" };
            string prefix = LongestCommonPrefix_HorizontalScanning(strs);
            prefix = LongestCommonPrefix_Trie(strs);
        }

        #region Horizontal Scanning
        /// <summary>
        /// Here we are literally comparing first two strings and get the prefix out and then compare it with nexlont string and go on
        /// TC = O(S), where s is the total charactes in all strings
        /// SC = O(1)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix_HorizontalScanning(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (prefix == "")
                        return "";
                }

            return prefix;
        }
        #endregion

        #region Trie
        public class TrieNode
        {
            public TrieNode[] childNode { get; set; }
            public int wordcount { get; set; }

            public TrieNode()
            {
                childNode = new TrieNode[26];
                wordcount = 0;
            }

            public void InsertKey(TrieNode root, string s)
            {
                TrieNode currentNode = root;
                foreach (char c in s)
                {
                    int currentIndex = c - 'a';
                    if (currentNode.childNode[currentIndex] == null)
                    {
                        currentNode.childNode[currentIndex] = new TrieNode();
                    }
                    currentNode = currentNode.childNode[currentIndex];
                    currentNode.wordcount++;
                }
            }
        }

        /// <summary>
        /// TC - O(nxm), where n is no of string and m is lenght of each string or O(S), S is sum of all the characters in the string
        /// SC - O(nxm)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix_Trie(string[] strs)
        {
            if (strs.Length == 0)
                return "";

            TrieNode root = new TrieNode();
            foreach (var s in strs)
            {
                root.InsertKey(root, s);
            }

            //traverse root and check if the wordcount is same as strs count
            TrieNode node = root;
            int stringsCount = strs.Length;
            int i = 0;
            for (; i < strs[0].Length; i++)
            {
                int currentIndex = strs[0][i] - 'a';
                node = node.childNode[currentIndex];
                if (node.wordcount != stringsCount)
                {
                    break;
                }
            }

            return strs[0].Substring(0, i);
        }
        #endregion
    }
}
