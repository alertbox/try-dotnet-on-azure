using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Skol.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Skol.Application.Orders.Commands
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder, Order>
    {
        private readonly ISkolContext db;

        public CreateOrderHandler(ISkolContext ctx) => db = ctx;

        public async Task<Order> Handle(CreateOrder request, CancellationToken cancellationToken = default)
        {
            Cocktail[] available = await db.Cocktails.AsNoTrackingWithIdentityResolution().ToArrayAsync(cancellationToken);
            OrderItem[] items = request.Items
                                       .Select(item =>
                                       {
                                           Cocktail cocktail = available.Single(d => d.Code.Equals(item.Code));

                                           return new OrderItem
                                           {
                                               Code = cocktail.Code,
                                               DisplayName = cocktail.DisplayName,
                                               ContainsAlcohol = cocktail.ContainsAlcohol,
                                               CocktailId = cocktail.Id,
                                               Quantity = item.Quantity,
                                               Value = cocktail.Value * item.Quantity
                                           };
                                       })
                                       .ToArray();

            Order order = new() { Discount = request.Discount.GetValueOrDefault(0) };
            order.Items.AddRange(items);
            order.StateChanges.Add(new OrderReceived { Entity = order });
            db.Orders.Add(order);

            await db.SaveChangesAsync(cancellationToken);

            return order;
        }
    }
}