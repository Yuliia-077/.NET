using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    [Couple(Pair = "Student", Probability = 0.4, ChildType = "PrettyGirl")]
    [Couple(Pair = "Botan", Probability = 0.1, ChildType = "PrettyGirl")]
    class PrettyGirl:Human
    {
        public PrettyGirl() : base("PrettyGirl")
        { }
        public PrettyGirl(string name) : base(name)
        { }
    }
}
