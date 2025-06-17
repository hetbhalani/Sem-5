using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    //-----------------------3----------------------
    abstract class Sum
    {
        public abstract void SumOfTwo(int a, int b);
        public abstract void SumOfThree(int a, int b,int c);
    }
    class Calculate : Sum
    {
        public override void SumOfTwo(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public override void SumOfThree(int a, int b,int c)
        {
            Console.WriteLine(a + b +c);
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


    class Program
    {
        static void Main(string[] args)
        {
            //int zero = 0;

            //try
            //{
            //    Console.WriteLine(5 / zero);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            //-------------------------2------------------------

            //int n = 5;
            //int[] a = new int[n];

            //try
            //{
            //    for (int i = 0; i <= n; i++)
            //    {
            //        a[i] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            //catch (Exception e) 
            //{
            //    Console.WriteLine(e);
            //}

            //-------------------------3-----------------------

            //Calculate s1 = new Calculate();
            //s1.SumOfTwo(1, 2);

            //s1.SumOfThree(1, 2, 3);

            //Console.ReadKey();

            //-----------------------4----------------------------

            Result a = new Result();
            Result s = new Result();
            a.add(1, 2);
            s.sub(2, 1);
            Console.ReadKey();
        }
    }
}