using MediatR;
using Skol.Domain;

namespace Skol.Application
{
    public class StateChangeNotification<TEntry> : INotification where TEntry : StateChangeEntry
    {
        public TEntry StateChangeEntry { get; }
        public StateChangeNotification(TEntry e) => StateChangeEntry = e;
    }
}