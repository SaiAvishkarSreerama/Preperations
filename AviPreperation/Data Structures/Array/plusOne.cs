using System;
using System.Collections.Generic;
using System.Linq;

public class PlusOneClass
{
    // All Test cases passed but O(n^2)
    // Time 280-428ms
    public int[] PlusOne2(int[] d)
    {
        Array.Reverse(d);
        int[] a = new int[d.Length + 1];
        int rem = 1;

        for (int i = 0; i < d.Length; i++)
        {
            int sum = d[i] + rem;
            a[i] = sum % 10;
            d[i] = sum % 10;
            rem = sum / 10;
        }

        if (rem > 0)
            a[d.Length] = rem;

        Array.Reverse(a);
        Array.Reverse(d);
        return rem > 0 ? a : d;
    }

    //Reccommended
    //Best Solution
    public int[] PlusOne(int[] d)
    {
        int n = d.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            if (d[i] < 9)
            {
                d[i]++;
                return d;
            }
            d[i] = 0;
        }

        int[] newArray = new int[n + 1];
        newArray[0] = 1;

        return newArray;
    }
}
public class PlusOneMainClass
{
    //static void Main()
    //{
    //    var pIndex = new PlusOneClass();
    //    int[] Array = new int[] { 1, 7, 3, 6, 5, 6 };
    //    //int[] Array = new int[] { -1, -1, -1, 0, 1, 1 };
    //    Console.WriteLine(pIndex.PlusOne(Array));
    //    Console.ReadLine();
    //}
}
