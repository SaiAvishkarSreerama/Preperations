/*
 * Implement pow(x, n), which calculates x raised to the power n (i.e., xn).
 * Example 1:
 * Input: x = 2.00000, n = 10
 * Output: 1024.00000
 * 
 * Example 2:
 * Input: x = 2.10000, n = 3
 * Output: 9.26100
 * 
 * Example 3:
 * Input: x = 2.00000, n = -2
 * Output: 0.25000
 * Explanation: 2-2 = 1/22 = 1/4 = 0.25
 * 
 * Constraints:
 * -100.0 < x < 100.0
 * -231 <= n <= 231-1
 * n is an integer.
 * Either x is not zero or n > 0.
 * -104 <= xn <= 104
 */

//Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Maths
{
    [TestClass]
    public class _50_Power_X_N
    {
        [TestMethod]
        public void Run()
        {
            MyPow(2.0, 10);
        }

        #region RECURSION

        // Instead of multiplying x for n-times
        // We do n/2 times and multiple the result twice will get n/2*n/2 = n
        // TC - O(logn) , reducing half caluculation
        // SC - O(logn), recusrion stack
        public double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1.0;
            }

            // case 1: check if n is negative, then convert it into positvie value
            // convert to long to avoid overflow of int
            long N = n;
            if (n < 0)
            {
                x = 1 / x;
                N = -1 * N;
            }

            return RecursiveMyPow(x, N);
        }

        public double RecursiveMyPow(double x, long n)
        {
            // base case
            if (n == 0)
            {
                return 1.0;
            }

            // get the pow of n/2
            double half = RecursiveMyPow(x, n / 2);
            if (n % 2 == 0)
            {
                // n is even
                return half * half;
            }
            else
            {
                // n is odd
                return x * half * half;
            }
        }
        #endregion

        #region ITERATIVE
        //Time Complexity - O(logn)
        //Space Complexity - O(1)
        public double MyPow_Iterative(double x, int n)
        {
            if (n == 0)
                return 1;
            long N = n;
            if (n < 0)
            {
                x = 1 / x;
                N = -N;
            }

            double res = 1;
            double product = x;
            for (long i = N; i > 0; i /= 2)
            {
                if (i % 2 == 1)
                {
                    res *= product;
                }
                product *= product;
            }
            return res;
        }
        #endregion
    }
}
