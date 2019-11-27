using System;
using System.Collections.Generic;
using System.Text;
/*
Design and Implement a Two Sum class.It should support the following operations add() and find();
add(x) - adds a value to the data structure;
find(n) - Return true if the value n is sum of any two numbers from the list, else return false.

Example 1:
add(1);
add(3);
add(5);

find(4) --> true (1+3)
find(5) --> false(no two numbers gives result 5)
*/
namespace AviPreperation.Data_Structures.HashTable
{
    //USING LIST AND HASHSET TO COMPARE THE RESULT
    //Time Complexity O(n)
    //Space Complexity O(n)
    class TwoSum3
    {
        List<int> list;
        TwoSum3()
        {
            list = new List<int>();
        }

        void Add(int num)
        {
            list.Add(num);
        }

        bool Find(int target)
        {
            HashSet<int> h = new HashSet<int>();
            for(int i=0; i< list.Count; i++)
            {
                if(h.Contains(target - list[i]))
                {
                    return true;
                }
                else
                {
                    h.Add(list[i]);
                }
            }
            return false;
        }
    }

    //USING DICTIONARY
    //Time Complexity - O(1) - HashTable has fast loopkups
    //SpaceComplexity - O(n) - storing the given numbers
    public class TwoSum3_DataStructure
    {
        Dictionary<int, int> d;

        public TwoSum3_DataStructure()
        {
            d = new Dictionary<int, int>();
        }

        public void Add(int num)
        {
            //if duplicate numbers were given we are incrementing the frequency in Value column where key is our original number
            if (d.ContainsKey(num))
            {
                d[num]++;
            }
            else
            {
                d.Add(num, 1);
            }
        }

        public bool Find(int target)
        {
            //Looping through the keys
            foreach(var key in d.Keys)
            {
                //target - key gives the num to find in
                int result = target - key;
                //condition 1: if key and result are same which means we found same num, so check if it has two count in value(let say tarhet=6, key=3, result=6-3=3, so if key-3 has duplicate value where value(>1) return true)
                //condition 2: if key and resukt ar not same, we have result in dictionary then return true
                if((result == key && d[key] > 1) || (result != key && d.ContainsKey(result)))
                {
                    return true;
                }
            }
            return false;
        }
    }

    //public class MainClass
    //{
    //    public static void Main()
    //    {
    //        //var c = new TwoSum3();
    //        var c = new TwoSum3_DataStructure();
    //        c.Add(1);
    //        c.Add(3);
    //        c.Add(3);
    //        c.Add(3);
    //        c.Add(5);
    //        Console.WriteLine(c.Find(6));
    //        Console.WriteLine(c.Find(8));
    //        Console.WriteLine(c.Find(8));
    //        Console.WriteLine(c.Find(9));
    //    }
    //}
}
