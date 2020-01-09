using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/problems/trapping-rain-water/
/*Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.
* 
* The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1].
* In this case, 6 units of rain water (blue section) are being trapped. 
* Thanks Marcos for contributing this image!
* 
* Example:
* Input: [0,1,0,2,1,0,1,3,2,1,2,1]
* Output: 6
*/
namespace AviPreperation.Data_Structures.Array
{
    public class TrappingRainWater
    {
        /*****************************************Approach 1: DP*************************************************/
        //USING DYNAMIC PROGRAMMING
        //Time Complexity - O(N)
        //Space complexity - O(N)
        public int Trap(int[] height)
        {
            int totalVolume = 0;
            int n = height.Length;
            if (n == 0)
                return totalVolume;

            //let take two arrays to find the left and right max values od that index
            int[] left_Max = new int[n];
            int[] right_Max = new int[n];

            //fill the max values of both left, right max arrays
            left_Max[0] = height[0]; //To move from front to add max values
            right_Max[n - 1] = height[n - 1]; //To move from back to add max values

            for (int i = 1; i < n - 1; i++)
                left_Max[i] = Math.Max(height[i], left_Max[i - 1]);

            for (int i = n - 2; i >= 0; i--)
                right_Max[i] = Math.Max(height[i], right_Max[i + 1]);

            //iterate through the height and add min of left,right max valeus to current index height
            for (int i = 0; i < n - 1; i++)
                totalVolume += Math.Min(left_Max[i], right_Max[i]) - height[i];

            return totalVolume;

        }

        /*****************************************Approach 2: STACK*************************************************/
        //USING STACK
        //Time Complexity -O(N)
        //Space Complexity -O(N)
        public int Trap1(int[] height)
        {
            int totalVolume = 0;
            Stack<int> stack = new Stack<int>();
            for (int right = 0; right < height.Length; right++)
            {
                //go only when previous value in stack is less then current value, which means the current height 
                //acts as a right side wall to store the water and the previous value in stack is max depth
                while (stack.Count > 0 && height[stack.Peek()] < height[right])
                {
                    int bottom = stack.Pop();

                    //after we pop bottom, if stack empty means there is no left wall to form a closure, so break it
                    if (stack.Count == 0)
                        break;

                    //after removing the bottom, we should have a left wall
                    int left = stack.Peek();

                    //to find water height, we should take the min heights of right and left as boundary height
                    //heights of right , left - bottom gives the min volume of water can store
                    //and right-left-1 gives the distnace
                    int distance = right - left - 1;
                    int water = Math.Min(height[right], height[left]) - height[bottom];

                    totalVolume += distance * water;

                }
                //push the current height
                stack.Push(right);
            }
            return totalVolume;
        }

        /***********************************Approach 3: TWO POINTER******************************************************/
        //TWO POINTER
        //TimeComplexity - O(N), twopointer iterating at one iteration
        //SpaceComplexity - O(1), no extra space is using
        public int Trap2(int[] height)
        {
            int ans = 0;
            int leftMax = 0;
            int rightMax = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                //h[left] < h[right]
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                        leftMax = height[left];
                    else
                        ans += leftMax - height[left];
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                        rightMax = height[right];
                    else
                        ans += rightMax - height[right];
                    right--;
                }
            }
            return ans;
        }
    }
}
