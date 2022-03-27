using System;
using System.Collections.Generic;
using System.Text;

namespace CricketDataTypes
{
    public class InvalidBookingException: Exception
    {

        public InvalidBookingException()
        {
        }

        public InvalidBookingException(string message)
            : base(message)
        {
        }

        public InvalidBookingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
