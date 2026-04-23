//Student Activity Evaluation 

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


    // delegate for evaluation
    delegate void EvaluateStudent(Student s);

    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>()
        
        
        
        
        // sample student
        {
            new Student { Name = "Arjun", Marks = 60, Attendance = 80, Participation = 70 },
            new Student { Name = "Meera", Marks = 45, Attendance = 60, Participation = 50 },
            new Student { Name = "Kabir", Marks = 85, Attendance = 90, Participation = 95 },
            new Student { Name = "Riya", Marks = 30, Attendance = 50, Participation = 40 }
        };

       
        
        
        // anonymous method
        EvaluateStudent evaluator = delegate (Student s)
        {
            int totalScore = s.Marks + s.Attendance + s.Participation;

            Console.WriteLine("----- Student Report -----");
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Marks: " + s.Marks);
            Console.WriteLine("Attendance: " + s.Attendance);
            Console.WriteLine("Participation: " + s.Participation);
            Console.WriteLine("Total Score: " + totalScore);

            if (totalScore >= 200)
                Console.WriteLine("Performance: Excellent");
            else if (totalScore >= 150)
                Console.WriteLine("Performance: Good");
            else
                Console.WriteLine("Performance: Needs Improvement");

            Console.WriteLine();
        };




        // calling the delegate for each student for evaluation
        foreach (var s in students)
        {
            evaluator(s);
        }




        // lambda Expression - for checking eligibility based on marks
        Predicate<Student> isEligible = s => s.Marks > 50;

        Console.WriteLine("----- Eligible Students (Marks > 50) -----");
        foreach (var s in students)
        {
            if (isEligible(s))
                Console.WriteLine(s.Name);
        }






        // Lambda + FindAll  - to filter top performers
        List<Student> topStudents = students.FindAll(s => s.Marks > 75);

        Console.WriteLine("\n----- Top Performers (Marks > 75) -----");
        foreach (var s in topStudents)
        {
            Console.WriteLine(s.Name);
        }
    }
}