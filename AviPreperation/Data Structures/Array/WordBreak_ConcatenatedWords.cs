using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class WordBreak_ConcatenatedWordsSolution
    {
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            List<string> res = new List<string>();
            HashSet<string> h = new HashSet<string>();

            System.Array.Sort(words, (a, b) => a.Length - b.Length);

            foreach (string word in words)
            {
                if (h.Count > 0 && canWordBreak(word, h))
                    res.Add(word);
                h.Add(word);
            }

            return res;
        }

        public bool canWordBreak(string word, HashSet<string> h)
        {
            bool[] dp = new bool[word.Length + 1];
            dp[0] = true;

            for (int i = 1; i <= word.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && h.Contains(word.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[word.Length];
        }


        /*
         public Trie root;
        public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
           List<string> returnData = new List<string>();
            if(words.Count()==0) return returnData;

                foreach (string str in words) {

                    Insert(str);
                }
                foreach (string str in words)
                {
                    if (isConcatenation(0, str, 0))
                    {
                        returnData.Add(str);
                    }
                }
                return returnData;
        }

         public void Insert(string str)
            {
                if (root == null) root = new Trie();
                Trie start = root;

                for (int i = 0; i < str.Length; i++)
                {
                    if (start.Children[str[i] - 'a'] == null)
                    {
                        start.Children[str[i] - 'a'] = new Trie();                    
                    }                
                    start = start.Children[str[i] - 'a'];                
                }
                start.IsWord = true;
            }

        private bool isConcatenation(int index, string word, int count)
            {

                Trie ptr = root;

                for (int i = index; i < word.Length; i++)
                {
                    if (ptr.Children[word[i] - 'a'] == null)
                        return false;
                    ptr = ptr.Children[word[i] - 'a'];
                    if (ptr.IsWord)
                    {
                        if (i == word.Length - 1)
                        {
                            return count >= 1;
                        }
                        if (isConcatenation(i + 1, word, count + 1))
                            return true;
                    }
                }

                return false;
            }
        }

        public class Trie{
             public bool IsWord { get; set; }        
                public Trie[] Children { get; set; }

                public Trie()
                {
                    Children = new Trie[26];

                }
        */
    }
}
