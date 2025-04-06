/*
 *  Matric chain multiplication - the best possible way of multiplying number of matrices so that we can get minimum cost of multiplying the matrices
 *  Example: A[3x3] * B[3x3], to get C[0,0] = A00xB00 + A01xB10 + A02xB20, totally 3-multiplications for one element and we have 3x3 - 9elements - 9x3=27 multiplication
 *      What is A1[5x4] * A2[4x6] * A3[6x2] * A4[2x7] there are several ways to multiply them.
 *      
 *  Formula: C[i,j] = min(C[i,k] + C[k+1, j] + d(i-1) * dk * dj) ,where A1[5 x 4] d0=5, d1=4, A2[4x6] d2= 4, d3=6, A3[6x2] d3=6, d4=2.....
 *      Simply we can multiply above four matrices in this order only 5x4 4x6 6x2 2x7 => 5 ,4, 6, 2, 7 => d0, d1, d2 ,d3 d4
 *  
 *  Formula to find no of multiplications required: Using Catalan formula (2n C n /(n+1)), n is no of matrices -1, for 4matrices, n=4-1=3, so simply we can convert the formula into (2(n-1) C (n-1) / n)
 *   | xx xx xx xx xx |
 *   | xx 11 12 13 14 |
 *   | xx xx 22 23 24 |
 *   | xx xx xx 33 34 |
 *   | xx xx xx xx 44 |
 *   
 *   we need to find out the above numbered values only to define the multiplication pattern
 *   For this example we get k-matrix as
 *   | xx xx xx xx xx |
 *   | xx 00 01 01 03 |
 *   | xx xx 00 02 03 |
 *   | xx xx xx 00 03 |
 *   | xx xx xx xx 00 |
 *          => so k[1,4]=3 means 3 matrices as a group (A1 * A2 * A3 ) * (A4) so we have 1-3 to decide, then go to k[1,3]
 *          => k[1,3] = 1 means 1 matrix is a group ((A1)*(A2 * A3))*(A4))
 *          
 * TC - O(n^3) - 3 loops
 * SC - (N) - n*n matrices for cost and k_matrix space
 */

namespace PreperationsTest.Algorithms.DynamicProgramming
{
    [TestClass]
    public class MatrixChainMultiplication
    {
        [TestMethod]
        public void Run()
        {
            // From the above example these are the dimentions of 4 matrices
            // {5*4 4*6 6*2 2*7} => {d0, d1, d2, d3, d4}
            int[] d = { 5, 4, 6, 2, 7 };

            MatricMultiplication(d);
        }

        /// <summary>
        /// Explanation
        ///     1. Our aim is to build the cost matrix and k-matrix where in cost[,] we knew diff = j - i;
        ///         c[1,1]=c[2,2]=c[3,3]=c[4,4]=0 so finding 
        ///         c[1,2], c[2,3], c[3,4] differnce is 1 for these rows. => 2-1, 3-2, 4-3
        ///         c[1,3], c[2,4] differnce is 2 for these rows. => 3-1, 4-2
        ///         c[1,4], difference is 3 => 4-1.
        ///         So for no of matrice n=4, we will get diff from 1 to 3, i.e, n-1=4-1=3
        ///     2. i(rows) should be from 1 to the last but one row, as we are finding the above matrix of diagonal
        ///         means for 4*4 matrix, i should be 1 to 3. as we are finding c[i=1, j=2 & 3 & 4], c[i=2, j=3 & 4], c[i=3, j=4] values, will be (n-diff)
        ///         1. diff = 1, 1 < i < n-diff => 1 < i < 3
        ///         2. diff = 2, 1 < i < 4-2 => 1 < i < 2
        ///         3. diff = 3 ,1 < i < 1
        ///     3. j(col), should go from 2 to 4 as well but horizontally
        ///         we get j => 2 to 4 from c[i=1, j=2 & 3 & 4], c[i=2, j=3 & 4], c[i=3, j=4] 
        ///     4. find min value for all possible k i <= k < j, uising 
        ///         Cost[i, k] + Cost[k + 1, j] + (d[i - 1] * d[k] * d[j]);
        ///     5. Return kmatrix, start from k[1,4] to below
        /// </summary>
        /// <param name="d">dimentions array</param>
        /// <returns></returns>
        public int MatricMultiplication(int[] d)
        {
            // total 4 matrices, we need a 4*4 cost and k-matrix, in such scenario we need to deal with 0-3 rows
            // lets create a 5*5 matrix and deal from 1-4 for easy approach
            int n = d.Length;
            int[,] Cost = new int[n, n]; // 5*5 matrix, where are dealing from 1-4 not 0-3 in this problem
            int[,] k_matrix = new int[n, n];
            // Iterate for j-i differences
            for (int diff = 1; diff < n - 1; diff++)
            {
                for (int i = 1; i < n - diff; i++)
                {
                    int j = i + diff;
                    Cost[i, j] = int.MaxValue;
                    for (int k = i; k < j; k++)
                    {
                        int formulaValue = Cost[i, k] + Cost[k + 1, j] + (d[i - 1] * d[k] * d[j]);
                        if (formulaValue < Cost[i, j])
                        {
                            Cost[i, j] = formulaValue;
                            k_matrix[i, j] = k;
                        }
                    }
                }
            }

            return k_matrix[1, n-1];
        }
    }
}
