using MediatR;

namespace ManagementService.Application.Contracts.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}