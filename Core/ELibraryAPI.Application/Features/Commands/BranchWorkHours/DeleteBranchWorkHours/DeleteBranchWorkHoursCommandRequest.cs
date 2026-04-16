using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BranchWorkHours.DeleteBranchWorkHours;

public sealed record DeleteBranchWorkHoursCommandRequest(Guid Id) : IRequest<Result>;
