using MediatR;
using ReviewService.Domain.IRepositories;
using ReviewService.Domain.Models;

namespace ReviewService.Application.Queries
{
    public class GetReviewsByItemIdQuery:IRequest<IEnumerable<Review>>
    {
        public Guid Id { get; set; }
        public class GetReviewsByItemIdQueryHandler : IRequestHandler<GetReviewsByItemIdQuery, IEnumerable<Review>>
        {
            private readonly IReviewRepository _repository;
            public GetReviewsByItemIdQueryHandler(IReviewRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Review>> Handle(GetReviewsByItemIdQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetReviewsByItemIdAsync(request.Id);
            }
        }
    }
}
