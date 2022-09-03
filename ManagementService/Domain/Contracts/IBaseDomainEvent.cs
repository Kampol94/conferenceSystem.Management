using MediatR;

namespace ManagementService.Domain.Contracts;

public interface IBaseDomainEvent : INotification
{
    Guid Id { get; }

    DateTime When { get; }
}