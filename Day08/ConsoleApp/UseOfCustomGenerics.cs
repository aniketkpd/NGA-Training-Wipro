using System;
using System.Collections.Generic;
using System.Text;


namespace Day8
{

    class MyGenerics<T>
    {
        public T data;

        public void display()
        {
            Console.WriteLine("Data: " + data);
        }
    }


    class UseOfCustomGenerics
    {
        public static void Main(string[] args)
        { 
            MyGenerics<int> intObj = new MyGenerics<int>();
            intObj.data = 42;
            intObj.display();
        }

    }
}
