using System;
using System.Collections.Generic;
using System.Text;

//Event Delicating Model


namespace Day6
{
    public delegate void MyDelegate();

    class Model1
    {
        public static void Hello()
        {
            Console.WriteLine("Hello");
        }

        public static void Main()
        {
            MyDelegate d = Hello;
            d(); // direct call
        }
    }
}
