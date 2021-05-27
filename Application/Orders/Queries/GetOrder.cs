using System.Collections.Generic;
using MediatR;
using Skol.Domain.Models;

namespace Skol.Application.Orders.Queries
{
    public record GetOrder(int Id) : IRequest<IEnumerable<Order>>;
}