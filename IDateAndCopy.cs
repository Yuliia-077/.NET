using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    public interface IDateAndCopy
    {
        object DeepCopy();

        DateTime Date { get; set; }
    }
}
