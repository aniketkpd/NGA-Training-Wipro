//Binary Search implementation in C#
using System;

class BinarySearchClass
{
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                return mid; // Return the index of the found element
            }
            else if (arr[mid] < target)
            {
                left = mid + 1; // Search in the right half
            }
            else
            {
                right = mid - 1; // Search in the left half
            }
        }
        return -1; // Return -1 if the element is not found
    }
    static void Main()
    {
        int[] arr = { 1, 2, 3, 5, 8 }; // Note: The array must be sorted for binary search

        int target = 3;
        int index = BinarySearch(arr, target);
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