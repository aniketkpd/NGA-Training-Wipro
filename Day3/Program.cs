
//Hello World program
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World");
    }
}






//Boxing unboxing Concept
Console.WriteLine("Boxing and Unboxing in C#");
//value type variables 
int a = 10;
//Boxing
object obj = a;
//Unboxing
int v = (int)obj;
Console.WriteLine(obj);
















//classes and objects
class Car
{
    //feild
    string color = "red";

    static void Main(string[] args)
    {
        //making object
        Car myObj = new Car();
        Console.WriteLine(myObj.color);
    }
}




using System;

class Animal
{
    //feild
    public string name;

    //method
    public void MakeSound()
    {
        Console.WriteLine(name + " makes sound");
    }
}

class Program
{
    static void Main()
    {
        Animal a1 = new Animal();
        a1.name = "Dog";

        //accessing members
        a1.MakeSound();
        Console.WriteLine(a1.name);
    }
}








using System;

class Student
{
    public string Name;
    public int Id;

    public Student(string name, int id)
    {
        this.Name = name;
        this.Id = id;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Name: " + Name + " Id: " + Id);
    }

    public void UpdateName(string n)
    {
        Name = n;
    }

    public void UpdateId(int i)
    {
        Id = i;
    }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student("Aniket", 101);
        Student s2 = new Student("Rahul", 102);

        s1.DisplayInfo();
        s2.DisplayInfo();

        s1.UpdateName("Aniket Kumar");
        s1.UpdateId(201);

        Console.WriteLine("After Update:");
        s1.DisplayInfo();
    }
}










using System;

class Program
{
    static void Main()
    {
        int num = 10;

        object obj = num;
        Console.WriteLine(obj);

        int num2 = (int)obj;
        Console.WriteLine(num2);

        Console.WriteLine(obj.GetType());
        Console.WriteLine(num2.GetType());
    }
}