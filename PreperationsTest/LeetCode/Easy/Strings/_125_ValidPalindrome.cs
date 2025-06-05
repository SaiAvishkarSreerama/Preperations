/*
 * A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
 * Given a string s, return true if it is a palindrome, or false otherwise.
 * 
 * Example 1:
 * Input: s = "A man, a plan, a canal: Panama"
 * Output: true
 * Explanation: "amanaplanacanalpanama" is a palindrome.
 * 
 * Example 2:
 * Input: s = "race a car"
 * Output: false
 * Explanation: "raceacar" is not a palindrome.
 * 
 * Example 3:
 * Input: s = " "
 * Output: true
 * Explanation: s is an empty string "" after removing non-alphanumeric characters.
 * Since an empty string reads the same forward and backward, it is a palindrome.
 * 
 * Constraints:
 * 1 <= s.length <= 2 * 105
 * s consists only of printable ASCII characters.
 **/

// Companies: @Meta
namespace PreperationsTest.LeetCode.Easy.Strings
{
    [TestClass]
    public class _125_ValidPalindrome
    {
        [TestMethod]
        public void Run()
        {
            string s = "A man, a plan, a canal: Panama";
            bool result = IsPalindrome(s);
        }

        /// <summary>
        /// TC - O(N), two pointer and readin each char once
        /// SC - O(1), no additional space used
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                // Skip any non alphanumeric values
                // Or Simply use built-in method char.IsLetterOrDigit(ch)
                while (i < j && !IsAlphaNumeric(s[i]))
                {
                    i++;
                }
                // Skip any non alphanumeric values
                while (i < j && !IsAlphaNumeric(s[j]))
                {
                    j--;
                }

                if (i < j && char.ToLower(s[i++]) != char.ToLower(s[j--]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the given char is Alpha numeric or not
        /// To use ASCII numbers, cast char to int => (int)c gives the num
        /// (ascii >= 48 && ascii <= 57) || (ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122))
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsAlphaNumeric(char c)
        {
            return ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'));
        }
    }
}
