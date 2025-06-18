using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    internal class Area2
    {
        public void findArea(float a)
        {
            Console.WriteLine(3.14 * a * a);
        }

        public void findArea(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        public void findArea(int a)
        {
            Console.WriteLine(a * a);
        }
    }
}
