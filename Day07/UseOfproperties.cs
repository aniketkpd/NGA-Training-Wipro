using System;
using System.Collections.Generic;
using System.Text;



class Employee
{
    private decimal _salary;                // This is a private field that will hold the salary of the employee.

    public decimal Salary
    {
        // The 'get' accessor allows us to retrieve the value of '_salary'.
        
        get 
        { 
            return _salary;
        }             
        
        
        // The 'set' accessor allows us to set the value of '_salary' while ensuring that it cannot be less than the minimum wage.
        set                                 
        {
            if (value < 18000)              // Assuming 18000 is the minimum wage.
            {
                throw new ArgumentException("Salary cannot be less than the minimum wage.");
            }
            _salary = value;
        }
    }
}


class Person
{
    private int _age;                       // This is a private field that will hold the age of the person.



    public int Age
    {
        
        // The 'get' accessor allows us to retrieve the value of '_age'.
        get 
        { 
            return _age; 
        }                               
        
        
        // The 'set' accessor allows us to set the value of '_age' while ensuring   that it cannot be negative.
        set                             
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }
            _age = value;
        }
    }
}
















namespace Day7
{
    internal class UseOfproperties
    {
        public static void Main()
        {
            // Object of Person class
            Person person = new Person();
            person.Age = 25;                                            // Setting the age using the property
            Console.WriteLine($"Person's Age: {person.Age}");           // Getting the age using the property
        

        
            // Object of Employee class
            Employee employee = new Employee();
            employee.Salary = 25000;                                     // Setting the salary using the property
            Console.WriteLine($"Employee's Salary: {employee.Salary}");  // Getting the salary using the property
        }
    }
}
