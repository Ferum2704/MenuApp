using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Queries;
using System.Text.Json;
namespace OrderService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("mostPopularItemsIds/{itemsNumber:int?}")]
        public async Task<IActionResult> GetMostPopularMenuItemsIds(int itemsNumber = 4)
        {
            return Ok(await _mediator.Send(new GetMostPopularMenuItemIdsQuery() { ItemsNumber= itemsNumber }));
        }
    }
}
