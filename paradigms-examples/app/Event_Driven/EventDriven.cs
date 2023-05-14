using System;
namespace EventDriven
{
    class Events : EventArgs
    {
        // The Publisher-Subscriber (pub-sub) pattern is one form of implementing an event-driven architecture. In this pattern:
        // Publisher: A class that exposes the event; The event emitter. This is where every event originates from.
        // Subscriber: A class that subscribes to your event; The event handlers. Methods are defined to respond to events.
        public string Message{ get; set; }
        public DateTime MessageDate { get; set; }
        public Events(string message, DateTime date)
        {
            Message = message;
            MessageDate = date;
        }
    }

    class Publisher
    {
        public event EventHandler<Events> OnSomeEvent;
        public void OnEvent()
        {
            // Send a notification that an event has occurred
            if (true)
            {
                OnSomeEvent(this, new Events("event happened", DateTime.Now));
            }

        }
    }

    class Subscriber
    {
        private void RespondToEvent(object sender, Events e)
        {
            Console.WriteLine(e.Message + " " + e.MessageDate);
        }
        public void Subscribe(Publisher publisher)
        {
            publisher.OnSomeEvent += RespondToEvent;
        }
    }
}