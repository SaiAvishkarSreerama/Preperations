/*
 * Given a string s, return true if the s can be palindrome after deleting at most one character from it.
 * 
 * Example 1:
 * Input: s = "aba"
 * Output: true
 * 
 * Example 2:
 * Input: s = "abca"
 * Output: true
 * Explanation: You could delete the character 'c'.
 * 
 * Example 3:
 * Input: s = "abc"
 * Output: false
 * 
 * Constraints:
 * 1 <= s.length <= 105
 * s consists of lowercase English letters.
 * */

// Companies: @Meta @Google @Apple @MSFT @ Amazon
namespace PreperationsTest.LeetCode.Easy.Strings
{
    [TestClass]
    public class _680_ValidPalindrome2
    {
        [TestMethod]
        public void Run()
        {
            ValidPalindrome("abc");
        }

        #region Iteration
        //USING ITERATION
        // TC - O(n), It checks atmost 2 times of extra iteration for the i+1,j or i,j-1
        // SC - O(1)
        public bool ValidPalindrome_Iteration(string s)
        {
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j--;
                    continue;
                }
                else
                {
                    // move i and check | move j to check
                    // if both false, then is not a palindrome
                    // if any one is true, then it is a palindrome
                    return checkIfPalidrome(s, i + 1, j) || checkIfPalidrome(s, i, j - 1);
                }
            }
            return true;
        }

        public bool checkIfPalidrome(string s, int i, int j)
        {
            while (i < j)
            {
                if (s[i++] != s[j--])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Recursion
        public bool ValidPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;
            return checkPalidrome(s, i, j, false);
        }

        // TC - O(n), eventhough recursive, it calls for only max of 2 recursive calls
        // SC - O(n), for stack memory for recursive
        public bool checkPalidrome(string s, int i, int j, bool isCharRemoved)
        {
            while (i < j)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j--;
                    continue;
                }
                else
                {
                    if (isCharRemoved)
                    {
                        return false;
                    }

                    // move i and check
                    // if is false, the we have only check with j-1
                    if (checkPalidrome(s, i + 1, j, true))
                    {
                        return true;
                    }

                    // move j and check
                    // if is false, then return false
                    else if (checkPalidrome(s, i, j - 1, true))
                    {
                        return true;
                    }
                    //if both false
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
