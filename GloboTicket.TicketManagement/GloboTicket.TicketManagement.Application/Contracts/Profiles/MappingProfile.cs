using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Contracts.Features.Categories.Queries.GetCategorieListwithEvent;
using GloboTicket.TicketManagement.Application.Contracts.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Contracts.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Contracts.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsExport;
using GloboTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Application.Contracts.Features.Order;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVM>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}