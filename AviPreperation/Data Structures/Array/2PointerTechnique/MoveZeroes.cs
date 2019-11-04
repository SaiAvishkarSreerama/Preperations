using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array._2PointerTechnique
{
    class MoveZerosArray
    {
        public static int[] MoveZeros(int[] nums)
        {
            int n = nums.Length;

            //TWO POINTERS I,J; I=0 AND J=1, WHERE USING ++J, WHCIH INCREMENTS FIRST
            for (int i = 0, j = 0; j < n; ++j)
            {
                //IF [I,J]==>[0,1(NON ZERO)]==> SWAP(0,1)==>[1,0]
                //AFTER SWAPPIONG INCREMENT BOTH I AND J(FOR LOOPS TAKES CARE OF IT)
                if (nums[i] == 0 && nums[j] != 0)
                {
                    int temp = nums[i];
                    nums[i++] = nums[j];
                    nums[j] = temp;
                }
                //IF ONLY I IS NOT ZERO, AND J MOVES FAR AWAY, MAKING I AT J POSITION BY I=J
                else if (nums[i] != 0)
                {
                    i = j;
                }
            }
            return nums;
        }
        //public static void Main()
        //{
        //    int[] a = new int[] {0,1,0,3,12,0,15};
        //    var x = MoveZeros(a);

        //    for(int i=0; i<x.Length; i++)
        //    {
        //        Console.WriteLine(x[i]);
        //    }
        //    Console.ReadLine();
        //}
    }
}
