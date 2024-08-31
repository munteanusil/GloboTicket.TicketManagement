using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Categories.Queries.GetCategorieListwithEvent
{
    public  class CategoryEventListVM
    {

        public Guid CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<CategoryEventDto>? Events { get; set; }

    }
}
