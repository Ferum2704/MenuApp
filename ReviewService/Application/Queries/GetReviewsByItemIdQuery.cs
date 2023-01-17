using AutoMapper;
using MediatR;
using ReviewService.Domain.IRepositories;
using ReviewService.Domain.Models;
using ReviewService.Presentation.ViewModels;

namespace ReviewService.Application.Queries
{
    public class GetReviewsByItemIdQuery:IRequest<IEnumerable<ReviewVM>>
    {
        public Guid Id { get; set; }
        public class GetReviewsByItemIdQueryHandler : IRequestHandler<GetReviewsByItemIdQuery, IEnumerable<ReviewVM>>
        {
            private readonly IReviewDapperRepository _repository;
            private readonly IMapper _mapper;
            public GetReviewsByItemIdQueryHandler(IReviewDapperRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ReviewVM>> Handle(GetReviewsByItemIdQuery request, CancellationToken cancellationToken)
            {
                var reviews = await _repository.GetReviewsByItemIdAsync(request.Id);
                return reviews.Select(r => _mapper.Map<ReviewVM>(r));
            }
        }
    }
}
