using System;
using System.Collections.Generic;
using System.Text;
/*Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest transformation sequence from beginWord to endWord, such that:
* 
* Only one letter can be changed at a time.
* Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
*
* Note:
* 
* Return 0 if there is no such transformation sequence.
* All words have the same length.
* All words contain only lowercase alphabetic characters.
* You may assume no duplicates in the word list.
* You may assume beginWord and endWord are non-empty and are not the same.
*
*Example 1:
* Input:
* beginWord = "hit",
* endWord = "cog",
* wordList = ["hot","dot","dog","lot","log","cog"]
* 
* Output: 5
* 
* Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
* return its length 5.
*
*Example 2:
* Input:
* beginWord = "hit"
* endWord = "cog"
* wordList = ["hot","dot","dog","lot","log"]
* 
* Output: 0
* 
* Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.*/
namespace AviPreperation.Data_Structures.Array
{
    //Time Complexity = O(N*M), n is no of words in wordlist, M is length of the words
    //SpaceComplexitu = O(N*M), n is size of visited dictionary, M transformations for each of N words
    public class Pair
    {
        public string key;
        public int level;
        public Pair(string _key, int _level)
        {
            key = _key;
            level = _level;
        }
    }

    public class WordLadderSolution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            //since all words are same length
            int L = beginWord.Length;

            //we need a dictionary for wordlist sequence words
            Dictionary<string, List<string>> allCombDict = new Dictionary<string, List<string>>();

            //for each word in wordlist, hot ==> *ot, h*t, ho* are the possible word combinations
            foreach (string word in wordList)
            {
                for (int i = 0; i < L; i++)
                {
                    string newWord = word.Substring(0, i) + '*' + word.Substring(i + 1);

                    if (allCombDict.ContainsKey(newWord))
                        allCombDict[newWord].Add(word);
                    else
                        allCombDict.Add(newWord, new List<string> { word });
                }
            }

            //we need a Queqe for BFS and a Dictionary for Visited node marking
            //Queue will maintain the word and its level
            Queue<Pair> Q = new Queue<Pair>();
            Q.Enqueue(new Pair(beginWord, 1));

            //Dictinary to maintian the visited words
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            visited.Add(beginWord, true);

            //BFS Iterative
            while (Q.Count > 0)
            {
                Pair node = Q.Dequeue();
                string key = node.key;
                int level = node.level;
                for (int i = 0; i < L; i++)
                {
                    string newWord = key.Substring(0, i) + "*" + key.Substring(i + 1);

                    if (!allCombDict.ContainsKey(newWord))
                        continue;

                    foreach (var word in allCombDict[newWord])
                    {
                        if (word == endWord)
                            return level + 1;

                        if (!visited.ContainsKey(word))
                        {
                            Q.Enqueue(new Pair(word, level + 1));
                            visited.Add(word, true);
                        }
                    }
                }
            }

            return 0;
        }
    }

    //Time Complexity = O(N*M), n is no of words in wordlist, M is length of the words
    //SpaceComplexitu = O(N*M), n is size of visited dictionary, M transformations for each of N words
    //Using Bi-Directional BFS
    //Only difference is doing BFS from both ends which requires, 
        //2 Queues for beign and end word
        //2 Dictionaries for visited words for begin and end
        //in first scenario our termination conidition is work == endWord, here if visited_begin and visited_end both has same value

    public class WordLadderSolution_BIDIRECTIONALBFS
    {
        //since all words are same length
        public int L;
        //we need a dictionary for wordlist sequence words
        public Dictionary<string, List<string>> allCombDict;

        public WordLadderSolution_BIDIRECTIONALBFS()
        {
            L = 0;
            allCombDict = new Dictionary<string, List<string>>();
        }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            L = beginWord.Length;

            if (!wordList.Contains(endWord))
                return 0;

            //for each word in wordlist, hot ==> *ot, h*t, ho* are the possible word combinations
            foreach (string word in wordList)
            {
                for (int i = 0; i < L; i++)
                {
                    string newWord = word.Substring(0, i) + '*' + word.Substring(i + 1);

                    if (allCombDict.ContainsKey(newWord))
                        allCombDict[newWord].Add(word);
                    else
                        allCombDict.Add(newWord, new List<string> { word });
                }
            }

            //we need a Queqe for BFS and a Dictionary for Visited node marking
            //Queue will maintain the word and its level
            Queue<Pair> Q_Begin = new Queue<Pair>();
            Q_Begin.Enqueue(new Pair(beginWord, 1));

            Queue<Pair> Q_End = new Queue<Pair>();
            Q_End.Enqueue(new Pair(endWord, 1));

            //Dictinary to maintian the visited words
            Dictionary<string, int> visited_Begin = new Dictionary<string, int>();
            visited_Begin.Add(beginWord, 1);

            Dictionary<string, int> visited_End = new Dictionary<string, int>();
            visited_End.Add(endWord, 1);

            //BFS Iterative
            while (Q_Begin.Count > 0 && Q_End.Count > 0)
            {
                int ans = visitWordNode(Q_Begin, visited_Begin, visited_End);
                if (ans > -1)
                    return ans;

                ans = visitWordNode(Q_End, visited_End, visited_Begin);
                if (ans > -1)
                    return ans;

            }

            return 0;
        }

        public int visitWordNode(Queue<Pair> Q, Dictionary<string, int> visited, Dictionary<string, int> visited_Other)
        {
            Pair node = Q.Dequeue();
            string key = node.key;
            int level = node.level;
            for (int i = 0; i < L; i++)
            {
                string newWord = key.Substring(0, i) + "*" + key.Substring(i + 1);

                if (!allCombDict.ContainsKey(newWord))
                    continue;

                foreach (var word in allCombDict[newWord])
                {
                    if (visited_Other.ContainsKey(word))
                        return level + visited_Other[word];

                    if (!visited.ContainsKey(word))
                    {
                        Q.Enqueue(new Pair(word, level + 1));
                        visited.Add(word, level + 1);
                    }
                }
            }
            return -1;
        }
    }
}
