using System;
using System.Collections.Generic;
using System.Linq;

public class Monotonic
{
    public bool IsMonotonic(int[] A)
    {
        bool isDecreasing = true;
        bool isIncreasing = true;
        //increasing
        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i] > A[i + 1])
                isIncreasing = false;
            if (A[i] < A[i + 1])
                isDecreasing = false;
        }
        return (isIncreasing || isDecreasing);
    }
}
public class MonotonicMainClass
{
    //static void Main()
    //{
    //    var pIndex = new Monotonic();
    //    int[] Array = new int[] { 1, 7, 3, 6, 5, 6 };
    //    //int[] Array = new int[] { -1, -1, -1, 0, 1, 1 };
    //    Console.WriteLine(pIndex.IsMonotonic(Array));
    //    Console.ReadLine();
    //}
}
    