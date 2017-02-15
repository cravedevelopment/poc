using System;

namespace POC.Events
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime EventDate { get; }
        int CustomerId { get; }
        int SiteId { get; }
        int EventType { get; }
        int EventState { get; }
        byte[] EventData { get; }
    }
}
