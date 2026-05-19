using System;

namespace WithDI
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("Engine is Started");
        }
    }

    public class Car
    {

        // this is dependency injection
        // here car can be injected with any engine - loosly coupled
        private readonly Engine _engine;

        public Car(Engine engine)
        {
            _engine = engine;
        }

        public void Drive()
        {
            _engine.Start();
            Console.WriteLine("Car is moving");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            Car car = new Car(engine);

            car.Drive();

            Console.ReadLine();
        }
    }
}