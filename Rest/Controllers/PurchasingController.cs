namespace Stocksly.Rest.Services.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Stocksly.Application.Purchasing.Commands;
    using Stocksly.Application.Purchasing.Queries;
    using Stocksly.Domain.Models;

    [ApiController]
    [Route("api/v1/purchasing")]
    public class PurchasingController : ControllerBase
    {
        private readonly ISender mediator;

        public PurchasingController(ISender sender) => mediator = sender;

        [HttpGet("orders/id/{id}")]
        public async Task<IEnumerable<PurchaseOrder>> GetAsync([FromRoute] int id)
        {
            return await mediator.Send(new GetPurchaseOrder { Id = id });
        }


        [HttpPost("orders")]
        public async Task<IActionResult> CreateAsync(CreatePurchaseOrder request)
        {
            int id = await mediator.Send(request);

            return CreatedAtAction(nameof(GetAsync), new { id });
        }
    }
}