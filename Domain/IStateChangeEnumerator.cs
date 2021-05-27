using System.Collections.Generic;

namespace Skol.Domain
{
    public interface IStateChangeEnumerator
    {
        List<StateChangeEntry> StateChanges { get; }
    }
}
