using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.String
{
    // string is immutable - cannot changes, if try to change, it wil create a new string 
    // StringBuilder is mutable- can be change at any time
    // StringBuilder does not have a definition of Reverse(); Below are the methods to use for SB
    // Append
    // AppendFormat
    // AppendJoin
    // AppendLine
    // Clear
    // CopyTo
    // EnsureCapacity
    // Equals
    // GetChunks
    // Insert
    // Remove
    // Replace
    // ToString
    public class StringBuilderSol
    {
        public static string AddBinary(string a, string b)
        {
            int carry = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;
            StringBuilder s = new StringBuilder();

            while (i >= 0 || j >= 0)
            {
                int sum = carry;
                if (i >= 0)
                    sum += a[i--] - '0';
                if (j >= 0)
                    sum += b[j--] - '0';

                s.Insert(0, sum % 2);
                carry = sum / 2;
            }
            if (carry != 0)
                s.Insert(0, carry);

            return s.ToString();
        }

        //public static void Main()
        //{
        //    Console.WriteLine(AddBinary("1011", "101"));
        //    Console.ReadLine();
        //}
    }
}
