using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class Test
    {
        string NameOfTest { get; set; }
        bool CreditTheTest { get; set; }
        public Test(string nameOfTest, bool creditTheTest)
        {
            NameOfTest = nameOfTest;
            CreditTheTest = creditTheTest;
        }

        public Test() : this("Python", false)
        { }

        public override string ToString()
        {
            return NameOfTest + " " + CreditTheTest;
        }

        public Test DeepCopy()
        {
            Test other = (Test)this.MemberwiseClone();
            return other;
        }




    }
}
