/*
 * Dynamic Programming
 */

namespace PreperationsTest.Algorithms.DynamicProgramming
{
    [TestClass]
    public class FibonacciSequence
    {
        [TestMethod]
        public void Run()
        {
            // Brute force
            int result = Fibonacci_BruteForce(5);

            // DynamicProgramming
            // 1. Bottom-Up Memoization approach
            result = Fibonacci_Memoization(5);

            // 2. Top-Down (Tabulation)
            result = Fibonacci_Tabulation(5);
        }

        #region BruteForce
        /// <summary>
        /// TC - O(2^N) - exponential
        /// SC - O(1)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fibonacci_BruteForce(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return Fibonacci_BruteForce(n - 2) + Fibonacci_BruteForce(n - 1);
        }
        #endregion

        #region Memoization
        /// <summary>
        /// Bottom-UP Recustive method -Memoization
        /// TC - O(N), recursion
        /// SC - O(N), used a memo table
        /// </summary>
        public int[] memoTable { get; set; }
        public int Fibonacci_Memoization(int n)
        {
            memoTable = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                memoTable[i] = -1;
            }

            return Fibonacci_Recursion(n);
        }
        public int Fibonacci_Recursion(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            if (memoTable[n] != -1)
            {
                return memoTable[n];
            }

            memoTable[n] = Fibonacci_Recursion(n - 1) + Fibonacci_Recursion(n - 2);

            return memoTable[n];
        }
        #endregion

        #region Tabulation
        /// <summary>
        /// Top-Down Tabulation approach
        /// TC - O(N), iteration
        /// SC - O(N), used an array
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fibonacci_Tabulation(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
        #endregion
    }
}
