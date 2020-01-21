using System;
using System.Collections.Generic;
using System.Text;
/*Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
* 
* Example:
* 
* Input:  [1,2,3,4]
* Output: [24,12,8,6]
* Note: Please solve it without division and in O(n).
* 
* Follow up:
* Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)
* */
namespace AviPreperation.Data_Structures.Array
{
    public class ProductofArrayExceptSelfSolution
    {
        //TC - O(N)
        //SC - O(N), used 3 extra spaces for 2 arrays L,R
        public int[] ProductExceptSelf(int[] nums)
        {
            //find prodcut from LEFT
            int[] L = new int[nums.Length];
            L[0] = 1;
            for(int i=1; i<nums.Length; i++){
                L[i] = nums[i - 1] * L[i - 1];
            }

            //find product from Right
            int[] R = new int[nums.Length];
            R[nums.Length - 1] = 1;
            for(int i = nums.Length-2; i>=0; i--){
                R[i] = nums[i + 1] * R[i + 1];
            }

            //result = let*right
            int[] result = new int[nums.Length];
            for(int i=0; i<nums.Length; i++){
                result[i] = L[i] * R[i];
            }

            return result;
        }

        //TC- O(N)
        //SC - O(1)
        public int[] ProductExceptSelf2(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];

            //Left product with out using extra array
            result[0] = 1;
            for (int i = 1; i < n; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            int R = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = result[i] * R;
                R = R * nums[i];
            }

            return result;
        }
    }
}
