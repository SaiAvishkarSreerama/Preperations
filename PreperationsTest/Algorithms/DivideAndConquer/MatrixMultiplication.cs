/*
 *  GeeksForGeeks code Implementation - https://www.geeksforgeeks.org/strassens-matrix-multiplication/?ref=shm
 *  In the below method, we do 8 multiplications for matrices of size N/2 x N/2 and 4 additions. Addition of two matrices takes O(N2) time.
 *  So the time complexity can be written as T(N) = 8T(N/2) + O(N^2)  => O(N^3)
 *  Check Strassen's method which can be done in T(N) = 7T(N/2) +  O(N^2) =>  O(N^2.8074)
 */
namespace PreperationsTest.Algorithms.DivideAndConquer
{
    [TestClass]
    public class MatrixMultiplication
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

        /// <summary>
        /// Multiplying matrices
        /// 1. prepare the rows and cols lenghts
        /// 2. check if A_col == B_row, if not return empty matrix with a message
        /// 3. initialize a result matrix of A_Row x B_Col
        /// 4. Base case for recursion if (Col == 1) do a[0]*b[0]
        /// 5. Initialize four result matrixes r00, r01, r10 r11
        /// 6. intialize submatrices a00-a11, b00-b11, and fill them with zeros
        /// 7. Fill data in sub matrices
        /// 8. Recursion call for c00 = a00.b00 + a01.b10 etc
        /// 9. combine the reusltant matrices 
        /// 10. return the matrix r
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[,] Multiply_Matrices(int[,] a, int[,] b)
        {
            // Step1 - get row-col lengths
            int aCol = a.GetLength(1);
            int bCol = b.GetLength(1);
            int aRow = a.GetLength(0);
            int bRow = b.GetLength(0);

            // Step2 - check the basic rule of matric multiplication
            if (aCol != bRow)
            {
                Console.WriteLine("Matrix multiplication is not possible for diff lenght matrices as col != row size");
                return new int[,] { { 0 }, { 0 } };
            }

            // Step3 - intialize resultant matrix and split_index of matrix
            int split_index = aCol / 2;
            int[,] c = new int[aRow, bCol];
            IntiWithZeros(c, aRow, bCol);

            // Step4 - Base case for recursion
            if (aCol == 1)
            {
                c[0, 0] = a[0, 0] * b[0, 0];
            }
            else
            {
                // step5 - Initialize 4 resultant matrices
                int[,] c00 = new int[split_index, split_index];
                int[,] c01 = new int[split_index, split_index];
                int[,] c10 = new int[split_index, split_index];
                int[,] c11 = new int[split_index, split_index];

                IntiWithZeros(c00, split_index, split_index);
                IntiWithZeros(c01, split_index, split_index);
                IntiWithZeros(c10, split_index, split_index);
                IntiWithZeros(c11, split_index, split_index);

                // Step6 - Initialize 8 submatrices 
                int[,] a00 = new int[split_index, split_index];
                int[,] a01 = new int[split_index, split_index];
                int[,] a10 = new int[split_index, split_index];
                int[,] a11 = new int[split_index, split_index];
                int[,] b00 = new int[split_index, split_index];
                int[,] b01 = new int[split_index, split_index];
                int[,] b10 = new int[split_index, split_index];
                int[,] b11 = new int[split_index, split_index];
                IntiWithZeros(a00, split_index, split_index);
                IntiWithZeros(a01, split_index, split_index);
                IntiWithZeros(a10, split_index, split_index);
                IntiWithZeros(a11, split_index, split_index);
                IntiWithZeros(b00, split_index, split_index);
                IntiWithZeros(b01, split_index, split_index);
                IntiWithZeros(b10, split_index, split_index);
                IntiWithZeros(b11, split_index, split_index);

                // step7 - Filling data
                for (int i = 0; i < split_index; i++)
                {
                    for (int j = 0; j < split_index; j++)
                    {
                        a00[i, j] = a[i, j];
                        a01[i, j] = a[i, j + split_index];
                        a10[i, j] = a[i + split_index, j];
                        a11[i, j] = a[i + split_index, j + split_index];
                        b00[i, j] = b[i, j];
                        b01[i, j] = b[i, j + split_index];
                        b10[i, j] = b[i + split_index, j];
                        b11[i, j] = b[i + split_index, j + split_index];
                    }
                }

                // step8 - recursive call
                Add_Matrices(Multiply_Matrices(a00, b00), Multiply_Matrices(a01, b10), c00, split_index); // c00 = a00.b00 + a01.b10
                Add_Matrices(Multiply_Matrices(a00, b01), Multiply_Matrices(a01, b11), c01, split_index); // c01 = a00.b01 + a01.b11
                Add_Matrices(Multiply_Matrices(a10, b00), Multiply_Matrices(a11, b10), c10, split_index); // c10 = a10.b00 + a11.b10
                Add_Matrices(Multiply_Matrices(a10, b01), Multiply_Matrices(a11, b11), c11, split_index); // c11 = a00.b01 + a11.b11

                // setp9 - combine reusltant submatrices
                for (int i = 0; i < split_index; i++)
                {
                    for (int j = 0; j < split_index; j++)
                    {
                        c[i, j] = c00[i, j];
                        c[i, j + split_index] = c01[i, j];
                        c[i + split_index, j] = c10[i, j];
                        c[i + split_index, j + split_index] = c11[i, j];
                    }
                }
            }

            // Step10 - return c
            return c;
        }

        public void IntiWithZeros(int[,] x, int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    x[i, j] = 0;
                }
            }
        }

        public void Add_Matrices(int[,] a, int[,] b, int[,] c, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
        }
    }
}