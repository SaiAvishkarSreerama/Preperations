/*
 * Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.
 * The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.
 * The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.
 * 
 * Example 1:
 * Input: candidates = [2,3,6,7], target = 7
 * Output: [[2,2,3],[7]]
 * Explanation:
 * 2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
 * 7 is a candidate, and 7 = 7.
 * These are the only two combinations.
 * 
 * Example 2:
 * Input: candidates = [2,3,5], target = 8
 * Output: [[2,2,2,2],[2,3,3],[3,5]]
 * 
 * Example 3:
 * Input: candidates = [2], target = 1
 * Output: []
 * 
 * TC - O(2^T), the algorithm explores all combinations of candidates that sum up to the target. Since each candidate can be chosen multiple times, the recursion tree can grow exponentially
 *      The branching factor is up to n (number of candidates), and the depth is roughly target / min(candidates).
 * SC - O(T), The maximum depth of the recursion stack is proportional to the target value (in the worst case, you keep adding the smallest candidate until you reach the target).
 * */
namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _39_CombinationSum
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { 2, 3, 6, 7 };
            IList<IList<int>> result = CombinationSum(nums, 7);
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            combinationSumRecursion(candidates, target, 0, new List<int>(), result);

            return result;
        }

        public void combinationSumRecursion(int[] candidates, int target, int currIndex, List<int> currList, List<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(currList));
            }

            for (int i = currIndex; i < candidates.Length; i++)
            {
                if (candidates[i] <= target)
                {
                    currList.Add(candidates[i]);

                    combinationSumRecursion(candidates, target - candidates[i], i, currList, result);

                    currList.RemoveAt(currList.Count - 1);
                }
            }
        }
    }
}
