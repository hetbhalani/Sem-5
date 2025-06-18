using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    internal class RBI
    {
        public void calculateInterest(int p)
        {
            Console.WriteLine((p * 3 * 3) / 100);
        }
    }
    class HDFC : RBI
    {
        public void calculateInterest(int p)
        {
            Console.WriteLine((p * 1.2 * 2) / 100);
        }
    }
    class SBI : RBI
    {
        public void calculateInterest(int p)
        {
            Console.WriteLine((p * 6 * 2) / 100);
        }
    }
    class ICICI : RBI
    {
        public void calculateInterest(int p)
        {
            Console.WriteLine((p * 3.14 * 3) / 100);
        }
    }
}
