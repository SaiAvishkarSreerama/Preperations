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

            for (int i = 0, j = 0; j < n; ++j)
            {
                if (nums[i] == 0 && nums[j] != 0)
                {
                    int temp = nums[i];
                    nums[i++] = nums[j];
                    nums[j] = temp;
                }
                else if (nums[i] != 0)
                {
                    i = j;
                }
            }
            return nums;
        }
        public static void Main()
        {
            int[] a = new int[] { 0,1,0,3,12,0,15};
            var x = MoveZeros(a);

            for(int i=0; i<x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }
            Console.ReadLine();
        }
    }
}
