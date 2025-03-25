/*
 *  GeeksForGeeks code Implementation for Strassen's - https://www.geeksforgeeks.org/strassens-matrix-multiplication/?ref=shm
 *  Time complexity can be written for normal method as T(N) = 8T(N/2) + O(N^2)  => O(N^3)
 *  For Strassen's method, TC can be done in T(N) = 7T(N/2) +  O(N^2) =>  O(N^2.8074)
 */
using Microsoft.Testing.Platform.Extensions.Messages;
using System.ComponentModel.Design.Serialization;
using System.Threading.Tasks.Dataflow;

namespace PreperationsTest.Algorithms.DivideAndConquer
{
    [TestClass]
    public class MatrixMultiplication_Strassens
    {
        [TestMethod]
        public void MatrixMultiplication_Test()
        {
            int[,] X = new int[,] {
                { 1, 1, 1, 1 },
                { 2, 2, 2, 2 },
                { 3, 3, 3, 3 },
                { 2, 2, 2, 2 }
            };

            int[,] Y = new int[,] {
                { 1, 1, 1, 1 },
                { 2, 2, 2, 2 },
                { 3, 3, 3, 3 },
                { 2, 2, 2, 2 }
            };

            int[,] R = Multiply(X, Y);
            /*          {  8,  8,  8,  8 },
                        { 16, 16, 16, 16 },
                  R =   { 24, 24, 24, 24 },
                        { 16, 16, 16, 16 }
             */
        }

        /// <summary>
        /// Strassen Matric multiplication
        /// 1. Get the length-n of the matric a
        /// 2. initialize c matrix with n/2
        /// 3. Base condition for the recursion
        /// 4. Create 4 sub matrices for X(a,b,c,d) and Y(e,f,g,h)
        /// 5. Split A and B into 4 halves
        /// 6. Prepare the strassens formulas recursions from P1 to P7 
        /// 7. Prepare C1 to C4 using P1 to P7
        /// 8. Join C1 to C4 and return C
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>

        public int[,] Multiply(int[,] x, int[,] y)
        {
            // Step 1: get the length n
            int n = x.GetLength(0);

            // Step2: Initialize c
            int[,] r = new int[n, n];

            // Step3: Base class for the recursion
            if (n == 1)
            {
                r[0, 0] = x[0, 0] * y[0, 0];
            }
            else
            {
                // Step4: create 4 halves for A and B
                int[,] a = new int[n / 2, n / 2];
                int[,] b = new int[n / 2, n / 2];
                int[,] c = new int[n / 2, n / 2];
                int[,] d = new int[n / 2, n / 2];
                int[,] e = new int[n / 2, n / 2];
                int[,] f = new int[n / 2, n / 2];
                int[,] g = new int[n / 2, n / 2];
                int[,] h = new int[n / 2, n / 2];

                // Step5: Split A and B into 4 halves
                Split(x, a, 0, 0);
                Split(x, b, 0, n / 2);
                Split(x, c, n / 2, 0);
                Split(x, d, n / 2, n / 2);

                Split(y, e, 0, 0);
                Split(y, f, 0, n / 2);
                Split(y, g, n / 2, 0);
                Split(y, h, n / 2, n / 2);

                // Step6: Prepare the strassen;'s formula from P1 to P7
                // p1 = a * (f - h); 
                // p2 = (a + b) * h; 
                // p3 = (c + d) * e; 
                // p4 = d * (g - e); 
                // p5 = (a + d) * (e + h); 
                // p6 = (b - d) * (g + h); 
                // p7 = (a - c) * (e + f); 

                int[,] p1 = Multiply(a, Sub(f, h));
                int[,] p2 = Multiply(Add(a, b), h);
                int[,] p3 = Multiply(Add(c, d), e);
                int[,] p4 = Multiply(d, Sub(g, e));
                int[,] p5 = Multiply(Add(a, d), Add(e, h));
                int[,] p6 = Multiply(Sub(b, d), Add(g, h));
                int[,] p7 = Multiply(Sub(c, a), Add(e, f));

                // Step7: prepare C1 to C4 by using the matrices p1-p7
                // C1 = P4 + P5 + P6 - P2 
                // C2 = P1 + P2
                // C3 = P3 + P4
                // C4 = P1 - P3 + P5 + P7

                int[,] r1 = Sub(Add(Add(p4, p5), p6), p2);
                int[,] r2 = Add(p1, p2);
                int[,] r3 = Add(p3, p4);
                int[,] r4 = Add(Add(Sub(p1, p3), p5), p7);

                // Step8: Combine c1-c4 to get c matrix
                Join(r1, r, 0, 0);
                Join(r2, r, 0, n / 2);
                Join(r3, r, n / 2, 0);
                Join(r4, r, n / 2, n / 2);
            }

            return r;
        }

        /// <summary>
        /// Splits the array into 4 halves
        /// ex: splits 4x4 into 4 => 2x2 matrices
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <param name="iB"></param>
        /// <param name="jB"></param>
        public void Split(int[,] parent, int[,] child, int iB, int jB)
        {
            for (int i1 = 0, i2 = iB; i1 < child.GetLength(0); i1++, i2++)
            {
                for (int j1 = 0, j2 = jB; j1 < child.GetLength(0); j1++, j2++)
                {
                    child[i1, j1] = parent[i2, j2];
                }
            }
        }

        public void Join(int[,] child, int[,] parent, int iB, int jB)
        {
            for (int i1 = 0, i2 = iB; i1 < child.GetLength(0); i1++, i2++)
            {
                for (int j1 = 0, j2 = jB; j1 < child.GetLength(0); j1++, j2++)
                {
                    parent[i2, j2] = child[i1, j1];
                }
            }
        }

        public int[,] Sub(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int[,] c = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }
            return c;
        }

        public int[,] Add(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int[,] c = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }
    }
}
