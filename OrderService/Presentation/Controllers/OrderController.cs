using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Commands;
using OrderService.Application.Queries;
using OrderService.Presentation.ViewModels;
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
        [HttpPost("newOrder")]
        public async Task<IActionResult> CreateNewOrder(OrderToCreateInfoViewModel newOrderInfo)
        {
            return Ok(await _mediator.Send(new CreateNewOrderCommand() { NewOrderInfo = newOrderInfo }));
        }
        [HttpGet("currentOrder/{visitorId:Guid?}")]
        public async Task<IActionResult> GetCurrentOrder(Guid visitorId)
        {
            return Ok(await _mediator.Send(new GetCurrentOrderQuery() { VisitorId= visitorId }));
        }
        [HttpDelete("currentOrder/{id:Guid?}")]
        public async Task<IActionResult> CancelCurrentOrder(Guid id)
        {
            return Ok(await _mediator.Send(new CancelCurrentOrderByIdCommand { Id = id }));
        }
        [HttpDelete("currentOrder")]
        public async Task<IActionResult> EnsureNoCurrentOrder([FromQuery] Guid visitorId)
        {
            return Ok(await _mediator.Send(new EnsureNoCurrentOrderCommand { VisitorId = visitorId }));
        }
        [HttpPost("menuItem")]
        public async Task<IActionResult> AddMenuItem(OrderedMenuItemViewModel item)
        {
            return Ok(await _mediator.Send(new AddItemToOrderCommand() {Item = item }));
        }
        [HttpDelete("menuItem")]
        public async Task<IActionResult> DeleteMenuItem([FromQuery] Guid id, [FromQuery] Guid orderId)
        {
            return Ok(await _mediator.Send(new DeleteItemByIdFromOrderCommand() { Id= id, OrderId= orderId }));
        }
    }
}
