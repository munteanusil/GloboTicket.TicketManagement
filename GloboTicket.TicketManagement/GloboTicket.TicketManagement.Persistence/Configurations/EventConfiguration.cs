﻿using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>   
    {
       public void Configure (EntityTypeBuilder<Event> builder)
       {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
       }
    }
}
