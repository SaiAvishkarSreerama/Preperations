using System;
using System.Collections.Generic;
using System.Text;
/*Given a date, return the corresponding day of the week for that date.
* 
* The input is given as three integers representing the day, month and year respectively.
* 
* Return the answer as one of the following values {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}.
* 
* Example 1:
* Input: day = 31, month = 8, year = 2019
* Output: "Saturday"
* 
* Example 2:
* Input: day = 18, month = 7, year = 1999
* Output: "Sunday"
* 
* Example 3:
* Input: day = 15, month = 8, year = 1993
* Output: "Sunday"
* 
* Constraints:
* The given dates are valid dates between the years 1971 and 2100.
* */
namespace AviPreperation.Data_Structures.Array
{
    public class DaayofTheWeekSolution
    {
        string[] days = new string[]{
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday"};
        public string DayOfTheWeek(int day, int month, int year)
        {

            //Zellers formula to find a day
            //month starts from Mar(1) to Feb(12), (year-1) for Jan and Feb
            //https://youtu.be/T49yIEYc6uI?t=150
            // F = (day + 13 * (month + 1) / 5 + (year % 100) + (year % 100)/4 
            //- 2*(year / 100) + (year / 100)/4 - 1) % 7;


            //if jan and feb
            if (month < 3)
            {
                month += 12;
                year -= 1;
            }
            int C = year / 100;
            int D = year % 100;

            int w = (day + 13 * (month + 1) / 5 + D + D / 4 - 2 * C + C / 4 - 1) % 7;

            return days[(w + 7) % 7];
        }
    }
}
