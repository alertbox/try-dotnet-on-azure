using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Skol.Application.Orders.Commands;
using Skol.Domain.Models;
using MediatR;

namespace Skol.Application.Bartenders.Triggers
{
    public class OrderReceivedHandler : INotificationHandler<StateChangeNotification<OrderReceived>>
    {
        public async Task Handle(StateChangeNotification<OrderReceived> notification, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Order received: {notification.StateChangeEntry.OccurredAsOf}");

            await Task.CompletedTask;
        }
    }
}