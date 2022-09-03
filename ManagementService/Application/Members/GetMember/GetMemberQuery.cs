using ManagementService.Application.Contracts.Queries;

namespace ManagementService.Application.Members.GetMember;

public class GetMemberQuery : QueryBase<MemberDto>
{
    public GetMemberQuery(Guid memberId)
    {
        MemberId = memberId;
    }

    public Guid MemberId { get; }
}