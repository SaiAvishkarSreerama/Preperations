using System;
using System.Collections.Generic;
using System.Text;
/*Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white and blue.
* Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
* Note: You are not suppose to use the library's sort function for this problem.
* 
* Example:
* Input: [2,0,2,1,1,0]
* Output: [0,0,1,1,2,2]
* Follow up:
* 
* A rather straight forward solution is a two-pass algorithm using counting sort.
* First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
* Could you come up with a one-pass algorithm using only constant space?
* */
namespace AviPreperation.Data_Structures.Array
{
    public class SortColorSolution
    {
        //TC - O(N)
        //SC - O(1)
        public void SortColors(int[] nums)
        {
            int p0 = 0;
            int cur = 0;
            int p2 = nums.Length - 1;

            int temp = 0;
            //one pass
            while (cur <= p2)
            {
                //if seen 0, swap with p0
                if (nums[cur] == 0)
                {
                    temp = nums[cur];
                    nums[cur++] = nums[p0];
                    nums[p0++] = temp;
                }
                else if (nums[cur] == 2)
                {
                    temp = nums[cur];
                    nums[cur] = nums[p2];
                    nums[p2--] = temp;
                }
                else
                {
                    cur++;
                }
            }
        }
    }
}
