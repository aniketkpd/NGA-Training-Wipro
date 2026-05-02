using System;

namespace WithISP
{
    public interface IWorkable
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    public class HumanWorker : IWorkable, IEatable
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

    public class RobotWorker : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot working...");
        }
    }

    class ProgramWithISP
    {
        static void Main(string[] args)
        {
            IWorkable human = new HumanWorker();
            IWorkable robot = new RobotWorker();

            human.Work();
            robot.Work();

            IEatable eater = new HumanWorker();
            eater.Eat();

            Console.ReadLine();
        }
    }
}