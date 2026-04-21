using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Day6
{

    // Step 1: Create delegate
    public delegate void NewsHandler(string topic, string news);

    // Step 2: Publisher
    class NewsAgency
    {
        public event NewsHandler NewsPublished;

        public void Publish(string topic, string news)
        {
            Console.WriteLine($"\nPublishing {topic}: {news}");
            NewsPublished?.Invoke(topic, news);
        }
    }

    // Step 3: Subscriber
    class Reader
    {
        public string Name;
        public string Topic;

        public Reader(string name, string topic)
        {
            Name = name;
            Topic = topic;
        }

        public void Receive(string topic, string news)
        {
            if (topic == Topic)
            {
                Console.WriteLine($"{Name} got {news}");
            }
        }
    }












    class ScenarioNewsAgencyPubSubModel
    {
        public static void Main(string[] args)
        {
            NewsAgency agency = new NewsAgency();

            Reader r1 = new Reader("Aniket", "Sports");
            Reader r2 = new Reader("Rahul", "Politics");

            agency.NewsPublished += r1.Receive;
            agency.NewsPublished += r2.Receive;

            agency.Publish("Sports", "India won!");
            agency.Publish("Politics", "Election coming!");
        }
    }
}
