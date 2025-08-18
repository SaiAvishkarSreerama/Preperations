/*
 * You are given a nested list of integers nestedList. Each element is either an integer or a list whose elements may also be integers or other lists.
 * The depth of an integer is the number of lists that it is inside of. For example, the nested list [1,[2,2],[[3],2],1] has each integer's value set to its depth.
 * Return the sum of each integer in nestedList multiplied by its depth.
 * 
 * Example 1:
 * Input: nestedList = [[1,1],2,[1,1]]
 * Output: 10
 * Explanation: Four 1's at depth 2, one 2 at depth 1. 1*2 + 1*2 + 2*1 + 1*2 + 1*2 = 10.
 * 
 * Example 2:
 * Input: nestedList = [1,[4,[6]]]
 * Output: 27
 * Explanation: One 1 at depth 1, one 4 at depth 2, and one 6 at depth 3. 1*1 + 4*2 + 6*3 = 27.
 * 
 * Example 3:
 * Input: nestedList = [0]
 * Output: 0
 * 
 * Constraints:
 * 1 <= nestedList.length <= 50
 * The values of the integers in the nested list is in the range [-100, 100].
 * The maximum depth of any integer is less than or equal to 50.
 */

//Companies: @Meta @Google @Apple @MSFT @Amazon
namespace PreperationsTest.LeetCode.Medium.Lists
{
    /**
     * // SAI : I have created the NestedInteger class, please scroll to bottom to see the class
     * // This is the interface that allows for creating nested lists.
     * // You should not implement it, or speculate about its implementation
     * interface NestedInteger {
     *
     *     // Constructor initializes an empty nested list.
     *     public NestedInteger();
     *
     *     // Constructor initializes a single integer.
     *     public NestedInteger(int value);
     *
     *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
     *     bool IsInteger();
     *
     *     // @return the single integer that this NestedInteger holds, if it holds a single integer
     *     // The result is undefined if this NestedInteger holds a nested list
     *     int GetInteger();
     *
     *     // Set this NestedInteger to hold a single integer.
     *     public void SetInteger(int value);
     *
     *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
     *     public void Add(NestedInteger ni);
     *
     *     // @return the nested list that this NestedInteger holds, if it holds a nested list
     *     // The result is undefined if this NestedInteger holds a single integer
     *     IList<NestedInteger> GetList();
     * }
     */
    [TestClass]
    public class Sol_339_NestedListWeightSumution
    {

        [TestMethod]
        public void TestDepthSum()
        {
            var nestedList = new List<NestedInteger>
            {
                new NestedInteger(1),
                new NestedInteger(2),
                new NestedInteger()
            };

            var innerList = new NestedInteger();
            innerList.Add(new NestedInteger(3));
            innerList.Add(new NestedInteger(4));
            nestedList[2].Add(innerList);

            // DFS
            int result = DepthSum_DFS(nestedList);

            // BFS
            result = DepthSum_BFS(nestedList);

            Assert.AreEqual(expected: 1 * 1 + 2 * 1 + (3 * 3 + 4 * 3), actual: result);
        }

        /// <summary>
        /// USing Depth first search(DFS) approach
        /// TC - O(n)
        /// SC - O(n), no extra space but the recursion takes n space
        /// </summary>
        /// <param name="nestedList"></param>
        /// <returns></returns>
        public int DepthSum_DFS(IList<NestedInteger> nestedList)
        {
            int sum = 0;
            foreach (var list in nestedList)
            {
                sum += DepthSum_DFS(list, 1);
            }

            return sum;
        }

        public int DepthSum_DFS(NestedInteger nestedInteger, int level)
        {
            if (nestedInteger.IsInteger())
            {
                return level * nestedInteger.GetInteger();
            }
            else
            {
                int localSum = 0;
                foreach (var list in nestedInteger.GetList())
                {
                    localSum += DepthSum_DFS(list, level + 1);
                }

                return localSum;
            }
        }


        /// <summary>
        /// USing Breadth first search(BFS) approach
        /// TC - O(n)
        /// SC - O(n), Queue holds n integers
        /// </summary>
        /// <param name="nestedList"></param>
        /// <returns></returns>
        public int DepthSum_BFS(IList<NestedInteger> nestedList)
        {
            int sum = 0;
            Queue<(NestedInteger, int)> q = new Queue<(NestedInteger, int)>();
            foreach (var list in nestedList)
            {
                q.Enqueue((list, 1));
            }

            while (q.Count > 0)
            {
                var (childList, level) = q.Dequeue();
                if (childList.IsInteger())
                {
                    sum += level * childList.GetInteger();
                }
                else
                {
                    foreach (var list in childList.GetList())
                    {
                        q.Enqueue((list, level + 1));
                    }
                }
            }

            return sum;
        }
    }

    public class NestedInteger
    {
        private int? singleInteger;
        private List<NestedInteger> nestedList;

        // Constructor initializes an empty nested list.
        public NestedInteger()
        {
            nestedList = new List<NestedInteger>();
        }

        // Constructor initializes a single integer.
        public NestedInteger(int value)
        {
            singleInteger = value;
        }

        // Return true if this NestedInteger holds a single integer, rather than a nested list.
        public bool IsInteger()
        {
            return singleInteger.HasValue;
        }

        // Return the single integer that this NestedInteger holds, if it holds a single integer.
        public int GetInteger()
        {
            return singleInteger ?? 0;
        }

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value)
        {
            singleInteger = value;
            nestedList = null;
        }

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni)
        {
            if (nestedList == null)
            {
                nestedList = new List<NestedInteger>();
                singleInteger = null;
            }
            nestedList.Add(ni);
        }

        // Return the nested list that this NestedInteger holds, if it holds a nested list.
        public IList<NestedInteger> GetList()
        {
            return nestedList;
        }
    }


}
