using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewService.Application.Queries;

namespace ReviewService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("reviewsByMenuItemId")]
        public async Task<IActionResult> GetReviewsOfMenuItem(Guid id)
        {
            return Ok(await _mediator.Send(new GetReviewsByItemIdQuery() { Id = id }));
        }
    }
}
