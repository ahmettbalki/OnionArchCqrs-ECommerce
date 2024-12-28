using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Extensions;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetListByPaginate;
public class GetListByPaginateCategoryQuery : IRequest<Paginate<GetListByPaginateCategoryResponseDto>>
{
    public PageRequest PageRequest { get; set; }
    public sealed class GetListByPaginateCategoryQueryHandler :
        IRequestHandler<GetListByPaginateCategoryQuery, Paginate<GetListByPaginateCategoryResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetListByPaginateCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Paginate<GetListByPaginateCategoryResponseDto>> Handle(GetListByPaginateCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetPaginateAsync(
                include: false,
                enableTracking: false,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            var response = _mapper.Map<Paginate<GetListByPaginateCategoryResponseDto>>(categories);
            return response;
        }
    }
}
