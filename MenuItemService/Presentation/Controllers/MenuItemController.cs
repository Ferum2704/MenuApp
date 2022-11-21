using MediatR;
using MenuItemService.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuItemService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private IMediator _mediator;
        public MenuItemController(IMediator mediator)
        {
            _mediator= mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            return Ok(await _mediator.Send(new GetAllMenuItemsQuery()));
        }
    }
}
