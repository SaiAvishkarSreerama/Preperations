/*Given a string s, return the longest palindromic substring in s.
* 
* Example 1:
* Input: s = "babad"
* Output: "bab"
* Explanation: "aba" is also a valid answer.
* 
* Example 2:
* Input: s = "cbbd"
* Output: "bb"
* 
* Constraints:
* 1 <= s.length <= 1000
* s consist of only digits and English letters.
*
*   TC:
*   Naive Solution takes O(N^3) times
*   Dynamic Programming takes O(N^2)
*   Manachars algorithm takes O(N)
*    
 */

using System.Text;

namespace PreperationsTest.LeetCode.Medium.Strings
{
    [TestClass]
    public class _5_LongestPalindromicSubstring
    {
        [TestMethod]
        public void Run()
        {
            string s = "abcdedcba";
            s = LongestPalidromicSubstring_DynamicProgram(s);
            s = LongestPalidromicSubstring_Manachers(s);
        }

        #region Dynamic Programming
        /// <summary>
        /// Dynamic programming
        /// TC - O(N^2)
        /// SC - O(N^2) - 2D matrix used for dp
        /// Explanation:
        ///     1. we start from bottom to up approach(iterations) from n-1 to 0
        ///     2. i goes from n-1 to 0
        ///     3. j goes from i to n
        ///     4. i.e, [i,j] => [5, 5], [4, 4,5], [3, 3,4,5], [2, 2,3,4,5], [1, 1,2,3,4,5], [0, 0,1,2,3,4,5]
        ///     5. for each iteration we track dp[i,j], if s[i]==s[j] and j-1+1 < 3 or dp[i+1, j-1] is true, which is the middle string between i and j
        ///     6. When lenght >result we note down the substring
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalidromicSubstring_DynamicProgram(string s)
        {
            if (s == "")
                return s;

            int n = s.Length;
            string result = "";
            bool[,] dp = new bool[n, n];

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i; j < n; j++)
                {
                    int currentStringLength = j - i + 1;
                    // j-i+1 gives lenght of the substring
                    // if is <3 means single char(always a palindrom) or 2chars(if equal)
                    dp[i, j] = s[i] == s[j] && (currentStringLength < 3 || dp[i + 1, j - 1]);

                    if (dp[i, j] && currentStringLength > result.Length)
                    {
                        result = s.Substring(i, currentStringLength);
                    }
                }
            }

            return result;
        }
        #endregion

        #region Manachars Algorithm
        /// <summary>
        /// TC - O(N)
        /// SC - O(N)
        /// Every time we get a center and righ side boundary
        /// when traverse from center to rightBoundary, use the mirror char numbers
        /// When crossed the right boundary, that position is our new center, and rightBoundary is palindrom boundary P[i] for the currentCenter i
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalidromicSubstring_Manachers(string s)
        {
            string T = MancharsStringBuilder(s);
            int n = T.Length;
            int[] P = new int[n];
            P[0] = 0;
            P[1] = 1;
            int Center = 1;
            int RightBoundary = 2;

            // i - is current position
            for (int i = 2; i < n - 1; i++)
            {
                // Get the mirror character position (mirror for 5 = 1)--(mirror for 4 = 2)--(3, center!)--(i=4)--(i=5) <==> [1 2 3 4 5] => [mirror5 mirror4 center3 4 5]
                int mirror = 2 * Center - i;

                // If currentposition is with in the boundary of previous pallindrom
                // means, its mirror character already have a number, get it
                P[i] = i < RightBoundary ? Math.Min(RightBoundary - i, P[mirror]) : 0;

                while ((i - 1) - P[i] >= 0 &&                           // leftSideCharacters -> (i - 1) - P[i]
                    (i + 1) + P[i] <= n - 1 &&                          // RightSideCharacters -> (i + 1) + P[i]
                    T[(i - 1) - P[i]] == T[(i + 1) + P[i]])             // T[leftSideCharacters] == T[RightSideCharacters]
                {
                    P[i]++;
                }

                int currentCenter = i + P[i];
                if (currentCenter > RightBoundary)
                {
                    Center = i;
                    RightBoundary = currentCenter;
                }
            }

            int maxLength = 0;
            int centerIndex = 0;
            for (int i = 0; i < P.Length; i++)
            {
                if (P[i] > maxLength)
                {
                    maxLength = P[i];
                    centerIndex = i;
                }
            }

            return s.Substring((centerIndex - maxLength) / 2, maxLength);
        }

        public string MancharsStringBuilder(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                sb.Append('|');
                sb.Append(c);
            }
            sb.Append("|");

            return sb.ToString();
        }
        #endregion

        #region BruteForce - Incomplete
        /// <summary>
        /// Naive/ Brute force: incomplete
        /// TC - O(N^3)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalidromicSubstring(string s)
        {
            if (s == "")
            {
                return s;
            }

            int startIndex = 0;
            int endIndex = -1;
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                if (s[i] == s[j])
                {
                    if (endIndex != -1)
                    {
                        startIndex = i;
                        endIndex = j;
                    }
                    i++;
                    j--;
                }
                else
                {
                    endIndex = startIndex;
                    j--;
                }
            }

            return s.Substring(startIndex, endIndex - startIndex + 1);
        }
        #endregion
    }
}
