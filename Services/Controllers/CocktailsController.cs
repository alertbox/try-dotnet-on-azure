using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skol.Domain.Models;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Skol.Application.Cocktails.Queries;
using System.Net;
using Skol.Application.Cocktails.Commands;

namespace Skol.Services.Controllers
{
    // [Route("api")]
    [Route("api/v{version:apiVersion}/cocktails")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CocktailsController : ControllerBase
    {
        private readonly ISender mediator;

        public CocktailsController(ISender sender) => mediator = sender;

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Cocktail>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Cocktail>> GetAsync([FromQuery]GetCocktails query) => await mediator.Send(query);

        [HttpPost("code/{code}/rebrand")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> RebrandAsync([FromRoute]string code, [FromBody]RebrandCocktail request)
        {
            if (!code.Equals(request.OriginCode)) { return BadRequest(); }
            
            Cocktail cocktail = await mediator.Send(request);

            return CreatedAtAction(nameof(GetAsync), value: cocktail);
        }

        [HttpDelete("code/{code}/discontinue")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DiscontinueAsync([FromRoute]DiscontinueCocktail request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}