using System;

public class Ways_to_create_array
{
    public static void Main(string[] args)
    {
        // Array
        //Way 1
        // int[] arr = {1,2,3};


        //Way 2
        // int[] arr = new int[] {1,2,3};

        //Way 3
        //int[] arr = new int[3] {1,2,3};

        //Way 4
        // int[] arr = new int[3];
        // arr[0] = 1;
        // arr[1] = 2;
        // arr[2] = 3;


        //Way 5
        // int[] arr; //declaration first
        // arr = new int[] {1,2,3}; //initialisation later using new keyword


        //Way 6
        int[] arr; //declaration first
        arr = new int[10]; //allocating size later
        //then adding elements later
        arr[0] = 1;
        arr[1] = 2;
        arr[2] = 3;


        foreach (int i in arr)
        {
            Console.WriteLine(i);
        }





    }
}
