using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    [Couple(Pair = "Girl", Probability = 0.7, ChildType = "SmartGirl")]
    [Couple(Pair = "PrettyGirl", Probability = 1, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 0.8, ChildType = "Book")]
    class Botan:Human
    {
        public Botan() : base("Botan")
        { }
        public Botan(string name) : base(name)
        { }
    }
}
