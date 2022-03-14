using Skol.Domain;
using Skol.Domain.Models;

namespace Skol.Application.Orders.Commands
{
    public class OrderReceived : StateChangeEntry
    {
        public Order Entity { get; init; }
    }
}