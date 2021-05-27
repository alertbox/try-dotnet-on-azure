using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skol.Domain.Models;
using Skol.Application.Orders.Queries;
using Skol.Application.Orders.Commands;
using System.Net;

namespace Skol.Rest.Services.Controllers
{
    // [Route("api/purchasing")]
    [Route("api/v{version:apiVersion}/orders")]
    [ApiController]
    [ApiVersion("1.0")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrdersController : ControllerBase
    {
        private readonly ISender mediator;

        public OrdersController(ISender sender) => mediator = sender;

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Order>> GetAsync([FromRoute] int id) => await mediator.Send(new GetOrder(id));

        [HttpPost("")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAsync([FromBody]CreateOrder request)
        {
            Order order = await mediator.Send(request);

            return CreatedAtAction(actionName: nameof(GetAsync), routeValues: new { id = order.Id }, value: null);
        }
    }
}