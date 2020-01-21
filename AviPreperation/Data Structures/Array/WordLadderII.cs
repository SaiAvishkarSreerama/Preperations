using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class WordLadderIISolution
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            //step1: create a unique comb list for wordlist
            Dictionary<string, HashSet<string>> allCombList = new Dictionary<string, HashSet<string>>();
            PrepareAllCombList(beginWord, allCombList);
            foreach (string word in wordList)
            {
                PrepareAllCombList(word, allCombList);
            }
            //Required a Queue-BFS, Dictianary-ShortestPaths, HashSet-Visited
            Queue<string> q = new Queue<string>();
            q.Enqueue(beginWord);

            HashSet<string> visited = new HashSet<string>();

            Dictionary<string, List<IList<string>>> shortestPaths = new Dictionary<string, List<IList<string>>>();
            shortestPaths.Add(beginWord, new List<IList<string>> { new List<string> { beginWord } });

            //BFS
            while (q.Count > 0)
            {
                var visit = q.Dequeue();

                if (visit == endWord)
                    return shortestPaths[endWord];

                if (visited.Contains(visit))
                    continue;
                visited.Add(visit);
                for (int i = 0; i < visit.Length; i++)
                {
                    StringBuilder sb = new StringBuilder(visit);
                    sb[i] = '*';
                    if (!allCombList.ContainsKey(sb.ToString()))
                        continue;
                    foreach (var word in allCombList[sb.ToString()])
                    {
                        if (visited.Contains(word))
                            continue;
                        foreach (var p in shortestPaths[visit])
                        {
                            var newPath = new List<string>(p);
                            newPath.Add(word);
                            if (!shortestPaths.ContainsKey(word))
                                shortestPaths.Add(word, new List<IList<string>> { newPath });
                            else if (shortestPaths[word][0].Count >= newPath.Count)
                                shortestPaths[word].Add(newPath);
                        }
                        q.Enqueue(word);
                    }
                }
            }
            return new List<IList<string>>();
        }

        public void PrepareAllCombList(string word, Dictionary<string, HashSet<string>> allCombList)
        {
            for (int i = 0; i < word.Length; i++)
            {
                StringBuilder sb = new StringBuilder(word);
                sb[i] = '*';
                if (!allCombList.ContainsKey(sb.ToString()))
                    allCombList.Add(sb.ToString(), new HashSet<string>());
                allCombList[sb.ToString()].Add(word);
            }
        }
        //public static void Main()
        //{
        //    string beginWord = "hit";
        //    string endWord = "cog";
        //    string[] wordList = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };
        //    var obj = new WordLadderIISolution();
        //    obj.FindLadders(beginWord, endWord, wordList);
        //}
    }
}
