using System;
using System.Collections.Generic;
using System.Text;
/*
* You have an array of logs.  Each log is a space delimited string of words.
* 
* For each log, the first word in each log is an alphanumeric identifier.  Then, either:
* 
* Each word after the identifier will consist only of lowercase letters, or;
* Each word after the identifier will consist only of digits.
* We will call these two varieties of logs letter-logs and digit-logs.  
* It is guaranteed that each log has at least one word after its identifier.
* 
* Reorder the logs so that all of the letter-logs come before any digit-log. 
* The letter-logs are ordered lexicographically ignoring identifier, with the identifier used in case of ties. 
* The digit-logs should be put in their original order.
* 
* Return the final order of the logs.
* 
* Example 1:
* Input: logs = ["dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero"]
* Output: ["let1 art can","let3 art zero","let2 own kit dig","dig1 8 1 5 1","dig2 3 6"] 
**/
namespace AviPreperation.Data_Structures.String
{
    //Time Complexity - O(N logN)
    //Space Complexity - O(N), total logs
    class ReorderDataInLogFiles
    {
        public string[] ReorderLogFiles(string[] logs) {
            List<string> digit_logs = new List<string>();
            List<string> letter_logs = new List<string>();

            //Devide logs into separate lists based on fist char after the identifier(i==>"dig1 1 2 3 4", a==>"let1 art sai")
            foreach (string s in logs) {
                if (Char.IsDigit(s[s.IndexOf(' ') + 1]))
                    digit_logs.Add(s);
                else
                    letter_logs.Add(s);
            }

            //Sorting the letter log files, internally, below are the steps
            //1. substring of two logs after the first space (a_sub ==> "art can", b_sub==>"own kit dig")
            //2. a_sub.compareTo(b_sub) gives -1(if a_sub ,b_sub), 0(a_sub == b_sub), 1(b_sub, a_sub) 
            //3. if 0-equal, then compare the identifiers of both logs
            //4. return the result(1 or -1) will altomatically swaps the logs
            letter_logs.Sort((a, b) =>
            {
                string a_sub = a.Substring(a.IndexOf(' ') + 1);
                string b_sub = b.Substring(b.IndexOf(' ') + 1);
                var result = a_sub.CompareTo(b_sub);
                if (result == 0)
                    result = a.Substring(0, a.IndexOf(' ')).CompareTo(b.Substring(0, b.IndexOf(' ')));
                return result;
            });

            letter_logs.AddRange(digit_logs);
            return letter_logs.ToArray();
        }

        //public static void Main()
        //{
        //    ReorderDataInLogFiles obj = new ReorderDataInLogFiles();
        //    string[] logs = new string[] { 
        //        "dig1 8 1 5 1", 
        //        "let1 art can", 
        //        "dig2 3 6", 
        //        "let2 own kit dig",
        //        "let3 art zero" };
        //    obj.ReorderLogFiles(logs);
        //}
    }
}
