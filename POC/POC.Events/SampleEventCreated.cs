using System;

namespace POC.Events
{
    public class SampleEventCreated : IEvent
    {
        public Guid Id { get; }
        public DateTime EventDate { get; }
        public int CustomerId { get; }
        public int SiteId { get; }
        public int EventType { get; }
        public int EventState { get; }
        public byte[] EventData { get; }

        public SampleEventCreated(Guid id, DateTime eventDate, int customerId, int siteId, int eventType, 
            int eventState, byte[] eventData)
        {
            Id = id;
            EventDate = eventDate;
            CustomerId = customerId;
            SiteId = siteId;
            EventType = eventType;
            EventState = eventState;
            EventData = eventData;
        }
    }
}
