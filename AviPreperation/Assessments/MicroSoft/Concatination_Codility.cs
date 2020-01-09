using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Given an Array A consisting of N Strings, calculate the length of the longest string S such that:

S is a concatenation of some of the Strings from A.
every letter in S is different.
Example -
A = ["co","dil","ity"] , function should return 5, resulting string S could be codil , dilco, coity,ityco
A = ["abc","kkk","def","csv"] , returns 6 , resulting Strings S could be abcdef , defabc, defcsv , csvdef
A = ["abc","ade","akl"] , return 0 , impossible to concatenate as letters wont be unique.

N is [1..8] ; A consists of lowercase English letters ; sum of length of strings in A does not exceed 100.*/
namespace AviPreperation.Assessments.MicroSoft
{
    class Solution
    {
        //Time Complexity : O(NlogN) 
        //Space Complexity : O(mn) where m is length of max unique string and n is length of an array.
        public int solution(string[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            //Sorting string array based on length;
            //Considering max length string and checking if it has all letter 
            A.ToList().Sort((x, y) => y.Length - x.Length);

            Dictionary<char, int> characterInputAddress = new Dictionary<char, int>();
            for (int i = 0; i < A.Length; i++)
            {
                String curr = A[i];
                //if current string length is not equal to unique word length
                if (curr.Length != findUniqueWordLength(curr)) continue;
                bool charaterExists = false;
                for (int j = 0; j < curr.Length; j++)
                {
                    if (characterInputAddress.ContainsKey(curr[j]))
                    {
                        charaterExists = true;
                        break;
                    }
                }
                //if character does not exists adding character to dictionary 
                if (!charaterExists)
                {
                    for (int j = 0; j < curr.Length; j++)
                    {
                        characterInputAddress.Add(curr[j], i);
                    }
                }
            }
            return characterInputAddress.Count;
        }
        //Helper function for finding unique word length
        public int findUniqueWordLength(String s)
        {
            HashSet<char> currWithoutDuplicates = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                currWithoutDuplicates.Add(s[i]);
            }
            return currWithoutDuplicates.Count;
        }
    }
     


}