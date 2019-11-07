using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Stacks
{
    public class DecodeStringSolution
    {
        public  static string DecodeString(string s)
        {
            //2 stacks for integers and strings, result, and index
            Stack<int> count = new Stack<int>();
            Stack<string> result = new Stack<string>();
            string res = "";
            int i = 0;

            while (i < s.Length)
            {
                //here we have 4 types of charecters in the given string
                //number, alphabet, '[' and ']'

                //If the char is digit, then we need to find the next char to for a complete numer like "345"
                // so we do while again till we reach diff char, then push the whole value to int stack
                if (Char.IsDigit(s[i]))
                {
                    int val = 0;
                    while (Char.IsDigit(s[i]))
                    {
                        val = 10 * val + (s[i] - '0');
                        i++;
                    }
                    count.Push(val);
                }
                //IF the char is '[' then push the string to string Stack
                else if (s[i] == '[')
                {
                    result.Push(res);
                    res = "";
                    i++;
                }
                //If the char is ']', means we have a string waiting at res, need to append to the one in string
                //stack (a) with the int stack number of times (2) k=0 ==> a+b, k=1==> a+b+b{here appending res}
                //finally put the value in res for next int stack pop value
                else if (s[i] == ']')
                {
                    StringBuilder sb = new StringBuilder(result.Pop());
                    int val = count.Pop();
                    for (int k = 0; k < val; k++)
                    {
                        sb.Append(res);
                    }
                    res = sb.ToString();
                    i++;
                }
                //If the char is alphabet then find the whole string and we need to keep it there only to for 
                //repeating it with its preceding number
                else
                {
                    res += s[i].ToString();
                    i++;
                }
            }
            return res;
        }

        //public static void Main()
        //{
        //    Console.WriteLine("3[a2[b]]");
        //    Console.ReadLine();
        //}
    }
}
