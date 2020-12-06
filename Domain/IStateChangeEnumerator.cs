namespace Stocksly.Domain
{
    using System.Collections.Generic;

    public interface IStateChangeEnumerator
    {
        List<StateChangeEntry> StateChanges { get; }
    }
}
