using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.LeetCodePrep._1.Easy
{
    public class Solution
    {
        //Time Complexity - O(n) - we traverse all charactersof a string only once
        //Space Complexity - O(n) - we used stack to push, pop hte string characters
        public bool IsValid(string s)
        {
            var charDict = new Dictionary<char, char>(){
            {')','('},
            {']','['},
            {'}','{'}
        };
            Stack<char> stack = new Stack<char>();
            //iterate through the string characters 
            for (int i = 0; i < s.Length; i++)
            {
                //if character is closing bracket
                // compare Dictionary[s[i]] and .Pop(), equals then continue, not eqauls then false
                if (charDict.ContainsKey(s[i]))
                {
                    //stack empty means, string starts with closing bracket--false
                    if (stack.Count == 0)
                        return false;
                    //Pop returns a prvious value, if char is not equal, 
                    if (charDict[s[i]] != stack.Pop())
                        return false;
                }
                //if char is opening brackets then .Push()
                else
                {
                    stack.Push(s[i]);
                }
            }

            return stack.Count == 0 ? true : false;
        }
    }
}
