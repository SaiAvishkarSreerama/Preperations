using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Given an Array A consisting of N Strings, calculate the length of the longest string S such that:

S is a concatenation of some of the Strings from A.
every letter in S is different.
Example -
A = ["co","dil","ityzd"] , function should return 5, resulting string S could be codil , dilco, coity,ityco
A = ["abc","kkk","def","csv"] , returns 6 , 
resulting Strings S could be abcdef , defabc, defcsv , csvdef
A = ["abc","ade","akl"] , return 0 , impossible to concatenate as letters wont be unique.

N is [1..8] ; A consists of lowercase English letters ; sum of length of strings in A does not exceed 100.*/

/*
* Given an array of strings arr. String s is a concatenation of a sub-sequence of arr which have unique characters.
* Return the maximum possible length of s.
* 
* Example 1:
* Input: arr = ["un","iq","ue"]
* Output: 4
* Explanation: All possible concatenations are "","un","iq","ue","uniq" and "ique".
* Maximum length is 4.
*
*Example 2:
* Input: arr = ["cha","r","act","ers"]
* Output: 6
* Explanation: Possible solutions are "chaers" and "acters".
*
*Example 3:
* Input: arr = ["abcdefghijklmnopqrstuvwxyz"]
* Output: 26
*  
* 
* Constraints:
* 1 <= arr.length <= 16
* 1 <= arr[i].length <= 26
* arr[i] contains only lower case English letters.
**/
namespace AviPreperation.Assessments.MicroSoft
{
    class Solution
    {
        ////Time Complexity : O(NlogN) 
        ////Space Complexity : O(mn) where m is length of max unique string and n is length of an array.
        //public static int solution(string[] A)
        //{
        //    // write your code in C# 6.0 with .NET 4.5 (Mono)
        //    //Sorting string array based on length;
        //    //Considering max length string and checking if it has all letter 
        //    Array.Sort(A,(x, y) => x.Length + y.Length);

        //    Dictionary<char, int> characterInputAddress = new Dictionary<char, int>();
        //    for (int i = 0; i < A.Length; i++)
        //    {
        //        String curr = A[i];
        //        //if current string length is not equal to unique word length
        //        if (curr.Length != findUniqueWordLength(curr)) continue;
        //        bool charaterExists = false;
        //        for (int j = 0; j < curr.Length; j++)
        //        {
        //            if (characterInputAddress.ContainsKey(curr[j]))
        //            {
        //                charaterExists = true;
        //                break;
        //            }
        //        }
        //        //if character does not exists adding character to dictionary 
        //        if (!charaterExists)
        //        {
        //            for (int j = 0; j < curr.Length; j++)
        //            {
        //                characterInputAddress.Add(curr[j], i);
        //            }
        //        }
        //    }
        //    return characterInputAddress.Count;
        //}
        ////Helper function for finding unique word length
        //public static int findUniqueWordLength(String s)
        //{
        //    HashSet<char> currWithoutDuplicates = new HashSet<char>();
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        currWithoutDuplicates.Add(s[i]);
        //    }
        //    return currWithoutDuplicates.Count;
        //}

        //TC - O(n * m) where n no of words and m lenght of each word
        //SC - O(n)
        public int maxLength = 0;
        public int maxLengthMethod(string[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            //Usiung Depth First Search Approach
            DFS(A, 0, "");
            return maxLength;
        }

        //Method perform depth first search approach on each string and updates the maxLength of the combination
        public void DFS(string[] A, int i, string s)
        {
            //check is string unique or not and return if it has duplicate characters
            if (!IsStringHasUniqueChars(s))
                return;

            //considering maximum value of the maxLength and current string length
            maxLength = Math.Max(maxLength, s.Length);

            //iterating through each character of the string 
            for (int j = i; j < A.Length; j++)
                DFS(A, j + 1, s + A[j]);
        }

        //check string does consists all unique characrers or not
        //Return true if unique else false
        public bool IsStringHasUniqueChars(string s)
        {
            int totalVal = 0;
            //iterate though the string
            foreach (char c in s)
            {
                //performing left shift bitwise operation to check the stirng is unique or not.
                int charVal = 1 << c - 'a'; //ascii value of character
                                            //if not unique bitwise AND returns value greater than zero
                if ((charVal & totalVal) > 0)
                    return false;

                //Adding the value to totalVal by doing bitwiseOR
                totalVal |= charVal;
            }

            return true;
        }


        //public static void Main()
        //{
        //    //Console.WriteLine(MinSwapssolution("baaaaa"));
        //    //var A = new string[] { "co", "ityzd", "dil" };
        //    //var A = new string[] { "potato", "kayak", "banana", "racecar" };
        //    var A = new string[] { "eva", "jqw", "tyn", "jan" };
        //    var obj = new Solution();
        //    Console.WriteLine(obj.maxLengthMethod(A));
        //    //Console.WriteLine(MaxLength(new string[] { "co", "ityzd", "dil" }));
        //}
    }
}