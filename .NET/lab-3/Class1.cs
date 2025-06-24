using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    abstract class Sum
    {
        public abstract void SumOfTwo(int a, int b);
        public abstract void SumOfThree(int a, int b, int c);
    }
    class Calculate : Sum
    {
        public override void SumOfTwo(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public override void SumOfThree(int a, int b, int c)
        {
            Console.WriteLine(a + b + c);
        }
    }

    //-------------------4---------------------
    interface Calculate_1
    {
        void add(int a, int b);
        void sub(int a, int b);
    }
    class Result : Calculate_1
    {
        public void add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public void sub(int a, int b)
        {
            Console.WriteLine(a - b);
        }
    }
}
