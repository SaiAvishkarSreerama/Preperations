using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    public class Logger
    {

        Dictionary<string, int> d;
        /** Initialize your data structure here. */
        public Logger()
        {
            d = new Dictionary<string, int>();
        }

        /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
            If this method returns false, the message will not be printed.
            The timestamp is in seconds granularity. */
        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (!d.ContainsKey(message))
            {
                d.Add(message, timestamp);
                return true;
            }
            if (timestamp - d[message] >= 10)
            {
                d[message] = timestamp;
                return true;
            }
            else
                return false;
        }
    }

    /**
        * Your Logger object will be instantiated and called as such:
        * Logger obj = new Logger();
        * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
        */
}
