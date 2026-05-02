using System;

namespace WithLSP
{
    // Bird is a base class that represents a bird. It has a method Eat() that all birds can use.
    public class Bird
    {
        public virtual void Eat()
        {
            Console.WriteLine("Bird is eating");
        }
    }

    // IFlyingBird - interface that represents a flying bird. It has a method Fly() that only flying birds can use.
    public interface IFlyingBird
    {
        void Fly();
    }




    // Sparrow is a flying bird, so it implements the IFlyingBird interface.
    public class Sparrow : Bird, IFlyingBird
    {
        public void Fly()
        {
            Console.WriteLine("Sparrow is flying");
        }
    }





    // Ostrich is a bird, but it can't fly. It doesn't implement the IFlyingBird interface, so it doesn't violate the Liskov Substitution Principle.
    public class Ostrich : Bird
    {
        // no Fly method
    }







    public class ProgramWithLSP
    {
        public static void Main(string[] args)
        {
            // LSP demonstration

            Bird bird1 = new Sparrow(); // valid substitution
            bird1.Eat();

            Bird bird2 = new Ostrich(); // also valid
            bird2.Eat();

            Console.WriteLine();

            // Only flying birds can fly
            IFlyingBird flyingBird = new Sparrow();
            flyingBird.Fly();

        }
    }

}