using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.String
{
    //APPROACH-1
    public class IntegerToEnglishWordSolution
    {
        //Time Complexity - O(n)
        //Space Complexity - O(1)

        //1-9
        public string Ones(int num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
            }
            return "";
        }
        
        //10-19
        public string LessThanTwenty(int num)
        {
            switch (num)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
            }
            return "";
        }

        //20-90
        public string Tens(int num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
            }
            return "";
        }
        
        
        //split the numbers into billion, million, thousands and hundreds(as rest)
        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            int billion = num / 1000000000;
            int million = (num - billion * 1000000000) / 1000000;
            int thousand = (num - billion * 1000000000 - million * 1000000) / 1000;
            int rest = (num - billion * 1000000000 - million * 1000000 - thousand * 1000);
            Console.WriteLine(rest);
            string res = "";

            if (billion != 0)
            {
                res = Three(billion) + " Billion";
            }

            if (million != 0)
            {
                if (res.Length > 0)
                    res += " ";
                res += Three(million) + " Million";
            }

            if (thousand != 0)
            {
                if (res.Length > 0)
                    res += " ";
                res += Three(thousand) + " Thousand";
            }

            if (rest != 0)
            {
                if (res.Length > 0)
                    res += " ";
                res += Three(rest);
            }

            return res;
        }

        //Split the three digit words into (123 as) 1-hundred and 23-rest(tens)
        public string Three(int num)
        {
            string res = "";
            int hundred = num / 100;
            int rest = num - hundred * 100;
            Console.WriteLine(rest);
            if (hundred * rest != 0)
            {
                res = Ones(hundred) + " Hundred " + Two(rest);
            }
            else if (hundred == 0 && rest != 0)
            {
                res = Two(rest);
            }
            else if (hundred != 0 && rest == 0)
            {
                res = Ones(hundred) + " Hundred";
            }

            return res;
        }

        //split 2 digit words into single-single
        //if number < 10 then call Ones()
        //if number < 20 tehn call LessThanTwenty()
        //else split and find the number from Ones() and Tens()
        public string Two(int num)
        {
            string res = "";
            if (num < 10)
                res = Ones(num);
            else if (num < 20)
                res = LessThanTwenty(num);
            else
            {
                int tenner = num / 10;
                int rest = num - tenner * 10;
                if (rest == 0)
                    res = Tens(tenner);
                else
                    res = Tens(tenner) + " " + Ones(rest);
            }
            return res;
        }



        /********************************************************************************************************************/
        /*********************************************APPROACH - 2***********************************************************/
        /********************************************************************************************************************/
        private string[] LESS_THAN_20 = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", 
                                         "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                                         "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        private string[] TENS = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private string[] THOUSANDS = { "", "Thousand", "Million", "Billion" };

        //Time Complexity - O(n)
        //Space Complexity - O(n) - RECURSION CALL STACK, but constant space for above arrays
        public string NumberToWords2(int num)
        {
            if (num == 0)
                return "Zero";
            int i = 0;
            string words = "";

            while (num > 0)
            {
                //processing 3digits each time
                if (num % 1000 != 0)
                    words = helper(num % 1000) + THOUSANDS[i] + " " + words;
                num /= 1000;
                i++;

            }
            return words.Trim();
        }

        public string helper(int num)
        {
            if (num == 0)
                return "";
            else if (num < 20)
                return LESS_THAN_20[num] + " ";
            else if (num < 100)
                return TENS[num / 10] + " " + helper(num % 10);
            else//if 3 digits split 1 , helper(23)
                return LESS_THAN_20[num / 100] + " Hundred " + helper(num % 100);
        }
    }
}
