using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Categories.Queries.GetCategorieListwithEvent
{
    public class GetCategoryListWithEventsQuery : IRequest<List<CategoryEventListVM>>
    {
        public bool IncludeHistory { get; set; }

    }
}
