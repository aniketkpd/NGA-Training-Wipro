using System;

class UseOfOut
{
    static void GetValues(out int a, out int b)
    {
        a = 10;
        b = 20;
    }

    static void Main()
    {
        int x, y; // no need to initialize

        GetValues(out x, out y);

        Console.WriteLine(x); // 10
        Console.WriteLine(y); // 20
    }
}



