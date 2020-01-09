using System;
using System.Collections.Generic;
using System.Text;
/* Given n non-negative integers a1, a2, ..., an , 
 * where each represents a point at coordinate (i, ai). 
 * n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). 
 * Find two lines, which together with x-axis forms a container, such that the container contains the most water.
 * Note: You may not slant the container and n is at least 2.
 * 
 * The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. 
 * In this case, the max area of water (blue section) the container can contain is 49.
 * */
namespace AviPreperation.Data_Structures.Array
{
    public class ContainerWithMostWaterSolution
    {
        //TWO POINTER*****
        //Time complexity - O(N)
        //Sapce Complexity - O(1)
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int ans = 0;

            while (left < right)
            {
                ans = Math.Max(ans, Math.Min(height[left], height[right]) * (right - left));
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return ans;
        }
    }
}
