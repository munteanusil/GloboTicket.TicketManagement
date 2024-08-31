using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Categories.Queries.GetCategorieListwithEvent
{
    public  class CategoryEventDto
    {
        public Guid EventId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Price {  get; set; }

        public string Artist { get; set; }

        public DateTime Date { get; set; }

        public Guid CategoryId { get; set; }

    }
}
