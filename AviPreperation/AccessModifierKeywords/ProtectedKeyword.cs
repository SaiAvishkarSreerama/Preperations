using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.AccessModifierKeywords
{
    class X
    {
        protected int x;

        public X()
        {
            x = 10;
        }
    }

    class Y : X
    {
        public int getX()
        {
            return x;
        }
    }

    class ProtectedProgram
    {
        //static void Main()
        //{
        //    X obj1 = new X();
        //    Y obj2 = new Y();

        //    Console.WriteLine("Value : {0}", obj2.getX());
        //}
    }
}