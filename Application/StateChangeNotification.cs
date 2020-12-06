namespace Stocksly.Application
{
    using MediatR;
    using Stocksly.Domain;

    public class StateChangeNotification<TEntry> : INotification where TEntry : StateChangeEntry
    {
        public TEntry StateChangeEntry { get; }
        public StateChangeNotification(TEntry e) => StateChangeEntry = e;
    }
}