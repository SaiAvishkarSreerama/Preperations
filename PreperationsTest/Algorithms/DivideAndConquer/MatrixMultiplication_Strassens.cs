/*
 *  GeeksForGeeks code Implementation for Strassen's - https://www.geeksforgeeks.org/strassens-matrix-multiplication/?ref=shm
 *  Time complexity can be written for normal method as T(N) = 8T(N/2) + O(N^2)  => O(N^3)
 *  For Strassen's method, TC can be done in T(N) = 7T(N/2) +  O(N^2) =>  O(N^2.8074)
 */
namespace PreperationsTest.Algorithms.DivideAndConquer
{
    [TestClass]
    public class MatrixMultiplication_Strassens
    {
        [TestMethod]
        public void MatrixMultiplication_Test()
        {
            int[,] A = new int[,] {
                { 1, 1, 1, 1 },
                { 2, 2, 2, 2 },
                { 3, 3, 3, 3 },
                { 2, 2, 2, 2 }
            };

            int[,] B = new int[,] {
                { 1, 1, 1, 1 },
                { 2, 2, 2, 2 },
                { 3, 3, 3, 3 },
                { 2, 2, 2, 2 }
            };

            int[,] C = Multiply_Matrices(A, B);
        }
    }
}
