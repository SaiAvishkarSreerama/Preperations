using System;
using System.Collections.Generic;
using System.Text;
/*Given a function rand7 which generates a uniform random integer in the range 1 to 7, write a function rand10 which generates a uniform random integer in the range 1 to 10.
* Do NOT use system's Math.random().
* 
* Example 1:
* Input: 1
* Output: [7]
* 
* Example 2:
* Input: 2
* Output: [8,4]
* 
* Example 3:
* Input: 3
* Output: [8,1,10]
* 
* Note:
* rand7 is predefined.
* Each testcase has one argument: n, the number of times that rand10 is called.
* 
* 
* *** Solution Explanation: ***
* This solution is based upon Rejection Sampling. The main idea is when you generate a number in the desired range, 
* output that number immediately. If the number is out of the desired range, reject it and re-sample again. As each 
* number in the desired range has the same probability of being chosen, a uniform distribution is produced.
* 
* Obviously, we have to run rand7() function at least twice, as there are not enough numbers in the range of 1 to 10.
* By running rand7() twice, we can get integers from 1 to 49 uniformly. Why?
* 
* 
* rejectionSamplingTable
* A table is used to illustrate the concept of rejection sampling. Calling rand7() twice will get us row and column index 
* that corresponds to a unique position in the table above. Imagine that you are choosing a number randomly from the table above.
* If you hit a number, you return that number immediately. If you hit a * , you repeat the process again until you hit a number.
* 
* Since 49 is not a multiple of 10, we have to use rejection sampling. Our desired range is integers from 1 to 40, 
* which we can return the answer immediately. If not (the integer falls between 41 to 49), we reject it and repeat the 
* whole process again.
* * */
namespace AviPreperation.Data_Structures.Array
{
    /**
     * The Rand7() API is already defined in the parent class SolBase.
     * public int Rand7();
     * @return a random integer in the range 1 to 7
     */
    public class SolBase
    {
        public int Rand7()
        {
            Random rnd = new Random();
            return rnd.Next(0, 7);
        }
    }


    //Time Complexity: O(1) average, but O(\infty)O(∞) worst case.
    //Space Complexity: O(1).
    public class Rand10_Using_Rand7Solution : SolBase
    {
        public int Rand10()
        {
            int row, col, idx;
            do
            {
                row = Rand7();
                col = Rand7();
                idx = col + (row - 1) * 7;
            } while (idx > 40);
            return 1 + (idx - 1) % 10;
        }
    }
}
