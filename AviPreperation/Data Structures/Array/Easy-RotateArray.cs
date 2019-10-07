using System;
using System.Collections.Generic;
using System.Linq;

public class RotateArraySol
{
    public int[] Rotate1(int[] nums, int k)
    {
        int length = nums.Length;
        while (k > 0)
        {
            int next = nums[0];
            int next1 = nums[length - 1];
            for (int i = 0; i < length; i++)
            {
                if (i != length - 1)
                {
                    next1 = nums[i + 1];
                    nums[i + 1] = next;
                    next = next1;
                }
                else
                    nums[0] = next1;
            }
            --k;
        }
        return nums;
    }

    public int[] Rotate(int[] nums, int k)
    {
        //From the Solution
        //gives the number of rotations required to place the elements
        // if [1,2] requires 2 rotations then no need to rotate because after 2rotations result is still [1,2]
        k %= length;
        int count = 0;
        // looping through the array
        for (int i = 0; count < length; i++)
        {
            //dealing with first element - 0 index
            int current = i;
            Console.WriteLine(current);
            // we need first element to place in its rotation position
            int prev = nums[i];
            // do until the while loop fails
            do
            {
                //this will gives the position we need to place our prev value
                int next = (current + k) % length;
                // taking that value into backup, unless will loose that value after the update
                int temp = nums[next];
                // update the nums array with for() i=0 element
                nums[next] = prev;
                // put the temp value in prev, as prev is the one always updating the array, look above line
                // next we are not going to second element, as temp has value of the place where first element was updated, we need to get rid of that temp value.
                prev = temp;
                //for that, go to next postition instead of for(i=1)
                current = next;
                //incrementing the count to loop
                //Do while loop till it fails
                count++;

                //Console.WriteLine("next - "+next + " - "+nums[next]);  
                //Console.WriteLine("prev - "+prev);  
                //Console.WriteLine("current - "+current);  
            } while (i != current);//when the current becomes 0, and we have i=0, whcih has already updated, then while loop terminates the functionality
        }
        return nums;
    }
}
public class RotateArrayClass
{
    //static void Main()
    //{
    //    var pIndex = new RotateArraySol();
    //    int[] Array = new int[] { 1, 7, 3, 6, 5, 6 };
    //    //int[] Array = new int[] { -1, -1, -1, 0, 1, 1 };
    //    Console.WriteLine(pIndex.Rotate(Array, 1));
    //    Console.ReadLine();
    //}
}
