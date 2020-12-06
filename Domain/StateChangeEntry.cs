namespace Stocksly.Domain
{
    using System;

    public abstract class StateChangeEntry
    {
        public DateTimeOffset OccurredTime => DateTime.UtcNow;
        public bool Published { get; set; }
    }
}
