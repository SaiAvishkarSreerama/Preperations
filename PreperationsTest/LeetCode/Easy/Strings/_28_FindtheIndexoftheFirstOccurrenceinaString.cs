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


        #region My Code(NAIVE approach) - Beats 100% Time(0m), 87.85% Space(38.78MB)
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
            // Condition: check till haystack-needle lenghts. if needle[0] matches after this lenght, then definetly the full needle chars do not exists
            // mississippi & issipi => total 4-i's in the string to compare,when doing haystack-needle lenghts, we dont need to check for last 2 i's
            for (int j = 0; j <= haystack.Length - needle.Length; j++)
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
                if ((needle[i] != haystack[j++]))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Knutt-Morris-Pratt (KMP) algorithm
        /*
         * In Naive approach, we are repeatedly checking the characters of haystack with needle
         * Ex: haystack - aaaaaaab
         *     needle - aaab, where we check all 5 out of 7-a's, where i=0 to 5 in haystack, for each check we move i++ and do check again
         * Terminology: Ex: abcdabc
         *      Prefix: a, ab, abc, abcd,...
         *      Suffix:c, bc, abc, dabc,...
         * Idea:
         *      1.is to check if there is any prefix matched with suffix? This uses to avoid the comparison.
         *      2. We prepare Pi-Table
         *      
         * TC - O(N+M), where n is lenght of haystack and m is needle. we iterate haystack for n characters,but for needle we only verify the non matching elements, we use the pi table to already found match
         * SC - O(m), pi table to store the needle info
         */
        public int StrStr_KMP(string haystack, string needle)
        {
            // base cases
            if (needle.Length == 0)
            {
                return 0;
            }
            if (haystack.Length == 0)
            {
                return -1;
            }

            // prepare a pi(pi like in apple-pie) table for the needle/pattern
            int[] needlePI = FindingPiTableForNeedle(needle);

            int j = 0;
            int i = 0;
            //Iterate the haystack/string
            while(i < haystack.Length && j < needle.Length)
            {
                if (haystack[i] == needle[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if( j != 0) // same as Pi table, This step ensures that we do not start the comparison from the beginning but from the next best possible prefix length.
                    {
                        j = needlePI[j-1];
                    }
                    else // j is aredy 0th position, then move i
                    {
                        i++;
                    }
                }
            }

            // we matched the string 
            if (j == needle.Length)
                return i - j;

            return -1;
        }

        public int[] FindingPiTableForNeedle(string needle)
        {
            int[] pi = new int[needle.Length];
            pi[0] = 0; // The first element is always 0
            int j = 0; // Pointer for the prefix
            int i = 1; // Pointer for the suffix
            while (i < needle.Length)
            {
                // When needle[j], haystack[i] are equal increment i and j
                if (needle[j] == needle[i])
                {
                    pi[i] = j + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0) // This step ensures that we do not start the comparison from the beginning but from the next best possible prefix length.
                    {
                        j = pi[j - 1];
                    }
                    else // it means there is no proper prefix which is also a suffix for the current character
                    {
                        pi[i] = 0;
                        i++;
                    }
                }
            }

            return pi;
        }
        #endregion
    }
}
