namespace Stocksly.Application
{
    using System.Threading.Tasks;
    using Stocksly.Domain;

    public interface IStateChangeHandler
    {
        Task BroadcastAsync(StateChangeEntry[] entries);
    }
}