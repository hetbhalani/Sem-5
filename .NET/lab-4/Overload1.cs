using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    internal class Overload1
    {
        public void sum(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public void sum(float a, float b)
        {
            Console.WriteLine(a + b);
        }
    }
}
