/*
 * You are given an integer num. You can swap two digits at most once to get the maximum valued number.
 * Return the maximum valued number you can get.
 * 
 * Example 1:
 * Input: num = 2736
 * Output: 7236
 * Explanation: Swap the number 2 and the number 7.
 * 
 * Example 2:
 * Input: num = 9973
 * Output: 9973
 * Explanation: No swap.
 * 
 * Constraints: 0 <= num <= 108
 * 
 * Explanation: To get the max num by swaping, swap the front side min num with last side max num, 52989, we have 2 9's, 1st 9 gives 98289, 2nd 92985(max), so always swap with last occureance of max digit.
 *   1. Convert given num to char array, easy to manipulate as string
 *   2. Iterate char array and note down last occurance of each digit into some array lastAppearance[10]
 *   3. Iterate the given num, for each digit(let say 5xxxxx, 5 is our digit), we check greater number exists on its left side or not, (6 to 9 after 5xxxx9x)
 *   4. For that another loop from 9 to 6(>5), get each num index from lastAppearance[], if that num comes after 5-index, swap them
 *   5. return the charArray parsing as integer.
 */
//Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Maths
{
    [TestClass]
    public class _670_MaximumSwap
    {
        [TestMethod]
        public void Run()
        {
            MaximumSwap(56867898);
        }

        /// <summary>
        /// TC - O(n), where n is no of digits in given num
        ///    - We have two for loops but the second is constant, iterating from 9 t0 1 max.
        /// SC - O(n), used charArray for num manipulation
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MaximumSwap(int num)
        {
            char[] numArr = num.ToString().ToCharArray();
            int[] lastAppear = new int[9];

            for (int i = 0; i < numArr.Length; i++)
            {
                lastAppear[numArr[i] - '0'] = i;
            }

            // for each digit in given num, let say 5, we can only swap with >5 numbers, i.e 6,7,8 or 9.
            // so check if any number exists after 5(current digit)
            // Get each digit from given num
            for( int i = 0; i < numArr.Length; i++)
            {
                int currDigit = numArr[i] - '0';
                // check from 9 to current num(5)
                for (int j = 9; j > currDigit; j--)
                {
                    // we know where the j exists in numArr, we saved it in lastAppearance
                    // if jth number Index > currentDigit Index, swap it
                    if (lastAppear[j] > i)
                    {
                        Swap(i, lastAppear[j], numArr);
                        return int.Parse(numArr);
                    }
                }
            }
            return num;
        }

        public void Swap(int i, int j, char[] arr)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
