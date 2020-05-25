using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    class CoupleAttribute: Attribute
    {
        public string Pair { get; set; }
        public double Probability { get; set; }
        public string ChildType { get; set; }
       
    }
}
