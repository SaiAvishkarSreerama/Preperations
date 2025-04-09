/*
 * Sliding window technique
 *  1. Start i=0; j=1
 *  2. Move j and if that char not seen before, add it to the hashset.
 *  3. If seen, remove the ith char and i++, means we are moving i repeat check for j untill j is not seen, once we are clear then hold i there and continue moving j.
 *      i. before removing ith char from set, update the longest substring using math.max.
 *      
 *  TC - O(N), Iterating the entire string
 *  SC - O(N), we use set to store n-characters in worst case, O(min(m,n)), where m is size of the hashset and n is the given string
 */
namespace PreperationsTest.LeetCode.Medium.Strings
{
    [TestClass]
    public class _3_LongestSubstringWithOutRepChars
    {
        [TestMethod]
        public void Run()
        {
            string s = "au";
            int longestSubstring = LengthOfLongestSubstring(s);
        }

        /// <summary>
        /// Return the Longest substring lenght
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return s.Length;

            int i = 0;
            int j = 0;
            int longestSubString = 0;
            HashSet<char> hSet = new HashSet<char>();

            // Sliding window, i-->j, i---->j, --i->j
            // move j until seen char, then i++, remove s[i].
            // Check long sub string for each iteration
            while (j < s.Length)
            {
                if (!hSet.Contains(s[j]))
                {
                    hSet.Add(s[j]);
                    j++;
                }
                else
                {
                    hSet.Remove(s[i]);
                    i++;
                }
                longestSubString = Math.Max(longestSubString, j - i);
            }

            return longestSubString;
        }

        /// <summary>
        /// Interested answer, but uses int[256] ASCII array to mark the visited characters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring_SolFromLeetCode(string s)
        {
            // Maximum length of substring without repeating characters
            int maxLength = 0;

            // Left pointer for the sliding window
            int left = 0;

            // Array to store the last seen index of each character (ASCII only)
            Span<int> lastSeenIndices = stackalloc int[256];
            for (int i = 0; i < lastSeenIndices.Length; i++)
            {
                lastSeenIndices[i] = -1; // Initialize all indices to -1
            }

            // Iterate through the string with the right pointer
            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];

                // If the current character was seen within the current window
                if (lastSeenIndices[currentChar] >= left)
                {
                    // Move the left pointer just past the last occurrence of the character
                    left = lastSeenIndices[currentChar] + 1;
                }

                // Update the last seen index of the current character
                lastSeenIndices[currentChar] = right;

                // Calculate the length of the current substring and update maxLength
                int currentLength = right - left + 1;
                maxLength = Math.Max(maxLength, currentLength);
            }

            return maxLength;
        }
    }
}
