using System;

class howToUseEvents
{
    public delegate void MyEventHandler();

    public static event MyEventHandler OnAction;

    static void Main()
    {
        // Subscribe
        OnAction += Method1;
        OnAction += Method2;

        // Trigger event
        OnAction?.Invoke();
    }

    static void Method1()
    {
        Console.WriteLine("Method 1 called");
    }

    static void Method2()
    {
        Console.WriteLine("Method 2 called");
    }
}