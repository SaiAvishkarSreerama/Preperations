using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreperationsTest.DataStructures.Trie
{
    [TestClass]
    public class TrieImplementation
    {
        /// <summary>
        /// Insert a key into the trie
        /// </summary>
        /// <param name="key"></param>
        public void InsertKey(Trie root, string key)
        {
            Trie currentNode = root;

            foreach (char c in key)
            {
                int currentIndex = c - 'a';
                if (currentNode.childNode[currentIndex] == null)
                {
                    currentNode.childNode[currentIndex] = new Trie();
                }

                currentNode = currentNode.childNode[currentIndex];
            }

            currentNode.wordCount++;
        }

        /// <summary>
        /// Search for a key in the trie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool SearchKey(Trie root, string key)
        {
            Trie currentNode = root;

            foreach (char c in key)
            {
                int currentIndex = c - 'a';
                if (currentNode.childNode[currentIndex] == null)
                {
                    return false;
                }

                currentNode = currentNode.childNode[currentIndex];
            }

            return currentNode.wordCount > 0;
        }

        /// <summary>
        /// Delete a key from the trie
        /// Conditions:
        ///     1. If the key is prefix of another key, then do not delete the key
        ///     2. If the key is not prefix of another key, then delete the key
        ///     3. If the key is not present in the trie, then do nothing
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteKey(Trie root, string key)
        {
            Trie currentNode = root;
            Trie lastBranchNode = null;
            int lastBranchIndex = 0;

            foreach (char c in key)
            {
                int currentIndex = c - 'a';
                // If the key is not present in the trie, then do nothing
                if (currentNode.childNode[currentIndex] == null)
                {
                    return false;
                }
                else
                {
                    // Iterate to check if the key is prefix of another key
                    // For example, if the key is 'the', then we check if there are any other child nodes with values after the 'e' node,
                    // and preserve the last branch node and index
                    int count = 0;
                    for (int i = 0; i < 26; i++)
                    {
                        if (currentNode.childNode[i] != null)
                        {
                            count++;
                        }
                    }

                    // means the word has other ending words an, and, any, answer
                    // If we try to delete and, we cannot detele it as its prefix shares with an, any, answer.
                    // so we preserve the current node 'n' from 'and' and make the work count of its childnode 'd'
                    if(count > 1)
                    {
                        lastBranchNode = currentNode;
                        lastBranchIndex = c - 'a';
                    }
                    currentNode = currentNode.childNode[c - 'a'];
                }
            }

            // We are currently at our last node of the string (ex: the, at 'e' node)
            // we check if there are any other child nodes with values, means our word 'the' is prefix of the other words 'their'
            int wordCount = 0;
            for (int i = 0; i < 26; i++)
            {
                if (currentNode.childNode[i] != null)
                {
                    wordCount++;
                }
            }

            //case 1: The deleted word is a prefix of other words in Trie
            if (wordCount > 0)
            {
                currentNode.wordCount--;
                return true;
            }

            //case 2: The deleted word shares a common prefix with other words in Trie
            if (lastBranchNode != null)
            {
                lastBranchNode.childNode[lastBranchIndex] = null;
                return true;
            }

            // case 3: The deleted word is a unique word in Trie
            else
            {
                root.childNode[key[0] - 'a'] = null;
                return true;
            }
        }

        [TestMethod]
        public void TrieDataStructureImplementation()
        {
            Trie root = new Trie();
            string[] keys = { "the", "a", "there", "answer", "an", "and", "any", "doop", "their" };
            //foreach (string key in keys)
            //{
            //    InsertKey(root, key);
            //}

            //Console.WriteLine(SearchKey(root, "the"));
            //Console.WriteLine(SearchKey(root, "these"));
            //Console.WriteLine(SearchKey(root, "their"));
            //Console.WriteLine(SearchKey(root, "thaw"));

            InsertKey(root, "doop");
            Console.WriteLine(SearchKey(root, "doop"));

            // IS prefix of other words the => there, their
            DeleteKey(root, "the");
            Console.WriteLine(SearchKey(root, "the"));

            // Share the common prefix with other words and => an, any, answer
            DeleteKey(root, "and");
            Console.WriteLine(SearchKey(root, "the"));

            // Unique word in Trie bye
            DeleteKey(root, "doop");
            Console.WriteLine(SearchKey(root, "doop"));
        }
    }
}
