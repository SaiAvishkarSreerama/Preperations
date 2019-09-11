using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.ConcpetsAndPrograms
{
    // Tuple is a data structure used to create a data set of same or different kind, like Array/List but they can maintain same datatype
    // Tuple can maintain up to 8 elements, more than 8 gives error
    // Syntax: Tuple<T1 T2 T3 T4>
    // Tuple can be created in two ways
        //1. Using constructor of tuple class
            //Tuple<T1>(T1)
            //Tuple<T1, T2>(T1, T2).... up to T8
        //2. Using create method
            //Create(T1)
            //Create(T1, T2)...up to T8
    public class Tuple
    {
        //static void Main()
        //{
        //    // Tuple with one element
        //    Tuple<string> t_String = new Tuple<string>("using constructor");

        //    //Tuple with multiple elements
        //    Tuple<int, string, int, int> t_person = new Tuple<int, string, int, int>(1, "Sai Avishakr, Sreerama", 25, 051612);
        //}
    }
}

//TODO: Need to figure out why tuple class is not accepting a namespace?
public class GFG
{
    //static void Main()
    //{
    //    CreateTuple();
    //}
    // Main method 
    static public void CreateTuple()
    {

        // Creating 1-tuple 
        // Using Create Method 
        var My_Tuple1 = Tuple.Create("GeeksforGeeks");

        // Creating 4-tuple 
        // Using Create Method 
        var My_Tuple2 = Tuple.Create(12, 30, 40, 50);

        Console.WriteLine("1 Element in Tuple class : " + My_Tuple2.Item1);
        Console.WriteLine("2 Element in Tuple class : " + My_Tuple2.Item2);
        Console.WriteLine("3 Element in Tuple class : " + My_Tuple2.Item3);
        Console.WriteLine("4 Element in Tuple class : " + My_Tuple2.Item4);

        // Creating 8-tuple 
        // Using Create Method 
        var My_Tuple3 = Tuple.Create(13, "Geeks",
                67, 89.90, 'g', 39939, "geek", 10);

        Console.WriteLine("1 Element in Tuple class : "+ My_Tuple3.Item1);
        Console.WriteLine("2 Element in Tuple class : "+ My_Tuple3.Item2);
        Console.WriteLine("3 Element in Tuple class : "+ My_Tuple3.Item3);
        Console.WriteLine("4 Element in Tuple class : "+ My_Tuple3.Item4);
        Console.WriteLine("5 Element in Tuple class : "+ My_Tuple3.Item5);
        Console.WriteLine("6 Element in Tuple class : "+ My_Tuple3.Item6);
        Console.WriteLine("7 Element in Tuple class : "+ My_Tuple3.Item7);
        Console.WriteLine("8 Element in Tuple class : "+ My_Tuple3.Rest);

        //Nested Tuple class
        var My_Tuple4 = Tuple.Create(1, 2, 3, Tuple.Create(4.1, 4.2, 4.3, Tuple.Create(4.41,4.42,4.43)), 5, 6, 7, 8);

        Console.WriteLine("1 Element in Tuple class : " + My_Tuple4.Item1);
        Console.WriteLine("2 Element in Tuple class : " + My_Tuple4.Item2);
        Console.WriteLine("3 Element in Tuple class : " + My_Tuple4.Item3);

        Console.WriteLine("4 Element in Tuple class : " + My_Tuple4.Item4);
        Console.WriteLine("4 Element in Tuple class : " + My_Tuple4.Item4.Item1);
        Console.WriteLine("4 Element in Tuple class : " + My_Tuple4.Item4.Item2);
        Console.WriteLine("4 Element in Tuple class : " + My_Tuple4.Item4.Item3);

        Console.WriteLine("4 Element in Tuple class : " + My_Tuple4.Item4.Item4);
        Console.WriteLine("4 Element in Tuple class : " + My_Tuple4.Item4.Item4.Item1);
        Console.WriteLine("4 Element in Tuple class : " + My_Tuple4.Item4.Item4.Item2);
        Console.WriteLine("4 Element in Tuple class : " + My_Tuple4.Item4.Item4.Item3);

        Console.WriteLine("5 Element in Tuple class : " + My_Tuple4.Item5);
        Console.WriteLine("6 Element in Tuple class : " + My_Tuple4.Item6);
        Console.WriteLine("7 Element in Tuple class : " + My_Tuple4.Item7);
        Console.WriteLine("8 Element in Tuple class : " + My_Tuple4.Rest);

        //Tuple as parameters
        var My_Tuple5 = Tuple.Create(1, 2, 3);
        TupleAsParamenterClass(My_Tuple5);

        //return tuple type
        var returnValue = PrintTheTuple();
        Console.WriteLine("1 Element in Tuple class : " + returnValue.Item1);
        Console.WriteLine("2 Element in Tuple class : " + returnValue.Item2);
        Console.WriteLine("3 Element in Tuple class : " + returnValue.Item3);

        var My_Tuple6 = Tuple.Create(100, 200, 300);

        //Pass tuple as parameter and Return tuple the tuple as reversible values
        var val = PrintTheTupleReturnTheTuple(My_Tuple6);
        Console.WriteLine("1 Element in Tuple class : " + val.Item1);
        Console.WriteLine("2 Element in Tuple class : " + val.Item2);
        Console.WriteLine("3 Element in Tuple class : " + val.Item3);

    }

    //As parameter
    static void TupleAsParamenterClass(Tuple<int, int, int> My_Tuple4)
    {
        Console.WriteLine("1 Element in Tuple class : " + My_Tuple4.Item1);
        Console.WriteLine("2 Element in Tuple class : " + My_Tuple4.Item2);
        Console.WriteLine("3 Element in Tuple class : " + My_Tuple4.Item3);
    }

    //Returns tuple
    static Tuple<int, string, int> PrintTheTuple()
    {
        return Tuple.Create(1, "stringValue", 2);
    }

    //Accepts Tuple as a parameter and return the reverse tuple
    static Tuple<int, string, int> PrintTheTupleReturnTheTuple(Tuple<int, int, int> My_Tuple6)
    {
        Console.WriteLine("1 Element in Tuple class : " + My_Tuple6.Item1);
        Console.WriteLine("2 Element in Tuple class : " + My_Tuple6.Item2);
        Console.WriteLine("3 Element in Tuple class : " + My_Tuple6.Item3);
        return Tuple.Create(My_Tuple6.Item3, My_Tuple6.Item2.ToString(), My_Tuple6.Item1);
    }
}