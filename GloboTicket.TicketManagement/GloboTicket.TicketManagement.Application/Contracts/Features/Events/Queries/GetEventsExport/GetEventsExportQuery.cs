using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery : IRequest<EventsExportFileVm>
    {

    }
}
