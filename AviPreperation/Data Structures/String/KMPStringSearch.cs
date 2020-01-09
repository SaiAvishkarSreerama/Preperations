using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.String
{
    class KMPStringSearch
    {
        //TimeComplexity - O(mn)
        //SpaceComplexity - O(1)
        public int StrStr1(string haystack, string needle)
        {
            if (needle.Length == 0)
                return 0;
            if (haystack.Length == 0)
                return -1;


            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                for (int j = 0; j <= needle.Length; j++)
                {
                    if (j == needle.Length)
                        return i;

                    if (haystack[i + j] != needle[j])
                        break;
                }
            }
            return -1;
        }




    //Time Complexity - O(m+n), where m = needle.Length, n=haystack.Length
    //Space Compelxity - O(m)
    //AbdulBari: https://www.youtube.com/watch?v=V5-7GzOfADQ
    //TusharRoy: https://www.youtube.com/watch?v=GTJr8OvyEVQ


    public static int StrStr(string haystack, string needle)
        {
            //Here needle is the patter we are finding in text which is haystack
            if (needle.Length == 0)
                return 0;
            if (haystack.Length == 0)
                return -1;

            //create a lps[] array of needle
            var lps = PrepareNeedleLps(needle);
            int i = 0;
            int j = 0;
            //iterate till i,j becomes the text and patter's lenth
            while (j <= needle.Length - 1 && i <= haystack.Length - 1)
            {
                //If needle[j] == haystack[i]
                if (needle[j] == haystack[i])
                {
                    i++;
                    j++;
                }
                //if needle[j] != haystack[i]
                else
                {
                    // if j!0 then making j wiht behind index value of lps
                    if (j != 0)
                        j = lps[j - 1];
                    else
                    {
                        //if j==0 then
                        i++;
                    }
                }
            }
            if (j == needle.Length)
                return i - j;

            return -1;
        }

        //Preparing an array whcih has the patter/needle string prefix and suffix repetitions
        //IF the first char and secon char of a string are equal then we put 1 and increment both positions
        public static int[] PrepareNeedleLps(string needle)
        {
            int[] arr = new int[needle.Length];
            int i = 1; // second char
            int j = 0; // first char
            arr[j] = 0; // first value of array will always 0
            for (; i <= needle.Length - 1; i++)
            {
                //if ith and jth
                if (needle[j] == needle[i])
                {
                    //placing j+1 in ith postion
                    arr[i] = j + 1;
                    j++;
                }
                // if not matches
                else
                {
                    // if j != 0 then find the arr[j-1]th value becomes j
                    if (j != 0)
                    {
                        j = arr[j - 1];
                        i--; //for loop automatically increments i, but we need to be at same position of i, hence decrementing it makes as we expected
                    }
                    else
                    {
                        //if already j==0 then i and j not 
                        arr[i] = 0;
                    }
                }
            }
            return arr;
        }

        //public static void Main()
        //{
        //    string t = "aabaaabaaac";
        //    string s = "aabaaac";
        //    var x = StrStr(t, s);
        //    Console.WriteLine(x);
        //    Console.ReadLine();
        //}
    }

}
