/*
 * You are given a string s and an array of strings words. All the strings of words are of the same length.
 * A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated.
 * For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.
 * Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order.
 * 
 * Example 1:
 * Input: s = "barfoothefoobarman", words = ["foo","bar"]
 * Output: [0,9]
 * Explanation:
 * The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is a permutation of words.
 * The substring starting at 9 is "foobar". It is the concatenation of ["foo","bar"] which is a permutation of words.
 * 
 * Example 2:
 * Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
 * Output: []
 * Explanation:
 * There is no concatenated substring.
 * 
 * Example 3:
 * Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
 * Output: [6,9,12]
 * Explanation:
 * The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"].
 * The substring starting at 9 is "barthefoo". It is the concatenation of ["bar","the","foo"].
 * The substring starting at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"].
 * 
 * Constraints:
 * 1 <= s.length <= 104
 * 1 <= words.length <= 5000
 * 1 <= words[i].length <= 30
 * s and words[i] consist of lowercase English letters.
 */

namespace PreperationsTest.LeetCode.Hard.Strings
{
    [TestClass]
    public class _30_substringWithConcatenationOfAllWords
    {
        [TestMethod]
        public void Run()
        {
            string s = "wordgoodgoodgoodbestword";
            string[] words = { "word", "good", "best", "good" };

            IList<int> result = FindSubstring(s, words);
        }

        /// <summary>
        /// Explanation:
        ///     1. Create a dictionary for Words array with its frequency
        ///     2. Iterates through each char of string from i=0 to i=word length
        ///         a. we start out window left = i, iterate to each word from there and check if the word in wordMap, add it to another seen dict, and count the words, wordCount++;.
        ///         b. If the current word in seenDict is more times than in wordMap, move out left window until we get seen[currenWord]==wordMap[currentWord]
        ///         c. When totalwords = wordcount, add left to result.
        ///     3. If the word not seen in wordMap, move to next word, left+=wordcount;reset all local variabels: wordCount, seenWord[], 
        ///     
        /// TC - O(m+n)
        ///     Initialization of wordsMap: This involves iterating over the words array once, which takes O(m) time, where m is the number of words.
        ///     Outer Loop: The outer loop runs wordLength times, which is a constant relative to the input size n
        ///     Inner Loop: The inner loop iterates over the string s from index i to n - wordLength, which runs O(n) times.
        ///     
        /// SC - O(n+m)
        ///     wordsMap Dictionary: This dictionary stores the count of each word in words, which takes O(m) space.
        ///     seenWords Dictionary: This dictionary stores the count of each word in the current window, which also takes O(m) space.
        ///     Result List: The list to store the starting indices can take up to O(n) space in the worst case.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> result = new List<int>();
            if (s == null || words == null || words.Length == 0 || s.Length < (words[0].Length * words.Length))
            {
                return result;
            }

            // Initializing the dictionary
            Dictionary<string, int> wordsMap = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!wordsMap.ContainsKey(word))
                {
                    wordsMap.Add(word, 0);
                }
                wordsMap[word]++;
            }

            int wordLength = words[0].Length; // we know each word is of same length
            int totalWords = words.Length;

            // Iterated the string, i goes to only one word length
            // wordgoodgood..., when i from w to d(word) we also check good, good, good, best word etc remaining words, so no need to check after the first word lenght again
            // Sliding Window
            for (int i = 0; i < wordLength; i++)
            {
                Dictionary<string, int> seenWords = new Dictionary<string, int>();
                int wordsFound = 0;
                int left = i;

                // for each i, we check the next following substring contains all permutations of words 
                // if any word is missing we break the loop and check the remaining
                for (int j = i; j <= s.Length - wordLength; j += wordLength)
                {
                    // Get the sub string for each char we are at
                    string currentWord = s.Substring(j, wordLength);
                    if (wordsMap.ContainsKey(currentWord))
                    {
                        if (!seenWords.ContainsKey(currentWord))
                        {
                            seenWords.Add(currentWord, 0);
                        }
                        seenWords[currentWord]++;
                        wordsFound++;

                        // remove the left window word untill we see the exact count of current word
                        // extra word comes, we slide our window to left passing that word
                        while (seenWords[currentWord] > wordsMap[currentWord])
                        {
                            string leftWord = s.Substring(left, wordLength);
                            seenWords[leftWord]--;
                            wordsFound--;
                            left += wordLength;
                        }

                        // add the current index to result
                        if (wordsFound == totalWords)
                        {
                            result.Add(left);
                            string leftWord = s.Substring(left, wordLength);
                            seenWords[leftWord]--;
                            wordsFound--;
                            left += wordLength;
                        }
                    }
                    else
                    {
                        // If the word not in word map, clear seenwords, wordFound, and move left window to next word
                        seenWords.Clear();
                        wordsFound = 0;
                        left = j + wordLength;
                    }

                }
            }

            return result;
        }
    }
}
