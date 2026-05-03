//Collections

//using System;
//using System.Collections.Generic;
//public class Collections
//{
//    public static void Main(string[] args)
//    {
//        //List
//        List<int> oddnumber = new List<int>();

//        oddnumber.Add(1);
//        oddnumber.Add(3);
//        oddnumber.Add(5);

//        foreach (var i in oddnumber)
//        {
//            Console.WriteLine(i);
//        }

//    }
//}





//using System;
//using System.Collections.Generic;
//public class Collections
//{
//    public static void Main(string[] args)
//    {
//        //Dictionary
//        Dictionary<int, string> mydict = new Dictionary<int, string>();

//        mydict.Add(1, "A");
//        mydict.Add(2, "B");
//        mydict.Add(3, "C");

//        Console.WriteLine(mydict[3]);

//    }
//}








//using System;
//using System.Collections.Generic;
//public class Collections
//{
//    public static void Main(string[] args)
//    {

//        // Queue
//        Queue<string> myq = new Queue<string>();

//        myq.Enqueue("A");
//        myq.Enqueue("B");
//        myq.Enqueue("C");

//        Console.WriteLine(myq.Dequeue());
//        Console.WriteLine(myq.Dequeue());
//        Console.WriteLine(myq.Dequeue());

//    }
//}













//using System;
//using System.Collections.Generic;
//public class Collections
//{
//    public static void Main(string[] args)
//    {

//        //Stack
//        Stack<int> mystk = new Stack<int>();

//        mystk.Push(1);
//        mystk.Push(2);
//        mystk.Push(3);

//        Console.WriteLine(mystk.Pop());
//        Console.WriteLine(mystk.Pop());
//        Console.WriteLine(mystk.Pop());

//    }
//}









using System;
using System.Collections.Generic;
public class Collections
{
    public static void Main(string[] args)
    {

        //Hashset
        HashSet<int> myset = new HashSet<int>();

        myset.Add(1);
        myset.Add(1);
        myset.Add(2);
        myset.Add(3);

        foreach (var i in myset)
        {
            Console.WriteLine(i);
        }

    }
}