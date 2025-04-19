/*
 * Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
 * A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
 * Example 1:
 * Input: digits = "23"
 * Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
 * 
 * Example 2:
 * Input: digits = ""
 * Output: []
 * 
 * Example 3:
 * Input: digits = "2"
 * Output: ["a","b","c"]
 * 
 * Constraints:
 * 0 <= digits.length <= 4
 * digits[i] is a digit in the range ['2', '9'].
 * 
 * TC - O(4^n), where n is length of the input digits. Each digit can map up to 4 letters (7-pqrs or 9-wxyz).
 * SC - O(4^n), storing the output list for all possible combinations
 */

namespace PreperationsTest.LeetCode.Medium.BackTracking
{
    [TestClass]
    public class _17_LetterCombinationOfAPhoneNumber
    {
        [TestMethod]
        public void Run()
        {
            string digits = "2345";
            IList<string> output = LetterCombinations(digits);
        }

        // Dictionary to store the key-number, values-alphabets as strings
        Dictionary<string, string> d = new Dictionary<string, string>{
            {"2", "abc"},
            {"3", "def"},
            {"4", "ghi"},
            {"5", "jkl"},
            {"6", "mno"},
            {"7", "pqrs"},
            {"8", "tuv"},
            {"9", "wxyz"},
        };
        IList<string> output = new List<string>();
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length != 0)
            {
                // start with empty combination
                BacktrackLetterCombinations("", digits);
            }

            //return the result
            return output;
        }

        public void BacktrackLetterCombinations(string combination, string nextDigits)
        {
            // if digits are empty means, we have a combination 
            if (nextDigits.Length == 0)
            {
                output.Add(combination);
            }
            else
            {
                // get the first digit from the digits:2345
                string digit = nextDigits.Substring(0, 1);

                // get the phone number letters from the dictionary
                string letters = d[digit];

                // ex: 2-abc, iterate each char a, b and c
                // for each char, a: we recursively adds 3-def, 4 and 5
                foreach (char c in letters)
                {
                    // send (a, "345") 
                    BacktrackLetterCombinations(combination + c.ToString(), nextDigits.Substring(1));
                }
            }
        }
    }
}
