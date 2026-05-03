using AutoMapper;
using ELibraryAPI.Application.Features.Commands.Transaction.CreateTransaction;
using ELibraryAPI.Application.Features.Commands.Transaction.UpdateTransaction;
using ELibraryAPI.Domain.Entities.Concrete;

namespace ELibraryAPI.Application.Mappings;

public sealed class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<CreateTransactionCommandRequest, Transaction>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<UpdateTransactionCommandRequest, Transaction>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Transaction, CreateTransactionCommandResponse>();
        CreateMap<Transaction, UpdateTransactionCommandResponse>();
    }
}