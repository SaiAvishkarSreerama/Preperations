using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreperationsTest.LeetCode.Medium.Maths
{
    [TestClass]
    public class _12_IntegerToRoman
    {
        [TestMethod]
        public void Run()
        {
            string roman = IntToRoman(3749);
        }
        public string IntToRoman(int num)
        {
            Dictionary<int, string> intToRomanDict = new Dictionary<int, string>(){
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };
            StringBuilder sb = new StringBuilder();

            foreach (var row in intToRomanDict)
            {
                while (num >= row.Key)
                {
                    sb.Append(row.Value);
                    num -= row.Key;
                }
            }

            return sb.ToString();
        }
    }
}
