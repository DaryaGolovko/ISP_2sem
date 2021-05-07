using System;
using System.Collections.Generic;

namespace lab6
{
    class GenericInput<T>
    {
        public void Input(T input) 
        {
            Console.WriteLine(input);
        }
    }
}
