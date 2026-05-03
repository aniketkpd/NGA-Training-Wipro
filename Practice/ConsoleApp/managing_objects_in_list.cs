

using System;
using System.Collections.Generic;

class Customer
{
    public string name;
    public int age;
}






public class managing_objects_in_list
{
    public static void Main(string[] args)
    {

        List<Customer> customersList = new List<Customer>();

        customersList.Add(new Customer
        {
            name = "Aniket",
            age = 12
        });




        customersList.Add(new Customer
        {
            name = "Rahul",
            age = 44
        });



        customersList.Remove(customersList[0]);

        foreach (var i in customersList)
        {
            Console.WriteLine(i.name);
        }
    }
}
