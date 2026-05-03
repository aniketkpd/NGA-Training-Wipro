
using System;

public class Sorting_an_array
{
    public static void Main(string[] args)
    {
        //mistake
        int[] arr; // declare
        arr = new int[6] { 5, 3, 6, 0, 2, 1 };

        Array.Sort(arr);
        int[] sorted_arr;
        sorted_arr = new int[6];

        for (int i = 0; i < arr.Length; i++)
        {
            sorted_arr[i] = arr[i];
        }



        for (int i = 0; i < sorted_arr.Length; i++)
        {
            Console.WriteLine(sorted_arr[i]);
        }


    }
}




