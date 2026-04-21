namespace DelegateDemo
{


    delegate int MathOperation(int a, int b);
    //define a delegate type called "MathOperation" that takes two integers as parameters and returns an integer as output.
    //outside the main method of the class and before the main method of the class
    public class delgateDemo
    {
        //here we will implemnt methods that match the signature of the delegate
        //Here we are defining methods as static because we are going to call these methods without creating an instance of the class.



        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}