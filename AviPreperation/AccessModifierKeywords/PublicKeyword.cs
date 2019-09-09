using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.AccessModifierKeywords
{
    class student
    {
        public int rollNo;
        public string name;

        public student(int r, string n)
        {
            rollNo = r;
            name = n;
        }

        public int getRollNo()
        {
            return rollNo;
        }

        public string getName()
        {
            return name;
        }
    }

    class accessModifierProgram
    {
        //static void Main(string[] args)
        //{
        //    var student = new student(41, "Sai Avishakr, Sreerama");

        //    Console.WriteLine("Student No : {0}", student.rollNo);
        //    Console.WriteLine("Student Name : {0}", student.name);

        //    Console.WriteLine("Student No from method: {0}", student.getRollNo());
        //    Console.WriteLine("Student Name from method: {0}", student.getName());

        //}
    }
}
