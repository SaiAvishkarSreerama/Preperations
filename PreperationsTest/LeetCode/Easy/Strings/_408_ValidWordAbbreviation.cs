/*
 * A string can be abbreviated by replacing any number of non-adjacent, non-empty substrings with their lengths. The lengths should not have leading zeros.
 * For example, a string such as "substitution" could be abbreviated as (but not limited to):
 * 
 * "s10n" ("s ubstitutio n")
 * "sub4u4" ("sub stit u tion")
 * "12" ("substitution")
 * "su3i1u2on" ("su bst i t u ti on")
 * "substitution" (no substrings replaced)
 * The following are not valid abbreviations:
 * 
 * "s55n" ("s ubsti tutio n", the replaced substrings are adjacent)
 * "s010n" (has leading zeros)
 * "s0ubstitution" (replaces an empty substring)
 * Given a string word and an abbreviation abbr, return whether the string matches the given abbreviation.
 * 
 * A substring is a contiguous non-empty sequence of characters within a string.
 * 
 * Example 1:
 * Input: word = "internationalization", abbr = "i12iz4n"
 * Output: true
 * Explanation: The word "internationalization" can be abbreviated as "i12iz4n" ("i nternational iz atio n").
 *
 *Example 2:
 * Input: word = "apple", abbr = "a2e"
 * Output: false
 * Explanation: The word "apple" cannot be abbreviated as "a2e".
 * 
 * Constraints:
 * 1 <= word.length <= 20
 * word consists of only lowercase English letters.
 * 1 <= abbr.length <= 10
 * abbr consists of lowercase English letters and digits.
 * All the integers in abbr will fit in a 32-bit integer.
 */

namespace PreperationsTest.LeetCode.Easy.Strings
{
    [TestClass]
    public class _408_ValidWordAbbreviation
    {
        [TestMethod]
        public void Run()
        {
            string word = "internationalization", abbr = "i5a11o1";
            bool res = ValidWordAbbreviation(word, abbr);
        }

        /// <summary>
        /// Algo:
        ///     1. itereate until word and abbr string are done
        ///     2. check if abbr[j] is letter, and see if matched or not and increment i & j
        ///     3. If abbr[j] is digit, check if is 0 and return false, lese get the whole number from abbr and increment i by that skipNum
        ///     4. Finally, if i and j are equal with respective lenghts, return 
        /// TC - O(n), lenght of abbr string, we are not iterating the word string 
        /// SC - O(1), no extra space is used
        /// </summary>
        /// <param name="word"></param>
        /// <param name="abbr"></param>
        /// <returns></returns>
        public bool ValidWordAbbreviation(string word, string abbr)
        {
            int i = 0, j = 0;
            while (i < word.Length && j < abbr.Length)
            {
                // if is a letter
                if (char.IsLetter(abbr[j]))
                {
                    if (word[i] != abbr[j])
                        return false;
                    i++;
                    j++;
                }
                // if not
                else
                {
                    // leading zero not allowed
                    if (abbr[j] == '0') 
                        return false;

                    // get the full num from abbr
                    int skipNum = 0;
                    while (j < abbr.Length && char.IsDigit(abbr[j]))
                    {
                        skipNum = skipNum * 10 + (abbr[j] - '0');
                        j++;
                    }
                    i += skipNum;
                }
            }

            return i == word.Length && j == abbr.Length;
        }
    }
}
