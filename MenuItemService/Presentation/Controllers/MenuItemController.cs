using MediatR;
using MenuItemService.Application.Queries;
using MenuItemService.Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuItemService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private IMediator _mediator;
        private IMenuItemRepository _rep;
        public MenuItemController(IMediator mediator, IMenuItemRepository rep)
        {
            _mediator = mediator;
            _rep = rep;
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
        [HttpGet("setDiscountOnCategory")]
        public async Task<IActionResult> SetDiscountOnCategory(int discount, string categoryName, decimal? minPrice = null, decimal? maxPrice = null)
        {
            await _rep.SetDiscountOnCategory(discount, categoryName, minPrice, maxPrice);
            return Ok();
        }
    }
}
