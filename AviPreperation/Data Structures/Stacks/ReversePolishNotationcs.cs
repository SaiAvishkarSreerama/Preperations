using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Stacks
{
    public class ReversePolishNotation
    {
        public static int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" || tokens[i] == "/")
                {
                    int bottom = stack.Pop();
                    int top = stack.Pop();

                    if (tokens[i] == "+")
                        stack.Push(top + bottom);

                    if (tokens[i] == "-")
                        stack.Push(top - bottom);

                    if (tokens[i] == "*")
                        stack.Push(top * bottom);

                    if (tokens[i] == "/")
                        stack.Push(top / bottom);
                }
                else
                {
                    stack.Push(Int32.Parse(tokens[i]));
                }
            }

            return stack.Pop();
        }
        static void Main()
        {
            string[] a = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            EvalRPN(a);
        }
    }
}
