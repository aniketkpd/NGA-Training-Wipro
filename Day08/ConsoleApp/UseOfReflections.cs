using System;
using System.Reflection;

class A
{
    //feilds
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }



    //methods
    public void Method1()
    {
        Console.WriteLine("Method1");
    }

    public void Method2()
    {
        Console.WriteLine("Method2");
    }

}

class UseofReflections
{
    public static void Main(string[] args)
    {
        //code for reflections
        Type t = typeof(A);

        //We can get the information about the class using the Type object
        //Console.WriteLine("Name of class: " + t.Name);
        //Console.WriteLine("Full name of class: " + t.FullName);
        //Console.WriteLine("Namespace of class: " + t.Namespace);
        //Console.WriteLine("Is class public: " + t.IsPublic);
        //Console.WriteLine("Is class abstract: " + t.IsAbstract);





        //foreach (var p in t.GetProperties())
        //{
        //    Console.WriteLine("Property: " + p.Name);
        //}


        //foreach (var m in t.GetMethods())
        //{
        //    Console.WriteLine("Method: " + m.Name);
        //}


        //printing the array of t.GetMethods()
        foreach (var m in t.GetMethods())
        {
            Console.WriteLine(m);
        }




    }
}