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
            _mediator = mediator;
        }
        [HttpGet("categorizedItems")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _mediator.Send(new GetCategoriesWithMenuItemsQuery()));
        }
        [HttpGet("mostPopularItems/{itemsNumber:int?}")]
        public async Task<IActionResult> GetMostPopularMenuItems(int itemsNumber = 4)
        {
            return Ok(await _mediator.Send(new GetMostPopularMenuItemsQuery() { ItemsNumber = itemsNumber}));
        }
    }
}
