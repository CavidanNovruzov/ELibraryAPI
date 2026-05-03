using AutoMapper;
using ELibraryAPI.Application.Features.Commands.OrderItem.CreateOrderItem;
using ELibraryAPI.Application.Features.Commands.OrderItem.UpdateOrderItem;
using ELibraryAPI.Domain.Entities.Concrete;

namespace ELibraryAPI.Application.Mappings;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<CreateOrderItemCommandRequest, OrderItem>();
        CreateMap<OrderItem, CreateOrderItemCommandResponse>();
        CreateMap<UpdateOrderItemCommandRequest, OrderItem>();
        CreateMap<OrderItem, UpdateOrderItemCommandResponse>();
    }
}