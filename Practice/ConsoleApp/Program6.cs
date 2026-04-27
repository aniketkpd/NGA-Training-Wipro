//Anonymous and Lamda
using System;
namespace practice
{ 

    class Program6
    {
        delegate void mydel(int x);
        static void Main()
        {
            // Anonymous function (build on delegate)
            // mydel d = delegate(int x)
            // {
            //     Console.WriteLine(x);
            // };

            // d(2);

            //Lamda also build on delegates | Function has no nmae
            mydel lam = (y) => Console.WriteLine(y);
            lam(22);
        }
    }



    //Expression-bodied | function has name but written in short form , not an lambda
    //void sum(int x, int y) => Console.WriteLine(x + y);
    //sum(2, 2);



}