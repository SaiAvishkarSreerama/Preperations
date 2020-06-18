using System;
using System.Collections.Generic;
using System.Text;
/*
 * A string S of lowercase letters is given. We want to partition this string into as many parts as possible so that each letter appears in at most one part, and return a list of integers representing the size of these parts.
 * 
 * Example 1:
 * Input: S = "ababcbacadefegdehijhklij"
 * Output: [9,7,8]
 * Explanation:
 * The partition is "ababcbaca", "defegde", "hijhklij".
 * This is a partition so that each letter appears in at most one part.
 * A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.
 * Note:
 * 
 * S will have length in range [1, 500].
 * S will consist of lowercase letters ('a' to 'z') only.
 **/
namespace AviPreperation.Data_Structures.Array
{
    public class PartitionLabelSolution
    {
        //TC - O(N)
        // SC - O(1)
        //Maximum partition is by finding the last appearance of char for each character
        public IList<int> PartitionLabels(string s)
        {
            int[] last = new int[26];
            for (int i = 0; i < s.Length; i++)
                last[s[i] - 'a'] = i;

            List<int> result = new List<int>();
            int maxLastpointer = 0;
            int start = 0;
            for (int end = 0; end < s.Length; end++)
            {
                //we are finding each maxium position that it reappear at the end
                //so we need to travel up to the maximum position to complete the sequence of that partition
                maxLastpointer = Math.Max(maxLastpointer, last[s[end] - 'a']);

                //if maxLastpointer and endpointer equal means we reached
                if (maxLastpointer == end)
                {
                    //add the length from end to start to result
                    result.Add(end - start + 1);

                    //start will be next of end for next partition
                    start = end + 1;
                }
            }

            return result.ToArray();
        }
    }
}
