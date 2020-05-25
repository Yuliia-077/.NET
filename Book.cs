using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class Book:IHasName
    {
        public string Name { get; }
        public Book(string name)
        {
            Name = name;
        }
        public Book()
        {
            Name = "Book";
        }
    }
}
