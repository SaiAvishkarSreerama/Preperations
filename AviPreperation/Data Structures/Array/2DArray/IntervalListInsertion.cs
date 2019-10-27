using System;
using System.Collections.Generic;
using System.Linq;

//Given two lists of closed intervals, each list of intervals is pairwise disjoint and in sorted order.

//Return the intersection of these two interval lists.
//(Formally, a closed interval [a, b] (with a <= b) denotes the set of real numbers x 
//with a <= x <= b.The intersection of two closed intervals is a set of real numbers that
//is either empty, or can be represented as a closed interval.For example, the intersection of[1, 3] and[2, 4] is [2, 3].)

//Example 1:
//Input: A = [[0,2],[5,10],[13,23],[24,25]], B = [[1,5],[8,12],[15,24],[25,26]]
//Output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]
//Reminder: The inputs and the desired output are lists of Interval objects, and not arrays or lists.

//Note:
//0 <= A.length< 1000
//0 <= B.length< 1000
//0 <= A[i].start, A[i].end, B[i].start, B[i].end< 10^9
//NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.

public class IntervalListInsertion
{
    public static int[][] IntervalIntersection(int[][] A, int[][] B)
    {
        int i = 0;
        int j = 0;
        // int l = A.Length;
        // int[][] arr = new int[l][];
        // If we take jagged array to store and return the output, we must mention the length
        // so taking list which can be inserted how many we want
        List<int[]> arr = new List<int[]>();

        //similar to merge sorting
        while (i < A.Length && j < B.Length)
        {
            //finding low and high ranges of A and B //let A=[0, 2], B=[1, 5]
            int low = Math.Max(A[i][0], B[j][0]);//Max[0,1]==>1
            int high = Math.Min(A[i][1], B[j][1]);//Min[2,5]==>2

            if (low <= high)
            {
                //arr[i]= new int[2]{low,high};
                //[1,2] is the matching interval between A and B of ith index array
                arr.Add(new int[] { low, high });
            }

            //going to next index of A and B by comparing the end values 
            //if a has smallest end number then b must be higher, so incrementing A to compare with B
            if (A[i][1] < B[j][1])
                i++;
            else
                j++;
        }

        //converting list to array
        return arr.ToArray();
    }

    //static void Main()
    //{
    //    int[][] A = new int[2][];
    //    int[][] B = new int[2][];
    //    A[0] = new int[] { 0, 2};
    //    A[1] = new int[] { 5, 10};
    //    A[2] = new int[] { 13, 23};
    //    A[2] = new int[] { 24, 25};
    //    B[2] = new int[] { 1, 2};
    //    B[2] = new int[] { 8, 12};
    //    B[2] = new int[] { 15, 24};
    //    B[2] = new int[] { 25, 26};
    //    Console.WriteLine(IntervalIntersection(A,B));
    //    Console.ReadLine();
    //}
}
