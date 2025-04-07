/*
 * TC - O(n * W)
 * SC - O(n * W)
 * 
 * Explanation:
 *      1. form a n*W matrix, where n is no of weight, W is max weight
 *      2. Iterate through each row (i <= n), and columns (w <= W)
 *      3. check if the current weight w <= weight[i], then use the formula to fill the pick weight: current profits + knapsack[prev row, diff weight {w - weights[i - 1]}];
 *          if not get the non-picked weight from previous row, use max(pick, non-pick) to fill the value.
 */

namespace PreperationsTest.Algorithms.DynamicProgramming
{
    [TestClass]
    public class _01KnapsackProblem
    {
        [TestMethod]
        public void Run()
        {
            int[] profits = { 1, 2, 5, 6 };
            int[] weights = { 2, 3, 4, 5 };
            int maxWeight = 8;

            int[,] dp = KnapSacProblem0_1(profits, weights, maxWeight);

            int[] output = new int[profits.Length];
            // print what weight are considered as 1 and not-considered as 0 [0, 1, 0, 1]

            int i = weights.Length;
            int j = maxWeight;

            while (i > 0 && j > 0)
            {
                if (dp[i, j] == dp[i - 1, j]) // if above value of table is same means the current weight is not added
                {
                    output[i - 1] = 0;
                    i--;
                }
                else
                {
                    output[i - 1] = 1;
                    i--;
                    j = j - weights[i];
                }
            }
        }


        public int[,] KnapSacProblem0_1(int[] profits, int[] weights, int maxWeight)
        {
            int[,] knapsack = new int[profits.Length + 1, maxWeight + 1];

            for (int i = 0; i <= profits.Length; i++)
            {
                for (int w = 0; w <= maxWeight; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        knapsack[i, w] = 0;
                    }
                    else
                    {
                        int pick = 0;


                        if (weights[i - 1] <= w)
                        {
                            // pick the current weight, so add profit and remaining wieight(current weight(w) - weight[i-1]) from the previous row
                            // i-1 from profits/weight means the current profit/wt
                            // i-1 from knpasact[] means the previous weight row
                            pick = profits[i - 1] + knapsack[i - 1, w - weights[i - 1]];
                        }

                        int notPick = knapsack[i - 1, w];
                        knapsack[i, w] = Math.Max(notPick, pick);
                    }
                }
            }

            // if return max weight from the table
            // return knapsack[weights.Length, maxWeight]; // returns knapsack[4,8] - last value having the max weight

            return knapsack;
        }
    }
}
