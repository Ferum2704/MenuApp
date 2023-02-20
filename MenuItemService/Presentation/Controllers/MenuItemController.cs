using MediatR;
using MenuItemService.Application.Queries;
using MenuItemService.Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [HttpGet("shortMenuItem/{id:Guid?}")]
        public async Task<IActionResult> GetShortMenuItem(Guid id)
        {
            return Ok(await _mediator.Send(new GetShortMenuItemByIdQuery() { Id = id }));
        }
        [HttpGet("shortMenuItemsByIds")]
        public async Task<IActionResult> GetShortMenuItemsByIds(IEnumerable<Guid> ids)
        {
            IEnumerable<ShortMenuItemViewModel> menuItems = await _mediator
                .Send(new GetShortMenuItemByIdsQuery() { Ids = ids });
            if (menuItems != null)
            {
                return Ok(menuItems);
                //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                //response.Content = JsonContent.Create(menuItems);
                //IEnumerable<ShortMenuItemViewModel> menuItemsCopy = await response.Content.ReadFromJsonAsync<IEnumerable<ShortMenuItemViewModel>>();
                //return response;
            }
            return null;
        }
    }
}
