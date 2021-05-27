using System.Threading.Tasks;
using Skol.Domain;

namespace Skol.Application
{
    public interface IStateChangeHandler
    {
        Task BroadcastAsync(StateChangeEntry[] entries);
    }
}