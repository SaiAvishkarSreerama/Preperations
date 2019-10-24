using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array._2PointerTechnique
{
    class RemoveDuplicatesFromSortedArray
    {
        public static int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            int j = 0;
            int n = nums.Length;

            // if null return 0
            if (n == 0)
                return 0;

            //case 1 - using while loop

            //while (j < n - 1)
            //{
            //    //if the i and j index values are same, increment j++
            //    if (nums[i] == nums[j])
            //    {
            //        j++;
            //    }
            //    //if i and j index values are not same, then update the next element at i with j and continue
            //    if (nums[i] != nums[j])
            //    {
            //        i++; //move to next poistion.
            //        nums[i] = nums[j]; //and then update, otherwise will lose the current postion value
            //    }
            //}

            //OR WE CAN USE FOR LOOP TOO, FOR LOOP IS FASTER THEN WHILE IN THE CASE, J IS AUTOMATICALLY INCREMENTS
            
            
            //case 2 - Uisng For loop
            for (; j < n; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++; //move to next poistion.
                    nums[i] = nums[j]; //and then update, otherwise will lose the current postion value
                }
            }

            return i + 1;
        }
        //public static void Main()
        //{
        //    int[] a = new int[] { 1,1,1,1,2,2,2,2,3,3,4,4,5,5,6,6,6,6,7,7,7,7,8,8,8,8,9,9,99};
        //    Console.WriteLine(RemoveDuplicates(a));
        //    Console.ReadLine();
        //}
    }
}
