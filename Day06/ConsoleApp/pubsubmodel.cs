using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class pubsubmodel
    {
        //IN a publisher subcriber model, the publisher is responsible for sending messages or events to subscribers.
        //The publisher does not need to know who the subscribers are or how they will handle the messages.
        //The subscribers can choose to subscribe to specific types of messages or events that they are interested in.
        //Problemstatement based on real world use case :
        //Consider a news agency that publishes news articles on various topics such as sports, politics, and entertainment.
        //The news agency acts as the publisher, while the ReaderXs who subscribe to the news articles are the subscribers.
        //The news agency can publish articles on different topics, and the ReaderXs can choose to subscribe to the topics they are interested in.
        //Step bystep implementation of publisher subscriber model in C#:
        //Step 1: Define the Publisher class ex : NewsAgencyX
        //Step 2: Define the Subscriber class ex : ReaderX
        //Step 3: Implement the subscription mechanism in the Publisher class ex : Subscribe method
        //Step 4: Implement the notification mechanism in the Publisher class ex : Publish method
        //Step 5: Create instances of the Publisher and Subscriber classes and demonstrate the functionality

        public static void Main(string[] args)
        {

            NewsAgencyX NewsAgencyX = new NewsAgencyX();
            ReaderX ReaderX1 = new ReaderX("Alice");
            ReaderX ReaderX2 = new ReaderX("Bob");
            ReaderX1.SubscribeToTopic("Sports");
            ReaderX2.SubscribeToTopic("Politics");
            NewsAgencyX.Subscribe(ReaderX1);
            NewsAgencyX.Subscribe(ReaderX2);
            NewsAgencyX.Publish("Sports", "New football season starts!");
            NewsAgencyX.Publish("Politics", "Elections coming up!");



            // Output:
            // Alice received article: New football season starts!
            // Bob received article: Elections coming up!
        }
    }
    //NewsAgencyX class acts as the publisher
    public class NewsAgencyX
    {
        private List<ReaderX> subscribers = new List<ReaderX>();
        public void Subscribe(ReaderX ReaderX)
        {
            subscribers.Add(ReaderX);
        }
        public void Publish(string topic, string article)
        {
            foreach (var subscriber in subscribers)
            {
                if (subscriber.IsSubscribedTo(topic))
                {
                    subscriber.ReceiveArticle(article);
                }
            }
        }
    }

    //ReaderX class acts as the subscriber
    public class ReaderX
    {
        private string name;
        private List<string> subscribedTopics = new List<string>();
        public ReaderX(string name)
        {
            this.name = name;
        }
        public void SubscribeToTopic(string topic)
        {
            subscribedTopics.Add(topic);
        }
        public bool IsSubscribedTo(string topic)
        {
            return subscribedTopics.Contains(topic);
        }
        public void ReceiveArticle(string article)
        {
            Console.WriteLine($"{name} received article: {article}");
        }
    }
}