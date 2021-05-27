using System;

namespace Skol.Domain
{
    public abstract class StateChangeEntry
    {
        public DateTimeOffset OccurredAsOf => DateTime.UtcNow;
        public bool Published { get; set; }
    }
}
