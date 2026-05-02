using System;

namespace WiththoutLSP
{

    // Bird is a base class that represents a bird. It has a method Fly() that all birds can use.
    public class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("Bird is flying");
        }
    }


    // Ostrich is a bird, but it can't fly. This violates the LSP.
    public class Ostrich : Bird
    {
        public override void Fly()
        {
            throw new Exception("Ostrich can't fly");
        }
    }




    public class ProgramWithoutLSP
    {
        public static void Main()
        {
            Bird bird = new Ostrich();
            //bird.Fly();   // breaks program
        }
    }
}
