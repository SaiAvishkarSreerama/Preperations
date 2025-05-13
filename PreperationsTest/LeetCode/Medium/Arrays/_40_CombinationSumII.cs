/*
 * Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sum to target.
 * Each number in candidates may only be used once in the combination.
 * Note: The solution set must not contain duplicate combinations.
 * 
 * Example 1:
 * Input: candidates = [10,1,2,7,6,1,5], target = 8
 * Output: 
 * [[1,1,6],[1,2,5],[1,7],[2,6]]
 * 
 * Example 2:
 * Input: candidates = [2,5,2,1,2], target = 5
 * Output: 
 * [[1,2,2],[5]]
 * 
 * TC - O(2^n + n log n), nlogn for sorting, each element can either be included or excluded, and duplicates are skipped using sorting and a check. This is tighter than CombinationSum because elements are not reused.
 * SC - O(n), recursion depth is at most n, and each path can hold up to n elements.
 * */
namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _40_CombinationSumII
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { 10, 1, 2, 7, 6, 1, 5 };
            IList<IList<int>> result = CombinationSum2(nums, 8);
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> curr = new List<int>();
            Array.Sort(candidates);
            combinationSumRecursion(candidates, target, 0, curr, result);

            return result;
        }

        public void combinationSumRecursion(int[] candidates, int target, int currIndex, List<int> currList, List<IList<int>> result)
        {
            if (target < 0)
            {
                return;
            }
            else if (target == 0)
            {
                result.Add(new List<int>(currList));
            }
            else
            {

                for (int i = currIndex; i < candidates.Length; i++)
                {
                    if (i > currIndex && candidates[i] == candidates[i - 1])
                    {
                        continue;
                    }
                    if (candidates[i] <= target)
                    {
                        currList.Add(candidates[i]);

                        combinationSumRecursion(candidates, target - candidates[i], i + 1, currList, result);

                        currList.RemoveAt(currList.Count - 1);
                    }
                }
            }
        }
    }
}
