using System.Collections;

//ArrayList ar1 = new ArrayList();

//ar1.Add("stu1");
//ar1.Add("stu2");
//ar1.Add("stu3");
//ar1.Add("stu4");

//for(int i = 0; i<ar1.Count; i++)
//{
//    Console.WriteLine(ar1[i]);
//}

//ar1.Remove("stu2");

//ar1.RemoveAt(2);

//for (int i = 0; i < ar1.Count; i++)
//{
//    Console.WriteLine(ar1[i]);
//}

//ar1.Clear();

//--------------------2-------------------

//List <String> ls = new List<String>();

//ls.Add("1");
//ls.Add("2");
//ls.Add("3");
//ls.Add("4");
//ls.Add("5");

//ls.Remove("3");

//ls.RemoveRange(0, 2);

//for(int i = 0; i< ls.Count; i++)
//{
//    Console.WriteLine(ls[i]);
//}

//ls.Clear();

//------------------3------------------------

//Stack<Int64> st = new Stack<Int64>();

//st.Push(0);
//st.Push(1);
//st.Push(2);
//st.Push(3);
//st.Push(4);
//st.Push(5);

//st.Pop();

//Console.WriteLine(st.Peek());

//foreach(int i in st)
//{
//    Console.WriteLine(i);
//}

//--------------------4-------------------------

//Queue q = new Queue();

//q.Enqueue(1);
//q.Enqueue(2);
//q.Enqueue(3);
//q.Enqueue(4);
//q.Enqueue(5);
//q.Enqueue(6);

//foreach(int i in q)
//{
//    Console.WriteLine(i);
//}

//Console.WriteLine();

//q.Dequeue();
//q.Dequeue();

//foreach (int i in q)
//{
//    Console.WriteLine(i);
//}

//Console.WriteLine();

//Console.WriteLine(q.Peek());

//if (q.Contains(1))
//{
//    Console.WriteLine("Line ma chhe");
//}
//else
//{
//    Console.WriteLine("E nathiiiii...");
//}

//q.Clear();

//----------------------5----------------------

//Dictionary<int, string> dict = new Dictionary<int, string>();
//dict.Add(1, "Het");
//dict.Add(2, "Meet-1");
//dict.Add(3, "Meet-2");
//dict.Add(4, "Sumit");

//dict.Remove(2);
//if (dict.ContainsKey(3))
//{
//    Console.WriteLine("Key 3: " + dict[3]);
//}
//else
//{
//    Console.WriteLine("Chavi madel nathi...");
//}

//if (dict.ContainsValue("Het"))
//{
//    Console.WriteLine("chhe bhai chhe");
//}
//else
//{
//    Console.WriteLine("Gumnam haiiii");
//}

//foreach (var i in dict)
//{
//    Console.WriteLine(i.Key+" : " +i.Value);
//}
//dict.Clear();

//------------------6--------------------

Hashtable table = new Hashtable();
table.Add(1, "Het");
table.Add(2, "Meet-1");
table.Add(3, "Meet-2");
table.Add(4, "Sumit");

table.Remove(2);

if (table.ContainsKey(3))
{
    Console.WriteLine("Key 3: " + table[3]);
}
else
{
    Console.WriteLine("na madi");
}

if (table.ContainsValue("Het"))
{
    Console.WriteLine("table ma chhe");
}
else
{
    Console.WriteLine("nathi");
}
table.Clear();