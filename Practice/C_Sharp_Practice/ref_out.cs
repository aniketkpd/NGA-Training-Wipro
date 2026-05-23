//ref and out keyword
using System;
namespace Practice
{ 
    class ref_out
    {
        static void GetNumUsingOut(out int a)
        {
            // out variable must be assigned here
            a = 10;
        }

        static void GetNumUsingRef(ref int b)
        {
            // No need to assign ref variable
        }

        static void Main()
        {
            // Initialisation not needed for out variable
            int x;
            GetNumUsingOut(out x);
            Console.WriteLine(x);

            // Initialisation needed for out variable
            int y = 20;
            GetNumUsingRef(ref y);
            Console.WriteLine(y);


        }
    }


}

