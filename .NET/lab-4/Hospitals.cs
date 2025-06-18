using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    internal class Hospitals
    {
        public void HospitalDetails()
        {
            Console.WriteLine("Hospital number ek");
        }
    }
    class Apollo : Hospitals
    {
        public void HospitalDetails()
        {
            Console.WriteLine("Biju davakhanu");
        }
    }

    class Wockhardt : Hospitals
    {
        public void HospitalDetails()
        {
            Console.WriteLine("Triju davakhanu");
        }
    }

    class Gokul : Hospitals
    {
        public void HospitalDetails()
        {
            Console.WriteLine("chothu davakhanu");
        }
    }
}
