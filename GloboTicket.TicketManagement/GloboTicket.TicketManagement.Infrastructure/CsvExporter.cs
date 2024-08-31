
using CsvHelper;
using GloboTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsExport;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
       
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDto)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentUICulture);
                csvWriter.WriteRecords(eventExportDto);
            }
            
            return memoryStream.ToArray();
        }
    }
}
