using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Categories.Queries.GetCategorieListwithEvent
{
    public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoryListWithEventsQuery, List<CategoryEventListVM>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryEventListVM>> Handle(GetCategoryListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithEvents
        (request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListVM>>(list);
                }
    }
}
