﻿using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository, IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Category> categoryRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);

            var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

            var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

            eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return eventDetailDto;
        }
    }

}
