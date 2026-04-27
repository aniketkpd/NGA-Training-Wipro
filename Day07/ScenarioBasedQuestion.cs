using System;
using System.Collections.Generic;
using System.Text;




namespace Day7
{

    class Product
    {
        private string _name;
        private decimal _price;
        private int _quantity;


        //Get Set properties 
        public string Name
        {
            get 
            { 
                return _name;
            }
            set 
            { 
                _name = value;
            }
        }


        public decimal Price
        {
            get 
            { 
                return _price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                else
                {
                    _price = value;
                }
            }
        }


        public int Quantity
        {
            get 
            { 
                return _quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative.");
                }
                else
                {
                    _quantity = value;
                }
            }
        }
    }





    // ProductCollection class with indexer
    class ProductCollection
    {
        private List<Product> products = new List<Product>();


        public void Add(Product product)
        {
            products.Add(product);
        }



        // Indexer
        public Product this[int index]
        {
            get
            {
                if (index < 0 || index >= products.Count)
                { 
                    throw new IndexOutOfRangeException("Invalid index");
                }
                else
                {
                    return products[index];
                }
            }
            set
            {
                if (index < 0 || index >= products.Count)
                { 
                    throw new IndexOutOfRangeException("Invalid index");
                }
                else
                {
                    products[index] = value;
                }
            }
        }

        public int Count
        {
            get 
            { 
                return products.Count;
            }
        }
    }














    class ScenarioBasedQuestion
    {
        static void Main()
        {
            ProductCollection inventory = new ProductCollection();

            // Adding products
            inventory.Add(new Product { 
                                        Name = "Laptop", 
                                        Price = 50000, 
                                        Quantity = 5 
                                      });



            inventory.Add(new Product { 
                                        Name = "Phone", 
                                        Price = 20000, 
                                        Quantity = 10 
                                        });





            // Access using indexer
            Console.WriteLine("First Product:");
            Console.WriteLine($"Name: {inventory[0].Name}");
            Console.WriteLine($"Price: {inventory[0].Price}");
            Console.WriteLine($"Quantity: {inventory[0].Quantity}");






            // Modify using indexer
            inventory[1].Price = 18000;
            inventory[1].Quantity = 8;

            Console.WriteLine("\nUpdated Second Product:");
            Console.WriteLine($"Name: {inventory[1].Name}");
            Console.WriteLine($"Price: {inventory[1].Price}");
            Console.WriteLine($"Quantity: {inventory[1].Quantity}");
        }
    }
}
