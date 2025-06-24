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

using lab_3;

Result a = new Result();
Result s = new Result();
a.add(1, 2);
s.sub(2, 1);
Console.ReadKey();