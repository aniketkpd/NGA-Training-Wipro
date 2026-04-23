using System;
using System.Collections.Generic;

class Student
{
    public string Name;
    public int Marks;
    public int Attendance;
    public int Participation;
}



class Program
{
    public static void Main()
    {

        List<Student> students = new List<Student>()


        {
            new Student { Name = "Arjun", Marks = 60, Attendance = 80, Participation = 70 },
            new Student { Name = "Meera", Marks = 45, Attendance = 60, Participation = 50 },
            new Student { Name = "Kabir", Marks = 85, Attendance = 90, Participation = 95 },
            new Student { Name = "Riya", Marks = 30, Attendance = 50, Participation = 40 }
        };



        // calculating total marks using Func delegate
        Func<Student, int> calculateTotal = delegate (Student s)
        {
            return s.Marks + s.Attendance + s.Participation;
        };



        // displaying student details using Action delegate
        Action<Student> displayStudent = (s) =>
        {
            Console.WriteLine("----- Student Report -----");
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Marks: " + s.Marks);
            Console.WriteLine("Attendance: " + s.Attendance);
            Console.WriteLine("Participation: " + s.Participation);
            Console.WriteLine("Total Score: " + calculateTotal(s));



            if (calculateTotal(s) >= 200)
            { 
                Console.WriteLine("Performance: Excellent");
            }
            else if (calculateTotal(s) >= 150)
            {
                Console.WriteLine("Performance: Good");
            }
            else
            { 
                Console.WriteLine("Performance: Needs Improvement");
            }

            Console.WriteLine();
        };



        //  calling the delegates
        foreach (var s in students)
        {
            displayStudent(s); 
        }






        // checking eligibility using Predicate delegate
        Predicate<Student> isEligible = (s) => s.Marks > 50;

        Console.WriteLine("----- Eligible Students (Marks > 50) -----");
        foreach (var s in students)
        {
            if (isEligible(s))
                Console.WriteLine(s.Name);
        }

        
        
        
        
        
        // filtering top performers
        List<Student> topStudents = students.FindAll(s => s.Marks > 75);

        Console.WriteLine("\n----- Top Performers (Marks > 75) -----");
        foreach (var s in topStudents)
        {
            Console.WriteLine(s.Name);
        }


    }
}