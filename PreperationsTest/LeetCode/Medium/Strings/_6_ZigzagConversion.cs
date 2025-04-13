/*
 * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
 * P   A   H   N
 * A P L S I I G
 * Y   I   R
 * And then read line by line: "PAHNAPLSIIGYIR" 
 * 
 * Example 1:
 * Input: s = "PAYPALISHIRING", numRows = 3
 * Output: "PAHNAPLSIIGYIR"
 * 
 * Example 2:
 * Input: s = "PAYPALISHIRING", numRows = 4
 * Output: "PINALSIGYAHRPI"
 * 
 * Explanation:
 * P     I    N
 * A   L S  I G
 * Y A   H R
 * P     I
 * 
 * Example 3:
 * Input: s = "A", numRows = 1
 * Output: "A"
 */
using System.Text;

namespace PreperationsTest.LeetCode.Medium.Strings
{
    [TestClass]
    public class _6_ZigzagConversion
    {
        [TestMethod]
        public void Run()
        {
            //string s = "PAYPALISHIRING";
            string s = "ABC";
            string output = Convert(s, 2);
        }

        #region LeetCode Solution from Vishal Meyyappan R
        /// <summary>
        /// TC - O(N)
        /// SC - O(N)
        /// 
        /// Here instead of forming a matrix, we assume the matrix and as we know for 3rows below are the elements placed
        /// 1st row: 0   4   8     12    16   => spaced 4(0,4,8..)  => 2*numRows-1 = 2(3-1) = 4
        /// 2nd row: 1 3 5 7 9  11 13 15 17   => spaced 4(1,5,9..), => 2*numRows-1 = 2(3-1) = 4,  between 2(3,7) gap => col + 2*numRows-1 - 2*r = col + 2(3-1) -2(1) = col+2
        /// 3rd row: 2   6   10    14    18   => spaced 4(2,6,10..) => 2*numRows-1 = 2(3-1) = 4
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert(string s, int numRows)
        {
            // Base case
            if (numRows == 1)
                return s;

            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < numRows; r++)
            {
                // each value in row is placed at a distance of 2*(numRows-1)
                for (int c = r; c < s.Length; c += 2 * (numRows - 1))
                {
                    sb.Append(s[c]);

                    // condition for middle rows
                    int midRowsPlacement = c + 2 * (numRows - 1) - 2 * r;
                    if (r > 0 && r < numRows - 1 && midRowsPlacement < s.Length)
                    {
                        sb.Append(s[midRowsPlacement]);
                    }
                }
            }
            return sb.ToString();
        }
        #endregion

        #region My Solution
        /// <summary>
        /// My solution: Not the best solution as it takes 30ms compared to 0ms solution below
        /// Time Complexity: O(n)
        /// Space Complexity: O(numRows×n)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert1(string s, int numRows)
        {
            // If given string is less than numRows, we can fit all chars in first col itself, reading the matrix gives you the same given string
            int n = s.Length;
            if (n <= numRows || numRows == 1)
            {
                return s;
            }

            // we dont know how many col required, so taking half of given string length
            char[,] mat = new char[numRows, n];
            int r = 0;
            int c = 0;
            int t = 0;
            bool rowIncrement = true;

            // iterate for each char in the string
            while (t < n)
            {
                // Update the matrix
                mat[r, c] = s[t++];

                // We need to increment the row till max and then decrement row till 0
                if (rowIncrement)
                {
                    r++;
                    // when reach max rows, decrement the rows
                    if (r == numRows - 1)
                    {
                        rowIncrement = false;
                    }
                }
                else if (!rowIncrement)
                {
                    r--;
                    // when row is between thw 0 and max, increment j
                    if (r < numRows - 1)
                    {
                        c++;
                    }
                    // when reach 0 row, increment the row
                    if (r == 0)
                    {
                        rowIncrement = true;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (r = 0; r < numRows; r++)
            {
                for (c = 0; c < n; c++)
                {
                    if (mat[r, c] != '\0')
                    {
                        sb.Append(mat[r, c]);
                    }

                    if (sb.Length == n)
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}
