/*
 *  You are given a 0-indexed array of positive integers w where w[i] describes the weight of the ith index.
 * You need to implement the function pickIndex(), which randomly picks an index in the range [0, w.length - 1] (inclusive) and returns it. The probability of picking an index i is w[i] / sum(w).
 * For example, if w = [1, 3], the probability of picking index 0 is 1 / (1 + 3) = 0.25 (i.e., 25%), and the probability of picking index 1 is 3 / (1 + 3) = 0.75 (i.e., 75%).
 * 
 * Example 1:
 * Input
 * ["Solution","pickIndex"]
 * [[[1]],[]]
 * Output
 * [null,0]
 * Explanation
 * Solution solution = new Solution([1]);
 * solution.pickIndex(); // return 0. The only option is to return 0 since there is only one element in w.
 * 
 * Example 2:
 * Input
 * ["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
 * [[[1,3]],[],[],[],[],[]]
 * Output
 * [null,1,1,1,1,0]
 * Explanation
 * Solution solution = new Solution([1, 3]);
 * solution.pickIndex(); // return 1. It is returning the second element (index = 1) that has a probability of 3/4.
 * solution.pickIndex(); // return 1
 * solution.pickIndex(); // return 1
 * solution.pickIndex(); // return 1
 * solution.pickIndex(); // return 0. It is returning the first element (index = 0) that has a probability of 1/4.
 * 
 * Since this is a randomization problem, multiple answers are allowed.
 * All of the following outputs can be considered correct:
 * [null,1,1,1,1,0]
 * [null,1,1,1,1,1]
 * [null,1,1,1,0,0]
 * [null,1,1,1,0,1]
 * [null,1,0,1,0,0]
 * ......
 * and so on.*/

//Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Maths
{
    [TestClass]
    public class _528_RandomPickwithWeight
    {
        /**
         * Your Solution object will be instantiated and called as such:
         * Solution obj = new Solution(w);
         * int param_1 = obj.PickIndex();
         */
        public class Solution
        {

            private int[] prefixSum;
            private int totalSum = 0;
            private Random random = new Random();

            public Solution(int[] w)
            {
                prefixSum = new int[w.Length];
                for (int i = 0; i < w.Length; i++)
                {
                    this.totalSum += w[i];
                    this.prefixSum[i] = totalSum;
                }
            }

            /// <summary>
            /// Linear Search: 
            ///     TC: O(N)
            ///     SC: O(N)
            ///     
            /// Binary Search: 
            ///     TC: O(logN)
            ///     SC: O(N)
            /// </summary>
            /// <returns></returns>
            public int PickIndex()
            {
                double target = this.totalSum * this.random.NextDouble(); // 0.0 <= random <= 1.0

                // Linear Search to pick index for weight
                // return LinearSearch(target);

                // Binary Search to pick index
                return this.BinarySearch(target);
            }

            public int BinarySearch(double target)
            {
                int low = 0;
                int high = this.prefixSum.Length;

                while (low < high)
                {
                    int mid = low + (high - low) / 2;
                    if (target < this.prefixSum[mid])
                    {
                        high = mid;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                return low;
            }

            public int LinearSearch(double target)
            {
                for (int i = 0; i < this.prefixSum.Length; i++)
                {
                    if (target < this.prefixSum[i])
                    {
                        return i;
                    }
                }

                return this.prefixSum.Length - 1;
            }
        }
    }
}
