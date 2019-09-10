using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.ConcpetsAndPrograms
{
    //Boxing is process of converting Value Type to an object or interface type (Reference type)
    //When CLR boxes the value type, it wraps the value inside object instance and stores in managed heap
    //Boxing is used to store the value type in Garbage collected heap
    class BoxingAndUnboxing
    {
        //Main Method
        //static void Main()
        //{
        //    Boxing();
        //    UnBoxing();
        //}

        public static void Boxing()
        {
            int num = 2000;

            //boxing
            object obj = num;

            num = 100;

            Console.WriteLine("Value - Type value of num is {0}", num);
            Console.WriteLine("Object- Type value of num is {0}", obj);


            //StringBuilder obj1 = new StringBuilder("2000");
            //StringBuilder obj2 = obj1;
            //Console.WriteLine("BEfore Value - Type value of num is {0}", obj1);
            //Console.WriteLine("BEfore Value - Type value of num is {0}", obj2);
            //obj1.Append("3000");
            //Console.WriteLine("after Value - Type value of num is {0}", obj1);
            //Console.WriteLine("after Value - Type value of num is {0}", obj2);
        }

        //UnBoxing is process of extracting the value from the object or converting reference type to value type
        static void UnBoxing()
        {
            int num = 9000;

            object obj = num;

            int i = (int)obj;

            Console.WriteLine("Value of object is : " + obj);
            Console.WriteLine("value after unboxing: " + i);
            Console.ReadLine();
        }
    }
}
