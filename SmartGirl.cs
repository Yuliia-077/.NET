using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    [Couple(Pair = "Student", Probability = 0.2, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 0.5, ChildType = "Book")]
    class SmartGirl:Human
    {
        public SmartGirl() : base("SmartGirl")
        { }
        public SmartGirl(string name) : base(name)
        { }
    }
}
