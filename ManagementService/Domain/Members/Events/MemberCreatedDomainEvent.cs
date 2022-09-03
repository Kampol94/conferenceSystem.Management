using ManagementService.Domain.Contracts;

namespace ManagementService.Domain.Members.Events;

public class MemberCreatedDomainEvent : DomainEventBase
{
    public MemberCreatedDomainEvent(MemberId memberId)
    {
        MemberId = memberId;
    }

    public MemberId MemberId { get; }
}