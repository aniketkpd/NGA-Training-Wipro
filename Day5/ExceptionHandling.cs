using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{

    //Creating a custom exception
    //1. Age less than 18 is not allowed to vote

    // Custom exception for age
    class AgeException : Exception
    {
        public AgeException(string message) : base(message) 
        {
        
        }
    }


    class ExceptionHandling
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());



            try
            {
                if (age < 18)
                {
                    throw new AgeException("Age less than 18 is not allowed to vote.");
                }
                else
                {
                    Console.WriteLine("You are eligible to vote.");
                }
            }

            catch (AgeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
