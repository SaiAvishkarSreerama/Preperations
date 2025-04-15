/*
 * You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
 * Find two lines that together with the x-axis form a container, such that the container contains the most water.
 * Return the maximum amount of water a container can store.
 * Notice that you may not slant the container.
 * 
 * Input: height = [1,8,6,2,5,4,8,3,7]
 * Output: 49
 * Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
 * 
 * Example 2:
 * Input: height = [1,1]
 * Output: 1Input: height = [1,8,6,2,5,4,8,3,7]
 * Output: 49
 * Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
 * 
 * Example 2:
 * Input: height = [1,1]
 * Output: 1
*/

namespace PreperationsTest.LeetCode.Medium.Array
{
    [TestClass]
    public class _10_ContainerWithMostWater
    {
        [TestMethod]
        public void Run()
        {
            int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7 ];
            int maxArea = MaxArea(height);
            maxArea = MaxArea_LC(height);
        }

        #region My Solution - Two Pointer - 1ms - 99.81% acceptance
        /// <summary>
        /// Tc - O(N)
        /// SC - O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int maxArea = 0;
            while (i <= j)
            {
                int h = Math.Min(height[i], height[j]);
                int distance = j - i;
                maxArea = Math.Max(maxArea, h * distance);

                if (height[i] <= height[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            return maxArea;
        }
        #endregion

        #region LC Solution - Two Pointer - 0ms - 99.81% acceptancs
        /// <summary>
        /// Tc - O(N)
        /// SC - O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea_LC(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int maxArea = 0;
            int maxHeight = 0;
            while (i <= j)
            {
                if (height[i] <= maxHeight)
                {
                    i++;
                    continue;
                }

                if (height[j] <= maxHeight)
                {
                    j--;
                    continue;
                }

                int distance = j - i;
                maxHeight = Math.Min(height[i], height[j]);
                maxArea = Math.Max(maxArea, maxHeight * distance);
            }

            return maxArea;
        }
        #endregion
    }
}
