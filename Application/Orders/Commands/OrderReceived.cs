using System.Collections.Generic;
using Skol.Domain;
using Skol.Domain.Models;
using MediatR;

namespace Skol.Application.Orders.Commands
{
    public class OrderReceived : StateChangeEntry
    {
        public Order Entity { get; init; }
    }
}