using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.AccessModifierKeywords
{
    class InternalKeyword
    {
        internal int number;

        public InternalKeyword()
        {
            number = 10;
        }
    }

    class internalDerived 
    {
        //static void Main()
        //{
        //    var obj = new InternalKeyword();

        //    Console.WriteLine(obj.number);
        //}
    }
}
