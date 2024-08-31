using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Responses
{
    public class BaseResponse
    {
        public BaseResponse(string message)
        {
            Success = true;
            Message = string.Empty;
           
        }

        public BaseResponse(string message, bool success)
        {
            Success = true;
            Message = message;

        }

        public bool Success { get;  set; }

        public string Message { get; set; } = string.Empty;

        public List<string>? ValidationErrors { get; set; }

    }
}
