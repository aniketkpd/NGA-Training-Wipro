using System;



//Rules of struct
//Cannot have parameterless constructor (by default behavior exists)
//Cannot inherit from another class
//Can implement interfaces
//Stored mostly in stack

namespace Day9.Structure_in_c_Sharp
{
    struct Student
    {
        public int Id;
        public string Name;
        public int Age;



        //struct constructor
        public Student(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }



        public void Display()
        {
            Console.WriteLine($"Id: {this.Id}, Name: {this.Name}, Age: {this.Age}");
        }
    }

    class UseOfStruct
    {
        public static void Main()
        {
            //Student st1;

            //st1.Id = 1;
            //st1.Name = "Rudi";
            //st1.Age = 20;

            //st1.Display();









            Student s2 = new Student(11,"tanjiro",22);
            
            s2.Display();
        }
    }
}
