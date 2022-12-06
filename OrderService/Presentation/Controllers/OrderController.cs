using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Queries;
using System.Text.Json;
namespace OrderService.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetMostPopularMenuItems(int itemsNumber = 4)
        {
            return Ok(await _mediator.Send(new GetMostPopularMenuItemIdsQuery() { ItemsNumber= itemsNumber }));
        }
    }
}
