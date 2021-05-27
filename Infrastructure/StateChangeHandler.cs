using System;
using System.Threading.Tasks;
using MediatR;
using Skol.Application;
using Skol.Domain;

namespace Skol.Infrastructure
{
    public class StateChangeHandler : IStateChangeHandler
    {
        private readonly Type defaultShape = typeof(StateChangeNotification<>);
        private readonly IPublisher mediator;

        public StateChangeHandler(IPublisher publisher) => mediator = publisher;

        public async Task BroadcastAsync(StateChangeEntry[] entries)
        {
            foreach (StateChangeEntry e in entries)
            {
                e.Published = true;
                await mediator.Publish(CreateNotification(e));
            }
        }

        private INotification CreateNotification(StateChangeEntry e)
        {
            Type shape = defaultShape.MakeGenericType(e.GetType());
            object instance = Activator.CreateInstance(shape, e);

            return (INotification)instance;
        }
    }
}
