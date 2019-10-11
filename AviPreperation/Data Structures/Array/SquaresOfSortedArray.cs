using System;
using System.Collections.Generic;
using System.Linq;

public class SortedSquaresClass
{
    public int[] SortedSquares(int[] A)
    {
        //  We should not use Sort() as it is NlogN
        //  Try to avoid all Array properties as we are developing them in this coding instead of taking help from them
        //  Time Complexity: O(N \log N)O(NlogN), where NN is the length of A.
        //  Space Complexity: O(N)O(N).

        //  for(int i=0; i<A.Length; i++){
        //      A[i] = (int)Math.Pow(A[i],2);
        //  }
        //  Array.Sort(A);
        //  return A;

        //  Two pointer for assending or descending the array
        //  Time complexity - O(N) - since has a single while loop
        //  Space complexity - O(N) - used an extra array to print out put

        int l = A.Length;
        int[] Out = new int[l];
        int left = 0;
        int right = l - 1;
        int current = l - 1;
        while (current >= 0)
        {
            if (Math.Abs(A[left]) > Math.Abs(A[right]))
            {
                //Out[current] = (int)Math.Pow(A[left],2);  
                Out[current] = A[left] * A[left];

                left++;
            }
            else
            {
                //Out[current] = (int)Math.Pow(A[right],2);
                Out[current] = A[right] * A[right];

                right--;
            }
            current--;
        }

        return Out;
    }
}
public class SortedSquaresMain
{
    static void Main()
    {
        var pIndex = new SortedSquaresClass();
        int[] Array = new int[] { -4, -1, 0, 1, 9, 12 };
        Console.WriteLine(pIndex.SortedSquares(Array));
        Console.ReadLine();
    }
}
    
