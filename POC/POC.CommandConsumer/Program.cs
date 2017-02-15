using EventStore.ClientAPI;
using System;
using System.Net;
using System.Text;

namespace POC.CommandConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string streamName = "po_command_stream";
            const int defaultPort = 1113;
            var settings = ConnectionSettings.Create();
            using (var conn = EventStoreConnection.Create(settings, new IPEndPoint(IPAddress.Loopback, defaultPort)))
            {
                conn.ConnectAsync().Wait();
                //Note the subscription is subscribing from the beginning every time. You could also save
                //your checkpoint of the last seen event and subscribe to that checkpoint at the beginning.
                //If stored atomically with the processing of the event this will also provide simulated
                //transactional messaging.
                var sub = conn.SubscribeToStreamFrom(streamName, StreamPosition.Start, true,
                    (_, x) =>
                    {
                        var data = Encoding.ASCII.GetString(x.Event.Data);
                        Console.WriteLine("Received: " + x.Event.EventStreamId + ":" + x.Event.EventNumber);
                        Console.WriteLine(data);
                    });
                Console.WriteLine("waiting for events. press enter to exit");
                Console.ReadLine();
            }
        }
    }
}