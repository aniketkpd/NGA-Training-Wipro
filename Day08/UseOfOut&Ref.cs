using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    internal class UseOfOut_Ref
    {

        public static void GetValueOut(out int value)
        {
            //must assign value before return
            value = 25;
        }

        public static void GetValueRef(ref int value)
        {

        }


        public static void Main(string[] args)
        {
            int x;
            GetValueOut(out x);
            Console.WriteLine(x);   //output: 25

            //must initialize value before passing to method
            int y = 11;
            GetValueRef(ref y);
            Console.WriteLine(y);   //output: 11
        }
    }
}
