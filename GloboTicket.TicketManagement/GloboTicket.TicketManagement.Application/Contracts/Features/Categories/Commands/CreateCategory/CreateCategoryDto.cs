using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        public Guid CategpryId { get; set; }

        public string Name { get; set; }

    }
}
