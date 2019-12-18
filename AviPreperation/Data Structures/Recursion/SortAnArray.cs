using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures
{
    public class SortArraySolution
    {
        //MERGE SORT using RECURSIVE
        //Top-Down Approach
        //Time Complexity - O(NlogN)
        //Space Complexity - O(N)
        public IList<int> SortArray_Recursive(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;

            //Case1
            //TimeComplexity - O(N logN)
            //SpaceComplexity -O(N)
            MergeSort(nums, low, high);

            //Case2
            //TimeComplexity - O(N logN)
            //SpaceComplexity -O(N)
            QuickSort(nums, low, high);
            return nums;
        }

        public void MergeSort(int[] nums, int l, int h)
        {
            if (l < h)
            {
                int mid = l + (h - l) / 2;
                MergeSort(nums, l, mid);
                MergeSort(nums, mid + 1, h);
                Merge(nums, l, mid, h);
            }
        }

        public void Merge(int[] nums, int l, int m, int h)
        {
            int[] L = new int[m - l + 1];
            int[] R = new int[h - m];

            int i = 0;
            int j = 0;
            int k = l;

            for (i = 0; i < L.Length; i++)
                L[i] = nums[l + i];
            for (j = 0; j < R.Length; j++)
                R[j] = nums[m + 1 + j];

            i = 0; j = 0;

            while (i < L.Length && j < R.Length)
            {
                if (L[i] < R[j])
                    nums[k++] = L[i++];
                else
                    nums[k++] = R[j++];
            }
            while (i < L.Length)
                nums[k++] = L[i++];
            while (j < R.Length)
                nums[k++] = R[j++];
        }


        //MERGE SORT isong ITERATIVE
        //BOTTOM UP Approach
        //Time Complexity - O(NlogN)
        //Space Complexity - O(1)
        public IList<int> SortArray_Iterative(int[] nums)
        {
            for (int n = 1; n <= nums.Length - 1; n = 2 * n)
            {
                for (int l= 0; l < nums.Length - 1; l = l + 2 * n)
                {
                    int m = n + l - 1;
                    int h = Math.Min(l + 2 * n - 1, nums.Length - 1);

                    Merge(nums, l, m, h);
                }
            }

            return nums;
        }



        //QUICK SORT USING RECURSION
        public void QuickSort(int[] nums, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(nums, low, high);
                //Console.WriteLine("low- " + low + ";" + "high- " + high + " pivot-" + pivot);
                //foreach (int k in nums)
                //{
                //    Console.WriteLine(k);
                //}
                QuickSort(nums, low, pivot - 1);
                QuickSort(nums, pivot + 1, high);
            }
        }

        public int Partition(int[] nums, int low, int high)
        {
            int pivot = nums[high];
            int i = low;

            for (int j = low; j < high; j++)
            {
                if (nums[j] < pivot)
                {
                    //Swap that value to the first(ith) position
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                }
            }

            //so, the no less than pivot are at starting till position i, so put the pivot at i
            //such that will get "less values + pivot + high values"
            int t = nums[i];
            nums[i] = nums[high];//or pivot;
            nums[high] = t;

            return i;
        }

        //public static void Main()
        //{
        //    int[] a = new int[] { 4, 2, 1, 5, 6, 0, 3 };
        //    var sort = new SortArraySolution();
        //    sort.SortArray_Iterative(a);
        //}
    }
}
