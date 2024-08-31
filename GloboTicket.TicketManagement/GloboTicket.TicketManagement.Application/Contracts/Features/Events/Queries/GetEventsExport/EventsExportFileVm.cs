using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsExport
{
    public class EventsExportFileVm
    {
        public string EventExportFileName { get; set; }

        public string ContentType { get; set; }

        public byte[]? Data { get; set; }
    }
}
