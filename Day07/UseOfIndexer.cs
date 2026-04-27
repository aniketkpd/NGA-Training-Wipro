using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;




class MyCollection                                  // This class represents a collection of integers and implements an indexer to access its elements.
{
    private int[] arr = new int[10];                // This array will hold the integers in the collection.

    // Implementing the indexer
    public int this[int index]                      // This is the indexer definition. It allows us to access elements of the collection using an index.
    {
        get                                         // The 'get' accessor is used to retrieve the value at the specified index.
        {
            if (index < 0 || index >= arr.Length)   // OR condition to check if the index is within the bounds of the array.
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            return arr[index];
        }

        set                                         // The 'set' accessor is used to assign a value to the specified index.
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            arr[index] = value;
        }
    }
}





namespace Day7
{
    internal class UseOfIndexer
    {
        public static void Main()
        {
            MyCollection obj = new MyCollection();

            obj[0] = 10;   // using set
            obj[1] = 20;

            Console.WriteLine(obj[0]); // using get
            Console.WriteLine(obj[1]);
        }
    }
}
