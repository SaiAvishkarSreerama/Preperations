using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion.BackTracking
{
    public class GenerateParanthesisSolution
    {
        //using BACKTRACKING
        //https://www.youtube.com/watch?v=sz1qaKt0KGQ
        //See the problem solution for Time and Space complexity
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            BackTracking(n, n, "", result);
            return result;
        }

        public void BackTracking(int leftParanthesisCount, int rightParanthesisCount, string s, List<string> result)
        {
            //if both paranthesis is 0 or the length of s is 2*n then all paranthesis were used
            if (leftParanthesisCount == 0 && rightParanthesisCount == 0)
                result.Add(s);

            //if leftParanthesisCount is not 0, we can still use then and reduce the count
            if (leftParanthesisCount > 0)
                BackTracking(leftParanthesisCount - 1, rightParanthesisCount, s + "(", result);

            //if rightParanthesisCount is greaterthan leftParanthesisCount, we can use right and reduce the count
            if (leftParanthesisCount < rightParanthesisCount)
                BackTracking(leftParanthesisCount, rightParanthesisCount - 1, s + ")", result);
        }
    }
}
