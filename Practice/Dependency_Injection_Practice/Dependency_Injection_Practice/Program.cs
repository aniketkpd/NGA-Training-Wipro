using System;

namespace WithoutDI
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("Engine Started");
        }
    }

    public class Car
    {

        // here car is bound to this engine - tightly coupled
        private Engine engine = new Engine();

        public void Drive()
        {
            engine.Start();
            Console.WriteLine("Car is moving");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Drive();

        }
    }
}