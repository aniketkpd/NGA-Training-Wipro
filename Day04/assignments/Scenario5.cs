using System;
using System.Collections.Generic;

class Scenario5
{
    static void AddTask(string task, List<string> allTasks, HashSet<string> uniqueTasks, Queue<string> queue)
    {
        if (uniqueTasks.Add(task))
        {
            allTasks.Add(task);
            queue.Enqueue(task);
        }
    }

    static void Main()
    {
        // Collections
        List<string> allTasks = new List<string>();
        HashSet<string> uniqueTasks = new HashSet<string>();
        Queue<string> taskQueue = new Queue<string>();
        Stack<string> undoStack = new Stack<string>();
        SortedDictionary<int, string> priorityTasks = new SortedDictionary<int, string>();

        // Add Tasks (avoid duplicates)
        AddTask("Backup", allTasks, uniqueTasks, taskQueue);
        AddTask("Update System", allTasks, uniqueTasks, taskQueue);
        AddTask("Scan Virus", allTasks, uniqueTasks, taskQueue);
        AddTask("Backup", allTasks, uniqueTasks, taskQueue); // duplicate ignored

        // Add Priority Tasks
        priorityTasks[2] = "Update System";
        priorityTasks[1] = "Scan Virus";   // higher priority (lower number)
        priorityTasks[3] = "Backup";

        // Execute Tasks (FIFO)
        Console.WriteLine("Executing Tasks:");
        while (taskQueue.Count > 0)
        {
            string task = taskQueue.Dequeue();
            Console.WriteLine(task);

            undoStack.Push(task);
        }

        // Undo Last Task (LIFO)
        Console.WriteLine("\nUndo Last Task:");
        if (undoStack.Count > 0)
        {
            string lastTask = undoStack.Pop();
            Console.WriteLine(lastTask + " undone");
        }

        // Show All Tasks
        Console.WriteLine("\nAll Tasks:");
        foreach (var task in allTasks)
        {
            Console.WriteLine(task);
        }

        // Show Priority Tasks (sorted)
        Console.WriteLine("\nPriority Tasks:");
        foreach (var item in priorityTasks)
        {
            Console.WriteLine($"Priority {item.Key}: {item.Value}");
        }
    }
}