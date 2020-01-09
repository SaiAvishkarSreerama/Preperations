using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Trie
{
    public class ReplaceWordSolution
    {
        public class TrieNode
        {
            public TrieNode[] children;
            public string word;

            public TrieNode()
            {
                children = new TrieNode[26];
            }
        }

        //Using TRIE DataStructure
        //TimeComplexity - O(N), lenght of the sentense
        //SpaceComplexity - O(N), size of Trie
        public static string ReplaceWords(IList<string> dict, string sentence)
        {
            //create a trie root
            TrieNode root = new TrieNode();

            //Create a Trie with the dictionary words
            for (int i = 0; i < dict.Count; i++)
            {
                TrieNode cur = root;
                foreach (char c in dict[i])
                {
                    if (cur.children[c - 'a'] == null)
                        cur.children[c - 'a'] = new TrieNode();
                    cur = cur.children[c - 'a'];
                }
                cur.word = dict[i];
            }

            //Declaring a StringBuilder to form the result
            StringBuilder sb = new StringBuilder();

            //Iterating through the sentence to replace the words with the dictionary using the Trie
            foreach (string word in sentence.Split(' '))
            {
                TrieNode cur = root;
                if (sb.Length > 0)
                    sb.Append(" ");

                foreach (char c in word)
                {
                    //If word is not null means our dictionary must have the word ending at that place, so we need to stop looping further... Ex: a aa aaa aaaa
                    //All words starting with a must replace with a, see the example below in Main method
                    if (cur.children[c - 'a'] == null || cur.word != null)
                        break;
                    cur = cur.children[c - 'a'];
                }
                sb.Append(cur.word == null ? word : cur.word);
            }
            return sb.ToString();
        }

        //public static void Main()
        //{
        ////List<string> dict = new List<string> { "cat", "bat", "rat" };
        ////Console.WriteLine(ReplaceWords(dict, "the cattle was rattled by the battery")); 
        
        //List<string> dict = new List<string> { "a", "aa", "aaa", "aaaa" };
        //Console.WriteLine(ReplaceWords(dict, "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa")); 
        //}

    }
}
