/*
 * There are n buildings in a line. You are given an integer array heights of size n that represents the heights of the buildings in the line.
 * The ocean is to the right of the buildings. A building has an ocean view if the building can see the ocean without obstructions. Formally, a building has an ocean view if all the buildings to its right have a smaller height.
 * Return a list of indices (0-indexed) of buildings that have an ocean view, sorted in increasing order.
 * 
 * Example 1:
 * Input: heights = [4,2,3,1]
 * Output: [0,2,3]
 * Explanation: Building 1 (0-indexed) does not have an ocean view because building 2 is taller.
 * 
 * Example 2:
 * Input: heights = [4,3,2,1]
 * Output: [0,1,2,3]
 * Explanation: All the buildings have an ocean view.
 * 
 * Example 3:
 * Input: heights = [1,3,2,4]
 * Output: [3]
 * Explanation: Only building 3 has an ocean view.
 * 
 * Constraints:
 * 1 <= heights.length <= 105
 * 1 <= heights[i] <= 109
 *  */

// Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _1762_BuildingsWithAnOceanView
    {
        [TestMethod]
        public void Run()
        {
            int[] heights = {4, 3, 2, 1};
            FindBuildings(heights);
        }

        /// <summary>
        /// Traversing from end
        /// 1. check curr building is taller than maxheight of building that we seen so far and push to result
        /// TC - O(n)
        /// SC - O(n)
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int[] FindBuildings(int[] heights)
        {
            List<int> result = new List<int>();
            int maxHeight = 0;
            int i = heights.Length - 1;
            // Move to 1st building from last but one building
            while (i >= 0)
            {
                // If current building is taller than our max height building 
                if (heights[i] > maxHeight)
                {
                    maxHeight = heights[i]; //now current building is the taller one
                    result.Add(i); // insert at front, as ans is expecting to be in sorting order
                }
                i--;
            }

            result.Reverse();
            return result.ToArray();
        }

        /// <summary>
        /// Traversing from start
        /// 1. push the current index to stack
        /// 2. before that see if any buildin(index form stack peek()) is smaller than current building, if so remove it (pop())
        /// 3. If stack is empty means, curret building is taller than previous building and have ocean view, add to result array or resturn the stack at last
        /// 4. Now our result array (asc order) or stack (desc order), return result or stack.reverse
        /// 
        /// TC - O(n)
        /// SC - O(1), no auxialary space used other than ourput array
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int[] FindBuildings_Start(int[] heights)
        {

            int n = heights.Length;
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                // Remove buildings from stack that are shorter than or equal to current
                while (stack.Count > 0 && heights[i] >= heights[stack.Peek()])
                {
                    stack.Pop();
                }

                stack.Push(i);
            }

            // Stack contains indices in reverse order, so reverse it
            return stack.Reverse().ToArray();

        }
    }
}
