/*
 * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
 * Symbol       Value
 * I             1
 * V             5
 * X             10
 * L             50
 * C             100
 * D             500
 * M             1000
 * For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
 * 
 * Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
 * 
 * I can be placed before V (5) and X (10) to make 4 and 9. 
 * X can be placed before L (50) and C (100) to make 40 and 90. 
 * C can be placed before D (500) and M (1000) to make 400 and 900.
 * Given a roman numeral, convert it to an integer.
 * 
 * Example 1:
 * Input: s = "III"
 * Output: 3
 * Explanation: III = 3.
 * 
 * Example 2:
 * Input: s = "LVIII"
 * Output: 58
 * Explanation: L = 50, V= 5, III = 3.
 * 
 * Example 3:
 * Input: s = "MCMXCIV"
 * Output: 1994
 * Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 * 
 * TC - O(n)
 * SC - O(1), dictionary is fixed size, so O(7) equivalent to constant
 */

namespace PreperationsTest.LeetCode.Easy.Maths
{
    [TestClass]
    public class _13_RomanToInteger
    {
        [TestMethod]
        public void Run()
        {
            string s = "III";
            int integer = RomanToInteger(s);
        }

        /// <summary>
        /// Start from front
        /// If lowest num comes first meand its subtraciton IV = V - I = 4, IX=X-I-9
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInteger(string s)
        {
            Dictionary<char, int> romanToIntDict = new Dictionary<char, int>(){
                {'M', 1000},
                {'D', 500},
                {'C', 100},
                {'L', 50},
                {'X', 10},
                {'V', 5 },
                {'I', 1 }
            };

            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1 && romanToIntDict[s[i]] < romanToIntDict[s[i + 1]])
                {
                    result += (romanToIntDict[s[i+1]] - romanToIntDict[s[i]]);
                    i++; //skip the i+1 index
                }
                else
                {
                    result += romanToIntDict[s[i]];
                }
            }

            return result;
        }

        /// <summary>
        /// Starts from back
        /// Add value to result and hold it as visited(previous), in next iteration compare it with curret and do + or _ accordingly
        /// If less, then subract it, or add it to the result
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInteger_LC(string s)
        {
            Dictionary<char, int> romanToIntDict = new Dictionary<char, int>(){
                {'M', 1000},
                {'D', 500},
                {'C', 100},
                {'L', 50},
                {'X', 10},
                {'V', 5 },
                {'I', 1 }
            };

            int result = 0;
            int previous = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int current = romanToIntDict[s[i]]; 
                result += current > previous ? current : -1 * current;
                previous = current;
            }

            return result;
        }
    }
}
