using System;

namespace WithoutISP
{
    // Here we have a single interface thats forces classes to implement methods they don't need, which violates the Interface Segregation Principle (ISP).

    public interface IWorker
    {
        void Work();
        void Eat();
    }




    // Human can work and eat, so it implements both methods.
    public class HumanWorker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Human working...");
        }

        public void Eat()
        {
            Console.WriteLine("Human eating...");
        }
    }





    // Robot can work but does not eat, yet it is forced to implement the Eat method due to the IWorker interface, which leads to a violation of the ISP.
    public class RobotWorker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Robot working...");
        }

        public void Eat()
        {
            Console.WriteLine("Robot eating...");  // Robot does not eat, but we are forced to implement this method due to the interface contract
        }


    }

    class ProgramWithoutISP
    {
        static void Main(string[] args)
        {
            IWorker human = new HumanWorker();
            IWorker robot = new RobotWorker();

            human.Work();
            human.Eat();

            robot.Work();

            try
            {
                robot.Eat(); // runtime problem
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}