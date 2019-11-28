using System;
using System.Collections.Generic;
using System.Text;
/*
*   Given a non-empty array of integers, return the k most frequent elements.
*  
*  Example 1:
*  Input: nums = [1,1,1,2,2,3], k = 2
*  Output: [1,2]
*  
*  Example 2:
*  Input: nums = [1], k = 1
*  Output: [1]
*  
*  Note:*  
*  You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
*  Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
*  */
namespace AviPreperation.Data_Structures.HashTable
{
    //Time complexity : O(Nlog(k)). The complexity of Counter method is O(N).
         //To build a heap and output list takes O(Nlog(k)). Hence the overall complexity of the algorithm is O(N+Nlog(k))=O(Nlog(k)).
    //Space complexity : O(N), to store Dictionary
    class TopKFrequentElements
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> fd = new Dictionary<int, int>();
            int maxCount = 0;

            //Step1: prepare the dictionary of unique keys from array nums
            foreach (int n in nums)
            {
                if (fd.ContainsKey(n))
                    fd[n]++;
                else fd.Add(n, 1);
                maxCount = Math.Max(maxCount, fd[n]);
            }

            //Step2:create a order list with the maxcount rows
            List<int>[] olist = new List<int>[maxCount + 1];
            foreach (var f in fd.Keys)
            {
                if (olist[fd[f]] == null)
                {
                    olist[fd[f]] = new List<int>();
                }
                olist[fd[f]].Add(f);
            }

            //create a list with k frequent top occurence elements by reverse iterating the olist
            List<int> topK = new List<int>();
            for (int i = maxCount; i >= 0 && k > 0; i--)
            {
                if (olist[i] != null && k > 0)
                {
                    foreach (int t in olist[i])
                    {
                        topK.Add(t);
                        k--;
                    }
                }
            }
            return topK;
        }

        //public static void Main()
        //{
        //    int[] A = new int[] { 1, 1, 1, 2, 2, 3 };
        //    var obj = new TopKFrequentElements();

        //    obj.TopKFrequent(A, 2);
        //}
    }
}
