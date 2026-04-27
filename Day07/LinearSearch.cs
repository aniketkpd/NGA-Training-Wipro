//Linear Search Algorithm in C#
using System;

class LinearSearchClass
{
    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                return i; // Return the index of the found element
            }
        }
        return -1; // Return -1 if the element is not found
    }



    static void Main()
    {
        int[] arr = { 5, 3, 2, 8, 1 };
        int target = 2;
        int index = LinearSearch(arr, target);
        if (index != -1)
        {
            Console.WriteLine($"Element found at index: {index}");
        }
        else
        {
            Console.WriteLine("Element not found in the array.");
        }
    }
}