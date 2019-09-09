using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AviPreperation
{
    /***************************ABSTRACT**********************************************/
    //The purpose of an abstract class is to provide a common definition of a base class that multiple derived classes can share
    //Abstarct modifier has a missing body in its methods
    //Abstract methods can only be used in abstarct classes
    //Override modifier must be used to define the abstarct class in inherited class
    // virtual => abstarct => override
    abstract class Shape //base class
    {
        public abstract int GetArea(); //overridden base method, no implementation in the body

    }

    /*inherited class from base class Shape - derived class*/
    class Square : Shape
    {
        int side;
        public Square(int n) => side = n;
        
        static int Hello()
        {
            return 1;
        }
        public override int GetArea()
        {
            return side * side;
        }

        //static void Main()
        //{
        //    var sq = new Square(12);
        //    Console.WriteLine(sq.GetArea());
        //}
    }


    /***********************ASYNC***************************/
    //An async method runs synchronously until it reaches its first await expression, at which point the method is suspended until the awaited task is complete
    //If the method that the async keyword modifies doesn't contain an await expression or statement, the method executes synchronously
    //A compiler warning alerts you to any async methods that don't contain await statements
    class AsyncExample
    {
        private async void ButtonClick()
        {
            try
            {
                int length = await GetTextBox();
            }
            catch (Exception ex)
            {

            }
        }

        //To get Tasks => System.Threading.Tasks
        private async Task<int> GetTextBox()
        {
            return Convert.ToInt32(100.00);
        }

    }

    //declaring an event keyword before the delegate reference type data type creates an event, here someEventHadler is a delegate
    // by putting event keyword it becomes an event 
    public class eventModifier
    {

        public delegate void someEventHandler();

        public event someEventHandler sampleEvent;


        //Example for Event - Publisher
        public class printHelper
        {

            public delegate void BeforePrint();

            public event BeforePrint beforePrintEvent;

            public printHelper() { }

            public void printNumber(int num)
            {
                if (beforePrintEvent != null)
                    beforePrintEvent();

                Console.WriteLine("Number: {0, -12:No}", num);
            }
        }
        //Subscriber
        public class Number
        {
            public printHelper _printHelper;
            public int _value;

            void printHelper_beforePrintevent()
            {
                Console.WriteLine("print the value");
            }

            public Number(int val)
            {
                _value = val;
                _printHelper = new printHelper();

                //subscribe to event
                _printHelper.beforePrintEvent += printHelper_beforePrintevent;
            }

            public void printMoney()
            {
                _printHelper.printNumber(_value);
            }

        }
    }

    // Extern + static
    // Extern and abstract cannot use together to modify the same member
    // Using the extern modifier means that the method is implemented outside the C# code
    // Using the abstract modifier means that the method implementation is not provided in the class
    public class ExternModifier
    {
        //[DllImport("avifile32.dll")]
        //public static extern void AnyMethod();

        //extern alias GridV1;
        //extern alias GridV2;

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type );

        //here type=0 Ok btn box
        //type-1 ok, cancel box
        //type-2 abort, retry, ignor
        //type-3 yes, no, cancel
        //type-4 yes, no
        //static int Main()
        //{
        //    string myString;
        //    Console.WriteLine("Enter you message: ");
        //    myString = Console.ReadLine();
        //    return MessageBox((IntPtr)0, myString, "My Message Box", 4);
        //}

    }

}
