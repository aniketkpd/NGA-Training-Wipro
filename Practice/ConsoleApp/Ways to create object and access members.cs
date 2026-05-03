using System;

class Students
{
    public string name;
    public int age;

    // public Students()
    // {

    // }

    // public Students(string name, int age)
    // {
    //     this.name = name;
    //     this.age = age;
    // }
}


class Ways_to_create_object_and_access_members
{
    public static void Main()
    {
        //If we have constructor
        // Students st1 = new Students("Aniket", 20);
        // Console.WriteLine(st1.name);
        // Console.WriteLine(st1.age);

        //If we do not have constructor - Way 1
        // Students st2 = new Students();
        // st2.name = "Aniket";
        // st2.age = 20;

        // Console.WriteLine(st2.name);
        // Console.WriteLine(st2.age);

        //If we do not have constructor - Way2
        Students st3 = new Students
        {
            name = "Aniket",
            age = 22
        };

        Console.WriteLine(st3.name);
        Console.WriteLine(st3.age);





    }
}
