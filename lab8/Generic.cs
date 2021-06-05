using System;
using System.Collections.Generic;

namespace Sport
{
    class GenericInput<T>
    {
        public void Input(T input) 
        {
            Console.WriteLine(input);
        }
    }
}
