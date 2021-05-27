using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Skol.Application.Orders.Commands;
using Skol.Domain.Models;
using MediatR;
using Skol.Application.Cocktails.Commands;

namespace Skol.Application.Cocktails.Triggers
{
    // TODO: Convert this handler to a Post-Process Behavior.
    public class CocktailRebrandedHandler : INotificationHandler<StateChangeNotification<CocktailRebranded>>
    {
        private readonly ISender mediator;
        public CocktailRebrandedHandler(ISender sender) => mediator = sender;

        public async Task Handle(StateChangeNotification<CocktailRebranded> notification, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Discontinue cocktail request received: {notification.StateChangeEntry.OccurredAsOf}");

            CocktailRebranded request = notification.StateChangeEntry;
            if (request.OriginDiscontinued)
            {
                await mediator.Send(new DiscontinueCocktail(request.Origin.Code), cancellationToken);
            }

            await Task.CompletedTask;
        }
    }
}