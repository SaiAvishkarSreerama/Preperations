/*
 * Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
 * 
 * Example 1:
 * Input: haystack = "sadbutsad", needle = "sad"
 * Output: 0
 * Explanation: "sad" occurs at index 0 and 6.
 * The first occurrence is at index 0, so we return 0.
 * 
 * Example 2:
 * Input: haystack = "leetcode", needle = "leeto"
 * Output: -1
 * Explanation: "leeto" did not occur in "leetcode", so we return -1.
 *  
 * Constraints:
 * 1 <= haystack.length, needle.length <= 104
 * haystack and needle consist of only lowercase English characters.
 */

namespace PreperationsTest.LeetCode.Easy.Strings
{

    [TestClass]
    public class _28_FindtheIndexoftheFirstOccurrenceinaString
    {
        [TestMethod]
        public void Run()
        {
            string needle = "baaa";
            string haystack = "aaaa";
            int k = StrStr(haystack, needle);
        }


        #region My Code - Beats 100% Time(0m), 87.85% Space(38.78MB)
        /// <summary>
        /// Explanation:
        ///     1. Edge cases to return 0 or -1
        ///     2. Iterate through haystack, for each haystack char, if it matched with needle[0], then got to another check
        ///     3. second check is to iterate needle and check if each char is matching with above haystack position, then return true.
        ///     4. Since we are looking for first occurance only, return true when second check is true
        ///     
        /// TC - O(mxn), where m is lenght of haystack and n is lenght of needle, for each char in haystack we check needle(n) elements
        /// SC - O(1), no extra space is used
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            // If two strings are same, return 0
            if (haystack == needle)
            {
                return 0;
            }

            // if haystack is not empty, but needle is empty
            // if haystack is empty
            // if haystack is smaller than needle
            if ((haystack.Length < needle.Length) ||
                haystack.Length == 0 ||
                (haystack.Length > 0 && needle.Length == 0))
            {
                return -1;
            }

            // Iterate through the haystack
            for (int j = 0; j < haystack.Length; j++)
            {
                // When needle first char matches, check for entire string match
                if (haystack[j] == needle[0])
                {
                    if (CheckFullMatch(j, needle, haystack))
                    {
                        // when whole string is matched, return the jth index
                        return j;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Method to check the full
        /// </summary>
        /// <param name="j"></param>
        /// <param name="needle"></param>
        /// <param name="haystack"></param>
        /// <returns></returns>
        public bool CheckFullMatch(int j, string needle, string haystack)
        {
            // ITerate throught the needle
            for (int i = 0; i < needle.Length; i++)
            {
                // when char are not matched, return false
                // check for i & j lenghts, if j reached the end of the haystack but needle means not matched
                if ((i < needle.Length && j == haystack.Length) || (needle[i] != haystack[j++]))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
