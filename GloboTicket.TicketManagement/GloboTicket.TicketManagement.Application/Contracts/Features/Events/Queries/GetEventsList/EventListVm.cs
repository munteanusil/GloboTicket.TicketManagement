﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsList
{
    public class EventListVm
    {
        public Guid EventId { get; set; }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public string ImageUrl { get; set; }
    }
}
