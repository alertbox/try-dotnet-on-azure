namespace Stocksly.Rest.Services.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Stocksly.Application.Inventory.Queries;
    using Stocksly.Domain.Models;

    [ApiController]
    [Route("api/v1")]
    public class InventoryController : ControllerBase
    {
        private readonly ISender mediator;

        public InventoryController(ISender sender) => mediator = sender;


        [HttpGet("products")]
        public async Task<IEnumerable<Product>> GetAsync([FromQuery] GetProducts query)
        {
            return await mediator.Send(query);
        }
    }
}