using System;

namespace POC.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
        DateTime CommandDate { get; }
        int CustomerId { get; }
        int SiteId { get; }
        int CommandType { get; }
        int CommandState { get; }
        byte[] CommandData { get; }
    }
}
