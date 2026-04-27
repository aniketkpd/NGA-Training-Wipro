using System;
using System.Reflection;

namespace Day8
{

    //class for reflection
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Study()
        {
            Console.WriteLine("Student is studying");
        }

        public void Play()
        {
            Console.WriteLine("Student is playing");
        }
    }




    //generic class
    class Box<T>
    {
        public T Value;

        public void Display()
        {
            Console.WriteLine("Value: " + Value);
        }
    }






    class ScenarioOngenerics
    {

        // Generic Method
        static void PrintData<T>(T data)
        {
            Console.WriteLine("Generic Method Output: " + data);
        }



        static void UpdateValue(ref int number)
        {
            number = number + 10;
        }



        static void GetValues(out int result, out string message)
        {
            result = 100;
            message = "Operation Successful";
        }






        public static void Main()
        {

            Type type = typeof(Student);
            Console.WriteLine("Class Name: " + type.Name);

            Console.WriteLine("\nProperties:");
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine(prop.Name);
            }

            Console.WriteLine("\nMethods:");
            foreach (var method in type.GetMethods())
            {
                if (method.DeclaringType == type) // only student methods
                    Console.WriteLine(method.Name);
            }




            Box<int> intBox = new Box<int>();
            intBox.Value = 10;
            intBox.Display();

            Box<string> strBox = new Box<string>();
            strBox.Value = "Hello";
            strBox.Display();




            PrintData(50);
            PrintData("Aniket");


            int num = 5;
            Console.WriteLine("Before: " + num);

            UpdateValue(ref num);

            Console.WriteLine("After: " + num);


            int result;
            string message;

            GetValues(out result, out message);

            Console.WriteLine("Result: " + result);
            Console.WriteLine("Message: " + message);
        }
    }
}