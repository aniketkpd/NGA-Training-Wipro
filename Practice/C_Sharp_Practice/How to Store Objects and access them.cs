

using System;
using System.Collections.Generic;

//Storing students data as objects in an array

class Student
{
    //fields
    public string name;
    public int age;

    //constructor
    // public Student(string name, int age)
    // {
    //     this.name = name;
    //     this.age = age;
    // }
}

class How_to_Store_Objects_and_access_them
{
    public static void Main(string[] args)
    {

        //I want an array to store objects of a particular class
        // Student[] arr =  new Student[5];

        //I want to store my objects into a List

        List<Student> StudentList = new List<Student>();

        StudentList.Add(new Student
        {
            name = "Aniket",
            age = 20
        });


        StudentList.Add(new Student
        {
            name = "Rahul",
            age = 22
        });

        StudentList.Add(new Student
        {
            name = "Mohan",
            age = 19
        });





        foreach (var i in StudentList)
        {
            Console.WriteLine(i.name + " " + i.age);

        }
    }
}
