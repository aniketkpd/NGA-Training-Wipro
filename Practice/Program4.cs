//reflection
using System;
using System.Reflection;

namespace practice
{ 

    class Program4
    {
        static void Main()
        {
            Type t1 = typeof(Program);

            foreach (var m in t1.GetMethods())
            {
                Console.WriteLine(m.Name);
            }

        }
    }

}