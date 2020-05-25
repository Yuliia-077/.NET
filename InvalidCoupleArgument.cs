using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    internal class InvalidCoupleArgument : Exception
    {
        public InvalidCoupleArgument(string message) : base(message)
        {}
    }
}
