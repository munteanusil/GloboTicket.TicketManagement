﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Order
{
    public class GetOrdersForMonthQueryHandler : IRequestHandler<GetOrdersForMonthQuery, PagedOrdersForMonthVm>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public GetOrdersForMonthQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
                
        }


        public async Task<PagedOrdersForMonthVm> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
        {
            var list = await _orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
            var orders = _mapper.Map<List<OrdersForMonthDto>>(list);

            var count = await _orderRepository.GetTotalCountOrdersForMonth(request.Date);
            return new PagedOrdersForMonthVm() { Count = count, OrdersForMonth = orders, Page = request.Page, Size = request.Size };
            
        }
    }
}
