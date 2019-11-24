using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    public class minIndexLists
    {
        // Time Complexity - O(n + m), n and m are length of strngs
        // Space Complexity - O(n * x), where x refers to avg string length
        public string[] FindRestaurant(string[] a, string[] d)
        {
            //load dictionary with array a
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < a.Length; i++)
            {
                dict.Add(a[i], i);
            }

            //need list to retrun
            List<string> l = new List<string>();
            //let min value taking as int.max
            int minIndex = int.MaxValue;

            //iterate second array
            for (int i = 0; i < d.Length; i++)
            {
                //we need only if contains in dictionary(array1)
                if (dict.ContainsKey(d[i]))
                {
                    //total index of current matched string is is arr2 index + arr1 index from dictionary
                    int val = i + dict[d[i]];
                    //if less then clear and add this value
                    if (val < minIndex)
                    {
                        l.Clear();
                        l.Add(d[i]);
                        minIndex = val;
                    }
                    //else add
                    else if (val == minIndex)
                    {
                        l.Add(d[i]);
                    }
                }
            }

            return l.ToArray();
        }
    }
}
