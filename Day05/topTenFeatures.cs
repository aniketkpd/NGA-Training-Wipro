using System;
using System.Collections.Generic;
using System.Linq;



// 1. Pattern Matching (C# 7)
/*
class topTenFeatures
{
    static void Main()
    {
        object obj = 10;

        if (obj is int x)
            Console.WriteLine($"Integer: {x}");
    }
}
*/



// 2. Tuples (C# 7)
/*
class topTenFeatures
{
    static void Main()
    {
        (int, string) data = (1, "Aniket");
        Console.WriteLine($"{data.Item1} {data.Item2}");
    }
}
*/


// 3. Out Variables (C# 7)
/*
class topTenFeatures
{
    static void Main()
    {
        if (int.TryParse("123", out int num))
            Console.WriteLine(num);
    }
}
*/



// 4. Local Functions (C# 7)
/*
class topTenFeatures
{
    static void Main()
    {
        int Square(int x) => x * x;
        Console.WriteLine(Square(5));
    }
}
*/


// 5. Switch Pattern Matching (C# 8)
/*
class topTenFeatures
{
    static void Main()
    {
        object obj = 25;

        string result = obj switch
        {
            int n => $"Integer {n}",
            string s => $"String {s}",
            _ => "Unknown"
        };

        Console.WriteLine(result);
    }
}
*/




// 6. Nullable Reference Types (C# 8)
/*
class topTenFeatures
{
    static void Main()
    {
        string? name = null;
        Console.WriteLine(name ?? "No Name");
    }
}
*/





// 7. Using Declaration (C# 8)
/*
class topTenFeatures
{
    static void Main()
    {
        using var file = new System.IO.MemoryStream();
        Console.WriteLine("Using without block");
    }
}
*/




// 8. Expression-bodied Members
/*
class topTenFeatures
{
    static void Main()
    {
        Console.WriteLine(Add(2, 3));
    }

    static int Add(int a, int b) => a + b;
}
*/


// 9. Index and Range (C# 8)
/*
class topTenFeatures
{
    static void Main()
    {
        int[] arr = {1,2,3,4,5};

        Console.WriteLine(arr[^1]);
        var slice = arr[1..4];

        foreach (var i in slice)
            Console.Write(i + " ");
    }
}
*/



// 10. Default Interface Methods (C# 8)

interface ITest
{
    void Show() => Console.WriteLine("Default Method");
}

class Test : ITest {}

class topTenFeatures
{
    static void Main()
    {
        ITest obj = new Test();
        obj.Show();
    }
}
