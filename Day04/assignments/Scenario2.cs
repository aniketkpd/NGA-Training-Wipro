using System;
using System.Collections.Generic;

class Scenario2
{
    static void Main()
    {
        // Collections
        List<string> posts = new List<string>();
        Dictionary<string, int> likes = new Dictionary<string, int>();
        HashSet<int> users = new HashSet<int>();
        Stack<string> actions = new Stack<string>();
        Queue<string> notifications = new Queue<string>();

        // Add Users
        users.Add(1);
        users.Add(2);
        users.Add(1); // duplicate ignored

        // Add Posts
        posts.Add("Hello World");
        posts.Add("Learning C#");

        // Initialize Likes
        likes["Hello World"] = 0;
        likes["Learning C#"] = 0;

        // Like a Post
        likes["Hello World"]++;
        actions.Push("Liked: Hello World");

        likes["Learning C#"]++;
        actions.Push("Liked: Learning C#");

        // Add Notifications
        notifications.Enqueue("User 1 liked your post");
        notifications.Enqueue("User 2 liked your post");

        // Process Notifications (FIFO)
        Console.WriteLine("Notifications:");
        while (notifications.Count > 0)
        {
            Console.WriteLine(notifications.Dequeue());
        }

        // Undo Last Action (LIFO)
        Console.WriteLine("\nUndo Last Action:");
        if (actions.Count > 0)
        {
            string lastAction = actions.Pop();
            Console.WriteLine(lastAction + " undone");
        }

        // Display Posts and Likes
        Console.WriteLine("\nPosts & Likes:");
        foreach (var post in posts)
        {
            Console.WriteLine($"{post} - Likes: {likes[post]}");
        }

        // Display Unique Users
        Console.WriteLine("\nUsers:");
        foreach (var user in users)
        {
            Console.WriteLine($"User ID: {user}");
        }
    }
}